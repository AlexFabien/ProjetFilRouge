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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acteur`
--

LOCK TABLES `acteur` WRITE;
/*!40000 ALTER TABLE `acteur` DISABLE KEYS */;
INSERT INTO `acteur` VALUES (1,'DOE','John','admin@quiz.fr','Admin123',2),(2,'HUMAN','Resource','recruteur@quiz.fr','Ib123456',1),(3,'ALEXANDRE','Fabien','fabien@quiz.fr','',3),(4,'HARISON','Rin','rin@quiz.fr','',3),(5,'MERCIER','Cyril','c.mercier@ib.fr',NULL,3),(6,'bloquiau','sophie','sophie@webnet.fr',NULL,3);
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
INSERT INTO `acteur_has_question` VALUES (4,36,NULL,1),(4,37,NULL,2),(4,47,NULL,1),(4,48,NULL,1),(4,49,NULL,1);
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
INSERT INTO `acteur_has_quiz` VALUES (1,1),(3,1),(4,1),(5,1),(1,2),(1,3),(3,3),(4,3),(1,4),(3,4),(4,4),(1,5),(6,5);
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
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `question`
--

LOCK TABLES `question` WRITE;
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
INSERT INTO `question` VALUES (1,'Que signifie CLR ?','Le CLR (Common Language Runtime) est un environnement d’exécution faisant partie du framework .NET de Microsoft. CLR gère l’exécution des programmes écrits dans différentes langages prises en charge. CLR transforme le code source en une forme de code secondaire appelée CIL (Common Intermediate Language). Au moment de l’exécution, CLR gère l’exécution du code CIL.',1,1,1,1,1),(2,'De quoi est responsable le CLR ?','Le CLR (Common Language Runtime) est responsable du garbage-collector(ramasse-miettes), sécurité d’accès et vérification du code.',1,2,1,1,2),(3,'Que signifie GAC ?','Le Global Assembly Cache (GAC) est un dossier du répertoire Windows (\\windows\\assembly) dans lequel sont stockés les « assembly » .NET spécifiquement désignés pour être partagés par toutes les applications exécutées sur un système. Le concept de GAC est le résultat de l’architecture .NET dont la conception répond au problème de « DLL » qui existait dans COM (Component Object Model). Contrairement à COM, il n’est pas nécessaire que le montage dans GAC soit enregistré avant son utilisation. L’accès à chaque « assembly » est global, sans conflit, en identifiant son nom, sa version, son architecture et sa clé publique.',1,1,1,1,3),(4,'A quoi sert le GAC','Global Assembly Cache (GAC) stocke les « assembly » .NET partagés entre plusieurs applications.',1,1,3,1,1),(5,'Quels sont les types de JIT?','Pre-JIT: Compile l’intégralité du code source lors de la compilation et est utilisé au moment du déploiement. Econo-JIT: Compile les méthodes appelées lors de l’exécution. Normal-JIT: Compile uniquement les méthodes appelées lors de l’exécution (au moment de leur premier appel) et stocke le code compilé dans la mémoire cache à utiliser lors des appels suivants.',1,2,NULL,1,NULL),(6,'Garbage collector (GC) comprend _______ générations.','Il y a trois générations: La génération 0 identifie un objet nouvellement créé qui n’a jamais été marqué pour la collecte. La génération 1 identifie un objet qui a survécu à un GC (marqué pour la collecte mais non supprimé parce qu’il y avait suffisamment d’espace de tas) La génération 2 identifie un objet ayant survécu à plus d’un balayage du GC.',1,1,NULL,1,NULL),(7,'Comment forcer le garbage-collector à s’exécuter?','System.GC.Collect() force l’exécution du garbage-collector.',1,1,NULL,1,NULL),(8,'Que signifie IL en .Net ?','Intermediate language (IL) ou le langage intermédiaire est un langage de programmation orienté objet conçu pour être utilisé par les compilateurs pour le Framework .NET. Le Framework .NET utilise IL pour générer du code indépendant de la machine en tant que sortie de la compilation du code source écrit dans n’importe quel langage de programmation .NET.',1,1,NULL,1,NULL),(9,'Quel outil est utilisé pour voir le code IL?','ILDASM (IL Disassembler) est un excellent outil pour ceux qui veulent voir le code IL. Cet outil est utilisé pour afficher Le contenu de l’assembly pour tous les composants de code. ',1,1,NULL,1,NULL),(10,'Que signifie le terme « boxing » en .net?','Boxing est le processus de conversion d’un type de valeur en type d’objet ou en tout type d’interface implémenté par ce type de valeur. Lorsque le CLR encadre un type de valeur, il encapsule la valeur dans un « System.Object » et la stocke dans le segment de mémoire géré. Unboxing extrait le type de valeur de l’objet.',1,1,NULL,1,NULL),(11,'Les métadonnées de l’ « assembly » .Net sont stockées dans quel fichier?','Le manifeste contient ces métadonnées d’ « assembly ». Un manifeste contient toutes les métadonnées nécessaires pour spécifier les exigences de l’ « assembly » et l’identité de sécurité, ainsi que toutes les métadonnées nécessaires pour définir la portée de l’ « assembly » et résoudre les références aux ressources et aux classes. Le manifeste peut être stocké dans un fichier PE (un fichier .exe ou .dll) avec le code MSIL (Microsoft Intermediate Language) ou dans un fichier PE autonome contenant uniquement les informations du manifeste.',1,1,NULL,1,NULL),(12,'Que gère le CTS (Common Type System) ?','Dans le Framework .NET , Common Type System (CTS) est une norme qui spécifie comment les définitions et les valeurs spécifiques d’un type sont représentées dans la mémoire de l’ordinateur. Il est destiné à permettre aux programmes écrits dans différents langages de programmation de partager facilement des informations.',1,1,NULL,1,NULL),(13,'Lequel des types suivants peut contenir une valeur de n’importe quelle taille?','Il n’y a pas de limite théorique. La classe BigInteger alloue autant de mémoire que nécessaire pour tous les bits de données qu’il lui est demandé de conserver.',1,1,NULL,1,NULL),(14,'Qu’est-ce que le « Code Access Security (CAS) »?','CAS est la solution pour empêcher le code non approuvé d’effectuer des actions privilégiées. Lorsque le CLR charge un assembly, il obtient des preuves de l’assembly et l’utilise pour identifier le groupe de codes auquel appartient l’assembly. Un groupe de codes contient un ensemble d’autorisations (une ou plusieurs autorisations).',1,1,NULL,1,NULL),(15,'Laquelle des méthodes suivantes demande au garbage-collector de ne pas appeler finalize?','« SuppressFinalize » ne doit être appelé que par une classe disposant d’un « finalizer ». Il informe le Garbage Collector (GC) que cet objet a été entièrement nettoyé.',1,1,NULL,1,NULL),(16,'Quel est l’espace de noms qui le père pour tous les types dans le framework .Net ?','C# a un système de types unifié, ce qui signifie que tous les types héritent, directement ou indirectement, de Objet (System.Object). Cela inclut les types de référence et de valeur. Il inclut également tous les types primitifs, tels que int et bool, ainsi que tous les types fournis dans le Framework .NET et tous les types personnalisés que vous définissez.',1,1,NULL,1,NULL),(17,'Quelle fonctionnalité est introduite dans .Net 3.5?','Microsoft Windows Communication Foundation(WCF) Microsoft Windows Presentation Foundation(WPF) Microsoft Windows Workflow Foundation(WWF)',1,1,NULL,1,NULL),(18,'Quelles sont les caractéristiques de .Net 4.5?','Applications .NET pour Windows Store Bibliothèques de classes portables Principales fonctionnalités et améliorations Traitement en parallèle Web Outils Windows Presentation Foundation (WPF) Windows Communication Foundation (WCF) Windows Workflow Foundation (WF)',1,2,NULL,1,NULL),(19,'Le code qui s’exécute sous CLR s’appelle','Le CLR (Common Language Runtime) est un environnement qui gère l’exécution du code et fournit des services de développement d’applications. Des compilateurs tels que VB.NET exposent les fonctionnalités du CLR pour permettre aux développeurs de créer des applications. Le code créé dans cet environnement est appelé code managé. Notez que les composants COM ne sont pas du code managé, bien qu’ils puissent (ainsi que d’autres codes non managés) être utilisés dans des applications construites sous le CLR.',1,1,NULL,1,NULL),(20,'Lequel des éléments suivants n’est pas un type de données valide dans .Net?','Les types disponibles dans le framework .Net sont : Entier signée: sbyte, short, int, long. Entier non signée: octet, ushort, uint, ulong. Caractères Unicode: char. Virgule flottante IEEE: float, double. Décimal de haute précision: decimal. Boolean: bool.',1,1,NULL,1,NULL),(21,'Lequel peut être utilisé pour compiler des assembly managés dans du code natif spécifique au processeur?','Ngen.exe est un outil qui améliore les performances des applications managées. Ngen.exe crée des images natives, qui sont des fichiers contenant du code machine compilé spécifique au processeur, et les installe dans le cache de l’ordinateur local. Le moteur d’exécution peut utiliser des images natives à partir du cache au lieu d’utiliser le compilateur JIT (Just-in-Time) pour compiler l’assembly d’origine.',1,1,NULL,1,NULL),(22,'Laquelle des affirmations suivantes est correcte à propos du code managé?','Le code managé est un code dont l’exécution est gérée par Common Language Runtime. Il récupère le code managé et le compile en code machine. Après cela, le code est exécuté.',1,1,NULL,1,NULL),(23,'Lesquels des énoncés suivants NE SONT PAS vrais à propos du framework .NET ?','...',1,2,NULL,1,NULL),(24,'Parmi les composants suivants du framework .NET, lesquels fournissent un ensemble extensible de classes pouvant être utilisé par tout langage de programmation compatible avec .NET?','La bibliothèque de classes du Framework .NET est une bibliothèque de classes, d’interfaces et de types de valeur permettant d’accéder aux fonctionnalités du système.',1,1,NULL,1,NULL),(25,'Lesquels des jobs suivants ne sont PAS effectués par Garbage Collector?','Le Garbage collector(ramasse-miettes) gère l’allocation et la récupération de la mémoire. GC fonctionne sur le tas managé, qui n’est rien d’autre qu’un bloc de mémoire pour stocker des objets. Il n’y a pas de timings spécifique pour que le CPG se déclenche, le CPG démarre automatiquement. Les objets managés sont créés et gérés sous la portée du CLR.',1,2,NULL,1,NULL),(26,'Lesquels des composants .NET suivants peuvent être utilisés pour supprimer les références inutilisées du mémoire dans le tas managé?','Le Garbage collector(ramasse-miettes) gère l’allocation et la récupération de la mémoire. GC fonctionne sur le tas managé, qui n’est rien d’autre qu’un bloc de mémoire pour stocker des objets. Il n’y a pas de timings spécifique pour que le CPG se déclenche, le CPG démarre automatiquement. Les objets managés sont créés et gérés sous la portée du CLR.',1,1,NULL,1,NULL),(27,'Laquelle des instructions suivantes définit correctement le framework .NET ?','.',1,1,NULL,1,NULL),(28,'Lequel des éléments suivants constitue le framework .NET ?','.',1,2,NULL,1,NULL),(29,' Lequel des assembly suivants peut être stocké dans Global Assembly Cache?','Shared assembly est un assembly qui réside dans un emplacement centralisé appelé GAC (Global Assembly Cache) et qui fournit des ressources à plusieurs applications. Si un assembly est partagé, plusieurs copies ne seront pas créées même si elles sont utilisées par plusieurs applications. Le dossier GAC est sous le dossier Windows.',1,1,NULL,1,NULL),(30,'Le code qui cible le Common Language Runtime(CLR) est appelé ','Le code managé est un code dont l’exécution est gérée par Common Language Runtime. Il récupère le code managé et le compile en code machine.',1,1,NULL,1,NULL),(31,'Lequel des éléments suivants est la racine de la hiérarchie de toutes les types .NET?','System.Object est la racine de la hiérarchie de toutes les types.',2,1,1,1,4),(32,'Laquelle des affirmations suivantes est correcte à propos du Framework .NET ?','Lors des transitions entre le code managé et le code non managé, l’infrastructure COM (en particulier DCOM) est utilisée pour la communication à distance. Dans les versions intermédiaires du CLR, cela s’applique également aux composants desservis (composants qui utilisent les services COM+).',2,1,2,1,1),(33,'Parmi les avantages suivants, quels sont les avantages du code managé sous CLR?','.',2,2,2,1,2),(34,'Lesquelles des fonctionnalités de sécurité suivantes peuvent être utilisées par les applications .NET?','Pour assurer la convivialité et la cohérence de la sécurité d’accès au code, la sécurité basée sur les rôles du framework .NET fournit des objets System.Security.Permissions.PrincipalPermission qui permettent au Common Language Runtime(CLR) d’effectuer une autorisation d’une manière similaire aux contrôles de sécurité d’accès au code.',2,2,3,1,2),(35,'Lesquels des travaux suivants sont réalisés par Common Language Runtime?','.',2,2,3,1,3),(36,'Parmi les affirmations suivantes, lesquelles sont correctes à propos d’un assembly .NET?','.',2,2,4,1,1),(37,'Quels sont les types de JIT?','Pre-JIT: Compile l’intégralité du code source lors de la compilation et est utilisé au moment du déploiement. Econo-JIT: Compile les méthodes appelées lors de l’exécution. Normal-JIT: Compile uniquement les méthodes appelées lors de l’exécution (au moment de leur premier appel) et stocke le code compilé dans la mémoire cache à utiliser lors des appels suivants.',2,2,4,1,2),(38,'Garbage collector (GC) comprend combien de générations ?','Il y a trois générations: La génération 0 identifie un objet nouvellement créé qui n’a jamais été marqué pour la collecte. La génération 1 identifie un objet qui a survécu à un GC (marqué pour la collecte mais non supprimé parce qu’il y avait suffisamment d’espace de tas) La génération 2 identifie un objet ayant survécu à plus d’un balayage du GC.',2,1,NULL,1,NULL),(39,'Parmi les affirmations suivantes, lesquelles sont correctes à propos de JIT?','.',2,2,NULL,1,NULL),(40,'Lesquels des éléments suivants font partie du framework .NET ?','.',2,2,NULL,1,NULL),(41,'Quelles sont les différentes façons de voir la valeur d’un paramètre passé à une méthode ?','.',3,2,1,1,5),(42,'Quels formats sont disponibles pour afficher la valeur d’une string dans un Data Tip ?','.',3,2,2,1,3),(43,'Comment détecter le changement de valeur d’une variable ?','.',3,2,2,1,4),(44,'Comment, pour un de vos types, changer la valeur affichée par le débogueur pour ses instances ?','.',3,1,2,1,5),(45,'Comment trouver rapidement la source d\'une exception ?','.',3,2,3,1,4),(46,'Est-il possible de garder un point d\'arrêt mais qu\'il ne se déclenche pas durant une session de débogage ?','.',3,1,3,1,5),(47,'Lequel des éléments suivants peut être utilisé pour terminer une boucle while et transférer le contrôle en dehors de la boucle?','.',3,2,4,1,3),(48,'Laquelle des déclarations suivantes est correcte?','.',3,1,4,1,4),(49,'Lequel des énoncés suivants est correct?','.',3,1,4,1,5),(50,'String en Java est :','Voir : Les chaînes de caractères(String) en Java',1,1,5,2,1),(51,' Laquelle de ces méthodes de la classe String est utilisée pour obtenir le caractère à l’index spécifié?','La méthode charAt() renvoie le caractère à l’index spécifié dans une chaîne. L’index du premier caractère est 0, le deuxième caractère est 1, etc.  …',1,1,5,2,2),(52,'Laquelle de ces méthodes de la classe String peut être utilisée pour tester l’égalité des chaînes de caractères?','La méthode equals() compare deux chaînes et renvoie « true » si les chaînes sont égales sinon renvoie « false ». Vous pouvez utiliser la méthode compareTo() pour comparer…',1,1,5,2,3),(53,' Lequel de ces mots clés est utilisé pour faire référence à un membre de la classe de base dans une sous-classe?','Chaque fois qu’une sous-classe doit se référer à sa super-classe immédiate, elle peut le faire en utilisant le mot-clé « super« .',1,1,NULL,2,NULL),(54,'Lesquelles des affirmations suivantes sont incorrectes?','Les chaînes en Java sont immuables, c’est-à-dire qu’elles ne peuvent pas être modifiées.',1,1,NULL,2,NULL),(55,'Lequel de ces opérateurs peut être utilisé pour concaténer deux ou plusieurs objets String?','L’opérateur + est utilisé pour concaténer des chaînes',1,1,NULL,2,NULL),(56,'Laquelle de ces méthodes de la classe String est utilisée pour obtenir la longueur d’une chaîne de caractères?','La méthode length() de la classe String est utilisée pour obtenir la longueur d’une chaîne de caractères.',1,1,NULL,2,NULL),(57,' Lequel de ces constructeurs est utilisé pour créer une chaîne vide?','.',1,1,NULL,2,NULL),(58,'Laquelle de ces méthodes de la classe String est utilisée pour vérifier si un objet donné commence par une chaîne particulier?','La méthode startsWith() de la classe String est utilisée pour vérifier si la chaîne en question commence par une chaîne spécifiée.',1,1,NULL,2,NULL),(59,'Quellesl valeurs ne sont pas renvoyées par « str1.compareTo(str2) » si str1 est inférieure à str2?','La fonction compareTo() renvoie zéro lorsque les deux chaînes sont égales, elle renvoie une valeur inférieure à zéro si str1 est inférieure à str2 et une valeur supérieure à zéro lorsque str1 est supérieur à str2.',1,2,NULL,2,NULL),(60,'La méthode equals() de la classe String ne retourne pas quels types ?','La méthode equals() de la classe String renvoie une valeur booléenne true si les deux chaînes sont égales et false si elles sont inégales.',1,2,NULL,2,NULL),(61,'La méthode toString() n\"est pas définie dans :','Si vous souhaitez représenter un objet sous forme de chaîne de caractères, la méthode toString() est utilisée.',1,2,NULL,2,NULL),(62,'La méthode compareTo() renvoie :','Voir aussi : Java | compareTo()',2,1,5,2,4),(63,'Laquelle de ces méthodes de la classe String est utilisée pour extraire une sous-chaîne d’une chaîne ?','La méthode substring() renvoie une nouvelle chaîne qui est une sous-chaîne de cette chaîne.',2,1,NULL,2,NULL),(64,'Lesquelles de ces méthodes de la classe String ne sont pas utilisées pour supprimer les espaces de début et de fin?','La méthode trim() est utilisée pour supprimer les espaces de début et de fin.',2,2,NULL,2,NULL),(65,'Laquelle de ces classes est utilisée pour créer un objet dont la séquence de caractères est modifiable?','StringBuffer est mutable ce qui signifie qu’on peut changer la valeur de l’objet.',2,1,NULL,2,NULL),(66,'Laquelle de ces méthodes de la classe StringBuffer est utilisée pour trouver la longueur d’une séquence de caractères?','.',3,1,5,2,5),(67,'Laquelle des affirmations suivantes est correcte?','La méthode reverse() inverse tous les caractères. Il renvoie l’objet inversé sur lequel il a été appelé.',3,1,NULL,2,NULL),(68,' Lesquels des éléments suivants sont une forme incorrecte du constructeur de la classe StringBuffer?','StringBuffer(int size , String str)',3,1,NULL,2,NULL),(69,'Combien de constructeurs dans la classe String? Identifier les mauvaises réponses.','13',3,2,NULL,2,NULL),(70,'une question de test','sans explication',3,2,NULL,3,NULL),(71,'ma question','sans explication ',1,1,NULL,1,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quiz`
--

