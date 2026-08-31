/* =====================================================
   REINICIO LIMPIO DE BASE Y CREACIÓN COMPLETA
   ===================================================== */
IF DB_ID('Agraria') IS NOT NULL
BEGIN
    ALTER DATABASE Agraria SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Agraria;
END;
GO

CREATE DATABASE Agraria;
GO
USE Agraria;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* ===========================
   TABLAS (campos NULL, salvo PK)
   =========================== */

-- Partido (base)
CREATE TABLE dbo.Partido(
    IdPartido     INT IDENTITY(1,1) NOT NULL,
    NombrePartido VARCHAR(100) NULL,
    CONSTRAINT PK_Partido PRIMARY KEY CLUSTERED (IdPartido ASC)
);
GO

-- Localidad (depende de Partido por FK que se agrega luego)
CREATE TABLE dbo.Localidad(
    IdLocalidad     INT IDENTITY(1,1) NOT NULL,
    NombreLocalidad VARCHAR(100) NULL,
    CodigoPostal    INT NULL,
    IdPartido       INT NULL,
    CONSTRAINT PK_Localidad PRIMARY KEY CLUSTERED (IdLocalidad ASC)
);
GO

-- PreguntaSeguridad
CREATE TABLE dbo.PreguntaSeguridad(
    IdPregunta    INT IDENTITY(1,1) NOT NULL,
    TextoPregunta VARCHAR(200) NULL,
    CONSTRAINT PK_PreguntaSeguridad PRIMARY KEY CLUSTERED (IdPregunta ASC)
);
GO

-- TipoEntorno
CREATE TABLE dbo.TipoEntorno(
    IdTipoEntorno INT IDENTITY(1,1) NOT NULL,
    Nombre        VARCHAR(100) NULL,
    CONSTRAINT PK_TipoEntorno PRIMARY KEY CLUSTERED (IdTipoEntorno ASC)
);
GO

-- TipoMedida
CREATE TABLE dbo.TipoMedida(
    IdTipoMedida INT IDENTITY(1,1) NOT NULL,
    Nombre       VARCHAR(50) NULL,
    CONSTRAINT PK_TipoMedida PRIMARY KEY CLUSTERED (IdTipoMedida ASC)
);
GO

-- Proveedores
CREATE TABLE dbo.Proveedores(
    IdProveedor INT IDENTITY(1,1) NOT NULL,
    RazonSocial NVARCHAR(150) NULL,
    Telefono    NVARCHAR(50) NULL,
    Email       NVARCHAR(100) NULL,
    Direccion   NVARCHAR(150) NULL,
    CONSTRAINT PK_Proveedores PRIMARY KEY CLUSTERED (IdProveedor ASC)
);
GO

-- Productos
CREATE TABLE dbo.Productos(
    idProducto     INT NOT NULL,
    Nombre         NVARCHAR(100) NULL,
    Descripcion    NVARCHAR(255) NULL,
    PrecioUnitario DECIMAL(10,2) NULL,
    CONSTRAINT PK_Productos PRIMARY KEY CLUSTERED (idProducto ASC)
);
GO

-- Box
CREATE TABLE dbo.Box(
    IdBox  INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(100) NULL,
    CONSTRAINT PK_Box PRIMARY KEY CLUSTERED (IdBox ASC)
);
GO

-- BoxCarne
CREATE TABLE dbo.BoxCarne(
    IdBoxCarne INT IDENTITY(1,1) NOT NULL,
    Nombre     NVARCHAR(100) NULL,
    Estado     BIT NULL,
    CONSTRAINT PK_BoxCarne PRIMARY KEY CLUSTERED (IdBoxCarne ASC)
);
GO

-- TipoAnimal
CREATE TABLE dbo.TipoAnimal(
    IdTipo INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NULL,
    CONSTRAINT PK_TipoAnimal PRIMARY KEY CLUSTERED (IdTipo ASC)
);
GO

-- AbmUsuario
CREATE TABLE dbo.AbmUsuario(
    Id                  INT IDENTITY(1,1) NOT NULL,
    Nombre              VARCHAR(100) NULL,
    Apellido            VARCHAR(100) NULL,
    Documento           INT NULL,
    Telefono            VARCHAR(20) NULL,
    Direccion           VARCHAR(200) NULL,
    IdLocalidad         INT NULL,
    IdPartido           INT NULL,
    Email               VARCHAR(150) NULL,
    NombreUsuario       VARCHAR(100) NULL,
    Contraseña          VARCHAR(100) NULL,
    IdPreguntaSeguridad INT NULL,
    RespuestaSeguridad  VARCHAR(200) NULL,
    Estado              BIT NULL,
    CONSTRAINT PK_AbmUsuario PRIMARY KEY CLUSTERED (Id ASC)
);
GO

