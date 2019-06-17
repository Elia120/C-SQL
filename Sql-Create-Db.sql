CREATE DATABASE SSES;
GO;

CREATE TABLE Users (
    UsersID int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
    DOB date NOT NULL,
	AccessLevel int NOT NULL
);
GO;
CREATE TABLE Doors (
    DoorsID int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
    AccessLevel int
);
GO;
CREATE TABLE [Credentials] (
    [CredentialsID] int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
);
GO;
CREATE TABLE UsersCredentials (
    UsersCredentialsID int IDENTITY(1,1) PRIMARY KEY,
    UsersID int NOT NULL ,
    CredentialsID int NOT NULL,
	FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
	FOREIGN KEY (CredentialsID) REFERENCES [Credentials](CredentialsID)
);
GO;
CREATE TABLE  DoorsCredentials(
    DoorsCredentialsID int IDENTITY(1,1) PRIMARY KEY,
    DoorsID int NOT NULL,
    CredentialsID int NOT NULL,
	FOREIGN KEY (DoorsID) REFERENCES Doors(DoorsID),
	FOREIGN KEY (CredentialsID) REFERENCES [Credentials](CredentialsID)
);
GO;
CREATE TABLE DoorsDeatails (
    DoorsDeatailsID int IDENTITY(1,1) PRIMARY KEY,
    DoorsID int NOT NULL,
    UsersID int ,
	AccessDate datetime,
    AccessGranted bit,
	FOREIGN KEY (UsersID) REFERENCES Users(UsersID),
	FOREIGN KEY (DoorsID) REFERENCES Doors(DoorsID)
);
GO;
