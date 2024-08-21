/*************************************************************************
CREAR BASE DE DATOS
ejecutar esta parte del query primero para despues ejectuar el resto
**************************************************************************/
use master;
GO

CREATE DATABASE DARWIN_SANCHEZ_DB;
GO

USE DARWIN_SANCHEZ_DB;
GO



/*************************************************************************
CREAR TABLAS
**************************************************************************/

CREATE TABLE dsc_tbl_Formulario(
FormularioId int identity(1000,10) not null,
Nombre nvarchar(100) not null,
Estado tinyint default 1,
constraint pk_dsc_tbl_Formulario_FormularioId primary key (FormularioId)
);


CREATE TABLE dsc_tbl_ControlTipo(
ControlTipoId nvarchar(20) not null,
Nombre nvarchar(100) not null,
Estado tinyint default 1,
constraint pk_dsc_tbl_ControlTipo_ControlId primary key (ControlTipoId),
);

CREATE TABLE dsc_tbl_Control(
ControlId int identity(1,1) not null,
FormularioId int not null,
Orden int not null,
Nombre nvarchar(100) not null,--name
Descripcion nvarchar(200) not null,--label
TipoId nvarchar(20) not null,--type
OpcionValor1 nvarchar(20) null,
OpcionTexto1 nvarchar(20) null,
OpcionValor2 nvarchar(20) null,
OpcionTexto2 nvarchar(20) null,
OpcionValor3 nvarchar(20) null,
OpcionTexto3 nvarchar(20) null,
ValidRequired tinyint null,
ValidRequiredMsg nvarchar(200) null,
ValidPattern tinyint null,
ValidPatternExpReg nvarchar(200) null,
ValidPatternMsg nvarchar(200) null,
Estado tinyint default 1 not null,
constraint pk_dsc_tbl_Control_ControlId primary key (ControlId),
constraint fk_dsc_tbl_Control_FormularioId foreign key (FormularioId) references dsc_tbl_Formulario(FormularioId),
constraint fk_dsc_tbl_Control_TipoId foreign key (TipoId) references dsc_tbl_ControlTipo(ControlTipoId)
);



