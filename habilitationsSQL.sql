-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 21 avr. 2023 à 13:44
-- Version du serveur :  5.7.31
-- Version de PHP : 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : habilitations
--
CREATE DATABASE IF NOT EXISTS habilitations DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
CREATE USER 'habilitations'@'%' IDENTIFIED BY 'motdepasseuser';
GRANT USAGE ON *.* TO 'habilitations'@'%';
GRANT ALL PRIVILEGES ON `habilitations`.* TO 'habilitations'@'%';
USE habilitations;

-- --------------------------------------------------------

--
-- Structure de la table developpeur
--

DROP TABLE IF EXISTS developpeur;
CREATE TABLE developpeur (
  iddeveloppeur int(11) NOT NULL,
  nom varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  prenom varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,
  tel varchar(15) COLLATE utf8_unicode_ci DEFAULT NULL,
  mail varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  pwd varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  idprofil int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table developpeur
--

INSERT INTO developpeur (iddeveloppeur, nom, prenom, tel, mail, pwd, idprofil) VALUES
(1, 'Nolan', 'Rooney', '09 65 36 85 44', 'Vivamus.non@egestasSedpharetra.org', '71f90b7c03aad530eafa769b2ad97cb333ca6dd455fce1080bc0b302e4231220', 5),
(2, 'Good', 'Lucy', '03 03 67 71 47', 'a.scelerisque@NullafacilisiSed.org', 'c939327ca16dcf97ca32521d8b834bf1de16573d21deda3bb2a337cf403787a6', 2),
(3, 'Blevins', 'Abel', '06 21 51 89 92', 'ipsum.Phasellus@sociosqu.edu', '3b17e2b513a94fc551bcaa6f8abba00f4cb52db9f5828689b8f8fefd9aaaba48', 3),
(4, 'Levine', 'Ira', '02 04 78 08 64', 'ridiculus.mus@ligulaelitpretium.net', '3a0eb3ea56e7f5e8f6f87aa9710717f8f0330060f8517b4249dab182d9b9d9c8', 2),
(5, 'Bailey', 'Burton', '09 70 53 44 50', 'Nunc.commodo.auctor@sollicitudinorci.org', 'ceb32b93931ce2ef0af1fcefb67c2e5ea38d67d3fb9424c53d53a0688381636f', 1),
(6, 'Delacruz', 'Owen', '04 60 51 48 15', 'in.aliquet@risusodio.edu', '6bf96b25f549f6dc3ef7f491c7ed763357a9baae5f392dfa0bb5b5c92747b954', 3),
(7, 'Garza', 'Jillian', '08 86 47 61 67', 'sem.eget.massa@hendreritconsectetuer.org', '2d49cda934944bfb136364f82d151585edfe3a78c9c988da451ea12a56fb956c', 4),
(8, 'West', 'Quintessa', '02 70 51 65 26', 'morbi.tristique@neque.net', '41a6741e9a0faee34fec1fce082d6c634d48b44aee0d15bee819d12917073df8', 1),
(9, 'Booth', 'Ryder', '08 53 71 05 71', 'porttitor.tellus@risusvariusorci.net', '59a286a9bbb686814b08ffc09917162dd03cafd0f90982a7d37abbbd809a9e7e', 3),
(10, 'Blackwell', 'Martena', '08 94 29 37 55', 'pellentesque@NulladignissimMaecenas.net', '1d39692d4ee10540bc02074e58a7fedcf00ec356a3f19ccd6d909bd9370394a8', 2),
(11, 'Paul', 'Harding', '02 79 83 05 14', 'placerat.augue.Sed@Donecfelis.edu', '818b5cc5f21d3e6e4e6071c06294528d44595022218446d8b79304d2b766327a', 1),
(12, 'Justice', 'Hamilton', '05 12 98 01 13', 'eros@sedpede.net', '5f9740dd7874801f460dfe0f92e5be0cf2cfd04088d7d5ab996c92a428d3ee8b', 5),
(13, 'Lawson', 'Yolanda', '05 69 69 73 20', 'elit@laciniaorci.edu', '9950fd2c5b1854dcf27d5f1c8cfcec3563c57694ba3ce6e4c3871c22836f8a50', 1),
(14, 'Moon', 'Kaseem', '09 46 08 25 44', 'auctor@eu.edu', '5fc165254f4f817ba6f8b6f80c08b3174c0fea225398b5b84c17c0af975feacf', 1),
(15, 'Solis', 'Justine', '03 82 07 14 43', 'penatibus@Utnec.co.uk', '7fc5e56ec97a6943a8e656a0b2480b92ed6bd25c8da6ec1775220ef925d79b7c', 4),
(16, 'Stuart', 'Ingrid', '09 29 08 45 60', 'consectetuer.adipiscing@eget.edu', '74452134eb5884242a688cd5214e50595e950b8ac83de37d4c75ff7582b5a798', 3),
(17, 'Barr', 'Wanda', '05 49 47 03 82', 'odio@Crasdolor.org', 'c0e17070d53e6b3362fa17221c1d501f7d7a76cacf69174d0a312a8159be6471', 4),
(18, 'Parker', 'Brooke', '05 33 06 99 16', 'dui@ipsumcursus.co.uk', '92039f1a7ad82575787e314975b24ac559b72031e5b7f84702e75821225f2929', 5),
(19, 'Valentine', 'Clinton', '05 08 28 27 67', 'id@atfringillapurus.edu', 'cef5c43e526793983cbd17f5c53ab76e48dc92584a83cbfa63820e82190fd8a5', 5),
(20, 'Hendrix', 'Christian', '08 09 24 53 25', 'Nunc.quis@tinciduntDonec.ca', '0ceec16c3d3170168bd3acfd48748d95eb98992c15399cd9a495ec2212f71bc2', 1);

-- --------------------------------------------------------

--
-- Structure de la table fonctionnalite
--

DROP TABLE IF EXISTS fonctionnalite;
CREATE TABLE fonctionnalite (
  idfonctionnalite int(11) NOT NULL,
  nom varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table fonctionnalite
--

INSERT INTO fonctionnalite (idfonctionnalite, nom) VALUES
(1, 'CSS'),
(2, 'HTML'),
(3, 'JavaScript'),
(4, 'PHP');

-- --------------------------------------------------------

--
-- Structure de la table habilitation
--

DROP TABLE IF EXISTS habilitation;
CREATE TABLE habilitation (
  idfonctionnalite int(11) NOT NULL,
  idoperation int(11) NOT NULL,
  idprofil int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table habilitation
--

INSERT INTO habilitation (idfonctionnalite, idoperation, idprofil) VALUES
(1, 1, 1),
(1, 1, 2),
(1, 1, 3),
(1, 1, 4),
(1, 2, 2),
(1, 2, 3),
(1, 3, 5),
(2, 1, 1),
(2, 1, 2),
(2, 1, 3),
(2, 1, 4),
(2, 2, 3),
(2, 2, 4),
(2, 3, 5),
(3, 1, 1),
(3, 1, 2),
(3, 1, 3),
(3, 1, 4),
(3, 2, 3),
(3, 2, 4),
(3, 3, 5),
(4, 1, 1),
(4, 1, 2),
(4, 1, 3),
(4, 1, 4),
(4, 2, 4),
(4, 3, 5);

-- --------------------------------------------------------

--
-- Structure de la table operation
--

DROP TABLE IF EXISTS operation;
CREATE TABLE operation (
  idoperation int(11) NOT NULL,
  nom varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table operation
--

INSERT INTO operation (idoperation, nom) VALUES
(1, 'consulter'),
(2, 'modifier'),
(3, 'administrer');

-- --------------------------------------------------------

--
-- Structure de la table profil
--

DROP TABLE IF EXISTS profil;
CREATE TABLE profil (
  idprofil int(11) NOT NULL,
  nom varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Déchargement des données de la table profil
--

INSERT INTO profil (idprofil, nom) VALUES
(1, 'stagiaire'),
(2, 'designer'),
(3, 'dev-front'),
(4, 'dev-back'),
(5, 'admin');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table developpeur
--
ALTER TABLE developpeur
  ADD PRIMARY KEY (iddeveloppeur),
  ADD KEY idprofil (idprofil);

--
-- Index pour la table fonctionnalite
--
ALTER TABLE fonctionnalite
  ADD PRIMARY KEY (idfonctionnalite);

--
-- Index pour la table habilitation
--
ALTER TABLE habilitation
  ADD PRIMARY KEY (idfonctionnalite,idoperation,idprofil),
  ADD KEY idoperation (idoperation),
  ADD KEY idprofil (idprofil);

--
-- Index pour la table operation
--
ALTER TABLE operation
  ADD PRIMARY KEY (idoperation);

--
-- Index pour la table profil
--
ALTER TABLE profil
  ADD PRIMARY KEY (idprofil);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table developpeur
--
ALTER TABLE developpeur
  MODIFY iddeveloppeur int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT pour la table fonctionnalite
--
ALTER TABLE fonctionnalite
  MODIFY idfonctionnalite int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table operation
--
ALTER TABLE operation
  MODIFY idoperation int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table profil
--
ALTER TABLE profil
  MODIFY idprofil int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
