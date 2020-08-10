IF DB_ID('MedicalInstitutionDb') IS NULL
CREATE DATABASE MedicalInstitutionDb
GO

USE MedicalInstitutionDb
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblMedicalInstitutions')
DROP TABLE tblMedicalInstitutions
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblClinicAdmins')
DROP TABLE tblClinicAdmins
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblClinicMaintances')
DROP TABLE tblClinicMaintances
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblReports')
DROP TABLE tblReports
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblClinicPatients')
DROP TABLE tblClinicPatients
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblClinicDoctors')
DROP TABLE tblClinicDoctors
IF EXISTS (SELECT NAME FROM sys.sysobjects WHERE NAME = 'tblClinicManagers')
DROP TABLE tblClinicManagers

CREATE TABLE tblMedicalInstitutions
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
ConstructionDate date,
Owner varchar(20),
Address varchar(30),
FloorsNumber int,
PersonsPerFloor int,
Terrace bit,
Yard bit,
AmbulanceAccessPointNumber int,
DisabledPatitentAccessPointNumber int
);

CREATE TABLE tblClinicAdmins
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
Surname varchar(20),
IDNumber int,
Gender char,
DateOfBirth date,
Citizenship varchar(20),
Username varchar(20),
Password varchar(20)
);

CREATE TABLE tblClinicMaintances
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
Surname varchar(20),
IDNumber int,
Gender char,
DateOfBirth date,
Citizenship varchar(20),
Username varchar(20),
Password varchar(20),
ExpendClinicPermission bit,
InChargeOfDisabledPatientAccess bit,
InChargeOfAmbulanceAccess bit
);

CREATE TABLE tblClinicManagers
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
Surname varchar(20),
IDNumber int,
Gender char,
DateOfBirth date,
Citizenship varchar(20),
Username varchar(20),
Password varchar(20),
Floor int,
MaxDoctorNumber int,
MaxPatientNumber int,
OmissionNumber int
);

CREATE TABLE tblClinicDoctors
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
Surname varchar(20),
IDNumber int,
Gender char,
DateOfBirth date,
Citizenship varchar(20),
Username varchar(20),
Password varchar(20),
UniqueNumber int,
AccountNumber int,
Department varchar(20),
Shift varchar(20),
AdmissionOfPatients bit,
FKManager int
);

CREATE TABLE tblClinicPatients
(
Id int PRIMARY KEY IDENTITY (1,1),
Name varchar(20),
Surname varchar(20),
IDNumber int,
Gender char,
DateOfBirth date,
Citizenship varchar(20),
Username varchar(20),
Password varchar(20),
HealthInsuranceNumber int,
HealthInsuranceExperationDate date,
DoctorUniqueNumber int,
FKDoctor int,
);

CREATE TABLE tblReports
(
Id int PRIMARY KEY IDENTITY (1,1),
Date Date,
TotalTIme int,
Description varchar(30),
FKClinicManager int
);

ALTER TABLE tblClinicDoctors ADD FOREIGN KEY(FKManager) REFERENCES tblClinicManagers(Id);

ALTER TABLE tblClinicPatients ADD FOREIGN KEY(FKDoctor) REFERENCES tblClinicDoctors(Id);

ALTER TABLE tblReports ADD FOREIGN KEY(FKClinicManager) REFERENCES tblClinicManagers(Id);