/*************************************************************************
LLENAR CON DATOS
**************************************************************************/
--formulario
set identity_insert dsc_tbl_Formulario on;
INSERT INTO dsc_tbl_Formulario(FormularioId,Nombre)VALUES(1000,'Persona');
INSERT INTO dsc_tbl_Formulario(FormularioId,Nombre)VALUES(1010,'Mascota');
set identity_insert dsc_tbl_Formulario off;
--controles tipo
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('text','Textos');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('password','Contraseñas');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('email','Correos electrónicos');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('number','Números');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('date','Fechas');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('color','Colores');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('radio','Opciones');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('checkbox','Activar | Desactivar');
INSERT INTO dsc_tbl_ControlTipo(ControlTipoId,Nombre)VALUES('file','Subir Imagenes');
--controles persona
set identity_insert dsc_tbl_Control on;
INSERT INTO dsc_tbl_Control(ControlId,FormularioId,Orden,Nombre,Descripcion,TipoId,OpcionValor1,OpcionTexto1,OpcionValor2,OpcionTexto2,OpcionValor3,OpcionTexto3,ValidRequired,ValidRequiredMsg,ValidPattern,ValidPatternExpReg,ValidPatternMsg,Estado)
     VALUES(1 --ControlId
			,1000 --FormularioId
           ,1--,<Orden, int,>
           ,'fotoPersona'--<Nombre, nvarchar(100),>
           ,'Foto de perfil :'--<Descripcion, nvarchar(200),>
           ,'file'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Foto de perfil es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
           (2 --ControlId
		   ,1000 --FormularioId
           ,2--,<Orden, int,>
           ,'nombrePersona'--<Nombre, nvarchar(100),>
           ,'Nombre :'--<Descripcion, nvarchar(200),>
           ,'text'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Nombre es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,1--<ValidPattern, tinyint,>
           ,'^[A-Za-z]+$'--<ValidPatternExpReg, nvarchar(200),>
           ,'Solo se permiten letras'--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (3 --ControlId
		   ,1000 --FormularioId
           ,3--,<Orden, int,>
           ,'generoPersona'--<Nombre, nvarchar(100),>
           ,'Genero :'--<Descripcion, nvarchar(200),>
           ,'radio'--<TipoId, nvarchar(20),>
           ,'M'--<OpcionValor1, nvarchar(20),>
           ,'Masculino'--<OpcionTexto1, nvarchar(20),>
           ,'F'--<OpcionValor2, nvarchar(20),>
           ,'Femenino'--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Nombre es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (4 --ControlId
		   ,1000 --FormularioId
           ,4--,<Orden, int,>
           ,'fechaNacimientoPersona'--<Nombre, nvarchar(100),>
           ,'Fecha de nacimiento :'--<Descripcion, nvarchar(200),>
           ,'date'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Fecha de nacimiento es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (5 --ControlId
		   ,1000 --FormularioId
           ,5--,<Orden, int,>
           ,'emailPersona'--<Nombre, nvarchar(100),>
           ,'Correo Electrónico :'--<Descripcion, nvarchar(200),>
           ,'email'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Correo electrónico es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,1--<ValidPattern, tinyint,>
           ,'^[^\s@]+@[^\s@]+\.[^\s@]+$'--<ValidPatternExpReg, nvarchar(200),>
           ,'Correo electronico invalido'--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (6 --ControlId
		   ,1000 --FormularioId
           ,6--,<Orden, int,>
           ,'edadActualPersona'--<Nombre, nvarchar(100),>
           ,'Edad Actual :'--<Descripcion, nvarchar(200),>
           ,'number'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Edad actual es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,1--<ValidPattern, tinyint,>
           ,'^[1-9][0-9]*$'--<ValidPatternExpReg, nvarchar(200),>
           ,'Edad actual debe ser mayor a 0'--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   );
set identity_insert dsc_tbl_Control off;


--controles mascota--------------------------------
set identity_insert dsc_tbl_Control on;
INSERT INTO dsc_tbl_Control(ControlId,FormularioId,Orden,Nombre,Descripcion,TipoId,OpcionValor1,OpcionTexto1,OpcionValor2,OpcionTexto2,OpcionValor3,OpcionTexto3,ValidRequired,ValidRequiredMsg,ValidPattern,ValidPatternExpReg,ValidPatternMsg,Estado)
     VALUES(7 --ControlId
			,1010 --FormularioId
           ,1--,<Orden, int,>
           ,'fotoMascota'--<Nombre, nvarchar(100),>
           ,'Foto de Mascota :'--<Descripcion, nvarchar(200),>
           ,'file'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Foto de perfil es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
           (8 --ControlId
		   ,1010 --FormularioId
           ,2--,<Orden, int,>
           ,'nombreMascota'--<Nombre, nvarchar(100),>
           ,'Nombre :'--<Descripcion, nvarchar(200),>
           ,'text'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Nombre es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,1--<ValidPattern, tinyint,>
           ,'^[A-Za-z]+$'--<ValidPatternExpReg, nvarchar(200),>
           ,'Solo se permiten letras'--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (9 --ControlId
		   ,1010 --FormularioId
           ,3--,<Orden, int,>
           ,'razaMascota'--<Nombre, nvarchar(100),>
           ,'Raza :'--<Descripcion, nvarchar(200),>
           ,'text'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'Raza es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (10 --ControlId
		   ,1010 --FormularioId
           ,4--,<Orden, int,>
           ,'colorMascota'--<Nombre, nvarchar(100),>
           ,'Color :'--<Descripcion, nvarchar(200),>
           ,'color'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'color es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (11 --ControlId
		   ,1010 --FormularioId
           ,5--,<Orden, int,>
           ,'pedigreeMascota'--<Nombre, nvarchar(100),>
           ,'Pedigree :'--<Descripcion, nvarchar(200),>
           ,'checkbox'--<TipoId, nvarchar(20),>
           ,''--<OpcionValor1, nvarchar(20),>
           ,''--<OpcionTexto1, nvarchar(20),>
           ,''--<OpcionValor2, nvarchar(20),>
           ,''--<OpcionTexto2, nvarchar(20),>
           ,''--<OpcionValor3, nvarchar(20),>
           ,''--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'pedigree es requerido'--<ValidRequiredMsg, nvarchar(200),>
           ,1--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   ),
		   (12 --ControlId
		   ,1010 --FormularioId
           ,6--,<Orden, int,>
           ,'tamanoMascota'--<Nombre, nvarchar(100),>
           ,'Tamaño :'--<Descripcion, nvarchar(200),>
           ,'radio'--<TipoId, nvarchar(20),>
           ,'P'--<OpcionValor1, nvarchar(20),>
           ,'Pequeño'--<OpcionTexto1, nvarchar(20),>
           ,'M'--<OpcionValor2, nvarchar(20),>
           ,'Mediano'--<OpcionTexto2, nvarchar(20),>
           ,'G'--<OpcionValor3, nvarchar(20),>
           ,'Grande'--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'tamaño es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
		   );
set identity_insert dsc_tbl_Control off;


/*************************************************************************
STORE PROCEDURE
**************************************************************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure dsc_sp_SelectControl(
@FormularioId int = null,
@ControlId int = null,
@Estado tinyint = null
)
as
begin
SELECT c.ControlId
      ,c.FormularioId
      ,c.Orden
      ,c.Nombre
      ,c.Descripcion
      ,c.TipoId
	  ,ct.Nombre as TipoNombre
      ,c.OpcionValor1
      ,c.OpcionTexto1
      ,c.OpcionValor2
      ,c.OpcionTexto2
      ,c.OpcionValor3
      ,c.OpcionTexto3
      ,c.ValidRequired
      ,c.ValidRequiredMsg
      ,c.ValidPattern
      ,c.ValidPatternExpReg
      ,c.ValidPatternMsg
      ,c.Estado
  FROM dsc_tbl_Control c inner join dsc_tbl_ControlTipo ct on (c.TipoId = ct.ControlTipoId)
  where (@FormularioId is null or c.FormularioId = @FormularioId) and
  (@ControlId is null or c.ControlId = @ControlId) and
  (@Estado is null or c.Estado = @Estado)
  order by FormularioId, c.Orden;
  end
  go

  /*
exec dsc_sp_SelectControl
null--@FormularioId int
,null--@ControlId int = null,
,null--@Estado tinyint
*/

----------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure dsc_sp_InsertControl(
@FormularioId int
,@Orden int
,@Nombre nvarchar(100)
,@Descripcion nvarchar(200)
,@TipoId nvarchar(20)
,@OpcionValor1 nvarchar(20)
,@OpcionTexto1 nvarchar(20)
,@OpcionValor2 nvarchar(20)
,@OpcionTexto2 nvarchar(20)
,@OpcionValor3 nvarchar(20)
,@OpcionTexto3 nvarchar(20)
,@ValidRequired tinyint
,@ValidRequiredMsg nvarchar(200)
,@ValidPattern tinyint
,@ValidPatternExpReg nvarchar(200)
,@ValidPatternMsg nvarchar(200)
,@Estado tinyint
)
as
begin
INSERT INTO dsc_tbl_Control(FormularioId,Orden,Nombre,Descripcion,TipoId,OpcionValor1,OpcionTexto1,OpcionValor2,OpcionTexto2,OpcionValor3,OpcionTexto3,ValidRequired,ValidRequiredMsg,ValidPattern,ValidPatternExpReg,ValidPatternMsg,Estado)
VALUES(@FormularioId,@Orden,@Nombre,@Descripcion,@TipoId,@OpcionValor1,@OpcionTexto1,@OpcionValor2,@OpcionTexto2,@OpcionValor3,@OpcionTexto3,@ValidRequired,@ValidRequiredMsg,@ValidPattern,@ValidPatternExpReg,@ValidPatternMsg,@Estado);
END
GO
/*
EXEC dsc_sp_InsertControl
		   1010 --FormularioId
           ,7--,<Orden, int,>
           ,'garrapatasMascota'--<Nombre, nvarchar(100),>
           ,'garrapatas :'--<Descripcion, nvarchar(200),>
           ,'radio'--<TipoId, nvarchar(20),>
           ,'P'--<OpcionValor1, nvarchar(20),>
           ,'Pequeño'--<OpcionTexto1, nvarchar(20),>
           ,'M'--<OpcionValor2, nvarchar(20),>
           ,'Mediano'--<OpcionTexto2, nvarchar(20),>
           ,'G'--<OpcionValor3, nvarchar(20),>
           ,'Grande'--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'tamaño es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>

	*/	   


-----------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure dsc_sp_UpdateControl(
@ControlId int
--,@FormularioId int
,@Orden int
,@Nombre nvarchar(100)
,@Descripcion nvarchar(200)
,@TipoId nvarchar(20)
,@OpcionValor1 nvarchar(20)
,@OpcionTexto1 nvarchar(20)
,@OpcionValor2 nvarchar(20)
,@OpcionTexto2 nvarchar(20)
,@OpcionValor3 nvarchar(20)
,@OpcionTexto3 nvarchar(20)
,@ValidRequired tinyint
,@ValidRequiredMsg nvarchar(200)
,@ValidPattern tinyint
,@ValidPatternExpReg nvarchar(200)
,@ValidPatternMsg nvarchar(200)
,@Estado tinyint
)
as
begin
UPDATE dsc_tbl_Control
SET 
--FormularioId=@FormularioId
Orden=@Orden
,Nombre=@Nombre
,Descripcion=@Descripcion
,TipoId=@TipoId
,OpcionValor1=@OpcionValor1
,OpcionTexto1=@OpcionTexto1
,OpcionValor2=@OpcionValor2
,OpcionTexto2=@OpcionTexto2
,OpcionValor3=@OpcionValor3
,OpcionTexto3=@OpcionTexto3
,ValidRequired=@ValidRequired
,ValidRequiredMsg=@ValidRequiredMsg
,ValidPattern=@ValidPattern
,ValidPatternExpReg=@ValidPatternExpReg
,ValidPatternMsg=@ValidPatternMsg
,Estado=@Estado
where ControlId = @ControlId;
END
GO
/*
EXEC dsc_sp_UpdateControl
			13,--ControlId int	
           ,7--,<Orden, int,>
           ,'pulgasMascota'--<Nombre, nvarchar(100),>
           ,'pulga :'--<Descripcion, nvarchar(200),>
           ,'checkbox'--<TipoId, nvarchar(20),>
           ,'P'--<OpcionValor1, nvarchar(20),>
           ,'pequenito'--<OpcionTexto1, nvarchar(20),>
           ,'M'--<OpcionValor2, nvarchar(20),>
           ,'mayorcito'--<OpcionTexto2, nvarchar(20),>
           ,'G'--<OpcionValor3, nvarchar(20),>
           ,'cansado'--<OpcionTexto3, nvarchar(20),>
           ,1--<ValidRequired, tinyint,>
           ,'tamaño es requerida'--<ValidRequiredMsg, nvarchar(200),>
           ,0--<ValidPattern, tinyint,>
           ,''--<ValidPatternExpReg, nvarchar(200),>
           ,''--<ValidPatternMsg, nvarchar(200),>
           ,1--<Estado, tinyint,>
*/



-----------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure dsc_sp_DeleteControl(
@ControlId int
)
as
begin
DELETE FROM dsc_tbl_Control
where ControlId = @ControlId;
END
GO

/*
exec dsc_sp_DeleteControl
13--@ControlId int
*/



-----------------------------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure dsc_sp_SelectControlTipo
as
begin
SELECT ControlTipoId,Nombre,Estado
  FROM dsc_tbl_ControlTipo
  ORDER BY Nombre;
END
GO

--exec dsc_sp_SelectControlTipo



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure dsc_sp_SelectFormulario
as
begin
SELECT FormularioId,Nombre,Estado
  FROM dsc_tbl_Formulario
  ORDER BY Nombre;
END
GO




