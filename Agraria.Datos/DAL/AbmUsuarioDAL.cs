using Agraria.Datos.DAL;
using Agraria.Datos.DTO;
using Agraria.Datos.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;

public class AbmUsuarioDAL
{
    public List<AbmUsuarioDTO> ObtenerUsuarios()
    {
        List<AbmUsuarioDTO> usuarios = new List<AbmUsuarioDTO>();
        ConexionBD.ConectarBD();

        string consulta = @"
            SELECT u.Id, u.Nombre, u.Apellido, u.Documento, CAST(u.Telefono AS VARCHAR) AS Telefono, 
                   u.Direccion, l.NombreLocalidad, p.NombrePartido, l.CodigoPostal, 
                   u.Email, u.NombreUsuario, u.Contraseña, 
                   qs.TextoPregunta, u.RespuestaSeguridad, u.Estado
            FROM AbmUsuario u
            INNER JOIN Localidad l ON u.IdLocalidad = l.IdLocalidad
            INNER JOIN Partido p ON l.IdPartido = p.IdPartido
            INNER JOIN PreguntaSeguridad qs ON u.IdPreguntaSeguridad = qs.IdPregunta";

        SqlCommand cmd = new SqlCommand(consulta, ConexionBD.ConexionSQL);
        SqlDataReader lector = cmd.ExecuteReader();

        while (lector.Read())
        {
            usuarios.Add(new AbmUsuarioDTO
            {
                Id = lector.GetInt32(0),
                Nombre = lector.GetString(1),
                Apellido = lector.GetString(2),
                Documento = lector.GetInt32(3),
                Telefono = lector.GetString(4),
                Direccion = lector.GetString(5),
                Localidad = lector.GetString(6),
                Partido = lector.GetString(7),
                CodigoPostal = lector.GetInt32(8).ToString(),
                Email = lector.GetString(9),
                NombreUsuario = lector.GetString(10),
                Contraseña = lector.GetString(11),
                PreguntaSeguridad = lector.GetString(12),
                RespuestaSeguridad = lector.GetString(13),
                Estado = lector.GetBoolean(14)
            });
        }

        ConexionBD.CierraBD();
        return usuarios;
    }

    public void InsertarUsuario(AbmUsuario usuario)
    {
        ConexionBD.ConectarBD();
        try
        {
            string query = @"
            INSERT INTO AbmUsuario
            (Nombre, Apellido, Documento, Telefono, Direccion, 
             IdLocalidad, IdPartido, IdPreguntaSeguridad, 
             Email, NombreUsuario, Contraseña, RespuestaSeguridad, Estado)
            VALUES
            (@Nombre, @Apellido, @Documento, @Telefono, @Direccion,
             @IdLocalidad, @IdPartido, @IdPreguntaSeguridad,
             @Email, @NombreUsuario, @Contraseña, @RespuestaSeguridad, @Estado)";

            SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
            cmd.Parameters.AddWithValue("@IdLocalidad", ObtenerIdLocalidad(usuario.IdLocalidad.NombreLocalidad));
            cmd.Parameters.AddWithValue("@IdPartido", ObtenerIdPartido(usuario.IdPartido.NombrePartido));
            cmd.Parameters.AddWithValue("@IdPreguntaSeguridad", ObtenerIdPregunta(usuario.IdPreguntaSeguridad.TextoPregunta));
            cmd.Parameters.AddWithValue("@Email", usuario.Email);
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            cmd.Parameters.AddWithValue("@RespuestaSeguridad", usuario.RespuestaSeguridad);
            cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            ConexionBD.CierraBD();
        }
    }

