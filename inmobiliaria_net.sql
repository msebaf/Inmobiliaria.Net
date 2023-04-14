-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 14-04-2023 a las 06:16:15
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `inmobiliaria.net`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `Id` int(11) NOT NULL,
  `InmuebleId` int(11) NOT NULL,
  `InquilinoId` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFinal` datetime NOT NULL,
  `MontoMensual` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`Id`, `InmuebleId`, `InquilinoId`, `FechaInicio`, `FechaFinal`, `MontoMensual`) VALUES
(6, 4, 1, '2023-04-07 21:46:00', '2023-04-21 21:46:00', '3455'),
(7, 1, 1, '2023-04-08 21:47:00', '2023-04-11 21:47:00', '32423'),
(9, 1, 1, '2023-04-03 01:11:00', '2023-04-03 01:11:00', '213'),
(10, 1, 1, '2023-03-29 01:15:00', '2023-04-13 01:15:00', '56'),
(12, 1, 1, '2023-02-01 18:17:08', '2023-02-28 18:17:08', '1'),
(14, 4, 1, '2023-04-09 19:51:00', '2023-08-24 19:51:00', '345'),
(15, 4, 1, '2023-04-09 19:51:00', '2023-08-24 19:51:00', '345'),
(16, 1, 1, '2023-04-10 19:58:00', '2023-05-25 19:58:00', '234'),
(17, 1, 1, '2023-04-10 19:58:00', '2023-05-25 19:58:00', '234'),
(18, 1, 1, '2023-04-10 19:58:00', '2023-05-25 19:58:00', '234'),
(19, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(20, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(21, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(22, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(23, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(24, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(25, 1, 1, '2023-04-09 20:01:00', '2023-05-25 20:02:00', '3333'),
(26, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(27, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(28, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(29, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(30, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(31, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(32, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(33, 1, 1, '2023-04-10 20:10:00', '2023-05-26 20:10:00', '222'),
(34, 1, 1, '2023-04-09 20:16:00', '2023-05-26 20:16:00', '3333'),
(35, 1, 1, '2023-04-09 20:16:00', '2023-05-26 20:16:00', '3333'),
(36, 1, 1, '2023-04-09 20:16:00', '2023-05-26 20:16:00', '3333'),
(37, 4, 1, '2023-05-18 20:26:00', '2023-07-26 20:26:00', '99999999'),
(38, 1, 1, '2023-04-06 00:34:00', '2023-04-22 00:34:00', '21');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `Id` int(11) NOT NULL,
  `Direccion` varchar(200) NOT NULL,
  `Uso` int(11) NOT NULL,
  `Tipo` int(11) NOT NULL,
  `CantidadDeAmbientes` int(11) NOT NULL,
  `Latitud` decimal(11,0) NOT NULL,
  `Longitud` decimal(11,0) NOT NULL,
  `Superficie` decimal(11,0) NOT NULL,
  `Precio` decimal(11,0) NOT NULL,
  `PropietarioId` int(11) NOT NULL,
  `Disponible` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inmueble`
--

INSERT INTO `inmueble` (`Id`, `Direccion`, `Uso`, `Tipo`, `CantidadDeAmbientes`, `Latitud`, `Longitud`, `Superficie`, `Precio`, `PropietarioId`, `Disponible`) VALUES
(1, 'dfdsf', 1, 0, 3, '21', '2', '2324', '23', 1, 1),
(4, '23', 0, 3, 4, '2323', '4324', '3524', '4', 3, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `Id` int(11) NOT NULL,
  `Dni` varchar(45) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Direccion` varchar(45) NOT NULL,
  `Telefono` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Nacimiento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`Id`, `Dni`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `Email`, `Nacimiento`) VALUES
(1, '8345234', 'afddsafdsfs', 'fas', 'sdsa', '2321', 'dsf@sdf.com', '2023-03-01 16:33:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `Id` int(11) NOT NULL,
  `ContratoId` int(11) NOT NULL,
  `Monto` decimal(10,0) NOT NULL,
  `FechaPago` datetime DEFAULT NULL,
  `Periodo` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `pago`
--

INSERT INTO `pago` (`Id`, `ContratoId`, `Monto`, `FechaPago`, `Periodo`) VALUES
(1, 12, '23', '2023-04-09 19:14:23', '2023-04-10 00:14:23'),
(2, 6, '23', '2023-04-09 19:14:23', '2023-04-10 00:19:20'),
(3, 35, '3333', NULL, '2023-04-09 20:16:00'),
(4, 35, '3333', NULL, '2023-05-09 20:16:00'),
(5, 36, '3333', NULL, '2023-04-09 20:16:00'),
(6, 36, '3333', NULL, '2023-05-09 20:16:00'),
(8, 37, '99999999', '2023-04-13 01:48:04', '2023-06-18 20:26:00'),
(9, 37, '99999999', '2023-04-13 01:46:11', '2023-07-18 20:26:00'),
(10, 38, '21', NULL, '2023-04-06 00:34:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `Id` int(11) NOT NULL,
  `Dni` varchar(45) NOT NULL,
  `Nombre` varchar(45) NOT NULL,
  `Apellido` varchar(45) NOT NULL,
  `Direccion` varchar(45) NOT NULL,
  `Telefono` varchar(45) NOT NULL,
  `Email` varchar(45) NOT NULL,
  `Nacimiento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`Id`, `Dni`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `Email`, `Nacimiento`) VALUES
(1, '435346', 'paco', 'perez', 'sad23', '3214234', 'fdf', '2023-03-09 23:06:46'),
(3, '432', 'pepo', 'pog', 'dfs', '3242', 'fdwsfw', '2023-03-15 23:45:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo`
--

CREATE TABLE `tipo` (
  `Id` int(11) NOT NULL,
  `Tipo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipo`
--

INSERT INTO `tipo` (`Id`, `Tipo`) VALUES
(0, 'Casa'),
(1, 'Departamento'),
(2, 'Local'),
(3, 'Deposito');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `uso`
--

CREATE TABLE `uso` (
  `Id` int(11) NOT NULL,
  `Uso` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `uso`
--

INSERT INTO `uso` (`Id`, `Uso`) VALUES
(0, 'Residencial'),
(1, 'Comercial');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `InquilinoId` (`InquilinoId`),
  ADD KEY `InmuebleId` (`InmuebleId`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `PropietarioId` (`PropietarioId`),
  ADD KEY `Uso` (`Uso`),
  ADD KEY `Uso_2` (`Uso`),
  ADD KEY `Tipo` (`Tipo`),
  ADD KEY `PropietarioId_2` (`PropietarioId`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `pago`
--
ALTER TABLE `pago`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `ContratoId` (`ContratoId`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `tipo`
--
ALTER TABLE `tipo`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `uso`
--
ALTER TABLE `uso`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `tipo`
--
ALTER TABLE `tipo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `uso`
--
ALTER TABLE `uso`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_2` FOREIGN KEY (`InquilinoId`) REFERENCES `inquilino` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `contrato_ibfk_3` FOREIGN KEY (`InmuebleId`) REFERENCES `inmueble` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`ContratoId`) REFERENCES `contrato` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
