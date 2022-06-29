USE [Payroll_Service_DB]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[SpAddEmployeeDetails]
		@name = N'chinki',
		@salary = 28000,
		@startDate = 28-04-2022,
		@Gender = N'female',
		@phone_number = 7566752725,
		@address = N'khushipura',
		@department = N'developer',
		@basic_pay = 300000

SELECT	'Return Value' = @return_value

GO