    public void ModificarUsuario(AbmUsuario usuarioModificado)
    {
        ConexionBD.ConectarBD();
        try
        {
            string query = @"
            UPDATE AbmUsuario SET
                Nombre = @Nombre, 
                Apellido = @Apellido, 
                Documento = @Documento, 
                Telefono = @Telefono,
                Direccion = @Direccion, 
                IdLocalidad = @IdLocalidad, 
                IdPartido = @IdPartido,
                IdPreguntaSeguridad = @IdPreguntaSeguridad, 
                Email = @Email, 
                NombreUsuario = @NombreUsuario,
                Contraseña = @Contraseña, 
                RespuestaSeguridad = @RespuestaSeguridad, 
                Estado = @Estado
            WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@Id", usuarioModificado.Id);
            cmd.Parameters.AddWithValue("@Nombre", usuarioModificado.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuarioModificado.Apellido);
            cmd.Parameters.AddWithValue("@Documento", usuarioModificado.Documento);
            cmd.Parameters.AddWithValue("@Telefono", usuarioModificado.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", usuarioModificado.Direccion);
            cmd.Parameters.AddWithValue("@IdLocalidad", ObtenerIdLocalidad(usuarioModificado.IdLocalidad.NombreLocalidad));
            cmd.Parameters.AddWithValue("@IdPartido", ObtenerIdPartido(usuarioModificado.IdPartido.NombrePartido));
            cmd.Parameters.AddWithValue("@IdPreguntaSeguridad", ObtenerIdPregunta(usuarioModificado.IdPreguntaSeguridad.TextoPregunta));
            cmd.Parameters.AddWithValue("@Email", usuarioModificado.Email);
            cmd.Parameters.AddWithValue("@NombreUsuario", usuarioModificado.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuarioModificado.Contraseña);
            cmd.Parameters.AddWithValue("@RespuestaSeguridad", usuarioModificado.RespuestaSeguridad);
            cmd.Parameters.AddWithValue("@Estado", usuarioModificado.Estado);
            cmd.ExecuteNonQuery();
        }
        finally
        {
            ConexionBD.CierraBD();
        }
    }

    private int ObtenerIdPartido(string nombrePartido)
    {
        string query = "SELECT IdPartido FROM Partido WHERE NombrePartido = @NombrePartido";
        using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
        {
            cmd.Parameters.AddWithValue("@NombrePartido", nombrePartido);
            return (int)cmd.ExecuteScalar();
        }
    }

    private int ObtenerIdLocalidad(string nombreLocalidad)
    {
        string query = "SELECT IdLocalidad FROM Localidad WHERE NombreLocalidad = @NombreLocalidad";
        using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
        {
            cmd.Parameters.AddWithValue("@NombreLocalidad", nombreLocalidad);
            return (int)cmd.ExecuteScalar();
        }
    }

    private int ObtenerIdPregunta(string textoPregunta)
    {
        string query = "SELECT IdPregunta FROM PreguntaSeguridad WHERE TextoPregunta = @TextoPregunta";
        using (SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL))
        {
            cmd.Parameters.AddWithValue("@TextoPregunta", textoPregunta);
            return (int)cmd.ExecuteScalar();
        }
    }