LOCK TABLES `quiz` WRITE;
/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;
INSERT INTO `quiz` VALUES (1,'Quiz C# débutant',1,1),(2,'Quiz C# expert',1,3),(3,'Quiz C#',1,2),(4,'Quiz C# Webnet',1,3),(5,'Quiz demo',2,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=291 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reponse`
--

LOCK TABLES `reponse` WRITE;
/*!40000 ALTER TABLE `reponse` DISABLE KEYS */;
INSERT INTO `reponse` VALUES (1,'Common Language Runtime',1,1),(2,'Common Local Runtime',0,1),(3,'Common Language Realtime',0,1),(4,'Common Local Realtime',0,1),(5,'Garbage-collector',1,2),(6,'Sécurité d’accès au code',1,2),(7,'Vérification du code',1,2),(8,'Global Assembly Cache',1,3),(9,'Global Assembly Store',0,3),(10,'Garbage Assemble Cache',0,3),(11,'Global Advanced Cache',0,3),(12,'Stocke les « assembly » .net partagés entre plusieurs applications.',1,4),(13,'Stocke les dll globales.',0,4),(14,'Mettre en cache les données d’application.',0,4),(15,'Aucune de ces réponses',0,4),(16,'Pre-JIT',1,5),(17,'Econo-JT',1,5),(18,'Normal-JIT',1,5),(19,'Trois',1,6),(20,'Cinq',0,6),(21,'Deux',0,6),(22,'Sept',0,6),(23,'Utilisation de la méthode GC.Collect()',1,7),(24,'Utilisation de la méthode GC.Run()',0,7),(25,'Utilisation de la méthode GC.Collection()',0,7),(26,'Utilisation de la méthode GC.Finalize()',0,7),(27,'Intermediate Language',1,8),(28,'International Language',0,8),(29,'Interoperate Language',0,8),(30,'Intermediate Local',0,8),(31,'IDASM.EXE',1,9),(32,'Util.exe',0,9),(33,'IL.exe',0,9),(34,'GACUtil.exe',0,9),(35,'Convertit le type de valeur en objet',1,10),(36,'Convertit le type de référence en type de valeur',0,10),(37,'Convertit le type primitif en type valeur',0,10),(38,'Aucune de ces réponses n’est vraie.',0,10),(39,'manifest',1,11),(40,'.dll',0,11),(41,'.exe',0,11),(42,'core',0,11),(43,'Communication entre plusieurs langues',1,12),(44,'Types de valeur',0,12),(45,'Types de référence',0,12),(46,'Tous les types de données en .net',0,12),(47,'BigInteger',1,13),(48,'Int32',0,13),(49,'Double',0,13),(50,'Long',0,13),(51,'Empêche l’accès non autorisé aux ressources et aux opérations et limite le code pour l’exécution de tâches particulières.',1,14),(52,'Il empêche l’accès non autorisé du code source.',0,14),(53,'Il empêche l’accès non autorisé au dll et exe.',0,14),(54,'Aucune de ces réponses n’est vraie.',0,14),(55,'GC.SuppressFinalize()',1,15),(56,'GC.Collect(int)',0,15),(57,'GC.Dispose()',0,15),(58,'GC.Cancel()',0,15),(59,'System.Object',1,16),(60,'System.Web',0,16),(61,'System.IO',0,16),(62,'System.File',0,16),(63,'WCF',1,17),(64,'WWF',0,17),(65,'WPF',0,17),(66,'Bibliothèque de classe portable',1,18),(67,'Traitement en parallèle',1,18),(68,'.Net pour les applications du Windows Store',1,18),(69,'Cette version n\'existe pas.',0,18),(70,'Code managé',1,19),(71,'Code non managé',0,19),(72,'Code COM',0,19),(73,'Code PIN',0,19),(74,'MIME',1,20),(75,'Double',0,20),(76,'Int32',0,20),(77,'Int16',0,20),(78,'ngen',1,21),(79,'gacutil',0,21),(80,'sn',0,21),(81,'dumpbin',0,21),(82,'ildasm',0,21),(83,'Le code managé est le code écrit pour cibler les services du CLR.',1,22),(84,'Le code managé est le code compilé par les compilateurs JIT.',0,22),(85,' Le code managé est le code dans lequel les ressources sont récupérées.',0,22),(86,'Le code managé est le code qui s’exécute sur Windows.',0,22),(87,'Le code managé est le code qui peut être exécuté sur Linux.',0,22),(88,' Il fournit différents modèles de programmation pour les applications Windows et les applications Web.',1,23),(89,'Il fournit un modèle de programmation piloté par les événements pour la construction des pilotes de périphériques Windows.',1,23),(90,'Il fournit un environnement de programmation cohérent orienté objet, que le code objet soit stocké et exécuté localement, mais distribué sur Internet ou exécuté à distance.',0,23),(91,'Il fournit un environnement d’exécution de code qui minimise les conflits de déploiement de logiciel et de version.',0,23),(92,'Il fournit un environnement d’exécution de code qui promeut une exécution sécurisée du code, y compris du code créé par un tiers inconnu ou semi-fiable.',0,23),(93,'Bibliothèque de classes du framework .NET',1,24),(94,'Common Language Runtime (CLR)',0,24),(95,'Common Language Infrastructure (CLI)',0,24),(96,'Component Object Model (COM)',0,24),(97,'Common Type System (CTS)',0,24),(98,'Libérer de la mémoire sur la pile.',1,25),(99,'Fermeture des collections de bases de données non fermées.',1,25),(100,'Fermeture des fichiers non fermés.',1,25),(101,'Éviter les fuites de mémoire.',0,25),(102,'Libération de la mémoire occupée par des objets non référencés.',0,25),(103,'Garbage Collector',1,26),(104,' Common Language Infrastructure',0,26),(105,'Class Loader',0,26),(106,'CLR',0,26),(107,'CTS',0,26),(108,'Il s’agit d’un environnement permettant de développer, créer, déployer et exécuter des applications desktop, des applications Web et des services Web.',1,27),(109,'C’est un environnement pour développer, construire, déployer et exécuter uniquement des applications Web.',0,27),(110,'C’est un environnement pour développer, créer, déployer et exécuter des applications distribuées.',0,27),(111,'Il s’agit d’un environnement permettant de développer, créer, déployer et exécuter des services Web.',0,27),(112,'C’est un environnement de développement et d’exécution d’applications Windows.',0,27),(113,'Applications ASP.NET',1,28),(114,'Bibliothèque de classes du framework .NET',1,28),(115,'Applications WinForm',0,28),(116,'Services Windows',0,28),(117,'CLR',0,28),(118,'Shared Assemblies',1,29),(119,'Private Assemblies',0,29),(120,'Friend Assemblies',0,29),(121,'Public Assemblies',0,29),(122,'Protected Assemblies',0,29),(123,'Code managé',1,30),(124,'Non managé',0,30),(125,'Distribué',0,30),(126,'Héritage',0,30),(127,'Code natif',0,30),(128,'System.Object',1,31),(129,'System.Type',0,31),(130,'System.Base',0,31),(131,'System.Parent',0,31),(132,'System.Root',0,31),(133,' Framework .NET utilise DCOM pour effectuer la transition entre le code managé et le code non managé.',1,32),(134,'Framework .NET utilise DCOM pour assurer l’interopérabilité des langues.',0,32),(135,' Framework .NET repose sur la technologie DCOM.',0,32),(136,'Framework .NET utilise DCOM pour créer des applications non managées.',0,32),(137,'Framework .NET utilise les services COM+ lors de la création des applications distribuées.',0,32),(138,' Le type de sécurité du code exécuté sous CLR est assuré.',1,33),(139,' Il est garanti qu’une application n’accédera pas à la mémoire à laquelle elle n’est pas autorisée à accéder.',0,33),(140,'Il lance un processus distinct pour chaque application exécutée sous ce dernier.',0,33),(141,' Les ressources sont récupérées.',0,33),(142,'Sécurité d’accès au code',1,34),(143,' Sécurité basée sur les rôles',1,34),(144,'Sécurité PIN',0,34),(145,'Sécurité de l’authentification',0,34),(146,' Sécurité Biorythme',0,34),(147,'Il fournit des services de base tels que la gestion de la mémoire, la gestion des threads et la communication à distance.',1,35),(148,' Il applique une sécurité de type stricte.',1,35),(149,'Il fournit une sécurité d’accès au code.',1,35),(150,' Il fournit des services de Garbage Collection.',1,35),(151,'C’est la plus petite unité déployable.',1,36),(152,' Chaque assemblage n’a qu’un seul point d’entrée – Main(), WinMain() ou DLLMain().',1,36),(153,'Un assembly peut être un assembly partagé ou un assembly privé.',1,36),(154,'Un assembly ne peut contenir que du code et des données.',0,36),(155,'Un assembly est toujours sous la forme d’un fichier EXE.',0,36),(156,'Pre-JIT',1,37),(157,' Econo-JT',1,37),(158,'Normal-JIT',1,37),(159,'Trois',1,38),(160,'Deux',0,38),(161,' Cinq',0,38),(162,'Quatre',0,38),(163,'Le compilateur JIT compile les instructions en code machine au moment de l’exécution.',1,39),(164,' Le code compilé par le compilateur JIT s’exécute sous CLR.',1,39),(165,'Les instructions compilées par les compilateurs JIT sont écrites en code natif',1,39),(166,'Les instructions compilées par les compilateurs JIT sont écrites en code IL (Intermediate Language).',0,39),(167,'Common Language Runtime (CLR)',1,40),(168,'Framework Class Libraries (FCL)',1,40),(169,'Microsoft Published Web Services',0,40),(170,' Les applications déployées sur IIS',0,40),(171,'Les applications mobiles',0,40),(172,'Panneau des Locals  ',1,41),(173,'Panneau Watch  ',0,41),(174,'Data Tip  ',0,41),(175,'Fenêtre Quick Watch  ',1,41),(176,'Point d’arrêt conditionnel',1,41),(177,'Panneau callstack (pile d’appels)',1,41),(178,'HTML  ',1,42),(179,'XAML  ',1,42),(180,'Text',1,42),(181,'JSON',1,42),(182,'UTF8',0,42),(183,'On ne peut pas. ',0,43),(184,'Avec un point d’arrêt conditionnel.  ',1,43),(185,'Avec un changement de couleur dans la fenêtre Quick Watch.  ',1,43),(186,'Avec un changement de couleur dans le panneau Locals.',1,43),(187,'Avec un changement de couleur dans le panneau Watch.',1,43),(188,'On ne peut pas.  ',0,44),(189,' On doit surcharger la méthode DebuggerString.  ',0,44),(190,'On doit surcharger la méthode ToDebugger. ',0,44),(191,'On doit surcharger la méthode StringDebugger.',1,44),(192,'On doit surcharger la méthode ToString.',0,44),(193,'En attendant qu\'elle se produise durant l\'exécution.',1,45),(194,'En attendant qu\'elle se produise dans une session de débogage.',1,45),(195,'En utilisant les informations affichées dans le panneau du Test Explorer.',0,45),(196,'En paramétrant le débogueur pour s\'arrêter lorsque l\'exception est levée lors d\'une session de débogage.',1,45),(197,'En exécutant toutes les instructions pas à pas jusqu\'à ce que l\'exception se produise.',1,45),(198,'Oui',1,46),(199,'Non',0,46),(200,'break',1,47),(201,'goto',1,47),(202,'exit while',0,47),(203,'continue',0,47),(204,'exit statement',0,47),(205,'L’instruction « if » réagit en fonction de la valeur d’une expression booléenne.',1,48),(206,'L’instruction « switch » peut agir sur les types : char, string et enum.',0,48),(207,' L’instruction « switch » peut avoir deux cas ayant la même valeur.',0,48),(208,'Un assembly ne peut contenir que du code et des données.',0,48),(209,'L’instruction « switch » peut agir aussi bien sur les types numériques que sur les types booléens.',1,49),(210,'L’instruction « switch » peut agir sur les types : char, string et enum.',0,49),(211,'une classe',1,50),(212,'un objet',0,50),(213,'une variable',0,50),(214,'un tableau de char',0,50),(215,'charAt()',1,51),(216,'Charat()',0,51),(217,'charat()',0,51),(218,'char()',0,51),(219,'equals()',1,52),(220,'equal()',0,52),(221,'isequals()',0,52),(222,'isequal()',0,52),(223,'super',1,53),(224,'this',0,53),(225,' upper',0,53),(226,'Les chaînes en java sont mutables',1,54),(227,' String est une classe',0,54),(228,' Chaque chaîne est un objet de classe String',0,54),(229,' Java définit une classe appelée StringBuffer, qui permet de modifier une chaîne.',0,54),(230,'+',1,55),(231,'=+',0,55),(232,'&',0,55),(233,'length()',1,56),(234,'lengthof()',0,56),(235,'Sizeof()',0,56),(236,'get()',0,56),(237,'String()',1,57),(238,'String(0)',0,57),(239,'String(void)',0,57),(240,'startsWith()',1,58),(241,'endsWith(',0,58),(242,' Starts()',0,58),(243,' start()',0,58),(244,'zéro',1,59),(245,'valeur supérieure à zéro',1,59),(246,'valeur inférieure à zéro',0,59),(247,'char',1,60),(248,'int',1,60),(249,'boolean',0,60),(250,'java.lang.String',1,61),(251,'java.lang.util',1,61),(252,'java.lang.Object',0,61),(253,'une valeur entière',1,62),(254,'true',0,62),(255,'false',0,62),(256,'1',0,62),(257,'-1',0,62),(258,'substring()',1,63),(259,'Substring()',0,63),(260,'SubString()',0,63),(261,' Trim()',1,64),(262,'startsWith()',1,64),(263,'empty()',1,64),(264,'trim()',0,64),(265,' StringBuffer()',1,65),(266,' String()',0,65),(267,'Le deux',0,65),(268,'length()',1,66),(269,'Length()',0,66),(270,'size()',0,66),(271,'Size()',0,66),(272,'capacity()',0,66),(273,'Capacity()',0,66),(274,'La méthode reverse() inverse tous les caractères.',1,67),(275,'La méthode reverseall() inverse tous les caractères.',0,67),(276,'La méthode replace() remplace la première occurrence d’un caractère dans une chaîne par un autre caractère.',0,67),(277,' La méthode replace() remplace la dernière occurrence d’un caractère dans une chaîne par un autre caractère.',0,67),(278,'StringBuffer(int size , String str)',1,68),(279,'StringBuffer(String str)',0,68),(280,' StringBuffer(int size)',0,68),(281,'StringBuffer()',0,68),(282,'1',1,69),(283,'20',0,69),(284,'15',1,69),(285,'13',0,69),(286,'10',1,69),(287,'reponse ok',1,70),(288,'reponse ko',1,70),(289,'reponse OK',1,71),(290,'reponse KO',0,71);
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
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reponse_candidat`
--

LOCK TABLES `reponse_candidat` WRITE;
/*!40000 ALTER TABLE `reponse_candidat` DISABLE KEYS */;
INSERT INTO `reponse_candidat` VALUES (34,'152',4,36),(35,'153',4,36),(36,'200',4,47),(37,'201',4,47),(38,'205',4,48),(39,'209',4,49);
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

-- Dump completed on 2021-03-18 14:11:00
