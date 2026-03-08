-- 1) Create a cursor for Employee table 
-- that increases Employee salary by 10% if Salary <3000
-- and increases it by 20% if Salary >=3000. Use company DB

USE Company_SD
GO

DECLARE Emp_Cur CURSOR 
FOR SELECT SSN, Fname, Salary FROM Employee
FOR UPDATE 

DECLARE @SSN INT
DECLARE @Fname VARCHAR(50)
DECLARE @Salary INT
OPEN Emp_Cur
FETCH Emp_Cur INTO @SSN, @Fname, @Salary
BEGIN
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF (@Salary < 3000)
            UPDATE Employee
            SET Salary = @Salary * 1.1
            WHERE CURRENT OF Emp_Cur

        ELSE
            UPDATE Employee
            SET Salary = @Salary * 1.2
            WHERE CURRENT OF Emp_Cur
        FETCH Emp_Cur INTO @SSN, @Fname, @Salary
    END
END
CLOSE Emp_Cur
DEALLOCATE Emp_Cur

SELECT SSN, Fname, Salary FROM Employee

-- 2) Display Department name with its manager name using cursor. Use ITI DB

USE ITI 
GO

DECLARE Dept_Cur CURSOR 
FOR SELECT Dept_Name, Ins_Name 
FROM Department d INNER JOIN Instructor i
ON d.Dept_Manager = i.Ins_Id
FOR READ ONLY 

DECLARE @Dept_Name VARCHAR(50)
DECLARE @Ins_Name VARCHAR(50)

OPEN Dept_Cur
FETCH Dept_Cur INTO @Dept_Name, @Ins_Name
BEGIN 
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @Dept_Name [Department Name], @Ins_Name [Manager Name]
        FETCH Dept_Cur INTO @Dept_Name, @Ins_Name
    END
END
CLOSE Dept_Cur
DEALLOCATE Dept_Cur


-- 3) Try to display all students first name in one cell separated by comma. Using Cursor 
DECLARE Stu_cur CURSOR 
FOR SELECT St_Fname FROM Student
FOR READ ONLY

DECLARE @Fname VARCHAR(50)
DECLARE @AllNames VARCHAR(MAX) = ''
OPEN Stu_Cur
FETCH NEXT FROM Stu_Cur INTO @Fname
BEGIN
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @AllNames = CONCAT(@AllNames, @Fname, ',') 
        FETCH NEXT FROM Stu_Cur INTO @Fname
    END
        SELECT LEFT(@AllNames, LEN(@AllNames) - 1) [Students First Name]
END
CLOSE Stu_Cur
DEALLOCATE Stu_Cur

-- 4) Create full, differential Backup for SD30_Company DB.

-- FULL
BACKUP DATABASE Company_SD
TO DISK = '/var/opt/mssql/backup/Company_SD_Full.bak'
WITH FORMAT

-- Differential
BACKUP DATABASE Company_SD
TO DISK = '/var/opt/mssql/backup/Company_SD_Differential.bak'
WITH DIFFERENTIAL

-- 5) Create Login Named Ahmed 
-- and give permission to select
-- and update from tables department, course on ITI

USE ITI
GO

CREATE LOGIN Ahmed
WITH PASSWORD = 'Ahmed@123'

CREATE USER Ahmed12
FOR LOGIN Ahmed

GRANT SELECT,UPDATE
ON Department TO Ahmed12

GRANT SELECT,UPDATE
ON Course TO Ahmed12

-- 6) Create Table Work With EmpID , Project ID , Hours
-- In any Database without PK then insert some values with repeating empid, 
-- project id then write query to calculate sum of hours depend on empid only with subtotal
-- and query to calculate sum of hours depend on empid , project id with subtotal of two columns.  


CREATE TABLE Work (
    EmpID INT,
    ProjectID INT,
    Hours INT,
)

INSERT INTO Work
VALUES (2,2,200),(4,1,30),(1,1,200),(4,1,230),(3,1,200),(1,3,50),(1,1,60),(4,1,250),(1,2,200),(2,1,100)

SELECT EmpID, SUM(Hours) [Hours In Each Emp]
FROM [Work]
GROUP BY EmpID

SELECT EmpID, SUM(Hours) [Total Hours]
FROM [Work]
GROUP BY ROLLUP(EmpID)


SELECT EmpID, ProjectID, SUM(Hours) [Total Hours]
FROM [Work]
GROUP BY ROLLUP(EmpID, ProjectID)