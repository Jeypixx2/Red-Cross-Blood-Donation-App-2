-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 17, 2025 at 03:21 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `redcrossdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE `accounts` (
  `adminID` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `dt_created` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`adminID`, `username`, `password`, `dt_created`) VALUES
(1, 'admin', 'pIbvhgmpVHahDBTYUgQvew==', '2024-12-09'),
(2, 'admin1', 'Lj/0jKeGO5+TuqLM3fMV3w==', '2024-12-09'),
(3, 'admin1', 'Lj/0jKeGO5+TuqLM3fMV3w==', '2024-12-24'),
(4, 'admin56', 'sBalC2SckJsS5IRhTqckjw==', '2025-03-04');

-- --------------------------------------------------------

--
-- Table structure for table `accountssuperadmin`
--

CREATE TABLE `accountssuperadmin` (
  `adminID` int(11) NOT NULL,
  `username` varchar(225) NOT NULL,
  `password` varchar(225) NOT NULL,
  `dt_created` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `accountssuperadmin`
--

INSERT INTO `accountssuperadmin` (`adminID`, `username`, `password`, `dt_created`) VALUES
(1, 'admin', 'pIbvhgmpVHahDBTYUgQvew==', '2025-03-09');

-- --------------------------------------------------------

--
-- Table structure for table `adminlogs`
--

CREATE TABLE `adminlogs` (
  `logsID` int(11) NOT NULL,
  `dt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `user_acounts_id` int(11) NOT NULL,
  `event` varchar(255) NOT NULL,
  `transactions` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `admin_account`
--