-- PermisosUsuario
CREATE TABLE dbo.PermisosUsuario(
    IdPermiso              INT IDENTITY(1,1) NOT NULL,
    IdUsuario              INT NULL,
    PuedeEntornoFormativo  BIT NULL,
    PuedeAltaUsuario       BIT NULL,
    PuedeVenta             BIT NULL,
    PuedeInventario        BIT NULL,
    PuedeIndustria         BIT NULL,
    PuedeProduccionAnimal  BIT NULL,
    PuedeProduccionVegetal BIT NULL,
    PuedeAdministracion    BIT NULL,
    PuedePañol             BIT NULL,
    CONSTRAINT PK_PermisosUsuario PRIMARY KEY CLUSTERED (IdPermiso ASC)
);
GO

-- Alimento
CREATE TABLE dbo.Alimento(
    IdAlimento    INT IDENTITY(1,1) NOT NULL,
    Nombre        NVARCHAR(120) NULL,
    Cantidad      DECIMAL(10,2) NULL,
    IdTipoMedida  INT NULL,
    Precio        DECIMAL(10,2) NULL,
    FechaIngreso  DATE NULL,
    IdTipoEntorno INT NULL,
    IdProveedor   INT NULL,
    Estado        BIT NULL,
    CONSTRAINT PK_Alimento PRIMARY KEY CLUSTERED (IdAlimento ASC)
);
GO

-- Articulo
CREATE TABLE dbo.Articulo(
    IdArticulo    INT IDENTITY(1,1) NOT NULL,
    NombreProducto VARCHAR(100) NULL,
    Cantidad       DECIMAL(10,2) NULL,
    IdTipoMedida   INT NULL,
    Precio         DECIMAL(10,2) NULL,
    FechaIngreso   DATE NULL,
    IdTipoEntorno  INT NULL,
    Responsable    VARCHAR(100) NULL,
    FechaEgreso    DATETIME NULL,
    Estado         BIT NULL,
    CONSTRAINT PK_Articulo PRIMARY KEY CLUSTERED (IdArticulo ASC)
);
GO

-- ArticulosPañol
CREATE TABLE dbo.[ArticulosPañol](
    IdArtPañol   INT IDENTITY(1,1) NOT NULL,
    NombreProducto VARCHAR(100) NULL,
    Cantidad       INT NULL,
    IdUnidad       INT NULL,
    FechaIngreso   DATE NULL,
    IdEntorno      INT NULL,
    Responsable    VARCHAR(100) NULL,
    Estado         BIT NULL,
    CONSTRAINT PK_ArticulosPañol PRIMARY KEY CLUSTERED (IdArtPañol ASC)
);
GO

-- Aves
CREATE TABLE dbo.Aves(
    Id                 INT IDENTITY(1,1) NOT NULL,
    Nombre             NVARCHAR(150) NULL,
    CantidadAves       INT NULL,
    FechaIngresoAves   DATE NULL,
    CantidadHuevos     INT NULL,
    FechaIngresoHuevos DATE NULL,
    CantidadRetiradas  INT NULL,
    FechaRetiradas     DATE NULL,
    Estado             BIT NULL,
    CONSTRAINT PK_Aves PRIMARY KEY CLUSTERED (Id ASC)
);
GO

-- Carne
CREATE TABLE dbo.Carne(
    IdCarne             INT IDENTITY(1,1) NOT NULL,
    Nombre              NVARCHAR(100) NULL,
    IdBoxCarne          INT NULL,
    NumeroAnimal        NVARCHAR(50) NULL,
    FechaIngreso        DATE NULL,
    Sexo                NVARCHAR(10) NULL,
    FechaRetiro         DATE NULL,
    FechaEnvioIndustria DATE NULL,
    Estado              BIT NULL,
    CONSTRAINT PK_Carne PRIMARY KEY CLUSTERED (IdCarne ASC),
    CONSTRAINT UQ_Carne_NumeroAnimal UNIQUE NONCLUSTERED (NumeroAnimal ASC)
);
GO

