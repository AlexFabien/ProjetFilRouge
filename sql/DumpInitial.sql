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
-- Dumping data for table `acteur`
--

LOCK TABLES `acteur` WRITE;
/*!40000 ALTER TABLE `acteur` DISABLE KEYS */;
INSERT INTO `acteur` VALUES (1,'admin','admin','admin@quiz.fr','admin',1),(2,'Recruteur','recruteur','recruteur@quiz.fr','recruteur',2),(3,'ALEXANDRE','Fabien','fabien@quiz.fr','1234',3),(4,'HARISON','Rin','rin@quiz.fr','azerty',3);
/*!40000 ALTER TABLE `acteur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `niveau`
--

LOCK TABLES `niveau` WRITE;
/*!40000 ALTER TABLE `niveau` DISABLE KEYS */;
INSERT INTO `niveau` VALUES (1,'Junior'),(2,'Confirmé'),(3,'Expérimenté');
/*!40000 ALTER TABLE `niveau` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `parametrage`
--

LOCK TABLES `parametrage` WRITE;
/*!40000 ALTER TABLE `parametrage` DISABLE KEYS */;
INSERT INTO `parametrage` VALUES (1,'40');
/*!40000 ALTER TABLE `parametrage` ENABLE KEYS */;
UNLOCK TABLES;


--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Admin'),(2,'Recruteur'),(3,'Candidat');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `technologie`
--

LOCK TABLES `technologie` WRITE;
/*!40000 ALTER TABLE `technologie` DISABLE KEYS */;
INSERT INTO `technologie` VALUES (1,'C#'),(2,'Java'),(3,'Pyhton'),(4,'Delphi');
/*!40000 ALTER TABLE `technologie` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `type_question`
--

LOCK TABLES `type_question` WRITE;
/*!40000 ALTER TABLE `type_question` DISABLE KEYS */;
INSERT INTO `type_question` VALUES (1,'Choix unique'),(2,'Choix multiple'),(3,'Réponse libre');
/*!40000 ALTER TABLE `type_question` ENABLE KEYS */;
UNLOCK TABLES;

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

-- Dump completed on 2021-02-17 15:30:32
