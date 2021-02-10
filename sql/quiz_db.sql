-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema quiz
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema quiz
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `quiz` DEFAULT CHARACTER SET utf8 ;
USE `quiz` ;

-- -----------------------------------------------------
-- Table `quiz`.`role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`role` (
  `id_role` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  PRIMARY KEY (`id_role`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`acteur`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`acteur` (
  `id_acteur` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(255) NULL,
  `prenom` VARCHAR(255) NULL,
  `email` VARCHAR(255) NULL,
  `password` VARCHAR(255) NULL,
  `id_role` INT NULL,
  PRIMARY KEY (`id_acteur`),
  INDEX `fk_Utilisateur_Role1_idx` (`id_role` ASC) VISIBLE,
  CONSTRAINT `fk_Utilisateur_Role1`
    FOREIGN KEY (`id_role`)
    REFERENCES `quiz`.`role` (`id_role`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`niveau`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`niveau` (
  `id_niveau` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(45) NULL,
  PRIMARY KEY (`id_niveau`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`type_question`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`type_question` (
  `id_type_question` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(45) NULL,
  PRIMARY KEY (`id_type_question`))
ENGINE = InnoDB
COMMENT = '			';


-- -----------------------------------------------------
-- Table `quiz`.`technologie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`technologie` (
  `id_technologie` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(45) NULL,
  PRIMARY KEY (`id_technologie`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`quiz`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`quiz` (
  `id_quiz` INT NOT NULL AUTO_INCREMENT,
  `id_technologie` INT NULL,
  `id_niveau` INT NULL,
  PRIMARY KEY (`id_quiz`),
  INDEX `fk_Quiz_Niveau1_idx` (`id_niveau` ASC) VISIBLE,
  INDEX `fk_Quiz_technologie1_idx` (`id_technologie` ASC) VISIBLE,
  CONSTRAINT `fk_Quiz_Niveau1`
    FOREIGN KEY (`id_niveau`)
    REFERENCES `quiz`.`niveau` (`id_niveau`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Quiz_technologie1`
    FOREIGN KEY (`id_technologie`)
    REFERENCES `quiz`.`technologie` (`id_technologie`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`question`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`question` (
  `id_question` INT NOT NULL AUTO_INCREMENT,
  `libelle` TEXT NULL,
  `explication_reponse` TEXT NULL,
  `id_niveau` INT NULL,
  `id_type_question` INT NULL,
  `id_quiz` INT NULL,
  PRIMARY KEY (`id_question`),
  INDEX `fk_Questions_Niveau1_idx` (`id_niveau` ASC) VISIBLE,
  INDEX `fk_Questions_TypeQuestion1_idx` (`id_type_question` ASC) VISIBLE,
  INDEX `fk_question_quiz1_idx` (`id_quiz` ASC) VISIBLE,
  CONSTRAINT `fk_Questions_Niveau1`
    FOREIGN KEY (`id_niveau`)
    REFERENCES `quiz`.`niveau` (`id_niveau`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Questions_TypeQuestion1`
    FOREIGN KEY (`id_type_question`)
    REFERENCES `quiz`.`type_question` (`id_type_question`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_question_quiz1`
    FOREIGN KEY (`id_quiz`)
    REFERENCES `quiz`.`quiz` (`id_quiz`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`reponse_candidat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`reponse_candidat` (
  `id_reponse_candidat` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(255) NULL,
  PRIMARY KEY (`id_reponse_candidat`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`acteur_has_quiz`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`acteur_has_quiz` (
  `id_acteur` INT NOT NULL,
  `id_quiz` INT NOT NULL,
  PRIMARY KEY (`id_acteur`, `id_quiz`),
  INDEX `fk_Utilisateur_has_Quiz_Quiz1_idx` (`id_quiz` ASC) VISIBLE,
  INDEX `fk_Utilisateur_has_Quiz_Utilisateur1_idx` (`id_acteur` ASC) VISIBLE,
  CONSTRAINT `fk_Utilisateur_has_Quiz_Utilisateur1`
    FOREIGN KEY (`id_acteur`)
    REFERENCES `quiz`.`acteur` (`id_acteur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Utilisateur_has_Quiz_Quiz1`
    FOREIGN KEY (`id_quiz`)
    REFERENCES `quiz`.`quiz` (`id_quiz`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`reponse`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`reponse` (
  `id_reponse` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(255) NULL,
  `reponse_correcte` TINYINT NULL,
  `id_question` INT NULL,
  PRIMARY KEY (`id_reponse`),
  INDEX `fk_Reponse_Questions1_idx` (`id_question` ASC) VISIBLE,
  CONSTRAINT `fk_Reponse_Questions1`
    FOREIGN KEY (`id_question`)
    REFERENCES `quiz`.`question` (`id_question`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`parametrage`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`parametrage` (
  `id_parametrage` INT NOT NULL,
  `valeur` VARCHAR(150) NULL,
  PRIMARY KEY (`id_parametrage`))
ENGINE = InnoDB
COMMENT = '	';


-- -----------------------------------------------------
-- Table `quiz`.`ventillation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`ventillation` (
  `id_niveau_quiz` INT NOT NULL,
  `id_niveau_question` INT NOT NULL,
  `valeur` INT NULL,
  PRIMARY KEY (`id_niveau_quiz`, `id_niveau_question`),
  INDEX `fk_ventillation_Niveau1_idx` (`id_niveau_quiz` ASC) VISIBLE,
  INDEX `fk_ventillation_Niveau2_idx` (`id_niveau_question` ASC) VISIBLE,
  CONSTRAINT `fk_ventillation_Niveau1`
    FOREIGN KEY (`id_niveau_quiz`)
    REFERENCES `quiz`.`niveau` (`id_niveau`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ventillation_Niveau2`
    FOREIGN KEY (`id_niveau_question`)
    REFERENCES `quiz`.`niveau` (`id_niveau`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = '	';


-- -----------------------------------------------------
-- Table `quiz`.`repondu`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`repondu` (
  `id_etat_reponse` INT NOT NULL AUTO_INCREMENT,
  `libelle` VARCHAR(45) NULL,
  PRIMARY KEY (`id_etat_reponse`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `quiz`.`acteur_has_question`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `quiz`.`acteur_has_question` (
  `id_acteur` INT NOT NULL,
  `id_question` INT NOT NULL,
  `commentaire` TEXT NULL,
  `id_etat_reponse` INT NULL,
  `id_reponse_candidat` INT NULL,
  PRIMARY KEY (`id_acteur`, `id_question`),
  INDEX `fk_utilisateur_has_question_question1_idx` (`id_question` ASC) VISIBLE,
  INDEX `fk_utilisateur_has_question_utilisateur1_idx` (`id_acteur` ASC) VISIBLE,
  INDEX `fk_utilisateur_has_question_repondu1_idx` (`id_etat_reponse` ASC) VISIBLE,
  INDEX `fk_utilisateur_has_question_reponse_candidat1_idx` (`id_reponse_candidat` ASC) VISIBLE,
  CONSTRAINT `fk_utilisateur_has_question_utilisateur1`
    FOREIGN KEY (`id_acteur`)
    REFERENCES `quiz`.`acteur` (`id_acteur`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_utilisateur_has_question_question1`
    FOREIGN KEY (`id_question`)
    REFERENCES `quiz`.`question` (`id_question`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_utilisateur_has_question_repondu1`
    FOREIGN KEY (`id_etat_reponse`)
    REFERENCES `quiz`.`repondu` (`id_etat_reponse`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_utilisateur_has_question_reponse_candidat1`
    FOREIGN KEY (`id_reponse_candidat`)
    REFERENCES `quiz`.`reponse_candidat` (`id_reponse_candidat`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
