using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Agraria.Helpers
{
    public static class ResolutionAdapter2
    {
        private static readonly float baseWidth = 1920f;
        private static readonly float baseHeight = 1080f;

        // Diccionario independiente para UC (NO se mezcla con ResolutionAdapter)
        private static readonly Dictionary<Control, OriginalMetrics> metrics = new();

        public static void AdaptUserControl(UserControl uc)
        {
            if (uc == null) return;

            float screenW = Screen.PrimaryScreen.WorkingArea.Width;
            float screenH = Screen.PrimaryScreen.WorkingArea.Height;

            float scaleX = screenW / baseWidth;
            float scaleY = screenH / baseHeight;

            float scale = Math.Min(scaleX, scaleY);
            if (scale > 1f) scale = 1f;

            if (Math.Abs(scale - 1f) < 0.001f)
                return;

            metrics.Clear();
            StoreOriginalMetrics(uc);
            ScaleControl(uc, scale);
            uc.PerformLayout();
        }

        // ===================== GUARDAR MÉTRICAS =====================
        private static void StoreOriginalMetrics(Control ctrl)
        {
            if (!metrics.ContainsKey(ctrl))
                metrics[ctrl] = new OriginalMetrics(ctrl);

            foreach (Control child in ctrl.Controls)
                StoreOriginalMetrics(child);
        }

        private static void ScaleControl(Control ctrl, float scale)
        {
            // LABELS: agregar más espacio inferior y superior
            if (ctrl is Label lbl)
            {
                lbl.AutoSize = true;

                int marginTop = (int)(4 * scale);
                if (marginTop < 2) marginTop = 2;

                lbl.Margin = new Padding(lbl.Margin.Left, marginTop, lbl.Margin.Right, lbl.Margin.Bottom);
            }

            // GROUPBOX: aumentar padding para que no choque con controles
            if (ctrl is GroupBox gb)
            {
                int pad = (int)(12 * scale);
                if (pad < 8) pad = 8;

                gb.Padding = new Padding(pad, pad, pad, pad);
            }

            // BOTONES con icono + texto
            if (ctrl is Button btn)
            {
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;

                int pad = (int)(10 * scale);
                if (pad < 5) pad = 5;

                btn.Padding = new Padding(pad, 0, pad, 0);

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
            }

            // POSICIÓN / TAMAÑO / FUENTE
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

            if (ctrl is PictureBox pb)
                pb.SizeMode = PictureBoxSizeMode.Zoom;

            foreach (Control child in ctrl.Controls)
                ScaleControl(child, scale);
        }


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
    }
}
