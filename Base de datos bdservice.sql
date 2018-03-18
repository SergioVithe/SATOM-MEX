/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.5.5-10.1.22-MariaDB : Database - bdservice
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bdservice` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bdservice`;

/*Table structure for table `tblcategoria` */

DROP TABLE IF EXISTS `tblcategoria`;

CREATE TABLE `tblcategoria` (
  `intIdCategoria` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchDescripcion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`intIdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `tblcategoria` */

insert  into `tblcategoria`(`intIdCategoria`,`vchNombre`,`vchDescripcion`) values (2,'Ungueto','Demasiada palabras para la boca'),(3,'Medicamento','Se usa para el mejoramiento '),(4,'Pastillas','Funcionales para la automedicaciónasd '),(9,'Cambio','Siempre al mando		'),(10,'Prueba','es un medicamento de la diabetes para el corazón'),(12,'prueba','descripcion pruebaasdasd');

/*Table structure for table `tblcliente` */

DROP TABLE IF EXISTS `tblcliente`;

CREATE TABLE `tblcliente` (
  `intIdCliente` int(11) NOT NULL AUTO_INCREMENT,
  `vchFechRegistro` datetime DEFAULT NULL,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchApellidos` varchar(240) DEFAULT NULL,
  `vchDomicilio` varchar(2409) DEFAULT NULL,
  `vchCorreo` varchar(100) DEFAULT NULL,
  `vchTelefono` varchar(20) DEFAULT NULL,
  `dteFechaNac` date DEFAULT NULL,
  `dbleIMC` double DEFAULT NULL,
  `intEstado` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdCliente`),
  KEY `relacionEstado_cliente` (`intEstado`),
  CONSTRAINT `relacionEstado_cliente` FOREIGN KEY (`intEstado`) REFERENCES `tblestado` (`intIdEstado`)
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=latin1;

/*Data for the table `tblcliente` */

insert  into `tblcliente`(`intIdCliente`,`vchFechRegistro`,`vchNombre`,`vchApellidos`,`vchDomicilio`,`vchCorreo`,`vchTelefono`,`dteFechaNac`,`dbleIMC`,`intEstado`) values (20,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',17.3,1),(21,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',17.5,1),(22,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',17.5,1),(23,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',17.5,1),(24,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',17.5,1),(25,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',18.8,1),(26,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',18.8,1),(27,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',18.8,1),(28,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',18.9,1),(29,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19,1),(30,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19,1),(31,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19.4,1),(32,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19.4,1),(33,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19.5,1),(34,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',19.5,1),(35,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',20.1,1),(36,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',20.4,1),(37,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',20.5,1),(38,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',20.5,1),(39,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',21,1),(40,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',21.4,1),(41,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',21.4,1),(42,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',22.8,1),(43,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',22.9,1),(44,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23,1),(45,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.4,1),(46,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.4,1),(47,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.7,1),(48,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.7,1),(49,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.7,1),(50,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',23.9,1),(51,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',24.2,1),(52,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',24.3,1),(53,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',24.7,1),(54,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',24.7,1),(55,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',25.4,1),(56,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',26.1,1),(57,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',26.2,1),(58,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',26.6,1),(59,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',27,1),(60,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',27.2,1),(61,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',28.8,1),(62,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',29.1,1),(63,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',30.1,1),(64,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',30.1,1),(65,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',31.1,1),(66,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',31.1,1),(67,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',31.2,1),(68,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',34.1,1),(69,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',34.2,1),(70,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',35.3,1),(71,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',35.6,1),(72,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',36.2,1),(73,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',36.6,1),(74,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',36.6,1),(75,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',40.8,1),(76,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',41.9,1),(77,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',42.2,1),(78,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',44.4,1),(79,'2018-03-12 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',47.1,1),(80,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',128,1),(81,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',136,1),(82,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',158,1),(83,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',136,1),(84,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',151,1),(85,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',154,1),(86,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',148,1),(87,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',116,1),(88,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',163,1),(89,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',135,1),(90,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',140,1),(91,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',130,1),(92,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',179,1),(93,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',132,1),(94,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',125,1),(95,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',122,1),(96,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',137,1),(97,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',141,1),(98,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',137,1),(99,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',132,1),(100,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',154,1),(101,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',146,1),(102,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',139,1),(103,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',145,1),(104,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',160,1),(105,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',135,1),(106,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',143,1),(107,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',129,1),(108,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',144,1),(109,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',156,1),(110,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',159,1),(111,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',162,1),(112,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',164,1),(113,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',150,1),(114,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',155,1),(115,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',167,1),(116,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',154,1),(117,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',175,1),(118,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',145,1),(119,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',138,1),(120,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',142,1),(121,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',146,1),(122,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',149,1),(123,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',170,1),(124,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',153,1),(125,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',144,1),(126,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',147,1),(127,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',128,1),(128,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',181,1),(129,'2018-03-17 00:00:00','Sergio','Hernández','Huextetitla','sergiovite250197@outlook.es','7711167127','1997-01-25',147,1);

/*Table structure for table `tbldepartamento` */

DROP TABLE IF EXISTS `tbldepartamento`;

CREATE TABLE `tbldepartamento` (
  `intIdDepartamento` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchNombreJefe` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`intIdDepartamento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbldepartamento` */

/*Table structure for table `tbldetalleproducto` */

DROP TABLE IF EXISTS `tbldetalleproducto`;

CREATE TABLE `tbldetalleproducto` (
  `intIdDetalle` int(11) NOT NULL AUTO_INCREMENT,
  `intIdProducto` int(11) DEFAULT NULL,
  `intIdFactura` int(11) DEFAULT NULL,
  `intCantidad` int(11) DEFAULT NULL,
  `dblePrecio` double DEFAULT NULL,
  PRIMARY KEY (`intIdDetalle`),
  KEY `relacion_Producto` (`intIdProducto`),
  KEY `relacion_Factura` (`intIdFactura`),
  CONSTRAINT `relacion_Factura` FOREIGN KEY (`intIdFactura`) REFERENCES `tblfactura` (`intIdFactura`),
  CONSTRAINT `relacion_Producto` FOREIGN KEY (`intIdProducto`) REFERENCES `tblproducto` (`intIdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbldetalleproducto` */

/*Table structure for table `tblempleado` */

DROP TABLE IF EXISTS `tblempleado`;

CREATE TABLE `tblempleado` (
  `intIdEmpleado` int(11) NOT NULL AUTO_INCREMENT,
  `dteFechaRegistro` datetime DEFAULT NULL,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchApellidos` varchar(200) DEFAULT NULL,
  `dteFechaNac` date DEFAULT NULL,
  `dbeSalario` double DEFAULT NULL,
  `intEstado` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdEmpleado`),
  KEY `relacion_EstadoEmpleado` (`intEstado`),
  CONSTRAINT `relacion_EstadoEmpleado` FOREIGN KEY (`intEstado`) REFERENCES `tblestado` (`intIdEstado`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Data for the table `tblempleado` */

insert  into `tblempleado`(`intIdEmpleado`,`dteFechaRegistro`,`vchNombre`,`vchApellidos`,`dteFechaNac`,`dbeSalario`,`intEstado`) values (2,'2018-02-18 00:00:00','Fabian','Santiago Hernández','1997-05-27',14000,1),(3,'2018-02-18 16:44:44','Martin','Meseño','2313-01-04',20000,1),(5,'2018-02-18 19:29:46','Gran Sayaman','Supermanholala','2018-02-08',9009,1),(7,'2018-02-23 11:58:13','Sergio','Hernández Vite','2018-02-24',999900,1),(10,'2018-02-23 13:34:27','Hola mundo','hernandez','2018-02-17',88.8,1),(11,'2018-02-24 12:37:13','prueba','prueba','2018-11-11',5000,2),(13,'2018-02-28 19:18:31','prueba 3','apell','2018-03-02',600,1);

/*Table structure for table `tblempledepa` */

DROP TABLE IF EXISTS `tblempledepa`;

CREATE TABLE `tblempledepa` (
  `intIdEmpleDepa` int(11) NOT NULL,
  `claveDepa` int(11) DEFAULT NULL,
  `claveEmpleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdEmpleDepa`),
  KEY `Relacionempleado` (`claveEmpleado`),
  KEY `realaciondepa` (`claveDepa`),
  CONSTRAINT `Relacionempleado` FOREIGN KEY (`claveEmpleado`) REFERENCES `tblempleado` (`intIdEmpleado`),
  CONSTRAINT `realaciondepa` FOREIGN KEY (`claveDepa`) REFERENCES `tbldepartamento` (`intIdDepartamento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tblempledepa` */

/*Table structure for table `tblestado` */

DROP TABLE IF EXISTS `tblestado`;

CREATE TABLE `tblestado` (
  `intIdEstado` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(50) DEFAULT NULL,
  `vchDescripcion` varchar(240) DEFAULT NULL,
  PRIMARY KEY (`intIdEstado`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tblestado` */

insert  into `tblestado`(`intIdEstado`,`vchNombre`,`vchDescripcion`) values (1,'Activo','El personal aún labora en la empresa'),(2,'Inactivo','El personal no se desempeña actualmene en la empresa');

/*Table structure for table `tblfactura` */

DROP TABLE IF EXISTS `tblfactura`;

CREATE TABLE `tblfactura` (
  `intIdFactura` int(11) NOT NULL AUTO_INCREMENT,
  `intIdCliente` int(11) DEFAULT NULL,
  `intIdModoPago` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdFactura`),
  KEY `relacion_Cliente` (`intIdCliente`),
  KEY `relacion_MododePago` (`intIdModoPago`),
  CONSTRAINT `relacion_Cliente` FOREIGN KEY (`intIdCliente`) REFERENCES `tblcliente` (`intIdCliente`),
  CONSTRAINT `relacion_MododePago` FOREIGN KEY (`intIdModoPago`) REFERENCES `tblmodopago` (`intIdModoPago`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tblfactura` */

/*Table structure for table `tbljefedepa` */

DROP TABLE IF EXISTS `tbljefedepa`;

CREATE TABLE `tbljefedepa` (
  `intIdJefeDepa` int(11) NOT NULL,
  `claveJefe` int(11) DEFAULT NULL,
  `claveDepa` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdJefeDepa`),
  KEY `relacionjefe` (`claveJefe`),
  KEY `relaciondepa` (`claveDepa`),
  CONSTRAINT `relaciondepa` FOREIGN KEY (`claveDepa`) REFERENCES `tbldepartamento` (`intIdDepartamento`),
  CONSTRAINT `relacionjefe` FOREIGN KEY (`claveJefe`) REFERENCES `tbljefedepartamento` (`intIdJefe`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tbljefedepa` */

/*Table structure for table `tbljefedepartamento` */

DROP TABLE IF EXISTS `tbljefedepartamento`;

CREATE TABLE `tbljefedepartamento` (
  `intIdJefe` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchApellidos` varchar(200) DEFAULT NULL,
  `dteFechaNac` date DEFAULT NULL,
  PRIMARY KEY (`intIdJefe`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `tbljefedepartamento` */

insert  into `tbljefedepartamento`(`intIdJefe`,`vchNombre`,`vchApellidos`,`dteFechaNac`) values (5,'Nombre','ape','2019-11-12'),(6,'Selena','Hernández Vite','2018-02-23');

/*Table structure for table `tblmodopago` */

DROP TABLE IF EXISTS `tblmodopago`;

CREATE TABLE `tblmodopago` (
  `intIdModoPago` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchOtroDetalle` varchar(240) DEFAULT NULL,
  PRIMARY KEY (`intIdModoPago`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `tblmodopago` */

insert  into `tblmodopago`(`intIdModoPago`,`vchNombre`,`vchOtroDetalle`) values (2,'Efectivo','Dinero en  efectivo'),(3,'Crédito','Crédito a meses con intereses del 16%'),(4,'Nuevo Registro','Nuevo registro');

/*Table structure for table `tblnivel` */

DROP TABLE IF EXISTS `tblnivel`;

CREATE TABLE `tblnivel` (
  `intIdNivel` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(50) DEFAULT NULL,
  `vchDescripcion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`intIdNivel`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tblnivel` */

insert  into `tblnivel`(`intIdNivel`,`vchNombre`,`vchDescripcion`) values (1,'Administrador','Control total'),(2,'Cliente','Control media');

/*Table structure for table `tblproducto` */

DROP TABLE IF EXISTS `tblproducto`;

CREATE TABLE `tblproducto` (
  `intIdProducto` int(11) NOT NULL AUTO_INCREMENT,
  `vchCodigo` varchar(20) DEFAULT NULL,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchDescripcion` varchar(240) DEFAULT NULL,
  `dblePrecio` double DEFAULT NULL,
  `intExistencia` int(11) DEFAULT NULL,
  `intIVA` int(11) DEFAULT '0',
  `intIdCategoria` int(11) DEFAULT NULL,
  `intIdProveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdProducto`),
  KEY `relacion_proveedor` (`intIdProveedor`),
  KEY `relacion_categoria` (`intIdCategoria`),
  CONSTRAINT `relacion_categoria` FOREIGN KEY (`intIdCategoria`) REFERENCES `tblcategoria` (`intIdCategoria`),
  CONSTRAINT `relacion_proveedor` FOREIGN KEY (`intIdProveedor`) REFERENCES `tblproveedor` (`intIdProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `tblproducto` */

insert  into `tblproducto`(`intIdProducto`,`vchCodigo`,`vchNombre`,`vchDescripcion`,`dblePrecio`,`intExistencia`,`intIVA`,`intIdCategoria`,`intIdProveedor`) values (1,'551018','Coca-Cola','Refresco Azucar',20.3,NULL,0,NULL,NULL);

/*Table structure for table `tblproveedor` */

DROP TABLE IF EXISTS `tblproveedor`;

CREATE TABLE `tblproveedor` (
  `intIdProveedor` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchUbicacion` varchar(200) DEFAULT NULL,
  `vchRFC` varchar(20) DEFAULT NULL,
  `vchCP` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`intIdProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `tblproveedor` */

insert  into `tblproveedor`(`intIdProveedor`,`vchNombre`,`vchUbicacion`,`vchRFC`,`vchCP`) values (1,'Coca-Cola','Huejutla de reyes Hidalgo bb','HTSAKSJ','43000'),(4,'SATOMMEX','HUEJUTLA DE REYES HIDALGO','HEVS970125HHGRTR01','43000'),(6,'Nuevo','Nuevo','Nuevo','Nuevo');

/*Table structure for table `tblsucursal` */

DROP TABLE IF EXISTS `tblsucursal`;

CREATE TABLE `tblsucursal` (
  `intIdSucursal` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) DEFAULT NULL,
  `vchRFC` varchar(50) DEFAULT NULL,
  `vchUbicacion` varchar(240) DEFAULT NULL,
  `vchGerente` varchar(200) DEFAULT NULL,
  `intIdCliente` int(11) DEFAULT NULL,
  `intIdDepartamento` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdSucursal`),
  KEY `relacion_departamento` (`intIdDepartamento`),
  KEY `relacion_Clientes` (`intIdCliente`),
  CONSTRAINT `relacion_Clientes` FOREIGN KEY (`intIdCliente`) REFERENCES `tblcliente` (`intIdCliente`),
  CONSTRAINT `relacion_departamento` FOREIGN KEY (`intIdDepartamento`) REFERENCES `tbldepartamento` (`intIdDepartamento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tblsucursal` */

/*Table structure for table `tblusuario` */

DROP TABLE IF EXISTS `tblusuario`;

CREATE TABLE `tblusuario` (
  `intIdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `vchNombre` varchar(100) NOT NULL,
  `vchContrasenia` varchar(60) NOT NULL,
  `intIdNivel` int(11) DEFAULT NULL,
  PRIMARY KEY (`intIdUsuario`),
  KEY `relacion_nivel` (`intIdNivel`),
  CONSTRAINT `relacion_nivel` FOREIGN KEY (`intIdNivel`) REFERENCES `tblnivel` (`intIdNivel`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tblusuario` */

insert  into `tblusuario`(`intIdUsuario`,`vchNombre`,`vchContrasenia`,`intIdNivel`) values (1,'admin','admin',1),(2,'cheko','cheko',2);

/* Procedure structure for procedure `SPDeleteCategoria` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteCategoria` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteCategoria`(in id int)
delete from tblcategoria where intIdCategoria=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPDeleteCliente` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteCliente` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteCliente`(in id int)
DELETE FROM tblcliente WHERE intIdCliente=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPDeleteEmpleado` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteEmpleado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteEmpleado`(in id int)
delete from tblEmpleado where intIdEmpleado=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPDeleteJefeDepartemento` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteJefeDepartemento` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteJefeDepartemento`(in id int)
DELETE FROM tbljefedepartamento WHERE intIdJefe=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPDeleteModoPago` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteModoPago` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteModoPago`(in id int)
DELETE FROM tblmodopago WHERE intIdModoPago=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPDeleteProveedor` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPDeleteProveedor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPDeleteProveedor`(in id int)
delete from tblproveedor where intIdProveedor=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertCategoria` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertCategoria` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertCategoria`(in nom varchar(100), in des varchar(100))
insert into tblCategoria (vchNombre,vchDescripcion) values (nom,des) */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertCliente` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertCliente` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertCliente`(in nom varchar(100), in ape varchar(100),in domi varchar(100),in corre varchar(100),in tel varchar(40),in dte varchar(100),in est int)
INSERT INTO tblcliente(vchNombre,vchApellidos, vchDomicilio,vchCorreo,vchTelefono,dteFechaNac,intEstado) VALUES (nom,ape,domi,corre,tel,dte,est) */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertEmpleado` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertEmpleado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertEmpleado`(in nom varchar(100),in ape varchar(100),in fech varchar(50),in sala double, in est int)
INSERT INTO tblempleado(dteFechaRegistro,vchNombre,vchApellidos,dteFechaNac,dbeSalario,intEstado) VALUES(now(),nom,ape,fech,sala,est) */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertJefeDepartamento` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertJefeDepartamento` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertJefeDepartamento`(in nom varchar(50),in ape varchar(100), in fech varchar(40))
INSERT INTO tbljefedepartamento(vchNombre,vchApellidos,dteFechaNac) VALUES(nom,ape,fech) */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertModoPago` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertModoPago` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertModoPago`(in nom varchar(100),in des varchar(240))
INSERT INTO tblmodopago( vchNombre,vchOtroDetalle) VALUES(nom,des) */$$
DELIMITER ;

/* Procedure structure for procedure `SPInsertProveedor` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPInsertProveedor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPInsertProveedor`(in nom varchar(100), in ubi varchar(100),in rfc varchar(30),in cp varchar(20))
INSERT INTO tblproveedor(vchNombre,vchUbicacion,vchRFC,vchCP) VALUES (nom,ubi,rfc,cp) */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchCategoria` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchCategoria` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchCategoria`(in var varchar(100))
select * from tblcategoria where vchNombre like var */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchCliente` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchCliente` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchCliente`(in busc varchar(20))
SELECT * FROM tblcliente where vchNombre like busc */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchEmpleado` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchEmpleado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchEmpleado`(IN var VARCHAR(100))
SELECT * FROM tblempleado WHERE vchNombre like var */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchJefeDepartamento` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchJefeDepartamento` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchJefeDepartamento`(in busc varchar(50))
SELECT * FROM tbljefedepartamento WHERE vchNombre LIKE busc */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchModoPago` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchModoPago` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchModoPago`(in buscar varchar(100))
select * from tblmodopago where vchNombre like buscar */$$
DELIMITER ;

/* Procedure structure for procedure `SPSearchProveedor` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPSearchProveedor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPSearchProveedor`(in nom varchar(100))
select * from tblproveedor  where vchNombre like nom */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateCategoria` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateCategoria` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateCategoria`(in nom varchar(100), in des varchar(100),in id int)
update tblcategoria set vchNombre=nom,vchDescripcion=des where intIdCategoria=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateCliente` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateCliente` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateCliente`(IN nom VARCHAR(100), IN ape VARCHAR(100),IN domi VARCHAR(100),IN corre VARCHAR(100),IN tel VARCHAR(40),IN dte VARCHAR(100),IN est INT, in id int)
UPDATE tblcliente SET vchNombre=nom, vchApellidos=ape,vchDomicilio=domi,vchCorreo=Corre,vchTelefono=tel,dteFechaNac=dte, intEstado=est WHERE intIdCliente=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateEmpleado` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateEmpleado` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateEmpleado`(in nom varchar(100),in ape varchar(100),in fech varchar(60),in sala double,in est int,in id int)
UPDATE tblEmpleado set vchNombre=nom,vchApellidos=ape, dteFechaNac=fech,dbeSalario=sala,intEstado=est where intIdEmpleado=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateJefeDepartamento` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateJefeDepartamento` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateJefeDepartamento`(in nom varchar(100),in ape varchar(100), in fech varchar(100),in id int)
UPDATE tbljefedepartamento SET vchNombre=nom,vchApellidos=ape,dteFechaNac=fech WHERE intIdJefe=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateModoPago` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateModoPago` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateModoPago`(IN nom VARCHAR(100),IN des VARCHAR(240), in id int)
UPDATE tblmodopago SET vchNombre=nom, vchOtroDetalle=des WHERE intIdModoPago=id */$$
DELIMITER ;

/* Procedure structure for procedure `SPUpdateProveedor` */

/*!50003 DROP PROCEDURE IF EXISTS  `SPUpdateProveedor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SPUpdateProveedor`(IN nom VARCHAR(100), IN ubi VARCHAR(100),IN rfc VARCHAR(30),IN cp VARCHAR(20), in id int)
UPDATE tblproveedor SET vchNombre=nom,vchUbicacion=ubi,vchRFC=rfc,vchCP=cp WHERE intIdProveedor=id */$$
DELIMITER ;

/*Table structure for table `vwcategoria` */

DROP TABLE IF EXISTS `vwcategoria`;

/*!50001 DROP VIEW IF EXISTS `vwcategoria` */;
/*!50001 DROP TABLE IF EXISTS `vwcategoria` */;

/*!50001 CREATE TABLE  `vwcategoria`(
 `intIdCategoria` int(11) ,
 `vchNombre` varchar(100) ,
 `vchDescripcion` varchar(200) 
)*/;

/*Table structure for table `vwcliente` */

DROP TABLE IF EXISTS `vwcliente`;

/*!50001 DROP VIEW IF EXISTS `vwcliente` */;
/*!50001 DROP TABLE IF EXISTS `vwcliente` */;

/*!50001 CREATE TABLE  `vwcliente`(
 `intIdCliente` int(11) ,
 `vchNombre` varchar(100) ,
 `vchApellidos` varchar(240) ,
 `vchDomicilio` varchar(2409) ,
 `vchCorreo` varchar(100) ,
 `vchTelefono` varchar(20) ,
 `dteFechaNac` date ,
 `intEstado` int(11) 
)*/;

/*Table structure for table `vwempleados` */

DROP TABLE IF EXISTS `vwempleados`;

/*!50001 DROP VIEW IF EXISTS `vwempleados` */;
/*!50001 DROP TABLE IF EXISTS `vwempleados` */;

/*!50001 CREATE TABLE  `vwempleados`(
 `intIdEmpleado` int(11) ,
 `dteFechaRegistro` datetime ,
 `vchNombre` varchar(100) ,
 `vchApellidos` varchar(200) ,
 `dteFechaNac` date ,
 `dbeSalario` double ,
 `intEstado` int(11) 
)*/;

/*Table structure for table `vwjefedepa` */

DROP TABLE IF EXISTS `vwjefedepa`;

/*!50001 DROP VIEW IF EXISTS `vwjefedepa` */;
/*!50001 DROP TABLE IF EXISTS `vwjefedepa` */;

/*!50001 CREATE TABLE  `vwjefedepa`(
 `intIdJefe` int(11) ,
 `vchNombre` varchar(100) ,
 `vchApellidos` varchar(200) ,
 `dteFechaNac` date 
)*/;

/*Table structure for table `vwmodopago` */

DROP TABLE IF EXISTS `vwmodopago`;

/*!50001 DROP VIEW IF EXISTS `vwmodopago` */;
/*!50001 DROP TABLE IF EXISTS `vwmodopago` */;

/*!50001 CREATE TABLE  `vwmodopago`(
 `intIdModoPago` int(11) ,
 `vchNombre` varchar(100) ,
 `vchOtroDetalle` varchar(240) 
)*/;

/*Table structure for table `vwproveedor` */

DROP TABLE IF EXISTS `vwproveedor`;

/*!50001 DROP VIEW IF EXISTS `vwproveedor` */;
/*!50001 DROP TABLE IF EXISTS `vwproveedor` */;

/*!50001 CREATE TABLE  `vwproveedor`(
 `intIdProveedor` int(11) ,
 `vchNombre` varchar(100) ,
 `vchUbicacion` varchar(200) ,
 `vchRFC` varchar(20) ,
 `vchCP` varchar(10) 
)*/;

/*View structure for view vwcategoria */

/*!50001 DROP TABLE IF EXISTS `vwcategoria` */;
/*!50001 DROP VIEW IF EXISTS `vwcategoria` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwcategoria` AS select `tblcategoria`.`intIdCategoria` AS `intIdCategoria`,`tblcategoria`.`vchNombre` AS `vchNombre`,`tblcategoria`.`vchDescripcion` AS `vchDescripcion` from `tblcategoria` */;

/*View structure for view vwcliente */

/*!50001 DROP TABLE IF EXISTS `vwcliente` */;
/*!50001 DROP VIEW IF EXISTS `vwcliente` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwcliente` AS select `tblcliente`.`intIdCliente` AS `intIdCliente`,`tblcliente`.`vchNombre` AS `vchNombre`,`tblcliente`.`vchApellidos` AS `vchApellidos`,`tblcliente`.`vchDomicilio` AS `vchDomicilio`,`tblcliente`.`vchCorreo` AS `vchCorreo`,`tblcliente`.`vchTelefono` AS `vchTelefono`,`tblcliente`.`dteFechaNac` AS `dteFechaNac`,`tblcliente`.`intEstado` AS `intEstado` from `tblcliente` */;

/*View structure for view vwempleados */

/*!50001 DROP TABLE IF EXISTS `vwempleados` */;
/*!50001 DROP VIEW IF EXISTS `vwempleados` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwempleados` AS select `tblempleado`.`intIdEmpleado` AS `intIdEmpleado`,`tblempleado`.`dteFechaRegistro` AS `dteFechaRegistro`,`tblempleado`.`vchNombre` AS `vchNombre`,`tblempleado`.`vchApellidos` AS `vchApellidos`,`tblempleado`.`dteFechaNac` AS `dteFechaNac`,`tblempleado`.`dbeSalario` AS `dbeSalario`,`tblempleado`.`intEstado` AS `intEstado` from `tblempleado` */;

/*View structure for view vwjefedepa */

/*!50001 DROP TABLE IF EXISTS `vwjefedepa` */;
/*!50001 DROP VIEW IF EXISTS `vwjefedepa` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwjefedepa` AS select `tbljefedepartamento`.`intIdJefe` AS `intIdJefe`,`tbljefedepartamento`.`vchNombre` AS `vchNombre`,`tbljefedepartamento`.`vchApellidos` AS `vchApellidos`,`tbljefedepartamento`.`dteFechaNac` AS `dteFechaNac` from `tbljefedepartamento` */;

/*View structure for view vwmodopago */

/*!50001 DROP TABLE IF EXISTS `vwmodopago` */;
/*!50001 DROP VIEW IF EXISTS `vwmodopago` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwmodopago` AS select `tblmodopago`.`intIdModoPago` AS `intIdModoPago`,`tblmodopago`.`vchNombre` AS `vchNombre`,`tblmodopago`.`vchOtroDetalle` AS `vchOtroDetalle` from `tblmodopago` */;

/*View structure for view vwproveedor */

/*!50001 DROP TABLE IF EXISTS `vwproveedor` */;
/*!50001 DROP VIEW IF EXISTS `vwproveedor` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwproveedor` AS select `tblproveedor`.`intIdProveedor` AS `intIdProveedor`,`tblproveedor`.`vchNombre` AS `vchNombre`,`tblproveedor`.`vchUbicacion` AS `vchUbicacion`,`tblproveedor`.`vchRFC` AS `vchRFC`,`tblproveedor`.`vchCP` AS `vchCP` from `tblproveedor` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
