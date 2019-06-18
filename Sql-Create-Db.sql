CREATE DATABASE SSES;

CREATE TABLE Users (
    UsersID int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
    DOB date NOT NULL,
	AccessLevel int NOT NULL
);
CREATE TABLE Doors (
    DoorsID int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
    AccessLevel int
);
CREATE TABLE [Credentials] (
    [CredentialsID] int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
);
CREATE TABLE UsersCredentials (
    UsersCredentialsID int IDENTITY(1,1) PRIMARY KEY,
    UsersID int NOT NULL ,
    CredentialsID int NOT NULL,
	Value varchar(255) NOT NULL,
	FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
	FOREIGN KEY (CredentialsID) REFERENCES [Credentials](CredentialsID)
);
CREATE TABLE  DoorsCredentials(
    DoorsCredentialsID int IDENTITY(1,1) PRIMARY KEY,
    DoorsID int NOT NULL,
    CredentialsID int NOT NULL,
	Value varchar(255) NOT NULL,
	FOREIGN KEY (DoorsID) REFERENCES Doors(DoorsID),
	FOREIGN KEY (CredentialsID) REFERENCES [Credentials](CredentialsID)
);
CREATE TABLE DoorsDeatails (
    DoorsDeatailsID int IDENTITY(1,1) PRIMARY KEY,
    DoorsID int NOT NULL,
    UsersID int ,
	AccessDate datetime,
    AccessGranted bit,
	FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
	FOREIGN KEY (DoorsID) REFERENCES Doors(DoorsID)
);