-- Colmenas
CREATE TABLE dbo.Colmenas(
    Id                INT IDENTITY(1,1) NOT NULL,
    Nombre            NVARCHAR(120) NULL,
    CantidadColmenas  INT NULL,
    FechaIngresoColmenas DATE NULL,
    CantidadMiel      INT NULL,
    FechaIngresoMiel  DATE NULL,
    CantidadRetiradas INT NULL,
    FechaRetiradas    DATE NULL,
    Estado            BIT NULL,
    CONSTRAINT PK_Colmenas PRIMARY KEY CLUSTERED (Id ASC)
);
GO

-- DetalleCompra
CREATE TABLE dbo.DetalleCompra(
    IdDetalle      INT IDENTITY(1,1) NOT NULL,
    IdNumeroFactura INT NULL,
    Fecha          DATE NULL,
    IdProducto     INT NULL,
    NombreProducto NVARCHAR(100) NULL,
    PrecioUnitario DECIMAL(10,2) NULL,
    Cantidad       INT NULL,
    CONSTRAINT PK_DetalleCompra PRIMARY KEY CLUSTERED (IdDetalle ASC)
);
GO

-- Engorde
CREATE TABLE dbo.Engorde(
    IdEngorde      INT IDENTITY(1,1) NOT NULL,
    IdBox          INT NULL,
    Nombre         NVARCHAR(100) NULL,
    FechaIngreso   DATE NULL,
    Cantidad       INT NULL,
    FechaActualizado DATE NULL,
    Semanas        INT NULL,
    Peso           DECIMAL(10,2) NULL,
    IdAlimento     INT NULL,
    AlimentoPorDia DECIMAL(10,2) NULL,
    Estado         BIT NULL,
    CONSTRAINT PK_Engorde PRIMARY KEY CLUSTERED (IdEngorde ASC)
);
GO

-- Entorno
CREATE TABLE dbo.Entorno(
    IdEntorno     INT IDENTITY(1,1) NOT NULL,
    Nombre        VARCHAR(150) NULL,
    IdTipoEntorno INT NULL,
    Responsable   VARCHAR(150) NULL,
    Año           VARCHAR(10) NULL,
    Division      VARCHAR(10) NULL,
    Grupo         VARCHAR(50) NULL,
    Fecha         DATETIME NULL,
    Observaciones VARCHAR(MAX) NULL,
    CONSTRAINT PK_Entorno PRIMARY KEY CLUSTERED (IdEntorno ASC)
);
GO

-- Industria
CREATE TABLE dbo.Industria(
    idRegistroIndustria INT IDENTITY(1,1) NOT NULL,
    idIndustria         INT NULL,
    idProducto          INT NULL,
    cantidadProduccion  INT NULL,
    FechaProduccion     DATE NULL,
    idInsumos           INT NULL,
    CantidadInsumos     INT NULL,
    CONSTRAINT PK_Industria PRIMARY KEY CLUSTERED (idRegistroIndustria ASC)
);
GO

-- Leche
CREATE TABLE dbo.Leche(
    IdLeche        INT IDENTITY(1,1) NOT NULL,
    Nombre         VARCHAR(100) NULL,
    NumeroAnimal   VARCHAR(50) NULL,
    FechaIngreso   DATE NULL,
    Sexo           VARCHAR(10) NULL,
    FechaOrdeñe    DATE NULL,
    LitrosLeche    DECIMAL(10,2) NULL,
    FechaFallecido DATE NULL,
    Estado         BIT NULL,
    CONSTRAINT PK_Leche PRIMARY KEY CLUSTERED (IdLeche ASC)
);
GO

-- ProduccionVegetal
CREATE TABLE dbo.ProduccionVegetal(
    IdProduccion       INT IDENTITY(1,1) NOT NULL,
    CantidadPlantines  INT NULL,
    FechaCosecha       DATE NULL,
    CantidadAtados     INT NULL,
    Estado             BIT NULL,
    FechaCultivo       DATE NULL,
    CONSTRAINT PK_ProduccionVegetal PRIMARY KEY CLUSTERED (IdProduccion ASC)
);
GO

