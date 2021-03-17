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
INSERT INTO `acteur` VALUES (1,'admin','admin','admin@quiz.fr','admin',2),(2,'Recruteur','recruteur','recruteur@quiz.fr','recruteur',1),(3,'ALEXANDRE','Fabien','fabien@quiz.fr','Ib123456',3),(4,'HARISON','Rin','rin@quiz.fr','azerty',3);
/*!40000 ALTER TABLE `acteur` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `acteur_has_question`
--

LOCK TABLES `acteur_has_question` WRITE;
/*!40000 ALTER TABLE `acteur_has_question` DISABLE KEYS */;
INSERT INTO `acteur_has_question` VALUES (3,199,NULL,2),(3,200,NULL,1),(3,201,NULL,1);
/*!40000 ALTER TABLE `acteur_has_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `acteur_has_quiz`
--

LOCK TABLES `acteur_has_quiz` WRITE;
/*!40000 ALTER TABLE `acteur_has_quiz` DISABLE KEYS */;
INSERT INTO `acteur_has_quiz` VALUES (2,1),(3,1),(4,1),(3,2),(4,2),(1,3),(2,3),(3,3),(4,3),(1,4),(1,5),(2,5),(3,5),(4,5),(1,6),(1,7),(1,8),(1,9),(1,13),(1,15),(1,16),(1,19),(1,20),(1,21),(1,22),(1,23),(1,24),(1,25),(1,26),(1,27),(1,28),(1,29),(1,30),(1,31),(3,31);
/*!40000 ALTER TABLE `acteur_has_quiz` ENABLE KEYS */;
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
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` VALUES (1,'libelle : Niveau 1','explication',1,1,5,1,NULL),(2,'libelle : Niveau 1','explication',1,1,5,1,NULL),(3,'libelle : Niveau 1','explication',1,1,9,1,NULL),(4,'libelle : Niveau 1','explication',1,1,13,1,NULL),(5,'libelle : Niveau 1','explication',1,1,15,1,NULL),(6,'libelle : Niveau 1','explication',1,1,15,1,NULL),(7,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(8,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(9,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(10,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(11,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(12,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(13,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(14,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(15,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(16,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(17,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(18,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(19,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(20,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(21,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(22,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(23,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(24,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(25,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(26,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(27,'libelle : Niveau 1','explication',1,1,NULL,1,NULL),(28,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(29,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(30,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(31,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(32,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(33,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(34,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(35,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(36,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(37,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(38,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(39,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(40,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(41,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(42,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(43,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(44,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(45,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(46,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(47,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(48,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(49,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(50,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(51,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(52,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(53,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(54,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(55,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(56,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(57,'libelle : Niveau 2','explication',2,1,NULL,2,NULL),(59,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(60,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(61,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(62,'libelle : Niveau 3','explication',3,1,NULL,3,NULL),(63,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(64,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(65,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(66,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(67,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(68,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(69,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(70,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(71,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(72,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(73,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(74,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(75,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(76,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(77,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(78,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(79,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(80,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(81,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(82,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(83,'libelle : Niveau 3\n','explication',3,1,NULL,3,NULL),(84,'libelle : Niveau 1','techno 1',3,1,3,1,NULL),(85,'libelle : Niveau 1','techno 1',3,1,4,1,NULL),(86,'libelle : Niveau 1','techno 1',3,1,5,1,NULL),(87,'libelle : Niveau 1','techno 1',3,1,6,1,NULL),(88,'libelle : Niveau 1','techno 1',3,1,7,1,NULL),(89,'libelle : Niveau 1','techno 1',3,1,8,1,NULL),(90,'libelle : Niveau 1','techno 1',3,1,9,1,NULL),(91,'libelle : Niveau 1','techno 1',3,1,13,1,NULL),(92,'libelle : Niveau 1','techno 1',3,1,15,1,NULL),(93,'libelle : Niveau 1','techno 1',3,1,16,1,2),(94,'libelle : Niveau 1','techno 1',3,1,16,1,3),(95,'libelle : Niveau 1','techno 1',3,1,19,1,1),(96,'libelle : Niveau 1','techno 1',3,1,20,1,1),(97,'libelle : Niveau 1','techno 1',3,1,21,1,1),(98,'libelle : Niveau 1','techno 1',3,1,22,1,1),(99,'libelle : Niveau 1','techno 1',3,1,23,1,1),(100,'libelle : Niveau 1','techno 1',3,1,24,1,1),(101,'libelle : Niveau 1','techno 1',3,1,25,1,1),(102,'libelle : Niveau 1','techno 1',3,1,26,1,1),(103,'libelle : Niveau 1','techno 1',3,1,27,1,1),(104,'libelle : Niveau 1','techno 1',3,1,28,1,1),(105,'libelle : Niveau 1','techno 1',3,1,29,1,1),(106,'libelle : Niveau 1','techno 1',3,1,30,1,1),(107,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(108,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(109,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(110,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(111,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(112,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(113,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(114,'libelle : Niveau 1','techno 1',3,1,NULL,1,NULL),(115,'libelle : Niveau 2','techno 1',2,1,16,1,1),(116,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(117,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(118,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(119,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(120,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(121,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(122,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(123,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(124,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(125,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(126,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(127,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(128,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(129,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(130,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(131,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(132,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(133,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(134,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(135,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(136,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(137,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(138,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(139,'libelle : Niveau 2','techno 1',2,1,NULL,1,NULL),(140,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(141,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(142,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(143,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(144,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(145,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(146,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(147,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(148,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(149,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(150,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(151,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(152,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(153,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(154,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(155,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(156,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(157,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(158,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(159,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(160,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(161,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(162,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(163,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(164,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(165,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(166,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(167,'libelle : Niveau 3','techno 1',3,1,NULL,1,NULL),(177,'string','string',1,1,NULL,1,0),(178,'string','string',1,1,NULL,1,NULL),(179,'string','string',1,1,NULL,1,NULL),(180,'string','string',1,1,NULL,1,NULL),(181,'string','string',1,1,NULL,1,NULL),(182,'string','string',1,1,NULL,1,NULL),(183,'string','string',1,1,NULL,1,NULL),(184,'string','string',1,1,NULL,1,NULL),(185,'string','string',1,1,NULL,1,NULL),(186,'string','string',1,1,NULL,1,NULL),(187,'string','string',1,1,NULL,1,NULL),(188,'string','string',1,1,NULL,1,NULL),(189,'string','string',1,1,NULL,1,NULL),(191,'aa','aa',1,1,NULL,1,NULL),(192,'zzz','zz',1,1,NULL,1,NULL),(193,'Une question depuis le front','Question pas facile ;)',3,1,NULL,4,NULL),(195,'eee','eee',1,1,NULL,1,NULL),(196,'','',NULL,NULL,NULL,NULL,NULL),(197,'','',NULL,NULL,NULL,NULL,NULL),(198,'une petite question ppp','sans explication pppp',3,2,NULL,1,NULL),(199,'Question Python','ss',1,1,31,3,2),(200,'question Python','99',2,2,31,3,3),(201,'python 3','33',3,1,31,3,1);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `quiz`
--

LOCK TABLES `quiz` WRITE;
/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;
INSERT INTO `quiz` VALUES (1,NULL,1,1),(2,NULL,1,1),(3,NULL,1,1),(4,'Mon quiz',1,1),(5,'Mon quiz',1,1),(6,'string',1,1),(7,'string',1,1),(8,'string',1,1),(9,'string',1,1),(10,'Mon quiz',1,1),(11,'Mon quiz',1,1),(12,'Mon quiz',1,1),(13,'Mon quiz',1,1),(14,'string',1,1),(15,'Mon nouveau quiz',1,1),(16,'Mon quiz',1,2),(17,NULL,NULL,NULL),(18,NULL,NULL,NULL),(19,'Mon quiz',1,1),(20,'Mon quiz',1,1),(21,'Mon quiz',1,1),(22,'Mon quiz',1,1),(23,'Mon quiz',1,1),(24,'a',1,1),(25,'aa',1,1),(26,'aaaa',1,1),(27,'qqq',1,1),(28,'aaa',1,2),(29,'aaa',1,3),(30,'quiz Python',1,1),(31,'quiz python',3,1);
/*!40000 ALTER TABLE `quiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `repondu`
--

