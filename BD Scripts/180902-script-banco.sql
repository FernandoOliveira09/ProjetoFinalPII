CREATE DATABASE  IF NOT EXISTS `sg_manager` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `sg_manager`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: sg_manager
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tbltipo_usuario`
--

DROP TABLE IF EXISTS `tbltipo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbltipo_usuario` (
  `id_tipo` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(15) NOT NULL,
  PRIMARY KEY (`id_tipo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltipo_usuario`
--

LOCK TABLES `tbltipo_usuario` WRITE;
/*!40000 ALTER TABLE `tbltipo_usuario` DISABLE KEYS */;
INSERT INTO `tbltipo_usuario` VALUES (1,'Administrador'),(2,'Lider');
/*!40000 ALTER TABLE `tbltipo_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblusuario`
--

DROP TABLE IF EXISTS `tblusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblusuario` (
  `login` varchar(15) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `senha` varchar(65) NOT NULL,
  `email` varchar(30) NOT NULL,
  `data_cadastro` date NOT NULL,
  `fk_tipo` int(11) DEFAULT NULL,
  PRIMARY KEY (`login`),
  KEY `fk_tipo` (`fk_tipo`),
  CONSTRAINT `tblusuario_ibfk_1` FOREIGN KEY (`fk_tipo`) REFERENCES `tbltipo_usuario` (`id_tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblusuario`
--

LOCK TABLES `tblusuario` WRITE;
/*!40000 ALTER TABLE `tblusuario` DISABLE KEYS */;
INSERT INTO `tblusuario` VALUES ('BA1500110','Natalia','tR3$gD','fernando@gmail.com','2018-09-02',2),('BA1500111','Teste','!4pZhP','teste@gmail.com','2018-09-02',1),('BA1500112','ee','5qRcNc','gg@gmail.com','2018-09-02',2),('BA1690150','Reginaldo','111111','reginaldo@gmail.com','2018-09-02',2),('BA888888','Bilbo','143e04bf33967a57609a991fa9ed8121a4fd9107d76769d142b4db0b2a57691c','bilbo@gmail.com','2018-09-02',1),('FernandoO','Fernando Oliveira','663b21d377e8b49e0235a1acaf175c6702580b0466782de62c94c398435fc32e','fernando@gmail.com','2018-09-02',1);
/*!40000 ALTER TABLE `tblusuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-02 21:59:36