CREATE TABLE `admin_account` (
  `adminID` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin_account`
--

INSERT INTO `admin_account` (`adminID`, `username`, `password`) VALUES
(1, 'ajuju', 'julius'),
(2, 'admin', 'admin'),
(3, 'Admin21', 'WB6/w1cKMZ5TAMaZOdEMdAXD6zzVyFOeQ0QzKGQgA8k='),
(4, 'admin', 'pIbvhgmpVHahDBTYUgQvew==');

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `BloodID` int(11) NOT NULL,
  `DonorID` int(11) NOT NULL,
  `Blood_Group` varchar(10) NOT NULL,
  `RhesusFactor` varchar(255) NOT NULL,
  `CollectionMethod` varchar(255) NOT NULL,
  `BloodVolume` int(11) NOT NULL,
  `DonationType` varchar(255) NOT NULL,
  `DonationDate` date NOT NULL,
  `DonationTime` time NOT NULL,
  `NextEligibilityDate` date NOT NULL,
  `BloodComponent` varchar(255) NOT NULL,
  `Compatibility` varchar(255) NOT NULL,
  `BagType` varchar(255) NOT NULL,
  `Expiration_Date` date NOT NULL,
  `StorageLocation` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `donation`
--

INSERT INTO `donation` (`BloodID`, `DonorID`, `Blood_Group`, `RhesusFactor`, `CollectionMethod`, `BloodVolume`, `DonationType`, `DonationDate`, `DonationTime`, `NextEligibilityDate`, `BloodComponent`, `Compatibility`, `BagType`, `Expiration_Date`, `StorageLocation`) VALUES
(1, 1, 'A', 'Rh-', 'Automatic Collection', 300, 'Platelet Donation (Apheresis)', '2025-06-17', '09:21:33', '2025-10-01', 'Platelets', 'A+, A-, AB+, AB-', 'Aphresis', '2025-06-22', 'Platelet Storage'),
(2, 2, 'AB', 'Rh+', 'Automatic Collection', 400, 'Red Blood Cell Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-09-18', 'Red Blood Cells', 'AB+', 'Quadruple Bag', '2025-07-29', 'Refrigerated Storage'),
(3, 3, 'A', 'Rh+', 'Automatic Collection', 500, 'Plasma Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-15', 'Plasma', 'A+, AB+', 'Triple Bag', '2026-06-17', 'Frozen Storage'),
(4, 4, 'B', 'Rh+', 'Manual Collection', 600, 'Whole Blood Donation', '2025-06-17', '09:21:34', '2025-10-07', 'Whole Blood', 'B+, AB+', 'Single Bag', '2025-07-29', 'Refrigerated Storage'),
(5, 5, 'B', 'Rh-', 'Manual Collection', 200, 'Whole Blood Donation', '2025-06-17', '09:21:34', '2025-09-26', 'Whole Blood', 'B+, B-, AB+, AB-', 'Aphresis', '2025-07-29', 'Refrigerated Storage'),
(6, 6, 'A', 'Rh+', 'Automatic Collection', 200, 'White Blood Cell Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-09-29', 'White Blood Cells', 'A+, AB+', 'Single Bag', '2025-06-18', 'White Blood Cell Storage'),
(7, 7, 'O', 'Rh-', 'Automatic Collection', 300, 'Plasma Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-09-21', 'Plasma', 'All Blood Types', 'Triple Bag', '2026-06-17', 'Frozen Storage'),
(8, 8, 'AB', 'Rh-', 'Automatic Collection', 500, 'White Blood Cell Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-11', 'White Blood Cells', 'AB+, AB-', 'Single Bag', '2025-06-18', 'White Blood Cell Storage'),
(9, 9, 'O', 'Rh+', 'Automatic Collection', 400, 'White Blood Cell Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-16', 'White Blood Cells', 'O+, A+, B+, AB+', 'Triple Bag', '2025-06-18', 'White Blood Cell Storage'),
(10, 10, 'A', 'Rh+', 'Automatic Collection', 500, 'Plasma Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-02', 'Plasma', 'A+, AB+', 'Triple Bag', '2026-06-17', 'Frozen Storage'),
(11, 11, 'O', 'Rh-', 'Automatic Collection', 600, 'Plasma Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-13', 'Plasma', 'All Blood Types', 'Double Bag', '2026-06-17', 'Frozen Storage'),
(12, 12, 'AB', 'Rh+', 'Automatic Collection', 300, 'Platelet Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-02', 'Platelets', 'AB+', 'Single Bag', '2025-06-22', 'Platelet Storage'),
(13, 13, 'A', 'Rh-', 'Automatic Collection', 400, 'Platelet Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-09-28', 'Platelets', 'A+, A-, AB+, AB-', 'Triple Bag', '2025-06-22', 'Platelet Storage'),
(14, 14, 'B', 'Rh+', 'Automatic Collection', 600, 'Platelet Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-09-27', 'Platelets', 'B+, AB+', 'Double Bag', '2025-06-22', 'Platelet Storage'),
(15, 15, 'A', 'Rh+', 'Automatic Collection', 300, 'Red Blood Cell Donation (Apheresis)', '2025-06-17', '09:21:34', '2025-10-07', 'Red Blood Cells', 'A+, AB+', 'Aphresis', '2025-07-29', 'Refrigerated Storage');

--
-- Triggers `donation`
--
DELIMITER $$
CREATE TRIGGER `after_donation_insert` AFTER INSERT ON `donation` FOR EACH ROW BEGIN
    DECLARE last_eligibility_date DATE;
    DECLARE total_eligibility_checks INT;
    DECLARE total_donations INT;

    -- Get the last eligibility check date and total checks
    SELECT COALESCE(MAX(EligibilityDate), NULL), COUNT(*) 
    INTO last_eligibility_date, total_eligibility_checks
    FROM eligibility 
    WHERE DonorID = NEW.DonorID;

    -- Count total donations made by the donor
    SELECT COUNT(*) 
    INTO total_donations
    FROM donation 
    WHERE DonorID = NEW.DonorID;

    -- Insert into history table
    INSERT INTO history (
        DonorID, totalEligibilityCheck, totalDonation, 
        TotalBloodVolume_Wholeblood, TotalBloodVolume_Redblood, 
        TotalBloodVolume_Platelets, TotalBloodVolume_Plasma, 
        TotalBloodVolume_Whiteblood, LastName, FirstName, MiddleName, 
        TotalBloodVolume_all, DonorRegDate, LastEligibilityCheckDate, 
        LatestDonationDate
    )
    SELECT 
        donors.DonorID, 
        total_eligibility_checks, 
        total_donations,
        IF(NEW.BloodComponent = 'Whole Blood', NEW.BloodVolume, 0),
        IF(NEW.BloodComponent = 'Red Blood Cells', NEW.BloodVolume, 0),
        IF(NEW.BloodComponent = 'Platelets', NEW.BloodVolume, 0),
        IF(NEW.BloodComponent = 'Plasma', NEW.BloodVolume, 0),
        IF(NEW.BloodComponent = 'White Blood Cells', NEW.BloodVolume, 0),
        donors.LastName, donors.FirstName, donors.MiddleName,
        NEW.BloodVolume, -- Assuming TotalBloodVolume_all = BloodVolume
        donors.RegDate,
        last_eligibility_date,
        NEW.DonationDate
    FROM donors 
    WHERE donors.DonorID = NEW.DonorID;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `donors`
--

CREATE TABLE `donors` (
  `DonorID` int(11) NOT NULL,
  `RegDate` date NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) NOT NULL,
  `Sex` varchar(255) NOT NULL,
  `Baranggay` varchar(255) NOT NULL,
  `City` varchar(255) NOT NULL,
  `Province` varchar(255) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Age` int(2) NOT NULL,
  `BloodType` varchar(3) NOT NULL,
  `CivilStatus` varchar(255) NOT NULL,
  `Nationality` varchar(255) NOT NULL,
  `Occupation` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `donors`
--

INSERT INTO `donors` (`DonorID`, `RegDate`, `LastName`, `FirstName`, `MiddleName`, `Sex`, `Baranggay`, `City`, `Province`, `DateOfBirth`, `Age`, `BloodType`, `CivilStatus`, `Nationality`, `Occupation`) VALUES
(1, '2025-06-17', 'Bryant', 'Violet', 'Judith', 'Male', 'Barangay 2', 'Dumaguete', 'Pangasinan', '2001-06-17', 24, 'A-', 'Single', 'Filipino', 'Firefighter'),
(2, '2025-06-17', 'Powell', 'Daisy', 'Zachary', 'Male', 'Barangay Maligaya', 'Caloocan', 'Tawi-Tawi', '1990-06-17', 35, 'AB+', 'Married', 'Filipino', 'Engineer'),
(3, '2025-06-17', 'Baker', 'Ella', 'Michael', 'Female', 'Barangay San Pedro', 'Marikina', 'Zamboanga del Sur', '1979-06-17', 46, 'A+', 'Married', 'Filipino', 'Teacher'),
(4, '2025-06-17', 'Watson', 'Igor', 'Andrew', 'Male', 'Barangay Makati', 'Quezon City', 'Bohol', '1987-06-17', 38, 'B+', 'Single', 'Filipino', 'Artist'),
(5, '2025-06-17', 'Ward', 'Juan', 'Claire', 'Female', 'Barangay Batangas', 'Marinduque', 'Pangasinan', '1988-06-17', 37, 'B-', 'Single', 'Filipino', 'Software Developer'),
(6, '2025-06-17', 'Watson', 'Nolan', 'Scott', 'Female', 'Barangay Culiat', 'Mandaluyong', 'Laguna', '2005-06-17', 20, 'A+', 'Single', 'Filipino', 'Police Officer'),
(7, '2025-06-17', 'Stewart', 'Xander', 'Catherine', 'Male', 'Barangay Northgate', 'Tagaytay', 'Siquijor', '1989-06-17', 36, 'O-', 'Single', 'Filipino', 'Nurse'),
(8, '2025-06-17', 'Morales', 'Penny', 'Michael', 'Female', 'Barangay New Manila', 'Santiago', 'Marinduque', '1988-06-17', 37, 'AB-', 'Married', 'Filipino', 'Chef'),
(9, '2025-06-17', 'Jackson', 'Ulysses', 'Jackson', 'Male', 'Barangay Culiat', 'Caloocan', 'Bataan', '1982-06-17', 43, 'O+', 'Married', 'Filipino', 'Artist'),
(10, '2025-06-17', 'Baker', 'Maya', 'Grace', 'Male', 'Barangay Bagumbayan', 'Lucena', 'Maguindanao', '2003-06-17', 22, 'A+', 'Single', 'Filipino', 'Artist'),
(11, '2025-06-17', 'Torres', 'Isla', 'Irene', 'Male', 'Barangay Mabini', 'Mati', 'Camiguin', '1988-06-17', 37, 'O-', 'Single', 'Filipino', 'Police Officer'),
(12, '2025-06-17', 'Murphy', 'Igor', 'Grace', 'Male', 'Barangay Panghulo', 'Butuan', 'Nueva Ecija', '1985-06-17', 40, 'AB+', 'Single', 'Filipino', 'Artist'),
(13, '2025-06-17', 'Simmons', 'Walter', 'Louise', 'Female', 'Barangay Subangdaku', 'Malolos', 'Sultan Kudarat', '1980-06-17', 44, 'A-', 'Married', 'Filipino', 'Mechanic'),
(14, '2025-06-17', 'Vargas', 'Isabel', 'Lily', 'Female', 'Barangay Northgate', 'Bulan', 'Lanao del Sur', '1978-06-17', 47, 'B+', 'Married', 'Filipino', 'Teacher'),
(15, '2025-06-17', 'Graham', 'Maya', 'Cora', 'Female', 'Barangay Tanauan', 'Navotas', 'Samar', '1983-06-17', 42, 'A+', 'Married', 'Filipino', 'Police Officer');

-- --------------------------------------------------------

--
-- Table structure for table `eligibility`
--

CREATE TABLE `eligibility` (
  `EligibilityID` int(11) NOT NULL,
  `DonorID` int(11) NOT NULL,
  `Weight` int(3) NOT NULL,
  `BloodPressure` varchar(255) NOT NULL,
  `Hemoglobin` int(11) NOT NULL,
  `ConditionCheck` int(1) NOT NULL,
  `ConditionType` varchar(255) DEFAULT NULL,
  `Substance` int(1) NOT NULL,
  `SubstanceDate` date DEFAULT NULL,
  `TattooPiercing` int(1) NOT NULL,
  `TattooPiercingDate` date DEFAULT NULL,
  `Medication` int(1) NOT NULL,
  `MedicationDate` date DEFAULT NULL,
  `EligibilityStatus` int(1) NOT NULL,
  `EligibilityDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `eligibility`
--

INSERT INTO `eligibility` (`EligibilityID`, `DonorID`, `Weight`, `BloodPressure`, `Hemoglobin`, `ConditionCheck`, `ConditionType`, `Substance`, `SubstanceDate`, `TattooPiercing`, `TattooPiercingDate`, `Medication`, `MedicationDate`, `EligibilityStatus`, `EligibilityDate`) VALUES
(1, 1, 66, '114/76', 16, 0, '', 0, NULL, 1, '2020-06-17', 1, '2024-08-25', 1, '2025-06-17'),
(2, 2, 119, '106/70', 15, 0, '', 1, '2025-03-12', 0, NULL, 0, NULL, 1, '2025-06-17'),
(3, 3, 132, '112/74', 15, 0, '', 1, '2025-05-03', 1, '2021-06-17', 1, '2024-10-21', 1, '2025-06-17'),
(4, 4, 101, '112/74', 16, 0, '', 1, '2024-09-30', 1, '2024-06-17', 0, NULL, 1, '2025-06-17'),
(5, 5, 62, '118/79', 16, 0, '', 1, '2024-11-26', 1, '2019-06-17', 1, '2025-03-21', 1, '2025-06-17'),
(6, 6, 80, '98/65', 13, 0, '', 0, NULL, 1, '2019-06-17', 1, '2024-07-01', 1, '2025-06-17'),
(7, 7, 101, '93/62', 13, 0, '', 1, '2024-07-10', 1, '2019-06-17', 0, NULL, 1, '2025-06-17'),
(8, 8, 95, '104/69', 14, 0, '', 1, '2024-12-30', 0, NULL, 0, NULL, 1, '2025-06-17'),
(9, 9, 78, '115/77', 16, 0, '', 1, '2024-09-05', 0, NULL, 1, '2024-12-21', 1, '2025-06-17'),
(10, 10, 80, '115/77', 16, 0, '', 1, '2024-07-03', 1, '2023-06-17', 1, '2024-07-10', 1, '2025-06-17'),
(11, 11, 64, '110/73', 16, 0, '', 1, '2024-08-15', 1, '2018-06-17', 1, '2024-10-13', 1, '2025-06-17'),
(12, 12, 93, '116/77', 16, 0, '', 0, NULL, 0, NULL, 0, NULL, 1, '2025-06-17'),
(13, 13, 105, '96/64', 13, 0, '', 0, NULL, 1, '2015-06-17', 0, NULL, 1, '2025-06-17'),
(14, 14, 104, '96/64', 13, 0, '', 0, NULL, 1, '2021-06-17', 1, '2024-10-31', 1, '2025-06-17'),
(15, 15, 95, '107/71', 14, 0, '', 0, NULL, 0, NULL, 0, NULL, 1, '2025-06-17');

-- --------------------------------------------------------

--
-- Table structure for table `healthprovider`
--

CREATE TABLE `healthprovider` (
  `RetrieveID` int(11) NOT NULL,
  `HealthProviderID` int(11) NOT NULL,
  `CompanyHospitalName` varchar(255) NOT NULL,
  `PersonnelID` int(11) NOT NULL,
  `PersonnelName` varchar(255) NOT NULL,
  `BloodID` int(11) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `Blood_Group` varchar(5) NOT NULL,
  `RhesusFactor` varchar(2) NOT NULL,
  `DonationType` varchar(50) NOT NULL,
  `BloodVolume` int(11) NOT NULL,
  `RetrieveDate` datetime NOT NULL,
  `PurposeOfRetrieval` varchar(255) NOT NULL,
  `ContactNo` varchar(255) NOT NULL,
  `EmailAdd` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `healthprovider`
--

INSERT INTO `healthprovider` (`RetrieveID`, `HealthProviderID`, `CompanyHospitalName`, `PersonnelID`, `PersonnelName`, `BloodID`, `LastName`, `FirstName`, `MiddleName`, `Blood_Group`, `RhesusFactor`, `DonationType`, `BloodVolume`, `RetrieveDate`, `PurposeOfRetrieval`, `ContactNo`, `EmailAdd`) VALUES
(1, 1, 'Lourdes Hospital', 1, 'Dr. Jose Gomez', 1, 'Bryant', 'Violet', 'Judith', 'A', 'Rh', 'Platelet Donation (Apheresis)', 300, '2025-06-17 09:21:33', 'Inventory Status Check', '0934082453', 'info@provincialhospital.com'),
(2, 2, 'New Doctor\'s Hospital', 2, 'Dr. Juan Dela Cruz', 2, 'Powell', 'Daisy', 'Zachary', 'AB', 'Rh', 'Red Blood Cell Donation (Apheresis)', 400, '2025-06-17 09:21:34', 'Patient Data Retrieval', '0964304196', 'info@newdoctor\'shospital.com'),
(3, 3, 'New Doctor\'s Hospital', 3, 'Dr. Ana Lopez', 3, 'Baker', 'Ella', 'Michael', 'A', 'Rh', 'Plasma Donation (Apheresis)', 500, '2025-06-17 09:21:34', 'Medical History Review', '0977249809', 'support@newdoctor\'shospital.com'),
(4, 4, 'Lourdes Hospital', 4, 'Dr. Maria Santos', 4, 'Watson', 'Igor', 'Andrew', 'B', 'Rh', 'Whole Blood Donation', 600, '2025-06-17 09:21:34', 'Appointment Scheduling', '0959467946', 'admin@leonhernandezhospital.com'),
(5, 5, 'New Doctor\'s Hospital', 5, 'Dr. Ana Lopez', 5, 'Ward', 'Juan', 'Claire', 'B', 'Rh', 'Whole Blood Donation', 200, '2025-06-17 09:21:34', 'Appointment Scheduling', '0944524714', 'info@leonhernandezhospital.com'),
(6, 6, 'Lourdes Hospital', 6, 'Dr. Juan Dela Cruz', 6, 'Watson', 'Nolan', 'Scott', 'A', 'Rh', 'White Blood Cell Donation (Apheresis)', 200, '2025-06-17 09:21:34', 'Appointment Scheduling', '0931070436', 'admin@provincialhospital.com'),
(7, 7, 'Provincial Hospital', 7, 'Dr. Maria Santos', 7, 'Stewart', 'Xander', 'Catherine', 'O', 'Rh', 'Plasma Donation (Apheresis)', 300, '2025-06-17 09:21:34', 'Blood Donation Records', '0994218589', 'info@leonhernandezhospital.com'),
(8, 8, 'Provincial Hospital', 8, 'Dr. Maria Santos', 8, 'Morales', 'Penny', 'Michael', 'AB', 'Rh', 'White Blood Cell Donation (Apheresis)', 500, '2025-06-17 09:21:34', 'Emergency Contact Lookup', '0999283371', 'admin@leonhernandezhospital.com'),
(9, 9, 'Lourdes Hospital', 9, 'Dr. Juan Dela Cruz', 9, 'Jackson', 'Ulysses', 'Jackson', 'O', 'Rh', 'White Blood Cell Donation (Apheresis)', 400, '2025-06-17 09:21:34', 'Donor Eligibility Check', '0933015531', 'admin@newdoctor\'shospital.com'),
(10, 10, 'Provincial Hospital', 10, 'Dr. Maria Santos', 10, 'Baker', 'Maya', 'Grace', 'A', 'Rh', 'Plasma Donation (Apheresis)', 500, '2025-06-17 09:21:34', 'Medical History Review', '0951148207', 'support@provincialhospital.com'),
(11, 11, 'Leon Hernandez Hospital', 11, 'Dr. Ana Lopez', 11, 'Torres', 'Isla', 'Irene', 'O', 'Rh', 'Plasma Donation (Apheresis)', 600, '2025-06-17 09:21:34', 'Appointment Scheduling', '0937342661', 'admin@leonhernandezhospital.com'),
(12, 12, 'Lourdes Hospital', 12, 'Dr. Maria Santos', 12, 'Murphy', 'Igor', 'Grace', 'AB', 'Rh', 'Platelet Donation (Apheresis)', 300, '2025-06-17 09:21:34', 'Medical History Review', '0945182138', 'info@provincialhospital.com'),
(13, 13, 'Leon Hernandez Hospital', 13, 'Dr. Carlos Reyes', 13, 'Simmons', 'Walter', 'Louise', 'A', 'Rh', 'Platelet Donation (Apheresis)', 400, '2025-06-17 09:21:34', 'Inventory Status Check', '0992931287', 'info@newdoctor\'shospital.com'),
(14, 14, 'New Doctor\'s Hospital', 14, 'Dr. Juan Dela Cruz', 14, 'Vargas', 'Isabel', 'Lily', 'B', 'Rh', 'Platelet Donation (Apheresis)', 600, '2025-06-17 09:21:34', 'Appointment Scheduling', '0997188452', 'support@lourdeshospital.com'),
(15, 15, 'Lourdes Hospital', 15, 'Dr. Juan Dela Cruz', 15, 'Graham', 'Maya', 'Cora', 'A', 'Rh', 'Red Blood Cell Donation (Apheresis)', 300, '2025-06-17 09:21:34', 'Medical History Review', '0945015578', 'contact@leonhernandezhospital.com');

-- --------------------------------------------------------

--
-- Table structure for table `history`
--

CREATE TABLE `history` (
  `HistoryID` int(11) NOT NULL,
  `DonorID` int(11) DEFAULT NULL,
  `totalEligibilityCheck` int(11) DEFAULT NULL,
  `totalDonation` int(11) DEFAULT NULL,
  `TotalBloodVolume_Wholeblood` int(11) DEFAULT NULL,
  `TotalBloodVolume_Redblood` int(11) DEFAULT NULL,
  `TotalBloodVolume_Platelets` int(11) DEFAULT NULL,
  `TotalBloodVolume_Plasma` int(11) DEFAULT NULL,
  `TotalBloodVolume_Whiteblood` int(11) DEFAULT NULL,
  `LastName` varchar(255) DEFAULT NULL,
  `FirstName` varchar(255) DEFAULT NULL,
  `MiddleName` varchar(255) DEFAULT NULL,
  `TotalBloodVolume_all` int(11) DEFAULT NULL,
  `DonorRegDate` date DEFAULT NULL,
  `LastEligibilityCheckDate` date DEFAULT NULL,
  `LatestDonationDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `history`
--

INSERT INTO `history` (`HistoryID`, `DonorID`, `totalEligibilityCheck`, `totalDonation`, `TotalBloodVolume_Wholeblood`, `TotalBloodVolume_Redblood`, `TotalBloodVolume_Platelets`, `TotalBloodVolume_Plasma`, `TotalBloodVolume_Whiteblood`, `LastName`, `FirstName`, `MiddleName`, `TotalBloodVolume_all`, `DonorRegDate`, `LastEligibilityCheckDate`, `LatestDonationDate`) VALUES
(1, 1, 1, 1, 0, 0, 300, 0, 0, 'Bryant', 'Violet', 'Judith', 300, '2025-06-17', '2025-06-17', '2025-06-17'),
(2, 2, 1, 1, 0, 400, 0, 0, 0, 'Powell', 'Daisy', 'Zachary', 400, '2025-06-17', '2025-06-17', '2025-06-17'),
(3, 3, 1, 1, 0, 0, 0, 500, 0, 'Baker', 'Ella', 'Michael', 500, '2025-06-17', '2025-06-17', '2025-06-17'),
(4, 4, 1, 1, 600, 0, 0, 0, 0, 'Watson', 'Igor', 'Andrew', 600, '2025-06-17', '2025-06-17', '2025-06-17'),
(5, 5, 1, 1, 200, 0, 0, 0, 0, 'Ward', 'Juan', 'Claire', 200, '2025-06-17', '2025-06-17', '2025-06-17'),
(6, 6, 1, 1, 0, 0, 0, 0, 200, 'Watson', 'Nolan', 'Scott', 200, '2025-06-17', '2025-06-17', '2025-06-17'),
(7, 7, 1, 1, 0, 0, 0, 300, 0, 'Stewart', 'Xander', 'Catherine', 300, '2025-06-17', '2025-06-17', '2025-06-17'),
(8, 8, 1, 1, 0, 0, 0, 0, 500, 'Morales', 'Penny', 'Michael', 500, '2025-06-17', '2025-06-17', '2025-06-17'),
(9, 9, 1, 1, 0, 0, 0, 0, 400, 'Jackson', 'Ulysses', 'Jackson', 400, '2025-06-17', '2025-06-17', '2025-06-17'),
(10, 10, 1, 1, 0, 0, 0, 500, 0, 'Baker', 'Maya', 'Grace', 500, '2025-06-17', '2025-06-17', '2025-06-17'),
(11, 11, 1, 1, 0, 0, 0, 600, 0, 'Torres', 'Isla', 'Irene', 600, '2025-06-17', '2025-06-17', '2025-06-17'),
(12, 12, 1, 1, 0, 0, 300, 0, 0, 'Murphy', 'Igor', 'Grace', 300, '2025-06-17', '2025-06-17', '2025-06-17'),
(13, 13, 1, 1, 0, 0, 400, 0, 0, 'Simmons', 'Walter', 'Louise', 400, '2025-06-17', '2025-06-17', '2025-06-17'),
(14, 14, 1, 1, 0, 0, 600, 0, 0, 'Vargas', 'Isabel', 'Lily', 600, '2025-06-17', '2025-06-17', '2025-06-17'),
(15, 15, 1, 1, 0, 300, 0, 0, 0, 'Graham', 'Maya', 'Cora', 300, '2025-06-17', '2025-06-17', '2025-06-17');

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE `logs` (
  `dt` timestamp NOT NULL DEFAULT current_timestamp(),
  `user_accounts_id` int(11) NOT NULL,
  `event` varchar(225) NOT NULL,
  `transactions` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`dt`, `user_accounts_id`, `event`, `transactions`) VALUES
('2024-12-06 03:09:09', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:09:15', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:09:18', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:09:23', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:09:27', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:09:37', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:35:02', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:35:05', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:35:09', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 03:35:14', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:18:00', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:18:02', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:18:03', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:23:25', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:23:26', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:23:27', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:29:00', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:33:13', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:33:14', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:33:18', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:33:20', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:33:27', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:38:57', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:38:59', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:39:00', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:39:04', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:03', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:05', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:07', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:09', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:11', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-06 04:43:13', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:05:21', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:05:59', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:19', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:27', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:29', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:30', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:36', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:06:49', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:13:55', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:01', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:12', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:17', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:18', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:50', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:52', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:14:56', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:15:02', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:15:10', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:23:34', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:23:37', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:23:43', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:23:44', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:02', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:06', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:20', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:25', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:28', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:24:37', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:25:15', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:48:35', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:48:44', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:48:50', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:48:51', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:04', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:06', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:06', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:15', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:28', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:31', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:36', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:42', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:45', 0, '*_Clicks', 'ViewHealth Provider report'),
('2024-12-09 00:49:54', 0, '*_Clicks', 'Updated transactions in logs for ID 0. Rows affected: 74.'),
('2024-12-09 00:49:56', 0, '*_Clicks', 'View History Data'),
('2024-12-09 00:50:02', 0, '*_Clicks', 'Updated adminID in accounts for ID 2. Rows affected: 0.'),
('2024-12-09 00:50:10', 0, '*_Clicks', 'Updated username in accounts for ID 2. Rows affected: 0.'),
('2024-12-09 00:50:26', 0, '*_Clicks', 'Updated password in accounts for ID 2. Rows affected: 0.'),
('2024-12-09 00:50:34', 0, '*_Clicks', 'Updated dt_created in accounts for ID 2. Rows affected: 0.'),
('2024-12-09 00:50:40', 0, '*_Clicks', 'View History Data'),
('2024-12-09 00:50:42', 0, '*_Clicks', 'View History Data'),
('2024-12-09 00:50:42', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:01:00', 0, '*_Clicks', 'View Donor History'),
('2024-12-09 01:04:50', 0, '*_Clicks', 'Updated City in donors for ID 12. Rows affected: 1.'),
('2024-12-09 01:04:54', 0, '*_Clicks', 'View Donor History'),
('2024-12-09 01:13:38', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:13:38', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:13:41', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:13:42', 0, '*_Clicks', 'View Donor History'),
('2024-12-09 01:14:08', 0, '*_Clicks', 'Updated Province in donors for ID 12. Rows affected: 1.'),
('2024-12-09 01:14:45', 0, '*_Clicks', 'View Donation History'),
('2024-12-09 01:14:59', 0, '*_Clicks', 'Updated Blood_Group in donation for ID 331. Rows affected: 1.'),
('2024-12-09 01:16:53', 0, '*_Clicks', 'View History'),
('2024-12-09 01:17:01', 0, '*_Clicks', 'Updated BloodID in healthprovider for ID 6. Rows affected: 1.'),
('2024-12-09 01:17:06', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:17:12', 0, '*_Clicks', 'Updated TotalBloodVolume_Redblood in history for ID 404. Rows affected: 1.'),
('2024-12-09 01:17:17', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:17:19', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:17:21', 0, '*_Clicks', 'View History Data'),
('2024-12-09 01:17:31', 0, '*_Click', 'Updated event in logs for ID 0. Rows affected: 100.'),
('2024-12-09 02:01:48', 0, '*_Click', 'View Donor History'),
('2024-12-09 02:06:16', 0, '*_Click', 'View Donor History'),
('2024-12-09 02:10:18', 0, '*_Click', 'View Donor History'),
('2024-12-09 02:10:19', 0, '*_Click', 'View Donation History'),
('2024-12-09 02:10:21', 0, '*_Click', 'View Eligibility History'),
('2024-12-09 02:10:22', 0, '*_Click', 'View History'),
('2024-12-09 02:10:23', 0, '*_Click', 'View History'),
('2024-12-09 02:10:26', 0, '*_Click', 'View History Data'),
('2024-12-22 15:58:30', 0, '*_Click', 'View Blood Inventory Report'),
('2024-12-22 16:02:31', 0, '*_Click', 'View Ineligibility Report'),
('2024-12-22 16:11:11', 0, '*_Click', 'View Donor Registration Report'),
('2024-12-22 16:13:08', 0, '*_Click', 'View Donor Registration Report'),
('2024-12-22 16:21:12', 0, '*_Click', 'View Donor Registration Report'),
('2024-12-22 16:22:23', 0, '*_Click', 'ViewHealth Provider Report'),
('2024-12-22 16:22:54', 0, '*_Click', 'View Donor History'),
('2024-12-22 16:23:01', 0, '*_Click', 'View History Data'),
('2024-12-22 16:23:03', 0, '*_Click', 'View History'),
('2024-12-22 16:23:05', 0, '*_Click', 'View Donation History'),
('2024-12-22 16:23:07', 0, '*_Click', 'View Donor History'),
('2024-12-22 16:23:08', 0, '*_Click', 'View Eligibility History'),
('2024-12-22 16:23:59', 0, '*_Click', 'View History Data'),
('2024-12-22 16:24:03', 0, '*_Click', 'View History Data'),
('2024-12-22 16:24:15', 0, '*_Click', 'View History Data'),
('2024-12-22 16:24:36', 0, '*_Click', 'View History'),
('2024-12-22 16:24:39', 0, '*_Click', 'View Eligibility History'),
('2024-12-22 16:24:40', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:11:18', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:21', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:24', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:11:25', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:11:27', 0, '*_Click', 'View History'),
('2024-12-24 12:11:30', 0, '*_Click', 'View History Data'),
('2024-12-24 12:11:39', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:40', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:41', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:11:42', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:43', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:11:45', 0, '*_Click', 'View History'),
('2024-12-24 12:11:48', 0, '*_Click', 'View History Data'),
('2024-12-24 12:11:51', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:11:51', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:11:52', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:11:52', 0, '*_Click', 'View History'),
('2024-12-24 12:11:54', 0, '*_Click', 'View History Data'),
('2024-12-24 12:11:59', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:12:42', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:12:56', 0, '*_Click', 'View Donor Registration Report'),
('2024-12-24 12:30:56', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:30:57', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:30:59', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:31:00', 0, '*_Click', 'View History'),
('2024-12-24 12:31:03', 0, '*_Click', 'View History Data'),
('2024-12-24 12:31:26', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:31:28', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:31:29', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:35:40', 0, '*_Click', 'View Donor History'),
('2024-12-24 12:35:42', 0, '*_Click', 'View Donation History'),
('2024-12-24 12:35:43', 0, '*_Click', 'View Eligibility History'),
('2024-12-24 12:35:45', 0, '*_Click', 'View History'),
('2024-12-24 12:35:48', 0, '*_Click', 'View History Data'),
('2025-03-04 10:05:55', 0, '*_Click', 'View Donor History'),
('2025-03-04 10:06:10', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:06:12', 0, '*_Click', 'View Donor History'),
('2025-03-04 10:06:28', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:06:28', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 10:06:32', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:06:35', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 10:06:36', 0, '*_Click', 'View History'),
('2025-03-04 10:06:37', 0, '*_Click', 'View History Data'),
('2025-03-04 10:06:39', 0, '*_Click', 'View History Data'),
('2025-03-04 10:06:41', 0, '*_Click', 'View History Data'),
('2025-03-04 10:06:49', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-04 10:07:36', 0, '*_Click', 'View Donor History'),
('2025-03-04 10:08:14', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 10:08:25', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:09:01', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:09:33', 0, '*_Click', 'Updated DonationDate in donation for ID 3734. Rows affected: 1.'),
('2025-03-04 10:09:45', 0, '*_Click', 'Updated DonationDate in donation for ID 5437. Rows affected: 1.'),
('2025-03-04 10:13:32', 0, '*_Click', 'View Donor History'),
('2025-03-04 10:14:04', 0, '*_Click', 'View Donation History'),
('2025-03-04 10:14:07', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 10:14:11', 0, '*_Click', 'View History Data'),
('2025-03-04 10:14:16', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-04 12:10:35', 0, '*_Click', 'View Donor History'),
('2025-03-04 12:10:38', 0, '*_Click', 'View Donation History'),
('2025-03-04 12:10:48', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 12:10:52', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 12:10:55', 0, '*_Click', 'View History Data'),
('2025-03-04 12:11:00', 0, '*_Click', 'View History Data'),
('2025-03-04 12:11:03', 0, '*_Click', 'View History Data'),
('2025-03-04 12:11:09', 0, '*_Click', 'View History Data'),
('2025-03-04 12:11:17', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-04 12:12:13', 0, '*_Click', 'View Donor History'),
('2025-03-04 12:12:22', 0, '*_Click', 'View Donation History'),
('2025-03-04 12:12:24', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 12:12:26', 0, '*_Click', 'View History'),
('2025-03-04 12:12:31', 0, '*_Click', 'View History Data'),
('2025-03-04 12:12:33', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-04 12:12:37', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-04 12:12:39', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-04 12:12:41', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-04 12:12:45', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-04 12:16:51', 0, '*_Click', 'View Donor History'),
('2025-03-04 12:17:58', 0, '*_Click', 'View Donation History'),
('2025-03-04 12:17:58', 0, '*_Click', 'View Eligibility History'),
('2025-03-04 12:18:00', 0, '*_Click', 'View History'),
('2025-03-04 12:18:02', 0, '*_Click', 'View History Data'),
('2025-03-06 13:07:14', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:39:46', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:40:02', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:40:30', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:40:39', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:40:45', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:43:18', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:43:20', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:43:22', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 13:43:24', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:43:30', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 13:43:32', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:46:07', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:48:38', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:49:30', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:50:22', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:50:24', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:50:26', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:50:28', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:50:31', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 13:50:33', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:50:37', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 13:50:39', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 13:55:25', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:55:29', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:55:32', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 13:55:35', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:55:37', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 13:58:30', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 13:58:56', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 13:59:10', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 13:59:21', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 13:59:32', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 14:04:15', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:06:04', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:07:03', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:07:44', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:14:17', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:14:47', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:14:49', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:20:34', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:24:00', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:25:46', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:36:48', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:44:40', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:47:39', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:48:28', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:49:38', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:50:01', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 14:51:14', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:52:12', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:54:42', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 14:54:53', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 14:55:16', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 14:55:32', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 14:56:00', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 14:56:56', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 14:57:17', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 15:01:16', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 15:05:53', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 15:58:21', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 16:00:03', 0, '*_Click', 'View Donation Donationn Histroy Report'),
('2025-03-06 16:00:42', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 16:01:54', 0, '*_Click', 'View Ineligibility Report'),
('2025-03-06 16:03:41', 0, '*_Click', 'View Blood Inventory Report'),
('2025-03-06 16:05:37', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 16:06:06', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-06 16:06:18', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 16:16:40', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 16:21:30', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-06 16:21:56', 0, '*_Click', 'ViewHealth Provider Report'),
('2025-03-07 02:26:52', 0, '*_Click', 'View Donor History'),
('2025-03-07 02:30:24', 0, '*_Click', 'View Donor History'),
('2025-03-09 10:51:39', 0, '*_Click', 'View History Data'),
('2025-03-09 10:52:03', 0, '*_Click', 'View History Data'),
('2025-03-09 10:54:55', 0, '*_Click', 'View History Data'),
('2025-03-09 10:55:53', 0, '*_Click', 'View History Data'),
('2025-03-09 10:56:14', 0, '*_Click', 'View History'),
('2025-03-09 10:56:24', 0, '*_Click', 'View Eligibility History'),
('2025-03-09 10:56:25', 0, '*_Click', 'View Donation History'),
('2025-03-09 10:56:25', 0, '*_Click', 'View Donor History'),
('2025-03-09 10:56:26', 0, '*_Click', 'View History Data'),
('2025-03-09 10:57:14', 0, '*_Click', 'View Donor History'),
('2025-03-09 10:57:15', 0, '*_Click', 'View Donation History'),
('2025-03-09 10:57:16', 0, '*_Click', 'View Eligibility History'),
('2025-03-09 10:57:16', 0, '*_Click', 'View History'),
('2025-03-09 10:57:18', 0, '*_Click', 'View History Data'),
('2025-03-09 10:57:19', 0, '*_Click', 'View History Data'),
('2025-03-09 10:57:25', 0, '*_Click', 'View History Data'),
('2025-03-09 10:57:40', 0, '*_Click', 'View Donor Registration Report'),
('2025-03-09 10:57:47', 0, '*_Click', 'View History Data'),
('2025-03-09 11:26:45', 0, '*_Click', 'View History Data'),
('2025-03-09 11:31:24', 0, '*_Click', 'View Donor History'),
('2025-03-09 12:32:29', 0, '*_Click', 'View History Data'),
('2025-06-17 00:56:43', 1, '*_Click', 'SuperAdmin logged in'),
('2025-06-17 00:56:44', 1, '*_Click', 'Load SuperAdmin Dashboard Successfully!'),
('2025-06-17 00:56:46', 1, '*_Click', 'Filter Daily'),
('2025-06-17 00:56:47', 1, '*_Click', 'Filter Weekly'),
('2025-06-17 00:56:54', 1, '*_Click', 'Filter Monthly'),
('2025-06-17 00:57:00', 1, '*_Click', 'Filter Monthly'),
('2025-06-17 00:57:05', 1, '*_Click', 'Filter Monthly'),
('2025-06-17 00:57:10', 1, '*_Click', 'Filter Weekly'),
('2025-06-17 01:03:20', 1, '*_Click', 'SuperAdmin logged in'),
('2025-06-17 01:03:21', 1, '*_Click', 'Load SuperAdmin Dashboard Successfully!'),
('2025-06-17 01:03:26', 1, '*_Click', 'View Donor History'),
('2025-06-17 01:03:28', 1, '*_Click', 'Filter Daily'),
('2025-06-17 01:04:00', 1, '*_Click', 'View Donor History'),
('2025-06-17 01:04:02', 1, '*_Click', 'Filter Daily'),
('2025-06-17 01:04:06', 1, '*_Click', 'View Donation History'),
('2025-06-17 01:04:07', 1, '*_Click', 'Filter Daily'),
('2025-06-17 01:04:59', 1, '*_Click', 'View Health Provider'),
('2025-06-17 01:05:01', 1, '*_Click', 'Filter Daily'),
('2025-06-17 01:05:43', 1, '*_Click', 'View History Data'),
('2025-06-17 01:06:12', 1, '*_Click', 'View Donation History'),
('2025-06-17 01:06:14', 1, '*_Click', 'Filter Daily');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`adminID`);

--
-- Indexes for table `accountssuperadmin`
--
ALTER TABLE `accountssuperadmin`
  ADD PRIMARY KEY (`adminID`);

--
-- Indexes for table `donation`
--
ALTER TABLE `donation`
  ADD PRIMARY KEY (`BloodID`),
  ADD KEY `DonorID` (`DonorID`);

--
-- Indexes for table `donors`
--
ALTER TABLE `donors`
  ADD PRIMARY KEY (`DonorID`);

--
-- Indexes for table `eligibility`
--
ALTER TABLE `eligibility`
  ADD PRIMARY KEY (`EligibilityID`),
  ADD KEY `DonorID` (`DonorID`);

--
-- Indexes for table `healthprovider`
--
ALTER TABLE `healthprovider`
  ADD PRIMARY KEY (`RetrieveID`),
  ADD KEY `BloodID` (`BloodID`);

--
-- Indexes for table `history`
--
ALTER TABLE `history`
  ADD PRIMARY KEY (`HistoryID`),
  ADD KEY `DonorID` (`DonorID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `accounts`
--
ALTER TABLE `accounts`
  MODIFY `adminID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `accountssuperadmin`
--
ALTER TABLE `accountssuperadmin`
  MODIFY `adminID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `donation`
--
ALTER TABLE `donation`
  MODIFY `BloodID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `donors`
--
ALTER TABLE `donors`
  MODIFY `DonorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `eligibility`
--
ALTER TABLE `eligibility`
  MODIFY `EligibilityID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `healthprovider`
--
ALTER TABLE `healthprovider`
  MODIFY `RetrieveID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `history`
--
ALTER TABLE `history`
  MODIFY `HistoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `history`
--
ALTER TABLE `history`
  ADD CONSTRAINT `history_ibfk_1` FOREIGN KEY (`DonorID`) REFERENCES `donors` (`DonorID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
