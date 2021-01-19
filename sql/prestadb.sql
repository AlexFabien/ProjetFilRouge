create database if not exists prestadb;
use prestadb;
drop table if exists role;
create table if not exists role
(	id_role int primary key not null auto_increment,
	nom_role varchar(15)
);
drop table if exists categorie_pro;
create table if not exists categorie_pro
(	id_categorie int primary key not null auto_increment,
	nom_categorie varchar(150),
    metier varchar(150),
    specialite varchar(200)
);
drop table if exists etape_prestation;
create table if not exists etape_prestation
(	id_etape_presta int primary key not null auto_increment,
	libelle_etape varchar(100),
    description varchar(255)
);
drop table if exists adresse;
create table if not exists adresse
(	id_adresse int primary key not null auto_increment,
	numero varchar(10),
    nom_rue varchar(150),
    code_postal int,
    ville varchar(100),
    departement varchar(150),
    region varchar(150)
);
drop table if exists compte;
create table if not exists compte
(	id_compte int primary key not null auto_increment,
	pseudo varchar(20),
    nom varchar(40),
    prenom varchar(40),
    email varchar(100),
    mot_de_passe varchar(100),
    telephone int,
    photo varchar(255),
    id_role int,
    id_categorie int,
    id_adresse int,
    constraint fk_role_id foreign key(id_role) references role(id_role),
    constraint fk_categorie_id foreign key(id_categorie) references categorie_pro(id_categorie),
    constraint fk_adresse_id foreign key(id_adresse) references adresse(id_adresse)
);
drop table if exists avis_cli_sur_presta;
create table if not exists avis_cli_sur_presta
(	id int primary key not null auto_increment,
	note int,
    commentaire text,
    id_compte int,
    constraint fk_compte_id foreign key(id_compte) references compte(id_compte)
);
drop table if exists tache;
create table if not exists tache
(	id_tache int primary key not null auto_increment,
	libelle varchar(150),
    description text,
    prix double,
    duree int
);
drop table if exists devis;
create table if not exists devis
(	id_devis int primary key not null auto_increment,
	reference_devis varchar(15),
    date_debut date,
    date_fin_estimee date
);
drop table if exists item_of_devis;
create table if not exists item_of_devis
(	id int primary key not null auto_increment,
	id_tache int,
    id_devis int,
    constraint fk_tache_id foreign key(id_tache) references tache(id_tache),
    constraint fk_devis_id foreign key(id_devis) references devis(id_devis)
);
drop table if exists suivi_tache;
create table if not exists suivi_tache
(	id int primary key not null auto_increment,
	date_debut date,
    date_fin date,
    id_tache int,
    constraint fk_suivi_tache_id foreign key(id_tache) references tache(id_tache)
);
drop table if exists statut_prestation;
create table if not exists statut_prestation
(	id int primary key not null auto_increment,
	id_devis int,
    id_tache int,
    id_etape_presta int,
    constraint fk_statut_devis_id foreign key(id_devis) references devis(id_devis),
    constraint fk_statut_tache_id foreign key(id_tache) references tache(id_tache),
    constraint fk_statut_etape_presta_id foreign key(id_etape_presta) references etape_prestation(id_etape_presta)
);