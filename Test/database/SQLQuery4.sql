IF object_id(N'weekdays', N'FN') IS NOT NULL
  DROP FUNCTION weekdays
GO

CREATE FUNCTION [dbo].[weekdays]
( 
	@FirstDate DATE, 
	@SecondDate DATE
)
RETURNS int   
AS
BEGIN
  DECLARE @StartDate DATETIME
  DECLARE @EndDate DATETIME
  DECLARE @Workdays INT
  IF( @FirstDate > @SecondDate)
     BEGIN
       SET @StartDate = @SecondDate
       SET @EndDate = @FirstDate
     END
  ELSE
    BEGIN
      SET @StartDate = @FirstDate
      SET @EndDate = @SecondDate
    END

-- Get all days in range, remove weekends, remove boundary dates if they are part of the weekend
  SET @WorkDays = 
     (DATEDIFF(dd, @StartDate, @EndDate) + 1) 
    -(DATEDIFF(wk, @StartDate, @EndDate) * 2) 
    -(CASE WHEN DATENAME(dw, @StartDate) = 'Sunday' THEN 1 ELSE 0 END)
    -(CASE WHEN DATENAME(dw, @EndDate) = 'Saturday' THEN 1 ELSE 0 END)
    
    RETURN @WorkDays
END
GO
