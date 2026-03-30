-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 30, 2026 at 08:02 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `autoservice`
--

-- --------------------------------------------------------

--
-- Table structure for table `cars`
--

CREATE TABLE `cars` (
  `Id_car` int(11) NOT NULL,
  `Brand` varchar(30) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Release_Year` date NOT NULL,
  `Gos_number` varchar(10) NOT NULL,
  `Id_Client` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cars`
--

INSERT INTO `cars` (`Id_car`, `Brand`, `Model`, `Release_Year`, `Gos_number`, `Id_Client`) VALUES
(1, 'BMW', 'X5', '2018-01-01', 'MDABC123', 1),
(2, 'Audi', 'A6', '2017-01-01', 'MDBCD234', 2),
(3, 'Toyota', 'Corolla', '2020-01-01', 'MDCDE345', 3),
(4, 'Mercedes', 'C200', '2019-01-01', 'MDDEF456', 4),
(5, 'Volkswagen', 'Passat', '2016-01-01', 'MDEFG567', 5),
(6, 'Ford', 'Focus', '2015-01-01', 'MDFGH678', 6),
(7, 'Honda', 'Civic', '2021-01-01', 'MDGHI789', 7),
(8, 'Hyundai', 'Elantra', '2018-01-01', 'MDHIJ890', 8),
(9, 'Kia', 'Sportage', '2022-01-01', 'MDIJK901', 9),
(10, 'Skoda', 'Octavia', '2019-01-01', 'MDJKL012', 10);

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `Id_client` int(11) NOT NULL,
  `Surname` varchar(30) NOT NULL,
  `Name` varchar(30) NOT NULL,
  `Phonenumber` varchar(10) NOT NULL,
  `Address` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`Id_client`, `Surname`, `Name`, `Phonenumber`, `Address`) VALUES
(1, 'Popescu', 'Ion', '079111111', 'Chisinau, Botanica'),
(2, 'Ionescu', 'Maria', '079222222', 'Chisinau, Riscani'),
(3, 'Rusu', 'Andrei', '079333333', 'Chisinau, Centru'),
(4, 'Munteanu', 'Elena', '079444444', 'Balti'),
(5, 'Ceban', 'Victor', '079555555', 'Cahul'),
(6, 'Luca', 'Ana', '079666666', 'Orhei'),
(7, 'Moraru', 'Sergiu', '079777777', 'Ungheni'),
(8, 'Balan', 'Cristina', '079888888', 'Soroca'),
(9, 'Sandu', 'Dumitru', '079999999', 'Comrat'),
(10, 'Grosu', 'Natalia', '078000000', 'Edinet');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`Id_car`),
  ADD KEY `Id_Client` (`Id_Client`);

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Id_client`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cars`
--
ALTER TABLE `cars`
  MODIFY `Id_car` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `Id_client` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cars`
--
ALTER TABLE `cars`
  ADD CONSTRAINT `cars_ibfk_1` FOREIGN KEY (`Id_Client`) REFERENCES `clients` (`Id_client`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