LOCK TABLES `repondu` WRITE;
/*!40000 ALTER TABLE `repondu` DISABLE KEYS */;
INSERT INTO `repondu` VALUES (1,'en attente de vérification'),(2,'passe'),(3,'correct'),(4,'incorrect');
/*!40000 ALTER TABLE `repondu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `reponse`
--

LOCK TABLES `reponse` WRITE;
/*!40000 ALTER TABLE `reponse` DISABLE KEYS */;
INSERT INTO `reponse` VALUES (1,'Réponse 1',0,115),(2,'Réponse 2',1,115),(3,'Réponse 3',0,115),(4,'Réponse 4',0,115),(5,'string',0,183),(6,'string',0,184),(7,'string',0,185),(8,'string',0,186),(9,'string',0,187),(10,'string',1,188),(11,'string',1,189),(12,'zzz',1,192),(13,'zzz',0,192),(14,'front 1',0,193),(15,'front 2',1,193),(16,'eeeee',0,195),(17,'eeeee',1,195),(18,'',0,196),(19,'',0,197),(20,'ma réponse une',0,198),(21,'une deuxième 2222',1,198),(22,'reponse python 1',0,199),(23,'reponse python 2',1,199),(24,'reponse python 1',1,200),(25,'reponse python 2',0,200),(26,'reponse python 1',0,201),(27,'reponse python 2',0,201),(28,'reponse python 3',1,201);
/*!40000 ALTER TABLE `reponse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `reponse_candidat`
--

LOCK TABLES `reponse_candidat` WRITE;
/*!40000 ALTER TABLE `reponse_candidat` DISABLE KEYS */;
INSERT INTO `reponse_candidat` VALUES (22,'26',3,201),(23,'24',3,200),(24,'25',3,200);
/*!40000 ALTER TABLE `reponse_candidat` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Recruteur'),(2,'Admin'),(3,'Candidat');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `technologie`
--

LOCK TABLES `technologie` WRITE;
/*!40000 ALTER TABLE `technologie` DISABLE KEYS */;
INSERT INTO `technologie` VALUES (1,'C#'),(2,'Java'),(3,'Python'),(4,'Delphi');
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

-- Dump completed on 2021-03-16 15:08:56
