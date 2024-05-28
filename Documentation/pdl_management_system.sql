-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 28, 2024 at 02:21 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pdl_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `admin_key` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`admin_key`, `username`, `password`) VALUES
('12345678', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `appointment`
--

CREATE TABLE `appointment` (
  `username` varchar(255) NOT NULL,
  `pdl_first_name` varchar(255) NOT NULL,
  `pdl_last_name` varchar(255) NOT NULL,
  `appointment_date` date NOT NULL,
  `appointment_time` time NOT NULL,
  `request_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`username`, `pdl_first_name`, `pdl_last_name`, `appointment_date`, `appointment_time`, `request_id`) VALUES
('Test', 'Oliver', 'Davis', '2024-05-25', '02:28:00', 6),
('Test', 'Oliver', 'Davis', '2024-05-25', '20:10:00', 9);

-- --------------------------------------------------------

--
-- Table structure for table `appointment_requests`
--

CREATE TABLE `appointment_requests` (
  `request_id` int(11) NOT NULL,
  `visitor_username` varchar(255) NOT NULL,
  `requested_date` date NOT NULL,
  `requested_time` time NOT NULL,
  `status_id` int(11) NOT NULL,
  `pdl_first_name` varchar(255) NOT NULL,
  `pdl_last_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointment_requests`
--

INSERT INTO `appointment_requests` (`request_id`, `visitor_username`, `requested_date`, `requested_time`, `status_id`, `pdl_first_name`, `pdl_last_name`) VALUES
(6, 'Test', '2024-05-25', '02:28:00', 2, 'Oliver', 'Davis'),
(9, 'Test', '2024-05-25', '20:10:00', 2, 'Oliver', 'Davis'),
(10, 'Test', '2024-05-31', '12:53:00', 3, 'James', 'Wilson'),
(12, 'Test', '2024-05-25', '12:08:00', 1, 'Ava', 'Davis'),
(13, 'Test', '0000-00-00', '00:00:00', 1, 'Ava', 'Davis'),
(14, 'Test', '2024-05-04', '06:00:00', 1, 'Ava', 'Davis'),
(15, 'Test', '2024-05-25', '09:43:00', 1, 'Ava', 'Davis'),
(16, 'Test', '2024-05-28', '19:09:00', 1, 'James', 'Wilson');

-- --------------------------------------------------------

--
-- Table structure for table `appointment_status`
--

CREATE TABLE `appointment_status` (
  `status_id` int(11) NOT NULL,
  `status_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointment_status`
--

INSERT INTO `appointment_status` (`status_id`, `status_name`) VALUES
(1, 'Pending'),
(2, 'Approved'),
(3, 'Declined');

-- --------------------------------------------------------

--
-- Table structure for table `cell_block_list`
--

CREATE TABLE `cell_block_list` (
  `cellblock_id` varchar(255) NOT NULL,
  `cell_capacity` varchar(255) NOT NULL,
  `gender_unit` enum('Male','Female','','') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cell_block_list`
--

INSERT INTO `cell_block_list` (`cellblock_id`, `cell_capacity`, `gender_unit`) VALUES
('!NO_CELLBLOCK', '999999', ''),
('!RELEASED', '999999', ''),
('0001', '5', 'Male'),
('0002', '6', 'Female'),
('0003', '5', 'Male'),
('0004', '5', 'Female'),
('0005', '5', 'Male'),
('0006', '5', 'Male'),
('0007', '5', 'Female'),
('0008', '5', 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `pdl_list`
--

CREATE TABLE `pdl_list` (
  `case_num` varchar(50) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `status` enum('Active','Released','','') NOT NULL,
  `crime` varchar(255) NOT NULL,
  `gender` enum('Male','Female','','') NOT NULL,
  `date_birth` date NOT NULL,
  `sentence_years` varchar(255) NOT NULL,
  `cellblock_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pdl_list`
--

INSERT INTO `pdl_list` (`case_num`, `first_name`, `last_name`, `status`, `crime`, `gender`, `date_birth`, `sentence_years`, `cellblock_id`) VALUES
('001', 'Liame', 'Johnson', 'Released', 'Homicide', 'Male', '1970-08-22', '15 years', '!RELEASED'),
('002', 'Noah', 'Brown', 'Active', 'Robbery', 'Male', '1980-01-01', '10 years', '0006'),
('003', 'Oliver', 'Davis', 'Active', 'Fraud', 'Male', '1990-01-01', '7 years', '0001'),
('004', 'Luis', 'Ultimo', 'Active', 'Murder', 'Male', '1989-08-26', '30 Years', '0001'),
('005', 'James', 'Wilson', 'Active', 'Burglary', 'Male', '1985-01-01', '12 years', '0001'),
('006', 'William', 'Moore', 'Active', 'Drug Trafficking', 'Male', '1975-01-01', '15 years', '0003'),
('007', 'Benjamin', 'Taylor', 'Active', 'Embezzlement', 'Male', '1991-01-01', '10 years', '0003'),
('008', 'Lucas', 'Anderson', 'Active', 'Cybercrime', 'Male', '1988-01-01', '5 years', '0003'),
('009', 'Henry', 'Thomas', 'Active', 'Vandalism', 'Male', '2000-01-01', '2 years', '0003'),
('010', 'Alexander', 'Jackson', 'Active', 'Battery', 'Male', '1993-01-01', '4 years', '0003'),
('011', 'Olivia', 'Johnson', 'Active', 'Arson', 'Female', '1999-01-01', '10 years', '0002'),
('012', 'Emma', 'Brown', 'Active', 'Prostitution', 'Female', '1992-01-01', '3 years', '0002'),
('013', 'Ava', 'Davis', 'Active', 'Sexual Assault', 'Female', '1978-01-01', '15 years', '0002'),
('014', 'Charlotte', 'Miller', 'Active', 'Identity Theft', 'Female', '1987-01-01', '5 years', '0002'),
('015', 'Sophia', 'Wilson', 'Active', 'Domestic Violence', 'Female', '1994-01-01', '4 years', '0002'),
('016', 'Amelia', 'Moore', 'Active', 'Shoplifting', 'Female', '2002-01-01', '1 year', '0004'),
('017', 'Isabella', 'Taylor', 'Active', 'Weapons Charges', 'Female', '1986-01-01', '7 years', '0004'),
('018', 'Mia', 'Anderson', 'Active', 'Theft/Larceny', 'Female', '1990-01-01', '3 years', '0004'),
('019', 'Evelyn', 'Thomas', 'Active', 'Assault', 'Female', '1983-01-01', '5 years', '0004'),
('020', 'Harper', 'Jackson', 'Active', 'Drug Possession', 'Female', '1997-01-01', '2 years', '0004');

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE `reports` (
  `report_id` int(11) NOT NULL,
  `creation_date` date NOT NULL,
  `pdl_first_name` varchar(50) NOT NULL,
  `pdl_last_name` varchar(50) NOT NULL,
  `report_details` text NOT NULL,
  `case_num` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reports`
--

INSERT INTO `reports` (`report_id`, `creation_date`, `pdl_first_name`, `pdl_last_name`, `report_details`, `case_num`) VALUES
(14, '2024-05-25', 'Henry', 'Thomas', 'Add_Report', '009'),
(15, '2024-05-25', 'Mia', 'Anderson', 'Add_Report', '018'),
(17, '2024-05-26', 'Mia', 'Anderson', 'REPORT REPORT I DID SOMETHING', '018'),
(18, '2024-05-26', 'Sophia', 'Wilson', 'ADKASIDASKDIASJM', '015');

-- --------------------------------------------------------

--
-- Table structure for table `user_visitors`
--

CREATE TABLE `user_visitors` (
  `user_firstname` varchar(255) NOT NULL,
  `user_lastname` varchar(255) NOT NULL,
  `gender` enum('Male','Female','','') NOT NULL,
  `contact_num` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user_visitors`
--

INSERT INTO `user_visitors` (`user_firstname`, `user_lastname`, `gender`, `contact_num`, `username`, `email`, `password`) VALUES
('', '', '', '', '', '', ''),
('Test', 'Test', 'Male', '123123', 'Test', 'Test@gmail.com', 'Test'),
('Test1', 'Test1', 'Female', '09123456789', 'Test1', 'Test1@gmail.com', 'Test1'),
('Test2', 'Test2', '', 'Test2', 'Test2', 'Test2@gmail.com', 'Test2');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`admin_key`);

--
-- Indexes for table `appointment`
--
ALTER TABLE `appointment`
  ADD UNIQUE KEY `request_id` (`request_id`),
  ADD KEY `fk_username` (`username`);

--
-- Indexes for table `appointment_requests`
--
ALTER TABLE `appointment_requests`
  ADD PRIMARY KEY (`request_id`),
  ADD KEY `visitor_username` (`visitor_username`);

--
-- Indexes for table `appointment_status`
--
ALTER TABLE `appointment_status`
  ADD PRIMARY KEY (`status_id`);

--
-- Indexes for table `cell_block_list`
--
ALTER TABLE `cell_block_list`
  ADD UNIQUE KEY `cellblock_id` (`cellblock_id`);

--
-- Indexes for table `pdl_list`
--
ALTER TABLE `pdl_list`
  ADD UNIQUE KEY `case_num` (`case_num`),
  ADD KEY `fk_cellblock_id` (`cellblock_id`);

--
-- Indexes for table `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`report_id`);

--
-- Indexes for table `user_visitors`
--
ALTER TABLE `user_visitors`
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointment_requests`
--
ALTER TABLE `appointment_requests`
  MODIFY `request_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `appointment_status`
--
ALTER TABLE `appointment_status`
  MODIFY `status_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `report_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `appointment`
--
ALTER TABLE `appointment`
  ADD CONSTRAINT `fk_request_id` FOREIGN KEY (`request_id`) REFERENCES `appointment_requests` (`request_id`) ON DELETE NO ACTION ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_username` FOREIGN KEY (`username`) REFERENCES `user_visitors` (`username`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Constraints for table `appointment_requests`
--
ALTER TABLE `appointment_requests`
  ADD CONSTRAINT `appointment_requests_ibfk_1` FOREIGN KEY (`visitor_username`) REFERENCES `user_visitors` (`username`) ON DELETE CASCADE;

--
-- Constraints for table `pdl_list`
--
ALTER TABLE `pdl_list`
  ADD CONSTRAINT `fk_cellblock_id` FOREIGN KEY (`cellblock_id`) REFERENCES `cell_block_list` (`cellblock_id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
