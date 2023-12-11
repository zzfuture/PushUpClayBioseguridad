CREATE TABLE `user` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `username` varchar(50) UNIQUE NOT NULL,
  `password` varchar(150) UNIQUE NOT NULL,
  `email` varchar(100) UNIQUE NOT NULL
);

CREATE TABLE `rol` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) UNIQUE NOT NULL
);

CREATE TABLE `userrol` (
  `idUsuarioFk` int NOT NULL,
  `idRolFk` int NOT NULL,
  PRIMARY KEY (`idUsuarioFk`, `idRolFk`)
);

CREATE TABLE `empleado` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50),
  `apellido` varchar(50),
  `telefono` varchar(10),
  `idPuestoFk` int
);

CREATE TABLE `puesto` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50)
);

CREATE TABLE `pais` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) UNIQUE
);

CREATE TABLE `departamento` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) UNIQUE,
  `idPaisFk` int NOT NULL
);

CREATE TABLE `ciudad` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) UNIQUE,
  `idDepartamentoFk` int NOT NULL
);

CREATE TABLE `contrato` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `idClienteFk` int,
  `fechaContrato` date,
  `idEmpleadoFk` int,
  `fechaFin` date,
  `idEstadoFk` int
);

CREATE TABLE `estado` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100)
);

CREATE TABLE `persona` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `idPersona` int UNIQUE,
  `idTipoPersonaFk` int,
  `dateReg` date,
  `idCiudadFk` int,
  `idDireccionFk` int
);

CREATE TABLE `tipo_persona` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50)
);

CREATE TABLE `cliente` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50),
  `apellido` varchar(50),
  `telefono` varchar(10),
  `email` varchar(50)
);

CREATE TABLE `programacion` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `idContratoFk` int,
  `idTurnoFk` int,
  `idEmpleadoFk` int
);

CREATE TABLE `direccion` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `tipo_via` varchar(50),
  `numero_principal` smallint,
  `letra_principal` char(2),
  `bis` char(10),
  `letra_secundaria` char(2),
  `cardinal_primario` char(10),
  `numero_secundario` smallint,
  `cardinal_secundario` char(10),
  `complemento` varchar(50),
  `idCiudadFk` int
);

CREATE TABLE `turno` (
  `id` int UNIQUE PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50),
  `horaInicio` time,
  `horaFinaliza` time
);

ALTER TABLE `userrol` ADD FOREIGN KEY (`idUsuarioFk`) REFERENCES `user` (`id`);

ALTER TABLE `userrol` ADD FOREIGN KEY (`idRolFk`) REFERENCES `rol` (`id`);

ALTER TABLE `empleado` ADD FOREIGN KEY (`idPuestoFk`) REFERENCES `puesto` (`id`);

ALTER TABLE `departamento` ADD FOREIGN KEY (`idPaisFk`) REFERENCES `pais` (`id`);

ALTER TABLE `ciudad` ADD FOREIGN KEY (`idDepartamentoFk`) REFERENCES `departamento` (`id`);

ALTER TABLE `contrato` ADD FOREIGN KEY (`idClienteFk`) REFERENCES `cliente` (`id`);

ALTER TABLE `contrato` ADD FOREIGN KEY (`idEmpleadoFk`) REFERENCES `empleado` (`id`);

ALTER TABLE `contrato` ADD FOREIGN KEY (`idEstadoFk`) REFERENCES `estado` (`id`);

ALTER TABLE `persona` ADD FOREIGN KEY (`idTipoPersonaFk`) REFERENCES `tipo_persona` (`id`);

ALTER TABLE `persona` ADD FOREIGN KEY (`idCiudadFk`) REFERENCES `ciudad` (`id`);

ALTER TABLE `persona` ADD FOREIGN KEY (`idDireccionFk`) REFERENCES `direccion` (`id`);

ALTER TABLE `programacion` ADD FOREIGN KEY (`idContratoFk`) REFERENCES `contrato` (`id`);

ALTER TABLE `programacion` ADD FOREIGN KEY (`idTurnoFk`) REFERENCES `turno` (`id`);

ALTER TABLE `programacion` ADD FOREIGN KEY (`idEmpleadoFk`) REFERENCES `empleado` (`id`);

ALTER TABLE `direccion` ADD FOREIGN KEY (`idCiudadFk`) REFERENCES `ciudad` (`id`);