-- RegistroCompra
CREATE TABLE dbo.RegistroCompra(
    IdRegistro      INT IDENTITY(1,1) NOT NULL,
    IdNumeroFactura INT NULL,
    Nombre          NVARCHAR(150) NULL,
    Cuit            NVARCHAR(30) NULL,
    Fecha           DATE NULL,
    Precio          DECIMAL(12,2) NULL,
    Descuento       DECIMAL(5,2) NULL,
    Total           DECIMAL(12,2) NULL,
    CONSTRAINT PK_RegistroCompra PRIMARY KEY CLUSTERED (IdRegistro ASC)
);
GO

-- RegistroFertilidadCarne
CREATE TABLE dbo.RegistroFertilidadCarne(
    IdRegistro     INT IDENTITY(1,1) NOT NULL,
    NumeroMadre    NVARCHAR(50) NULL,
    NumeroPadre    NVARCHAR(50) NULL,
    FechaMonta     DATE NULL,
    FechaParto     DATE NULL,
    CantidadHembras INT NULL,
    CantidadMachos  INT NULL,
    TotalNacidos    INT NULL,
    Estado          BIT NULL,
    CONSTRAINT PK_RegistroFertilidadCarne PRIMARY KEY CLUSTERED (IdRegistro ASC)
);
GO

-- RegistroFertilidadLeche
CREATE TABLE dbo.RegistroFertilidadLeche(
    IdRegistro     INT IDENTITY(1,1) NOT NULL,
    Nombre         VARCHAR(100) NULL,
    NumeroMadre    VARCHAR(50) NULL,
    NumeroPadre    VARCHAR(50) NULL,
    FechaMonta     DATE NULL,
    FechaParto     DATE NULL,
    IdTipo         INT NULL,
    CantidadHembras INT NULL,
    CantidadMachos  INT NULL,
    TotalNacidos    INT NULL,
    Estado          BIT NULL,
    CONSTRAINT PK_RegistroFertilidadLeche PRIMARY KEY CLUSTERED (IdRegistro ASC)
);
GO

-- Urgencias
CREATE TABLE dbo.Urgencias(
    IdUrgencia INT IDENTITY(1,1) NOT NULL,
    Mensaje    NVARCHAR(500) NULL,
    Fecha      DATETIME NULL,
    CONSTRAINT PK_Urgencias PRIMARY KEY CLUSTERED (IdUrgencia ASC)
);
GO

-- Vegetales
CREATE TABLE dbo.Vegetales(
    IdProduccion      INT IDENTITY(1,1) NOT NULL,
    Nombre            VARCHAR(100) NULL,
    CantidadPlantines INT NULL,
    Cantidad          INT NULL,
    FechaCultivo      DATE NULL,
    FechaCosecha      DATE NULL,
    Estado            BIT NULL,
    CONSTRAINT PK_Vegetales PRIMARY KEY CLUSTERED (IdProduccion ASC)
);
GO

/* ===========================
   DEFAULTS
   =========================== */
ALTER TABLE dbo.AbmUsuario        ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Alimento          ADD DEFAULT ((0)) FOR Cantidad;
ALTER TABLE dbo.Alimento          ADD DEFAULT ((0)) FOR Precio;
ALTER TABLE dbo.Alimento          ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Articulo          ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.[ArticulosPañol]  ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Aves              ADD DEFAULT ((0)) FOR CantidadAves;
ALTER TABLE dbo.Aves              ADD DEFAULT ((0)) FOR CantidadHuevos;
ALTER TABLE dbo.Aves              ADD DEFAULT ((0)) FOR CantidadRetiradas;
ALTER TABLE dbo.Aves              ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.BoxCarne          ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Carne             ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Colmenas          ADD DEFAULT ((0)) FOR CantidadColmenas;
ALTER TABLE dbo.Colmenas          ADD DEFAULT ((0)) FOR CantidadMiel;
ALTER TABLE dbo.Colmenas          ADD DEFAULT ((0)) FOR CantidadRetiradas;
ALTER TABLE dbo.Colmenas          ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Engorde           ADD DEFAULT ((0)) FOR Cantidad;
ALTER TABLE dbo.Engorde           ADD DEFAULT ((0)) FOR Semanas;
ALTER TABLE dbo.Engorde           ADD DEFAULT ((0)) FOR Peso;
ALTER TABLE dbo.Engorde           ADD DEFAULT ((0)) FOR AlimentoPorDia;
ALTER TABLE dbo.Engorde           ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeEntornoFormativo;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeAltaUsuario;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeVenta;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeInventario;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeIndustria;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeProduccionAnimal;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeProduccionVegetal;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((0)) FOR PuedeAdministracion;
ALTER TABLE dbo.PermisosUsuario   ADD DEFAULT ((1)) FOR PuedePañol;
ALTER TABLE dbo.ProduccionVegetal ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.ProduccionVegetal ADD DEFAULT (GETDATE()) FOR FechaCultivo;
ALTER TABLE dbo.Productos         ADD DEFAULT ((0)) FOR PrecioUnitario;
ALTER TABLE dbo.RegistroFertilidadCarne ADD DEFAULT ((1)) FOR Estado;
ALTER TABLE dbo.Urgencias         ADD DEFAULT (GETDATE()) FOR Fecha;
ALTER TABLE dbo.Vegetales         ADD DEFAULT ((1)) FOR Estado;
GO

