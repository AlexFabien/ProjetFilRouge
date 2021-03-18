-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: quiz
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `acteur`
--

DROP TABLE IF EXISTS `acteur`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acteur` (
  `id_acteur` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) DEFAULT NULL,
  `prenom` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `id_role` int DEFAULT NULL,
  PRIMARY KEY (`id_acteur`),
  KEY `fk_Utilisateur_Role1_idx` (`id_role`),
  CONSTRAINT `fk_Utilisateur_Role1` FOREIGN KEY (`id_role`) REFERENCES `role` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acteur`
--

LOCK TABLES `acteur` WRITE;
/*!40000 ALTER TABLE `acteur` DISABLE KEYS */;
INSERT INTO `acteur` VALUES (1,'admin','admin','admin@quiz.fr','Admin123',2),(2,'Recruteur','recruteur','recruteur@quiz.fr','Rec123456',1),(3,'ALEXANDRE','Fabien','fabien@quiz.fr','Ib123456',3),(4,'HARISON','Rin','rin@quiz.fr','azerty',3),(5,'alex','ooo','ppp@ib.fr',NULL,3),(6,'recruteur','recrutement','recrut1@ib.fr','Recrut123456',1),(7,'CNous','Coucou','coucou@ib.fr',NULL,3),(8,'Mehdi','Linda','lll@ib.fr',NULL,3),(9,'Titi','Toto','toto@ib.fr',NULL,3),(10,'Demoulin','Segolene','segolene@ib.fr',NULL,3),(11,'Coro','Antoine','a.coro@ib.fr',NULL,3);
/*!40000 ALTER TABLE `acteur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acteur_has_question`
--

DROP TABLE IF EXISTS `acteur_has_question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acteur_has_question` (
  `id_acteur` int NOT NULL,
  `id_question` int NOT NULL,
  `commentaire` text,
  `id_etat_reponse` int DEFAULT NULL,
  PRIMARY KEY (`id_acteur`,`id_question`),
  KEY `fk_utilisateur_has_question_question1_idx` (`id_question`),
  KEY `fk_utilisateur_has_question_utilisateur1_idx` (`id_acteur`),
  KEY `fk_utilisateur_has_question_repondu1_idx` (`id_etat_reponse`),
  CONSTRAINT `fk_utilisateur_has_question_question1` FOREIGN KEY (`id_question`) REFERENCES `question` (`id_question`),
  CONSTRAINT `fk_utilisateur_has_question_repondu1` FOREIGN KEY (`id_etat_reponse`) REFERENCES `repondu` (`id_etat_reponse`),
  CONSTRAINT `fk_utilisateur_has_question_utilisateur1` FOREIGN KEY (`id_acteur`) REFERENCES `acteur` (`id_acteur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acteur_has_question`
--

LOCK TABLES `acteur_has_question` WRITE;
/*!40000 ALTER TABLE `acteur_has_question` DISABLE KEYS */;
INSERT INTO `acteur_has_question` VALUES (3,199,NULL,1),(3,200,NULL,1),(3,201,NULL,2),(4,199,NULL,1),(4,200,NULL,1),(4,201,NULL,1),(7,199,NULL,1),(7,200,NULL,1),(7,201,NULL,1),(8,199,NULL,2),(8,200,NULL,1),(8,201,NULL,1),(11,193,NULL,1);
/*!40000 ALTER TABLE `acteur_has_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acteur_has_quiz`
--

DROP TABLE IF EXISTS `acteur_has_quiz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `acteur_has_quiz` (
  `id_acteur` int NOT NULL,
  `id_quiz` int NOT NULL,
  PRIMARY KEY (`id_acteur`,`id_quiz`),
  KEY `fk_Utilisateur_has_Quiz_Quiz1_idx` (`id_quiz`),
  KEY `fk_Utilisateur_has_Quiz_Utilisateur1_idx` (`id_acteur`),
  CONSTRAINT `fk_Utilisateur_has_Quiz_Quiz1` FOREIGN KEY (`id_quiz`) REFERENCES `quiz` (`id_quiz`),
  CONSTRAINT `fk_Utilisateur_has_Quiz_Utilisateur1` FOREIGN KEY (`id_acteur`) REFERENCES `acteur` (`id_acteur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acteur_has_quiz`
--

LOCK TABLES `acteur_has_quiz` WRITE;
/*!40000 ALTER TABLE `acteur_has_quiz` DISABLE KEYS */;
INSERT INTO `acteur_has_quiz` VALUES (2,1),(3,1),(4,1),(3,2),(4,2),(1,3),(2,3),(3,3),(4,3),(1,4),(1,5),(2,5),(3,5),(4,5),(1,6),(1,7),(1,8),(1,9),(1,13),(1,15),(1,16),(1,19),(1,20),(1,21),(1,22),(1,23),(1,24),(1,25),(1,26),(1,27),(1,28),(1,29),(1,30),(1,31),(3,31),(4,31),(7,31),(8,31),(9,31),(1,32),(1,33),(1,34),(3,34),(1,35),(11,35);
/*!40000 ALTER TABLE `acteur_has_quiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `niveau`
--

DROP TABLE IF EXISTS `niveau`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `niveau` (
  `id_niveau` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_niveau`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `niveau`
--

LOCK TABLES `niveau` WRITE;
/*!40000 ALTER TABLE `niveau` DISABLE KEYS */;
INSERT INTO `niveau` VALUES (1,'Junior'),(2,'Confirmé'),(3,'Expérimenté');
/*!40000 ALTER TABLE `niveau` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parametrage`
--

DROP TABLE IF EXISTS `parametrage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `parametrage` (
  `id_parametrage` int NOT NULL,
  `valeur` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id_parametrage`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parametrage`
--

LOCK TABLES `parametrage` WRITE;
/*!40000 ALTER TABLE `parametrage` DISABLE KEYS */;
INSERT INTO `parametrage` VALUES (1,'40');
/*!40000 ALTER TABLE `parametrage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `question`
--

DROP TABLE IF EXISTS `question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `question` (
  `id_question` int NOT NULL AUTO_INCREMENT,
  `libelle` text,
  `explication_reponse` text,
  `id_niveau` int DEFAULT NULL,
  `id_type_question` int DEFAULT NULL,
  `id_quiz` int DEFAULT NULL,
  `id_technologie` int DEFAULT NULL,
  `numero` int DEFAULT NULL,
  PRIMARY KEY (`id_question`),
  KEY `fk_Questions_Niveau1_idx` (`id_niveau`),
  KEY `fk_Questions_TypeQuestion1_idx` (`id_type_question`),
  KEY `fk_question_quiz1_idx` (`id_quiz`),
  KEY `fk_question_technologie1_idx` (`id_technologie`),
  CONSTRAINT `fk_question_quiz1` FOREIGN KEY (`id_quiz`) REFERENCES `quiz` (`id_quiz`),
  CONSTRAINT `fk_question_technologie1` FOREIGN KEY (`id_technologie`) REFERENCES `technologie` (`id_technologie`),
  CONSTRAINT `fk_Questions_Niveau1` FOREIGN KEY (`id_niveau`) REFERENCES `niveau` (`id_niveau`),
  CONSTRAINT `fk_Questions_TypeQuestion1` FOREIGN KEY (`id_type_question`) REFERENCES `type_question` (`id_type_question`)
) ENGINE=InnoDB AUTO_INCREMENT=206 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` VALUES (1,'libelle : Niveau 1','explication',1,1,5,1,NULL),(2,'libelle : Niveau 1','explication',1,1,5,1,NULL),(3,'libelle : Niveau 1','explication',1,1,9,1,NULL),(4,'libelle : Niveau 1','explication',1,1,13,1,NULL),(5,'libelle : Niveau 1','explication',1,1,15,1,NULL),(6,'libelle : Niveau 1','explication',1,1,15,1,NULL),(7,'libelle : Niveau 1','explication',1,1,32,1,1),(8,'libelle : Niveau 1','explication',1,1,33,1,1),(9,'libelle : Niveau 1','explication',1,1,34,1,1),(10,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(11,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(12,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(13,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(14,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(15,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(16,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(17,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(18,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(19,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(20,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(21,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(22,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(23,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(24,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(25,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(26,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(27,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(28,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(29,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(30,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(31,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(32,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(33,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(34,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(35,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(36,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(37,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(38,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(39,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(40,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(41,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(42,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(43,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(44,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(45,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(46,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(47,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(48,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(49,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(50,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(51,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(52,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(53,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(54,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(55,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(56,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(57,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(59,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(60,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(61,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(62,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(63,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(64,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(65,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(66,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(67,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(68,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(69,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(70,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(71,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(72,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(73,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(74,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(75,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(76,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(77,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(78,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(79,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(80,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(81,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(82,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(83,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(84,'libelle : Niveau 1','techno 1',3,1,3,1,NULL),(85,'libelle : Niveau 1','techno 1',3,1,4,1,NULL),(86,'libelle : Niveau 1','techno 1',3,1,5,1,NULL),(87,'libelle : Niveau 1','techno 1',3,1,6,1,NULL),(88,'libelle : Niveau 1','techno 1',3,1,7,1,NULL),(89,'libelle : Niveau 1','techno 1',3,1,8,1,NULL),(90,'libelle : Niveau 1','techno 1',3,1,9,1,NULL),(91,'libelle : Niveau 1','techno 1',3,1,13,1,NULL),(92,'libelle : Niveau 1','techno 1',3,1,15,1,NULL),(93,'libelle : Niveau 1','techno 1',3,1,16,1,2),(94,'libelle : Niveau 1','techno 1',3,1,16,1,3),(95,'libelle : Niveau 1','techno 1',3,1,19,1,1),(96,'libelle : Niveau 1','techno 1',3,1,20,1,1),(97,'libelle : Niveau 1','techno 1',3,1,21,1,1),(98,'libelle : Niveau 1','techno 1',3,1,22,1,1),(99,'libelle : Niveau 1','techno 1',3,1,23,1,1),(100,'libelle : Niveau 1','techno 1',3,1,24,1,1),(101,'libelle : Niveau 1','techno 1',3,1,25,1,1),(102,'libelle : Niveau 1','techno 1',3,1,26,1,1),(103,'libelle : Niveau 1','techno 1',3,1,27,1,1),(104,'libelle : Niveau 1','techno 1',3,1,28,1,1),(105,'libelle : Niveau 1','techno 1',3,1,29,1,1),(106,'libelle : Niveau 1','techno 1',3,1,30,1,1),(107,'libelle : Niveau 1','techno 1',3,1,32,1,2),(108,'libelle : Niveau 1','techno 1',3,1,33,1,2),(109,'libelle : Niveau 1','techno 1',3,1,34,1,2),(110,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(111,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(112,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(113,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(114,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(115,'libelle : Niveau 2','techno 1',2,1,16,1,1),(116,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(117,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(118,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(119,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(120,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(121,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(122,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(123,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(124,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(125,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(126,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(127,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(128,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(129,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(130,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(131,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(132,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(133,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(134,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(135,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(136,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(137,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(138,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(139,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(140,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(141,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(142,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(143,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(144,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(145,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(146,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(147,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(148,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(149,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(150,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(151,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(152,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(153,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(154,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(155,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(156,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(157,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(158,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(159,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(160,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(161,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(162,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(163,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(164,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(165,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(166,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(167,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(177,'string','string',1,1,NULL,1,0),(178,'string','string',1,1,NULL,1,NULL),(179,'string','string',1,1,NULL,1,NULL),(180,'string','string',1,1,NULL,1,NULL),(181,'string','string',1,1,NULL,1,NULL),(182,'string','string',1,1,NULL,1,NULL),(183,'string','string',1,1,NULL,1,NULL),(184,'string','string',1,1,NULL,1,NULL),(185,'string','string',1,1,NULL,1,NULL),(186,'string','string',1,1,NULL,1,NULL),(187,'string','string',1,1,NULL,1,NULL),(188,'string','string',1,1,NULL,1,NULL),(189,'string','string',1,1,NULL,1,NULL),(191,'aa','aa',1,1,NULL,1,NULL),(192,'zzz','zz',1,1,NULL,1,NULL),(193,'Une question depuis le front','Question pas facile ;)',3,1,35,4,1),(195,'eee','eee',1,1,NULL,1,NULL),(196,'','',NULL,NULL,NULL,NULL,NULL),(197,'','',NULL,NULL,NULL,NULL,NULL),(198,'une petite question ppp','sans explication pppp',3,2,NULL,1,NULL),(199,'Question Python','ss',1,1,31,3,2),(200,'question Python','99',2,2,31,3,3),(201,'python 3','33',3,2,31,3,1),(202,'ooo','ooo',1,1,NULL,1,NULL),(203,'aaaa','aaaa',1,1,NULL,1,NULL),(204,'Question suivante','pourquoi pas',1,2,NULL,1,NULL),(205,'aa','aaa',1,1,NULL,4,NULL);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quiz`
--

DROP TABLE IF EXISTS `quiz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quiz` (
  `id_quiz` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(150) DEFAULT NULL,
  `id_technologie` int DEFAULT NULL,
  `id_niveau` int DEFAULT NULL,
  PRIMARY KEY (`id_quiz`),
  KEY `fk_Quiz_Niveau1_idx` (`id_niveau`),
  KEY `fk_Quiz_technologie1_idx` (`id_technologie`),
  CONSTRAINT `fk_Quiz_Niveau1` FOREIGN KEY (`id_niveau`) REFERENCES `niveau` (`id_niveau`),
  CONSTRAINT `fk_Quiz_technologie1` FOREIGN KEY (`id_technologie`) REFERENCES `technologie` (`id_technologie`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quiz`
--

LOCK TABLES `quiz` WRITE;
/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;
INSERT INTO `quiz` VALUES (1,NULL,1,1),(2,NULL,1,1),(3,NULL,1,1),(4,'Mon quiz',1,1),(5,'Mon quiz',1,1),(6,'string',1,1),(7,'string',1,1),(8,'string',1,1),(9,'string',1,1),(10,'Mon quiz',1,1),(11,'Mon quiz',1,1),(12,'Mon quiz',1,1),(13,'Mon quiz',1,1),(14,'string',1,1),(15,'Mon nouveau quiz',1,1),(16,'Mon quiz',1,2),(17,NULL,NULL,NULL),(18,NULL,NULL,NULL),(19,'Mon quiz',1,1),(20,'Mon quiz',1,1),(21,'Mon quiz',1,1),(22,'Mon quiz',1,1),(23,'Mon quiz',1,1),(24,'a',1,1),(25,'aa',1,1),(26,'aaaa',1,1),(27,'qqq',1,1),(28,'aaa',1,2),(29,'aaa',1,3),(30,'quiz Python',1,1),(31,'quiz python',3,1),(32,'ppp',1,1),(33,'toto',1,1),(34,'un quiz de test',1,1),(35,'quiz antoine',4,1);
/*!40000 ALTER TABLE `quiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repondu`
--

DROP TABLE IF EXISTS `repondu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repondu` (
  `id_etat_reponse` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_etat_reponse`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repondu`
--

LOCK TABLES `repondu` WRITE;
/*!40000 ALTER TABLE `repondu` DISABLE KEYS */;
INSERT INTO `repondu` VALUES (1,'en attente de vérification'),(2,'passe'),(3,'correct'),(4,'incorrect');
/*!40000 ALTER TABLE `repondu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reponse`
--

DROP TABLE IF EXISTS `reponse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reponse` (
  `id_reponse` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) DEFAULT NULL,
  `reponse_correcte` tinyint DEFAULT NULL,
  `id_question` int DEFAULT NULL,
  PRIMARY KEY (`id_reponse`),
  KEY `fk_Reponse_Questions1_idx` (`id_question`),
  CONSTRAINT `fk_Reponse_Questions1` FOREIGN KEY (`id_question`) REFERENCES `question` (`id_question`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reponse`
--

LOCK TABLES `reponse` WRITE;
/*!40000 ALTER TABLE `reponse` DISABLE KEYS */;
INSERT INTO `reponse` VALUES (1,'Réponse 1',0,115),(2,'Réponse 2',1,115),(3,'Réponse 3',0,115),(4,'Réponse 4',0,115),(5,'string',0,183),(6,'string',0,184),(7,'string',0,185),(8,'string',0,186),(9,'string',0,187),(10,'string',1,188),(11,'string',1,189),(12,'zzz',1,192),(13,'zzz',0,192),(14,'front 1',0,193),(15,'front 2',1,193),(16,'eeeee',0,195),(17,'eeeee',1,195),(18,'',0,196),(19,'',0,197),(20,'ma réponse une',0,198),(21,'une deuxième 2222',1,198),(22,'reponse python 1',0,199),(23,'reponse python 2',1,199),(24,'reponse python 1',1,200),(25,'reponse python 2',0,200),(26,'reponse python 1',0,201),(27,'reponse python 2',1,201),(28,'reponse python 3',1,201),(29,'zzzzzz',1,202),(30,'eeeee',0,202),(31,'reponse junior',0,203),(32,'reponse 2 correcte',1,203),(33,'reponse correcte 1',1,204),(34,'reponse correcte 2',1,204),(35,'aa',1,205),(36,'rrr',0,205);
/*!40000 ALTER TABLE `reponse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reponse_candidat`
--

DROP TABLE IF EXISTS `reponse_candidat`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reponse_candidat` (
  `id_reponse_candidat` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) DEFAULT NULL,
  `id_acteur` int DEFAULT NULL,
  `id_question` int DEFAULT NULL,
  PRIMARY KEY (`id_reponse_candidat`),
  KEY `fk_reponse_candidat_acteur_has_question1_idx` (`id_acteur`,`id_question`),
  CONSTRAINT `fk_reponse_candidat_acteur_has_question1` FOREIGN KEY (`id_acteur`, `id_question`) REFERENCES `acteur_has_question` (`id_acteur`, `id_question`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reponse_candidat`
--

LOCK TABLES `reponse_candidat` WRITE;
/*!40000 ALTER TABLE `reponse_candidat` DISABLE KEYS */;
INSERT INTO `reponse_candidat` VALUES (77,'26',4,201),(78,'27',4,201),(79,'23',4,199),(80,'24',4,200),(81,'26',7,201),(82,'27',7,201),(83,'23',7,199),(84,'24',7,200),(86,'26',8,201),(87,'27',8,201),(88,'24',8,200),(89,'25',8,200),(105,'14',11,193);
/*!40000 ALTER TABLE `reponse_candidat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id_role` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Recruteur'),(2,'Admin'),(3,'Candidat');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `technologie`
--

DROP TABLE IF EXISTS `technologie`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `technologie` (
  `id_technologie` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_technologie`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `technologie`
--

LOCK TABLES `technologie` WRITE;
/*!40000 ALTER TABLE `technologie` DISABLE KEYS */;
INSERT INTO `technologie` VALUES (1,'C#'),(2,'Java'),(3,'Python'),(4,'Delphi');
/*!40000 ALTER TABLE `technologie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_question`
--

DROP TABLE IF EXISTS `type_question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_question` (
  `id_type_question` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_type_question`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='			';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_question`
--

LOCK TABLES `type_question` WRITE;
/*!40000 ALTER TABLE `type_question` DISABLE KEYS */;
INSERT INTO `type_question` VALUES (1,'Choix unique'),(2,'Choix multiple'),(3,'Réponse libre');
/*!40000 ALTER TABLE `type_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventillation`
--

DROP TABLE IF EXISTS `ventillation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventillation` (
  `id_niveau_quiz` int NOT NULL,
  `id_niveau_question` int NOT NULL,
  `valeur` int DEFAULT NULL,
  PRIMARY KEY (`id_niveau_quiz`,`id_niveau_question`),
  KEY `fk_ventillation_Niveau1_idx` (`id_niveau_quiz`),
  KEY `fk_ventillation_Niveau2_idx` (`id_niveau_question`),
  CONSTRAINT `fk_ventillation_Niveau1` FOREIGN KEY (`id_niveau_quiz`) REFERENCES `niveau` (`id_niveau`),
  CONSTRAINT `fk_ventillation_Niveau2` FOREIGN KEY (`id_niveau_question`) REFERENCES `niveau` (`id_niveau`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventillation`
--

LOCK TABLES `ventillation` WRITE;
/*!40000 ALTER TABLE `ventillation` DISABLE KEYS */;
INSERT INTO `ventillation` VALUES (1,1,70),(1,2,20),(1,3,10),(2,1,25),(2,2,50),(2,3,25),(3,1,10),(3,2,40),(3,3,50);
/*!40000 ALTER TABLE `ventillation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-18 10:01:31
