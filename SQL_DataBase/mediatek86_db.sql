-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mer. 30 avr. 2025 à 20:08
-- Version du serveur : 9.1.0
-- Version de PHP : 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86_db`
--
CREATE DATABASE IF NOT EXISTS `mediatek86_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `mediatek86_db`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2025-04-01 08:00:00', '2025-04-15 18:00:00', 1),
(2, '2025-05-10 09:00:00', '2025-05-20 18:00:00', 2),
(3, '2025-06-05 08:30:00', '2025-06-10 17:00:00', 3),
(4, '2025-07-15 08:00:00', '2025-07-25 18:00:00', 1),
(5, '2025-08-03 09:00:00', '2025-08-12 18:00:00', 4),
(6, '2025-09-20 08:00:00', '2025-09-30 18:00:00', 2),
(7, '2025-10-12 08:00:00', '2025-10-22 18:00:00', 1),
(8, '2025-11-01 08:00:00', '2025-11-15 18:00:00', 3),
(9, '2025-12-07 08:00:00', '2025-12-17 18:00:00', 4),
(10, '2025-01-25 08:00:00', '2025-02-05 18:00:00', 1),
(1, '2025-02-10 08:00:00', '2025-02-20 18:00:00', 2),
(2, '2025-03-01 09:00:00', '2025-03-10 18:00:00', 3),
(3, '2025-04-15 08:30:00', '2025-04-25 17:00:00', 1),
(4, '2025-05-20 08:00:00', '2025-05-30 18:00:00', 4),
(5, '2025-06-10 09:00:00', '2025-06-20 18:00:00', 2),
(6, '2025-07-05 08:00:00', '2025-07-15 18:00:00', 1),
(7, '2025-08-12 08:00:00', '2025-08-22 18:00:00', 3),
(8, '2025-09-01 08:00:00', '2025-09-15 18:00:00', 4),
(9, '2025-10-07 08:00:00', '2025-10-17 18:00:00', 1),
(10, '2025-11-25 08:00:00', '2025-12-05 18:00:00', 2),
(1, '2025-12-10 08:00:00', '2025-12-20 18:00:00', 3),
(2, '2025-01-05 09:00:00', '2025-01-15 18:00:00', 4),
(3, '2025-02-20 08:30:00', '2025-03-01 17:00:00', 1),
(4, '2025-03-10 08:00:00', '2025-03-20 18:00:00', 2),
(5, '2025-04-25 09:00:00', '2025-05-05 18:00:00', 3),
(6, '2025-05-15 08:00:00', '2025-05-25 18:00:00', 4),
(7, '2025-06-02 08:00:00', '2025-06-12 18:00:00', 1),
(8, '2025-07-20 08:00:00', '2025-07-30 18:00:00', 2),
(9, '2025-08-05 08:00:00', '2025-08-15 18:00:00', 3),
(10, '2025-09-12 08:00:00', '2025-09-22 18:00:00', 4),
(1, '2025-10-10 08:00:00', '2025-10-20 18:00:00', 1),
(2, '2025-11-01 08:00:00', '2025-11-11 18:00:00', 2),
(3, '2025-12-07 08:30:00', '2025-12-17 17:00:00', 3),
(4, '2025-01-15 08:00:00', '2025-01-25 18:00:00', 4),
(5, '2025-02-25 09:00:00', '2025-03-05 18:00:00', 1),
(6, '2025-03-10 08:00:00', '2025-03-20 18:00:00', 2),
(7, '2025-04-07 08:00:00', '2025-04-17 18:00:00', 3),
(8, '2025-05-12 08:00:00', '2025-05-22 18:00:00', 4),
(9, '2025-06-25 08:00:00', '2025-07-05 18:00:00', 1),
(10, '2025-08-10 08:00:00', '2025-08-20 18:00:00', 2),
(1, '2025-09-15 08:00:00', '2025-09-25 18:00:00', 3),
(2, '2025-10-07 08:00:00', '2025-10-17 18:00:00', 4),
(3, '2025-11-20 08:00:00', '2025-11-30 18:00:00', 1),
(4, '2025-12-05 08:00:00', '2025-12-15 18:00:00', 2),
(5, '2025-01-10 08:00:00', '2025-01-20 18:00:00', 3),
(6, '2025-02-12 08:00:00', '2025-02-22 18:00:00', 4);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Bryant', 'Brady', '1-852-852-6771', 'congue@icloud.edu', 1),
(2, 'Barlow', 'Hop', '1-111-736-1177', 'turpis.nulla.aliquet@aol.edu', 2),
(3, 'Smith', 'Chester', '1-145-441-2397', 'proin@protonmail.couk', 3),
(4, 'Waller', 'Clinton', '1-942-442-5756', 'ut.lacus@yahoo.net', 4),
(5, 'Hartman', 'Hop', '1-921-835-0637', 'lectus.rutrum@protonmail.couk', 5),
(6, 'Wooten', 'Clio', '(128) 529-3760', 'metus.sit@hotmail.couk', 6),
(7, 'Gilbert', 'Jacqueline', '1-676-513-6456', 'per@yahoo.org', 7),
(8, 'Simon', 'Melyssa', '(456) 832-7327', 'egestas.lacinia@hotmail.edu', 8),
(9, 'Salinas', 'Eaton', '1-235-957-1432', 'ultrices.posuere@hotmail.com', 9),
(10, 'Pope', 'Gillian', '(478) 613-8040', 'cras.dolor@protonmail.edu', 10);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('Mediatek86_Admin', 'dce26a91a42909b899636c38b40bc50438016b6fcc9d64d9f01e102aa9bd53c5');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

CREATE USER 'Mediatek86_Admin'@'localhost' IDENTIFIED BY 'GEd(E[*-zmK9w6W7';
GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, ALTER ON *.* TO `Mediatek86_Admin`@`%localhost`;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