/* ===========================
   FOREIGN KEYS
   =========================== */
ALTER TABLE dbo.AbmUsuario  WITH CHECK ADD FOREIGN KEY (IdLocalidad)         REFERENCES dbo.Localidad (IdLocalidad);
ALTER TABLE dbo.AbmUsuario  WITH CHECK ADD FOREIGN KEY (IdPartido)           REFERENCES dbo.Partido   (IdPartido);
ALTER TABLE dbo.AbmUsuario  WITH CHECK ADD FOREIGN KEY (IdPreguntaSeguridad) REFERENCES dbo.PreguntaSeguridad (IdPregunta);

ALTER TABLE dbo.Alimento    WITH CHECK ADD FOREIGN KEY (IdProveedor)   REFERENCES dbo.Proveedores (IdProveedor);
ALTER TABLE dbo.Articulo    WITH CHECK ADD FOREIGN KEY (IdTipoMedida)  REFERENCES dbo.TipoMedida  (IdTipoMedida);
ALTER TABLE dbo.Articulo    WITH CHECK ADD FOREIGN KEY (IdTipoEntorno) REFERENCES dbo.TipoEntorno (IdTipoEntorno);

ALTER TABLE dbo.[ArticulosPañol] WITH CHECK ADD FOREIGN KEY (IdEntorno) REFERENCES dbo.TipoEntorno (IdTipoEntorno);
ALTER TABLE dbo.[ArticulosPañol] WITH CHECK ADD FOREIGN KEY (IdUnidad)  REFERENCES dbo.TipoMedida  (IdTipoMedida);

ALTER TABLE dbo.Carne       WITH CHECK ADD FOREIGN KEY (IdBoxCarne) REFERENCES dbo.BoxCarne (IdBoxCarne);

ALTER TABLE dbo.Engorde     WITH CHECK ADD FOREIGN KEY (IdAlimento) REFERENCES dbo.Alimento (IdAlimento);
ALTER TABLE dbo.Engorde     WITH CHECK ADD FOREIGN KEY (IdBox)      REFERENCES dbo.Box      (IdBox);

ALTER TABLE dbo.Entorno     WITH CHECK ADD FOREIGN KEY (IdTipoEntorno) REFERENCES dbo.TipoEntorno (IdTipoEntorno);

ALTER TABLE dbo.Industria   WITH CHECK ADD CONSTRAINT FK_Industria_Articulo  FOREIGN KEY (idInsumos) REFERENCES dbo.Articulo  (IdArticulo);
ALTER TABLE dbo.Industria   WITH CHECK ADD CONSTRAINT FK_Industria_Producto  FOREIGN KEY (idProducto) REFERENCES dbo.Productos (idProducto);

ALTER TABLE dbo.Localidad   WITH NOCHECK ADD FOREIGN KEY (IdPartido) REFERENCES dbo.Partido (IdPartido);

ALTER TABLE dbo.PermisosUsuario WITH CHECK ADD FOREIGN KEY (IdUsuario) REFERENCES dbo.AbmUsuario (Id);
GO

/* ===========================
   CHECK CONSTRAINTS
   =========================== */
ALTER TABLE dbo.Industria  WITH CHECK ADD CHECK ((cantidadProduccion >= (0)));
ALTER TABLE dbo.Industria  WITH CHECK ADD CHECK ((CantidadInsumos   >= (0)));
ALTER TABLE dbo.Vegetales  WITH CHECK ADD CHECK ((CantidadPlantines >= (0)));
ALTER TABLE dbo.Vegetales  WITH CHECK ADD CHECK ((Cantidad          >= (0)));
GO

/* ===========================
   DATOS INICIALES
   =========================== */

