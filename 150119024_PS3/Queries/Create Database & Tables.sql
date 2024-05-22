CREATE DATABASE RequestPortal;
USE RequestPortal;

CREATE TABLE City (
	CityID int IDENTITY(1, 1),
	CityName nvarchar(50),
	PRIMARY KEY (CityID)
);

CREATE TABLE Department (
	DepartmentID int IDENTITY(1, 1),
	DepartmentName nvarchar(50),
	PRIMARY KEY (DepartmentID)
);

CREATE TABLE Company (
	CompanyID int IDENTITY(1, 1),
	CompanyName nvarchar(50),
	PRIMARY KEY (CompanyID)
);

CREATE TABLE Users (
	UserID int IDENTITY(1, 1),
	UserName nvarchar(25),
	UserPassword nvarchar(25),
	CreateDate smalldatetime DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (UserID)
);

CREATE TABLE UserRole (
	UserID int,
	Role nvarchar(25),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
);

CREATE TABLE Employee (
	Ssn int,
	FirstName nvarchar(25),
	LastName nvarchar(25),
	PhoneNumber nvarchar(15),
	Mail nvarchar(50),
	ManagerSsn int,
	UserID int,
	CityID int NOT NULL,
	DepartmentID int NOT NULL,
	CompanyID int NOT NULL,
	PRIMARY KEY (Ssn),
    FOREIGN KEY (ManagerSsn) REFERENCES Employee(Ssn),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (CityID) REFERENCES City(CityID),
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID),
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID)
);

CREATE TABLE Request (
	RequestID int IDENTITY(1, 1),
	RequestType tinyint,
	CreateDate smalldatetime DEFAULT CURRENT_TIMESTAMP,
	Explanation nvarchar(250),
	EmployeeSsn int,
	PRIMARY KEY (RequestID)
);

CREATE TABLE RequestFlow (
	RequestFlowID int IDENTITY(1, 1),
	RequestID int INDEX IX_RequestID NONCLUSTERED,
	ApproverSsn int,
	CreateDate smalldatetime DEFAULT CURRENT_TIMESTAMP,
	CloseDate smalldatetime,
	Status tinyint,
	Explanation nvarchar(250),
	PRIMARY KEY (RequestFlowID),
    FOREIGN KEY (ApproverSsn) REFERENCES Employee(Ssn),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID),
);

CREATE TABLE LeaveRequest (
	RequestID int,
	StartDate smalldatetime,
	EndDate smalldatetime,
	RequestReason nvarchar(250),
	TotalDay AS DATEDIFF(day, StartDate, EndDate),
	PRIMARY KEY (RequestID),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);

CREATE TABLE TravelRequest (
	RequestID int,
	StartDate smalldatetime,
	EndDate smalldatetime,
	Origin nvarchar(50),
	Destination nvarchar(50),
	PRIMARY KEY (RequestID),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);

CREATE TABLE AdvanceRequest (
	RequestID int,
	RequestedAmount smallmoney,
	ApprovedAmount smallmoney,
	CHECK (RequestedAmount > 0),
	CHECK (ApprovedAmount >= 0),
	PRIMARY KEY (RequestID),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);

CREATE TABLE EducationRequest (
	RequestID int,
	StartDate smalldatetime,
	EndDate smalldatetime,
	EducationName nvarchar(150),
	PRIMARY KEY (RequestID),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);

CREATE TABLE OverTimeRequest (
	RequestID int,
	Date smalldatetime,
	Hours int,
	PRIMARY KEY (RequestID),
    FOREIGN KEY (RequestID) REFERENCES Request(RequestID)
);