    public void CambiarEstadoUsuario(int id, bool estado)
    {
        ConexionBD.ConectarBD();
        string query = "UPDATE AbmUsuario SET Estado = @Estado WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@Estado", estado);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
        ConexionBD.CierraBD();
    }

    public List<AbmUsuarioDTO> BuscarUsuarioPorNombreODni(string textoBusqueda)
    {
        List<AbmUsuarioDTO> usuarios = new List<AbmUsuarioDTO>();
        ConexionBD.ConectarBD();

        string consulta = @"
        SELECT u.Id, u.Nombre, u.Apellido, u.Documento, u.Telefono, 
               u.Direccion, l.NombreLocalidad, p.NombrePartido, l.CodigoPostal, 
               u.Email, u.NombreUsuario, u.Contraseña, 
               qs.TextoPregunta, u.RespuestaSeguridad, u.Estado
        FROM AbmUsuario u
        INNER JOIN Localidad l ON u.IdLocalidad = l.IdLocalidad
        INNER JOIN Partido p ON u.IdPartido = p.IdPartido
        INNER JOIN PreguntaSeguridad qs ON u.IdPreguntaSeguridad = qs.IdPregunta
        WHERE u.Apellido LIKE @Texto OR u.Documento LIKE @Texto";

        SqlCommand cmd = new SqlCommand(consulta, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@Texto", $"%{textoBusqueda}%");

        SqlDataReader lector = cmd.ExecuteReader();

        while (lector.Read())
        {
            usuarios.Add(new AbmUsuarioDTO
            {
                Id = lector.GetInt32(0),
                Nombre = lector.GetString(1),
                Apellido = lector.GetString(2),
                Documento = lector.GetInt32(3),
                Telefono = lector.GetString(4),
                Direccion = lector.GetString(5),
                Localidad = lector.GetString(6),
                Partido = lector.GetString(7),
                CodigoPostal = lector.GetInt32(8).ToString(),
                Email = lector.GetString(9),
                NombreUsuario = lector.GetString(10),
                Contraseña = lector.GetString(11),
                PreguntaSeguridad = lector.GetString(12),
                RespuestaSeguridad = lector.GetString(13),
                Estado = lector.GetBoolean(14)
            });
        }

        ConexionBD.CierraBD();
        return usuarios;
    }

    public List<PartidoDTO> CargarPartidos()
    {
        List<PartidoDTO> lista = new List<PartidoDTO>();
        ConexionBD.ConectarBD();
        string query = "SELECT IdPartido, NombrePartido FROM Partido ORDER BY NombrePartido";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        SqlDataReader lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new PartidoDTO
            {
                IdPartido = lector.GetInt32(0),
                NombrePartido = lector.GetString(1)
            });
        }
        ConexionBD.CierraBD();
        return lista;
    }

    public List<LocalidadDTO> CargarLocalidades()
    {
        List<LocalidadDTO> lista = new List<LocalidadDTO>();
        ConexionBD.ConectarBD();
        string query = @"
            SELECT l.IdLocalidad, l.NombreLocalidad, l.CodigoPostal, l.IdPartido
            FROM Localidad l
            ORDER BY l.NombreLocalidad";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        SqlDataReader lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new LocalidadDTO
            {
                IdLocalidad = lector.GetInt32(0),
                NombreLocalidad = lector.GetString(1),
                CodigoPostal = lector.GetInt32(2),
                IdPartido = lector.GetInt32(3)
            });
        }
        ConexionBD.CierraBD();
        return lista;
    }
    public List<LocalidadDTO> CargarLocalidadesPorPartido(int idPartido)
    {
        List<LocalidadDTO> lista = new List<LocalidadDTO>();
        ConexionBD.ConectarBD();
        string query = @"
        SELECT IdLocalidad, NombreLocalidad, CodigoPostal, IdPartido
        FROM Localidad
        WHERE IdPartido = @IdPartido
        ORDER BY NombreLocalidad";

        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@IdPartido", idPartido);
        SqlDataReader lector = cmd.ExecuteReader();

        while (lector.Read())
        {
            lista.Add(new LocalidadDTO
            {
                IdLocalidad = lector.GetInt32(0),
                NombreLocalidad = lector.GetString(1),
                CodigoPostal = lector.GetInt32(2),
                IdPartido = lector.GetInt32(3)
            });
        }

        ConexionBD.CierraBD();
        return lista;
    }


    public List<PreguntaSeguridadDTO> CargarPreguntasSeguridad()
    {
        List<PreguntaSeguridadDTO> lista = new List<PreguntaSeguridadDTO>();
        ConexionBD.ConectarBD();
        string query = "SELECT IdPregunta, TextoPregunta FROM PreguntaSeguridad ORDER BY TextoPregunta";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        SqlDataReader lector = cmd.ExecuteReader();
        while (lector.Read())
        {
            lista.Add(new PreguntaSeguridadDTO
            {
                IdPregunta = lector.GetInt32(0),
                TextoPregunta = lector.GetString(1)
            });
        }
        ConexionBD.CierraBD();
        return lista;
    }

    public void InsertarPermisos(int idUsuario, bool entorno, bool altaUsuario, bool venta, bool inventario, bool industria, bool prodAnimal, bool prodVegetal, bool admin, bool pañol)
    {
        ConexionBD.ConectarBD();
        string query = @"
    INSERT INTO PermisosUsuario 
    (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, 
     PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion, PuedePañol)
    VALUES
    (@IdUsuario, @Entorno, @AltaUsuario, @Venta, @Inventario, @Industria, 
     @ProdAnimal, @ProdVegetal, @Admin, @Pañol)";

        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
        cmd.Parameters.AddWithValue("@Entorno", entorno);
        cmd.Parameters.AddWithValue("@AltaUsuario", altaUsuario);
        cmd.Parameters.AddWithValue("@Venta", venta);
        cmd.Parameters.AddWithValue("@Inventario", inventario);
        cmd.Parameters.AddWithValue("@Industria", industria);
        cmd.Parameters.AddWithValue("@ProdAnimal", prodAnimal);
        cmd.Parameters.AddWithValue("@ProdVegetal", prodVegetal);
        cmd.Parameters.AddWithValue("@Admin", admin);
        cmd.Parameters.AddWithValue("@Pañol", pañol);
        cmd.ExecuteNonQuery();

        ConexionBD.CierraBD();
    }


    public int InsertarUsuarioYObtenerId(AbmUsuario usuario)
    {
        ConexionBD.ConectarBD();
        try
        {
            string query = @"
        INSERT INTO AbmUsuario (
            Nombre, Apellido, Documento, Telefono, Direccion,
            IdLocalidad, IdPartido, IdPreguntaSeguridad,
            Email, NombreUsuario, Contraseña,
            RespuestaSeguridad, Estado
        )
        OUTPUT INSERTED.Id
        VALUES (
            @Nombre, @Apellido, @Documento, @Telefono, @Direccion,
            @IdLocalidad, @IdPartido, @IdPreguntaSeguridad,
            @Email, @NombreUsuario, @Contraseña,
            @RespuestaSeguridad, @Estado
        )";

            SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
            cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
            cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);

            cmd.Parameters.AddWithValue("@IdLocalidad", ObtenerIdLocalidad(usuario.IdLocalidad.NombreLocalidad));
            cmd.Parameters.AddWithValue("@IdPartido", ObtenerIdPartido(usuario.IdPartido.NombrePartido));

            // ✅ Agregamos correctamente la pregunta de seguridad
            cmd.Parameters.AddWithValue("@IdPreguntaSeguridad", ObtenerIdPregunta(usuario.IdPreguntaSeguridad.TextoPregunta));

            cmd.Parameters.AddWithValue("@Email", usuario.Email);
            cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
            cmd.Parameters.AddWithValue("@RespuestaSeguridad", usuario.RespuestaSeguridad);
            cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

            int idGenerado = (int)cmd.ExecuteScalar();
            return idGenerado;
        }
        finally
        {
            ConexionBD.CierraBD();
        }
    }


    public PermisosUsuarioDTO ObtenerPermisosPorUsuario(int idUsuario)
    {
        ConexionBD.ConectarBD();
        string query = "SELECT * FROM PermisosUsuario WHERE IdUsuario = @IdUsuario";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

        var permisos = new PermisosUsuarioDTO();
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            permisos.PuedeEntornoFormativo = reader.GetBoolean(reader.GetOrdinal("PuedeEntornoFormativo"));
            permisos.PuedeAltaUsuario = reader.GetBoolean(reader.GetOrdinal("PuedeAltaUsuario"));
            permisos.PuedeVenta = reader.GetBoolean(reader.GetOrdinal("PuedeVenta"));
            permisos.PuedeInventario = reader.GetBoolean(reader.GetOrdinal("PuedeInventario"));
            permisos.PuedeIndustria = reader.GetBoolean(reader.GetOrdinal("PuedeIndustria"));
            permisos.PuedeProduccionAnimal = reader.GetBoolean(reader.GetOrdinal("PuedeProduccionAnimal"));
            permisos.PuedeProduccionVegetal = reader.GetBoolean(reader.GetOrdinal("PuedeProduccionVegetal"));
            permisos.PuedeAdministracion = reader.GetBoolean(reader.GetOrdinal("PuedeAdministracion"));
            permisos.PuedePañol = reader.GetBoolean(reader.GetOrdinal("PuedePañol")); // ✅ nuevo
        }

        ConexionBD.CierraBD();
        return permisos;
    }


    public bool HayUsuariosRegistrados()
    {
        ConexionBD.ConectarBD();
        string query = "SELECT COUNT(*) FROM AbmUsuario";
        SqlCommand cmd = new SqlCommand(query, ConexionBD.ConexionSQL);
        int cantidad = (int)cmd.ExecuteScalar();
        ConexionBD.CierraBD();
        return cantidad > 0;
    }

    public void CrearUsuarioAdminInicial()
    {
        ConexionBD.ConectarBD();

        int idPartido = 1;
        int idLocalidad = 1;
        int idPregunta = 1;

        string verificarPartido = "SELECT TOP 1 IdPartido FROM Partido";
        using (SqlCommand cmdCheck = new SqlCommand(verificarPartido, ConexionBD.ConexionSQL))
        {
            object result = cmdCheck.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                idPartido = Convert.ToInt32(result);
            }
            else
            {
                string insertarPartido = "INSERT INTO Partido (NombrePartido) OUTPUT INSERTED.IdPartido VALUES ('General')";
                using (SqlCommand cmdInsert = new SqlCommand(insertarPartido, ConexionBD.ConexionSQL))
                {
                    idPartido = (int)cmdInsert.ExecuteScalar();
                }
            }
        }

        string verificarLocalidad = "SELECT TOP 1 IdLocalidad FROM Localidad";
        using (SqlCommand cmdCheck = new SqlCommand(verificarLocalidad, ConexionBD.ConexionSQL))
        {
            object result = cmdCheck.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                idLocalidad = Convert.ToInt32(result);
            }
            else
            {
                string insertarLocalidad = @"INSERT INTO Localidad (NombreLocalidad, CodigoPostal, IdPartido)
                                         OUTPUT INSERTED.IdLocalidad 
                                         VALUES ('Centro', 1000, @IdPartido)";
                using (SqlCommand cmdInsert = new SqlCommand(insertarLocalidad, ConexionBD.ConexionSQL))
                {
                    cmdInsert.Parameters.AddWithValue("@IdPartido", idPartido);
                    idLocalidad = (int)cmdInsert.ExecuteScalar();
                }
            }
        }

        string verificarPregunta = "SELECT TOP 1 IdPregunta FROM PreguntaSeguridad";
        using (SqlCommand cmdCheck = new SqlCommand(verificarPregunta, ConexionBD.ConexionSQL))
        {
            object result = cmdCheck.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                idPregunta = Convert.ToInt32(result);
            }
            else
            {
                string insertarPregunta = "INSERT INTO PreguntaSeguridad (TextoPregunta) OUTPUT INSERTED.IdPregunta VALUES ('Pregunta por defecto')";
                using (SqlCommand cmdInsert = new SqlCommand(insertarPregunta, ConexionBD.ConexionSQL))
                {
                    idPregunta = (int)cmdInsert.ExecuteScalar();
                }
            }
        }

        string queryUsuario = @"
        INSERT INTO AbmUsuario 
        (Nombre, Apellido, Documento, Telefono, Direccion, 
         IdLocalidad, IdPartido, Email, NombreUsuario, Contraseña, 
         IdPreguntaSeguridad, RespuestaSeguridad, Estado)
        OUTPUT INSERTED.Id
        VALUES 
        ('Administrador', 'General', 0, '0000000000', 'Sistema',
         @IdLocalidad, @IdPartido, 'admin@agraria.com', 'admin', '123',
         @IdPreguntaSeguridad, 'Default', 1)";

        SqlCommand cmd = new SqlCommand(queryUsuario, ConexionBD.ConexionSQL);
        cmd.Parameters.AddWithValue("@IdLocalidad", idLocalidad);
        cmd.Parameters.AddWithValue("@IdPartido", idPartido);
        cmd.Parameters.AddWithValue("@IdPreguntaSeguridad", idPregunta);

        int nuevoId = (int)cmd.ExecuteScalar();

        string queryPermisos = @"
        INSERT INTO PermisosUsuario
        (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario, 
         PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion)
        VALUES
        (@IdUsuario, 1, 1, 1, 1, 1, 1, 1, 1)";

        SqlCommand cmdPermisos = new SqlCommand(queryPermisos, ConexionBD.ConexionSQL);
        cmdPermisos.Parameters.AddWithValue("@IdUsuario", nuevoId);
        cmdPermisos.ExecuteNonQuery();

        ConexionBD.CierraBD();
    }

    public void UpsertPermisos(int idUsuario,
    bool entorno, bool altaUsuario, bool venta, bool inventario,
    bool industria, bool prodAnimal, bool prodVegetal, bool admin, bool panol)
    {
        ConexionBD.ConectarBD();
        try
        {
            string sql = @"
IF EXISTS (SELECT 1 FROM PermisosUsuario WHERE IdUsuario = @IdUsuario)
BEGIN
    UPDATE PermisosUsuario SET
        PuedeEntornoFormativo   = @Entorno,
        PuedeAltaUsuario        = @AltaUsuario,
        PuedeVenta              = @Venta,
        PuedeInventario         = @Inventario,
        PuedeIndustria          = @Industria,
        PuedeProduccionAnimal   = @ProdAnimal,
        PuedeProduccionVegetal  = @ProdVegetal,
        PuedeAdministracion     = @Admin,
        [PuedePañol]            = @Panol
    WHERE IdUsuario = @IdUsuario;
END
ELSE
BEGIN
    INSERT INTO PermisosUsuario
    (IdUsuario, PuedeEntornoFormativo, PuedeAltaUsuario, PuedeVenta, PuedeInventario,
     PuedeIndustria, PuedeProduccionAnimal, PuedeProduccionVegetal, PuedeAdministracion, [PuedePañol])
    VALUES
    (@IdUsuario, @Entorno, @AltaUsuario, @Venta, @Inventario,
     @Industria, @ProdAnimal, @ProdVegetal, @Admin, @Panol);
END";

            using (var cmd = new SqlCommand(sql, ConexionBD.ConexionSQL))
            {
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Entorno", entorno);
                cmd.Parameters.AddWithValue("@AltaUsuario", altaUsuario);
                cmd.Parameters.AddWithValue("@Venta", venta);
                cmd.Parameters.AddWithValue("@Inventario", inventario);
                cmd.Parameters.AddWithValue("@Industria", industria);
                cmd.Parameters.AddWithValue("@ProdAnimal", prodAnimal);
                cmd.Parameters.AddWithValue("@ProdVegetal", prodVegetal);
                cmd.Parameters.AddWithValue("@Admin", admin);
                cmd.Parameters.AddWithValue("@Panol", panol); // ← parámetro ASCII
                cmd.ExecuteNonQuery();
            }
        }
        finally
        {
            ConexionBD.CierraBD();
        }
    }

}


