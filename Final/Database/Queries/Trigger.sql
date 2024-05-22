CREATE TRIGGER InsertFlowAfterInsertedRequest ON Request
AFTER INSERT AS 
BEGIN
	DECLARE 
	@RequestId int,
	@ManagerSsn int,
	@Now smalldatetime = CURRENT_TIMESTAMP

	SELECT @RequestId = i.RequestID
	FROM inserted i;

	SELECT @ManagerSsn = e.ManagerSsn
	FROM inserted i
	LEFT JOIN Employee e
		ON i.EmployeeSsn = e.Ssn;

	EXEC InsertRequestFlow_Sp
	@RequestID = @RequestId,
	@ApproverSsn = @ManagerSsn,
	@CloseDate = @Now,
	@Status = 1,
	@Explanation = NULL
END;