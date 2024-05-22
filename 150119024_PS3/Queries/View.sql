CREATE VIEW GetRequestWithFlow_View AS
SELECT 
	r.RequestID,
	r.RequestType,
	r.EmployeeSsn,
	r.CreateDate AS 'RequestCreateDate',
	r.Explanation AS 'RequestExplanation',
	rf.RequestFlowID,
	rf.ApproverSsn,
	rf.CreateDate AS 'FlowCreateDate',
	rf.CloseDate AS 'FlowCloseDate',
	rf.Explanation AS 'FlowExplanation',
	rf.Status AS 'FlowStatus'
FROM Request r
JOIN RequestFlow rf
ON r.RequestID = rf.RequestID;

CREATE VIEW GetLeaveRequest_View AS
SELECT 
	r.*,
	lr.StartDate,
	lr.EndDate,
	lr.RequestReason,
	lr.TotalDay
FROM Request r
JOIN LeaveRequest lr ON lr.RequestID = r.RequestID
WHERE r.RequestType = 1;

CREATE VIEW GetTravelRequest_View AS
SELECT 
	r.*,
	tr.StartDate,
	tr.EndDate,
	tr.Origin,
	tr.Destination
FROM Request r
JOIN TravelRequest tr ON tr.RequestID = r.RequestID
WHERE r.RequestType = 2;

CREATE VIEW GetAdvanceRequest_View AS
SELECT 
	r.*,
	ar.RequestedAmount,
	ar.ApprovedAmount
FROM Request r
JOIN AdvanceRequest ar ON ar.RequestID = r.RequestID
WHERE r.RequestType = 3;

CREATE VIEW GetEducationRequest_View AS
SELECT 
	r.*,
	er.StartDate,
	er.EndDate,
	er.EducationName
FROM Request r
JOIN EducationRequest er ON er.RequestID = r.RequestID
WHERE r.RequestType = 4;

CREATE VIEW GetOverTimeRequest_View AS
SELECT 
	r.*,
	otr.Date,
	otr.Hours
FROM Request r
JOIN OverTimeRequest otr ON otr.RequestID = r.RequestID
WHERE r.RequestType = 5;

CREATE VIEW GetEmployee_View AS
SELECT 
	e.Ssn,
	e.FirstName + ' ' + e.LastName AS FullName,
	e.PhoneNumber,
	e.Mail,
	mngr.FirstName + ' ' + mngr.LastName AS ManagerName,
	u.UserName,
	u.UserPassword,
	c.CityName,
	co.CompanyName,
	d.DepartmentName
FROM Employee e
LEFT JOIN Employee mngr
	ON e.ManagerSsn = mngr.Ssn
LEFT JOIN Users u
	ON e.UserID = u.UserID
LEFT JOIN City c
	ON e.CityID = c.CityID
LEFT JOIN Company co
	ON e.CompanyID = co.CompanyID
LEFT JOIN Department d
	ON e.DepartmentID = d.DepartmentID;

CREATE VIEW GetUserRole_View AS
SELECT 
	u.UserID,
	u.UserName,
	u.UserPassword,
	u.CreateDate,
	ur.Role
FROM Users u
JOIN UserRole ur
	ON u.UserID = ur.UserID;