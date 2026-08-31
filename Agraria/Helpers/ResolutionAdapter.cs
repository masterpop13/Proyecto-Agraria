using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Agraria.Helpers
{
    public static class ResolutionAdapter
    {
        private static readonly float baseWidth = 1920f;
        private static readonly float baseHeight = 1080f;

        // Métricas originales de cada control
        private static readonly Dictionary<Control, OriginalMetrics> metrics = new();

        private static Size originalFormSize;
        private static Image originalBackground;
        private static float lastScale = 1f;

        // 🔹 Adaptar cualquier formulario (Login, Inicio, etc.)
        public static void Adapt(Form form)
        {
            if (form == null) return;

            metrics.Clear();

            float screenW = Screen.PrimaryScreen.WorkingArea.Width;
            float screenH = Screen.PrimaryScreen.WorkingArea.Height;

            float scaleX = screenW / baseWidth;
            float scaleY = screenH / baseHeight;

            // Escala que garantiza que TODO entre en pantalla
            float scale = Math.Min(scaleX, scaleY);

            // No agrandar más del diseño original (1920×1080)
            if (scale > 1f) scale = 1f;

            lastScale = scale;

            StoreOriginalMetrics(form);

            originalFormSize = form.Size;
            originalBackground = form.BackgroundImage;

            if (form.IsMdiContainer)
                ResizeMainMdi(form, scale);
            else
                ResizeNormalForm(form, scale);

            ScaleControl(form, scale);
            form.PerformLayout();
        }

        // 🔹 Adaptar formularios MDI hijo (AbmUsuario, Inventario, etc.)
        public static void AdaptMdiChild(Form form)
        {
            if (form == null) return;

            float scale = lastScale;

            // Si por alguna razón todavía no hay escala, la calculamos
            if (scale <= 0f)
            {
                float screenW = Screen.PrimaryScreen.WorkingArea.Width;
                float screenH = Screen.PrimaryScreen.WorkingArea.Height;

                float scaleX = screenW / baseWidth;
                float scaleY = screenH / baseHeight;

                scale = Math.Min(scaleX, scaleY);
                if (scale > 1f) scale = 1f;

                lastScale = scale;
            }

            metrics.Clear();

            StoreOriginalMetrics(form);
            originalFormSize = form.Size;
            originalBackground = form.BackgroundImage;

            ResizeMdiChild(form, scale);
            ScaleControl(form, scale);

            form.PerformLayout();
        }

        // ===================== REDIMENSIONAR FORMULARIOS =====================

        private static void ResizeMainMdi(Form form, float scale)
        {
            form.WindowState = FormWindowState.Normal;

            int newW = (int)(originalFormSize.Width * scale);
            int newH = (int)(originalFormSize.Height * scale);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(newW, newH);

            // Que el form pueda cambiar de tamaño libremente
            form.MinimumSize = Size.Empty;
            form.MaximumSize = Size.Empty;

            if (originalBackground != null)
                form.BackgroundImage = ResizeBackground(originalBackground, form.ClientSize);
        }

        private static void ResizeNormalForm(Form form, float scale)
        {
            int newW = (int)(originalFormSize.Width * scale);
            int newH = (int)(originalFormSize.Height * scale);

            form.StartPosition = FormStartPosition.CenterScreen;
            form.Size = new Size(newW, newH);

            form.MinimumSize = Size.Empty;
            form.MaximumSize = Size.Empty;

            if (originalBackground != null)
                form.BackgroundImage = ResizeBackground(originalBackground, form.ClientSize);
        }

        private static void ResizeMdiChild(Form form, float scale)
        {
            int newW = (int)(originalFormSize.Width * scale);
            int newH = (int)(originalFormSize.Height * scale);

            form.Size = new Size(newW, newH);
            form.MinimumSize = Size.Empty;
            form.MaximumSize = Size.Empty;

            if (originalBackground != null)
                form.BackgroundImage = ResizeBackground(originalBackground, form.ClientSize);
        }

        // ===================== ESCALADO DE CONTROLES =====================

        private static void StoreOriginalMetrics(Control ctrl)
        {
            if (!metrics.ContainsKey(ctrl))
                metrics[ctrl] = new OriginalMetrics(ctrl);

            foreach (Control c in ctrl.Controls)
                StoreOriginalMetrics(c);
        }

        private static void ScaleControl(Control ctrl, float scale)
        {


            if (ctrl is Button btn)
            {
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;

                int pad = (int)(10 * scale);
                if (pad < 5) pad = 5;
                btn.Padding = new Padding(pad, 0, pad, 0);

                // Escalar icono
                if (btn.Image != null)
                {
                    int newW = (int)(btn.Image.Width * scale);
                    int newH = (int)(btn.Image.Height * scale);

                    if (newW < 18) newW = 18;
                    if (newH < 18) newH = 18;

                    btn.Image = new Bitmap(btn.Image, new Size(newW, newH));
                }

                btn.ImageAlign = ContentAlignment.MiddleLeft;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.AutoSize = false;

                // ⭐ Ajustar tamaño de fuente automáticamente
                AdjustButtonFontToFit(btn);
            }


            // 🔹 LABELS DE FORMULARIOS (igual que en UC)
            if (ctrl is Label lbl)
            {
                lbl.AutoSize = true;
            }

            // 🔹 GROUPBOX: más padding
            if (ctrl is GroupBox gb)
            {
                int pad = (int)(10 * scale);
                if (pad < 6) pad = 6;

                gb.Padding = new Padding(pad, pad, pad, pad);
            }


            // 🔹 ESCALADO GENERAL
            if (metrics.TryGetValue(ctrl, out var m))
            {
                ctrl.Left = (int)(m.Left * scale);
                ctrl.Top = (int)(m.Top * scale);

                ctrl.Width = Math.Max((int)(m.Width * scale), 40);
                ctrl.Height = Math.Max((int)(m.Height * scale), 20);

                float fontSize = m.FontSize * scale;
                if (fontSize < 9f) fontSize = 9f;

                ctrl.Font = new Font(ctrl.Font.FontFamily, fontSize, ctrl.Font.Style);
            }

            // 🔹 PICTUREBOX
            if (ctrl is PictureBox pb)
                pb.SizeMode = PictureBoxSizeMode.Zoom;

            // 🔹 DATAGRIDVIEW (igual que antes)
            if (ctrl is DataGridView dgv)
                ScaleDataGridView(dgv, scale);

            // 🔹 Escalar hijos
            foreach (Control child in ctrl.Controls)
                ScaleControl(child, scale);
        }

        private static void ScaleDataGridView(DataGridView dgv, float scale)
        {
            dgv.RowTemplate.Height = Math.Max((int)(dgv.RowTemplate.Height * scale), 20);

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Width = Math.Max((int)(col.Width * scale), 30);

                if (col.DefaultCellStyle.Font != null)
                {
                    float fs = col.DefaultCellStyle.Font.Size * scale;
                    if (fs < 9f) fs = 9f;

                    col.DefaultCellStyle.Font =
                        new Font(col.DefaultCellStyle.Font.FontFamily, fs, col.DefaultCellStyle.Font.Style);
                }
            }
        }

        private static Image ResizeBackground(Image img, Size target)
        {
            if (img == null) return null;

            Bitmap bmp = new Bitmap(target.Width, target.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float ratioW = (float)target.Width / img.Width;
                float ratioH = (float)target.Height / img.Height;
                float ratio = Math.Min(ratioW, ratioH);

                int newW = (int)(img.Width * ratio);
                int newH = (int)(img.Height * ratio);

                int posX = (target.Width - newW) / 2;
                int posY = (target.Height - newH) / 2;

                g.Clear(Color.Black);
                g.DrawImage(img, posX, posY, newW, newH);
            }
            return bmp;
        }

        // ===================== MÉTRICAS ORIGINALES =====================

        private sealed class OriginalMetrics
        {
            public int Left { get; }
            public int Top { get; }
            public int Width { get; }
            public int Height { get; }
            public float FontSize { get; }

            public OriginalMetrics(Control c)
            {
                Left = c.Left;
                Top = c.Top;
                Width = c.Width;
                Height = c.Height;
                FontSize = c.Font.Size;
            }
        }

        private static void AdjustButtonFontToFit(Button btn)
        {
            if (btn == null || string.IsNullOrEmpty(btn.Text)) return;

            using (Graphics g = btn.CreateGraphics())
            {
                float fontSize = btn.Font.Size;

                // Intentamos reducir fuente hasta que entre el texto
                while (fontSize > 7f)
                {
                    SizeF textSize = g.MeasureString(btn.Text, new Font(btn.Font.FontFamily, fontSize, btn.Font.Style));

                    // Si el texto entra en el botón → OK
                    if (textSize.Width + btn.Padding.Left + btn.Padding.Right < btn.Width - 10)
                        break;

                    fontSize -= 0.5f; // reducimos la fuente en pasos
                }

                btn.Font = new Font(btn.Font.FontFamily, fontSize, btn.Font.Style);
            }
        }


    }
}