-- Partidos
INSERT INTO dbo.Partido (NombrePartido) VALUES ('Almirante Brown');
INSERT INTO dbo.Partido (NombrePartido) VALUES ('San Vicente');
GO

-- Localidades (Almirante Brown = IdPartido 1)
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Adrogué', 1846, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Burzaco', 1852, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Claypole', 1849, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Glew', 1856, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Longchamps', 1854, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Malvinas Argentinas (Brown)', 1847, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Ministro Rivadavia', 1854, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'San José', 1846, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Soledad', 1853, 1);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Rafael Calzada', 1847, 1);
GO

-- Localidades (San Vicente = IdPartido 2)
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'San Vicente', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Alejandro Korn', 1864, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Domselaar', 1984, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Villa Coll', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Laguna del Ojo', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Estancia El Pino', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Paraje La Laurita', 1865, 2);
INSERT INTO dbo.Localidad (NombreLocalidad, CodigoPostal, IdPartido) VALUES (N'Campo de Mayo Chico', 1865, 2);
GO

-- Preguntas de seguridad
INSERT INTO dbo.PreguntaSeguridad (TextoPregunta)
VALUES
(N'¿Nombre de tu primer Mascota?'),
(N'¿Cual es tu libro favorito?'),
(N'¿Nombre de tu mejor amigo de la infancia?'),
(N'¿Ciudad donde naciste?'),
(N'¿Nombre de tu escuela primaria?');
GO

-- TipoEntorno
INSERT INTO dbo.TipoEntorno (Nombre)
VALUES ('Animal'), ('Vegetal'), ('Industria'), ('Compras'), ('Pañol');
GO

-- TipoMedida
INSERT INTO dbo.TipoMedida (Nombre)
VALUES ('Kilo'), ('Unidad'), ('Litro');
GO

-- Productos
INSERT INTO dbo.Productos (idProducto, Nombre, Descripcion, PrecioUnitario)
VALUES
(1, 'Pollo al escabeche', 'Se cocina el pollo en agua con sal, luego se fríe y se marina con vinagre, laurel, ajo, pimienta y zanahoria.', 4000),
(2, 'Empanadas de pollo', 'Pollo desmenuzado con cebolla y morrón. Se rellena la masa y se hornea.', 3000),
(3, 'Pollo parrillero', 'Pollo condimentado con salmuera o adobo y cocinado a la parrilla.', 2000),
(4, 'Miel', 'Preparación de miel con frascos de 1kg o ½ kg según el producto.', 2400);
GO

-- Box
INSERT INTO dbo.Box (Nombre) VALUES ('Box1'), ('Box2'), ('Box3');
GO

-- Proveedores
INSERT INTO dbo.Proveedores (RazonSocial, Telefono, Email, Direccion)
VALUES
(N'AgroNutri SRL', N'381-4456789', 'contacto@agronutri.com', N'Ruta 9 Km 1250, San Miguel de Tucumán'),
(N'CampoFert SA',  N'011-47781234', 'ventas@campofert.com',    N'Av. del Agricultor 1050, Rosario'),
(N'Nutrición Animal del Norte', N'381-4224455', 'info@nutrianimalnorte.com', N'Bº Sur, Catamarca 450, Tucumán'),
(N'Granjas Unidas', N'351-4895566', 'comercial@granjasunidas.com', N'Av. Circunvalación 8900, Córdoba'),
(N'ProCampo SRL',  N'261-4573312', 'administracion@procampo.com', N'Ruta 40 Km 45, Mendoza');
GO

-- Alimento
INSERT INTO dbo.Alimento (Nombre, Cantidad, IdTipoMedida, Precio, FechaIngreso, IdTipoEntorno, IdProveedor, Estado)
VALUES
(N'Maíz molido',         1000, 2, 350.00, GETDATE(), 2, 1, 1),
(N'Balanceado Engorde',   800, 2, 420.00, GETDATE(), 2, 1, 1),
(N'Soja Pelletizada',     600, 2, 480.00, GETDATE(), 2, 1, 1),
(N'Avena',                500, 2, 300.00, GETDATE(), 2, 1, 1);
GO

-- BoxCarne
INSERT INTO dbo.BoxCarne (Nombre) VALUES ('Box 1'), ('Box 2'), ('Box 3');
GO

-- TipoAnimal
INSERT INTO dbo.TipoAnimal (Nombre) VALUES ('Melliceros'),('Ninguno');
GO
