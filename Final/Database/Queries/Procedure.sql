CREATE PROCEDURE GetWaitingRequestWithManagerSsn_Sp 
	@ManagerSsn int
AS
SELECT 
	rf.*,
	r.RequestType,
	r.CreateDate AS 'RequestCreateDate',
	r.Explanation AS 'RequestExplanation',
	r.EmployeeSsn
FROM RequestFlow rf
LEFT JOIN Request r
	ON rf.RequestID = r.RequestID
WHERE rf.ApproverSsn = @ManagerSsn;

CREATE PROCEDURE GetRequestWithEmployeeSsn_Sp 
	@EmployeeSsn int
AS
SELECT 
	r.*,
	e.FirstName + ' ' + e.LastName AS 'EmployeeFullName'
FROM Request r
LEFT JOIN Employee e
	ON r.EmployeeSsn = e.Ssn
WHERE EmployeeSsn = @EmployeeSsn;

CREATE PROCEDURE GetRequestAndFlowWithRequestID_Sp
	@RequestID int
AS
SELECT *
FROM GetRequestWithFlow_View
WHERE RequestID = @RequestID;

CREATE PROCEDURE GetEmployeeWithSsn_Sp
	@EmployeeSsn int
AS
SELECT *
FROM GetEmployee_View
WHERE Ssn = @EmployeeSsn;

CREATE PROCEDURE GetEmployeeAndUserWithSsn_Sp
	@EmployeeSsn int
AS
SELECT 
	gev.Ssn,
	gev.FullName,
	gev.PhoneNumber,
	gev.Mail,
	gev.ManagerName,
	gev.CityName,
	gev.CompanyName,
	gev.CompanyName, 
	gurv.CreateDate AS 'UserCreateDate',
	gurv.Role AS 'UserRole'
FROM Employee e
LEFT JOIN GetEmployee_View gev
	ON e.Ssn = gev.Ssn
LEFT JOIN GetUserRole_View gurv
	ON e.UserID = gurv.UserID
WHERE e.Ssn = @EmployeeSsn;

CREATE PROCEDURE InsertCity_Sp
	@CityName nvarchar(50)
AS
INSERT INTO City (CityName) VALUES (@CityName);

CREATE PROCEDURE InsertCompany_Sp
	@CompanyName nvarchar(50)
AS
INSERT INTO Company (CompanyName)
VALUES (@CompanyName);

CREATE PROCEDURE InsertDepartment_Sp
	@DepartmentID int,
	@DepartmentName nvarchar(50)
AS
INSERT INTO Department (DepartmentName) VALUES (@DepartmentName);

CREATE PROCEDURE InsertUser_Sp
	@UserName nvarchar(25),
	@UserPassword nvarchar(25)
AS
INSERT INTO Users (UserName, UserPassword) VALUES (@UserName, @UserPassword)

CREATE PROCEDURE InsertUserRole_Sp
	@Role nvarchar(25)
AS
INSERT INTO UserRole (Role) VALUES (@Role)

CREATE PROCEDURE InsertEmployee_Sp
	@Ssn int,
	@FirstName nvarchar(25),
	@LastName nvarchar(25),
	@PhoneNumber nvarchar(15),
	@Mail nvarchar(50),
	@ManagerSsn int,
	@UserID int,
	@CityID int,
	@DepartmentID int,
	@CompanyID int
AS
INSERT INTO Employee (Ssn, FirstName, LastName, PhoneNumber, 
	Mail, ManagerSsn, UserID, CityID, DepartmentID, CompanyID) 
VALUES (@Ssn, @FirstName, @LastName, @PhoneNumber, 
	@Mail, @ManagerSsn, @UserID, @CityID, @DepartmentID, @CompanyID);

CREATE PROCEDURE InsertRequest_Sp
	@RequestType tinyint,
	@Explanation nvarchar(250),
	@EmployeeSsn int
AS
INSERT INTO Request (RequestType, Explanation, EmployeeSsn) 
VALUES (@RequestType, @Explanation, @EmployeeSsn);

CREATE PROCEDURE InsertRequestFlow_Sp
	@RequestID int,
	@ApproverSsn int,
	@CloseDate smalldatetime,
	@Status tinyint,
	@Explanation nvarchar(250)
AS
INSERT INTO RequestFlow (RequestID, ApproverSsn, CloseDate, Status, Explanation) 
VALUES (@RequestID, @ApproverSsn, @CloseDate, @Status, @Explanation);

CREATE PROCEDURE InsertLeaveRequest_Sp
	@RequestID int,
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@RequestReason nvarchar(250)
AS
INSERT INTO LeaveRequest (RequestID, StartDate, EndDate, RequestReason) 
VALUES (@RequestID, @StartDate, @EndDate, @RequestReason);

CREATE PROCEDURE InsertTravelRequest_Sp
	@RequestID int,
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@Origin nvarchar(50),
	@Destination nvarchar(50)
AS
INSERT INTO TravelRequest (RequestID, StartDate, EndDate, Origin, Destination) 
VALUES (@RequestID, @StartDate, @EndDate, @Origin, @Destination);

CREATE PROCEDURE InsertAdvanceRequest_Sp
	@RequestID int,
	@RequestedAmount smallmoney,
	@ApprovedAmount smallmoney
AS
INSERT INTO AdvanceRequest (RequestID, RequestedAmount, ApprovedAmount) 
VALUES (@RequestID, @RequestedAmount, @ApprovedAmount);

CREATE PROCEDURE InsertEducationRequest_Sp
	@RequestID int,
	@StartDate smalldatetime,
	@EndDate smalldatetime,
	@EducationName nvarchar(150)
AS
INSERT INTO EducationRequest (RequestID, StartDate, EndDate, EducationName) 
VALUES (@RequestID, @StartDate, @EndDate, @EducationName);

CREATE PROCEDURE InsertOverTimeRequest_Sp
	@RequestID int,
	@Date smalldatetime,
	@Hours int
AS
INSERT INTO OverTimeRequest (RequestID, Date, Hours) 
VALUES (@RequestID, @Date, @Hours);

CREATE PROCEDURE UpdateRequestFlowStatus_Sp
	@RequestFlowID int,
	@Status tinyint
AS
UPDATE RequestFlow
SET Status = @Status,
	CloseDate = CURRENT_TIMESTAMP
WHERE RequestFlowID = @RequestFlowID;