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
-- Table structure for table `tblgrupo`
--

DROP TABLE IF EXISTS `tblgrupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblgrupo` (
  `id_grupo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) NOT NULL,
  `sigla` varchar(10) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `texto_descricao` text,
  `logotipo` varchar(100) DEFAULT NULL,
  `lattes` varchar(100) DEFAULT NULL,
  `data_inicio` date DEFAULT NULL,
  `fk_situacao` int(11) NOT NULL,
  PRIMARY KEY (`id_grupo`),
  KEY `fk_situacao` (`fk_situacao`),
  CONSTRAINT `tblgrupo_ibfk_1` FOREIGN KEY (`fk_situacao`) REFERENCES `tblsituacao` (`id_situacao`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblgrupo_lider`
--

DROP TABLE IF EXISTS `tblgrupo_lider`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblgrupo_lider` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_grupo` int(11) DEFAULT NULL,
  `fk_lider` varchar(15) DEFAULT NULL,
  `data_entrada` date NOT NULL,
  `data_saida` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_grupo` (`fk_grupo`),
  KEY `fk_lider` (`fk_lider`),
  CONSTRAINT `tblgrupo_lider_ibfk_1` FOREIGN KEY (`fk_grupo`) REFERENCES `tblgrupo` (`id_grupo`),
  CONSTRAINT `tblgrupo_lider_ibfk_2` FOREIGN KEY (`fk_lider`) REFERENCES `tblusuario` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblpermissao`
--

DROP TABLE IF EXISTS `tblpermissao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblpermissao` (
  `id_permissao` int(11) NOT NULL AUTO_INCREMENT,
  `permissao` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id_permissao`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblpermissao_tipo_usuario`
--

DROP TABLE IF EXISTS `tblpermissao_tipo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblpermissao_tipo_usuario` (
  `fk_permissao` int(11) NOT NULL,
  `fk_tipo` int(11) NOT NULL,
  PRIMARY KEY (`fk_permissao`,`fk_tipo`),
  KEY `fk_tipo` (`fk_tipo`),
  CONSTRAINT `tblpermissao_tipo_usuario_ibfk_1` FOREIGN KEY (`fk_permissao`) REFERENCES `tblpermissao` (`id_permissao`),
  CONSTRAINT `tblpermissao_tipo_usuario_ibfk_2` FOREIGN KEY (`fk_tipo`) REFERENCES `tbltipo_usuario` (`id_tipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblrecuperacao_senha`
--

DROP TABLE IF EXISTS `tblrecuperacao_senha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrecuperacao_senha` (
  `id_recuperacao` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_recuperacao` varchar(68) NOT NULL,
  `ativo` char(1) NOT NULL,
  PRIMARY KEY (`id_recuperacao`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblrecuperacao_senha_usuario`
--

DROP TABLE IF EXISTS `tblrecuperacao_senha_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrecuperacao_senha_usuario` (
  `fk_recuperacao` int(11) NOT NULL,
  `fk_usuario` varchar(15) NOT NULL,
  `data_hora_alteracao` datetime NOT NULL,
  PRIMARY KEY (`fk_recuperacao`,`fk_usuario`),
  KEY `fk_usuario` (`fk_usuario`),
  CONSTRAINT `tblrecuperacao_senha_usuario_ibfk_1` FOREIGN KEY (`fk_recuperacao`) REFERENCES `tblrecuperacao_senha` (`id_recuperacao`),
  CONSTRAINT `tblrecuperacao_senha_usuario_ibfk_2` FOREIGN KEY (`fk_usuario`) REFERENCES `tblusuario` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblsituacao`
--

DROP TABLE IF EXISTS `tblsituacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblsituacao` (
  `id_situacao` int(11) NOT NULL AUTO_INCREMENT,
  `situacao` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_situacao`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsituacao`
--

LOCK TABLES `tblsituacao` WRITE;
/*!40000 ALTER TABLE `tblsituacao` DISABLE KEYS */;
INSERT INTO `tblsituacao` VALUES (1,'Ativo'),(2,'Inativo'),(3,'Aguardando Lider');
/*!40000 ALTER TABLE `tblsituacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblstatus_usuario`
--

DROP TABLE IF EXISTS `tblstatus_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblstatus_usuario` (
  `id_status` int(11) NOT NULL AUTO_INCREMENT,
  `status` varchar(15) NOT NULL,
  PRIMARY KEY (`id_status`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblstatus_usuario`
--

LOCK TABLES `tblstatus_usuario` WRITE;
/*!40000 ALTER TABLE `tblstatus_usuario` DISABLE KEYS */;
INSERT INTO `tblstatus_usuario` VALUES (1,'Ativo'),(2,'Bloqueado'),(3,'Desativado');
/*!40000 ALTER TABLE `tblstatus_usuario` ENABLE KEYS */;
UNLOCK TABLES;

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
  `senha` varchar(68) NOT NULL,
  `email` varchar(50) NOT NULL,
  `data_cadastro` date NOT NULL,
  `fk_tipo` int(11) DEFAULT NULL,
  `fk_status` int(11) DEFAULT NULL,
  `lattes` varchar(70) DEFAULT NULL,
  `primeiro_acesso` char(1) DEFAULT NULL,
  `imagem` varchar(120) DEFAULT NULL,
  PRIMARY KEY (`login`),
  KEY `fk_tipo` (`fk_tipo`),
  KEY `fk_status` (`fk_status`),
  CONSTRAINT `tblusuario_ibfk_1` FOREIGN KEY (`fk_tipo`) REFERENCES `tbltipo_usuario` (`id_tipo`),
  CONSTRAINT `tblusuario_ibfk_2` FOREIGN KEY (`fk_status`) REFERENCES `tblstatus_usuario` (`id_status`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-30 21:06:25
