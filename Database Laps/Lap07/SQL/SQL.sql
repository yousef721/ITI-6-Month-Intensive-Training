USE ITI
GO
-- 1) Create a stored procedure without parameters to show the number of students per department name.[use ITI DB]
 CREATE PROCEDURE P_No_Stud_Dept
 AS
 BEGIN
    SELECT Dept_Name, COUNT(St_Id) [Number of Students] 
    FROM Student s RIGHT JOIN Department d
    ON d.Dept_Id = s.Dept_Id
    GROUP BY Dept_Name
 END

EXEC P_No_Stud_Dept
GO
-- 2) Create a stored procedure takes 2 integers and returns the Even values between them.
 CREATE PROCEDURE Who_Even(@a INT, @b INT)
 AS
 BEGIN
    IF (@a > @b)
    BEGIN
        DECLARE @temp INT
        SET @temp = @a
        SET @a = @b
        SET @b = @temp
    END
    WHILE (@a <= @b)
    BEGIN
        IF (@a % 2 = 0) SELECT @a [Even_Numbers]
        SET @a = @a + 1
    End
 END

 EXECUTE Who_Even 2,8
 GO

 -- 3) Create a stored procedure that will check for the # of employees in the project p1
 -- if they are more than 3 print message to the user 
 --     “'The number of employees in the project p1 is 3 or more'” 
 -- if they are less display a message to the user 
 --     “'The following employees work for the project p1'” 
 --         in addition to the first name and last name of each one. [Company DB] 

 USE Company_SD 
 GO

 CREATE PROCEDURE Emp_Pro 
 AS
 BEGIN
    DECLARE @count INT
    SELECT @count = COUNT(SSN) 
                 FROM Employee e INNER JOIN Works_for w
                 ON w.ESSn = e.SSN
                 RIGHT JOIN Project p
                 ON w.Pno = p.Pnumber
                 WHERE p.Pname = 'p1'

    IF (@count >= 3)
        SELECT 'The number of employees in the project p1 is 3 or more'
    ELSE
    BEGIN
        SELECT 'The following employees work for the project p1'

        SELECT Fname, Lname
        FROM Employee e INNER JOIN Works_for w
        ON w.ESSn = e.SSN
        RIGHT JOIN Project p
        ON w.Pno = p.Pnumber
        WHERE p.Pname = 'p1'
    END
 END
 
EXEC Emp_Pro
GO

 -- 4) Create multi-statements table-valued function that takes a string
        -- If string='first name' returns student first name
        -- If string='last name' returns student last name 
        -- If string='full name' returns Full Name from student table 
    -- Note: Use “ISNULL” function
USE ITI
GO

CREATE PROCEDURE Check_Name (@str NVARCHAR(20))
AS
BEGIN
    IF (@str = 'first name')
        SELECT ISNULL(St_Fname, 'Not Found Name') [first name] FROM Student
    ELSE IF (@str = 'last name')
        SELECT ISNULL(St_Lname, 'Not Found Name') [last name] FROM Student
    ELSE IF (@str = 'full name')
        SELECT CONCAT(ISNULL(St_fname, ''), ' ', ISNULL(St_Lname, '')) [full name] FROM Student
    ELSE
        SELECT 'Invalid Input Choose From This --> (first name, last name, full name)'
END

EXEC Check_Name 'first name'
EXEC Check_Name 'last name'
EXEC Check_Name 'full name'
EXEC Check_Name ' '
GO


-- 5) Create a stored procedure that will be used 
-- in case there is an old employee has left the project 
-- and a new one become instead of him.
-- The procedure should take 3 parameters 
-- (old Emp number, new Emp number and the project number) 
-- and it will be used to update works_on table. [Company DB]

USE Company_SD
GO

CREATE PROCEDURE Update_Info_Emp (@noOldEmp INT, @noNewEmp INT, @noPro INT)
AS 
BEGIN
    IF EXISTS(SELECT ESSN, Pno FROM Works_for WHERE ESSn = @noOldEmp AND Pno = @noPro)
        UPDATE Works_for
        SET ESSn = @noNewEmp
        WHERE ESSn = @noOldEmp AND Pno = @noPro
    ELSE
       PRINT 'Employee Is Not Exist In This Project'
END

EXEC Update_Info_Emp 2, 4, 5
EXEC Update_Info_Emp 512463, 112233, 600 
GO

-- 6) add column budget in project table and insert any draft values in it. 
    -- then Create an Audit table with the following structure 

-- This table will be used to audit the update trials on the Budget column (Project table, Company DB)
-- Example:
-- If a user updated the budget column then the project number, 
-- user name that made that update, the date of the modification 
-- and the value of the old and the new budget will be inserted into the Audit table
-- Note: This process will take place only if the user updated the budget column


-- 7) Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
-- “Print a message for user to tell him that he can’t insert a new record in that table”

USE ITI
GO

CREATE TRIGGER Prevent_insert ON Department INSTEAD OF INSERT
AS
BEGIN
    PRINT 'You can’t insert a new record in this table'
ENd

INSERT INTO Department (Dept_Id, Dept_Name, Dept_Desc, Dept_Location)
VALUES (80, 'AR', 'Arabic', 'Cairo')

GO

-- 8) Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
USE Company_SD
GO
CREATE TRIGGER Prevent_insert ON Employee INSTEAD OF INSERT
AS
BEGIN
    IF MONTH(GETDATE()) = 3
        PRINT 'You can’t insert a new record in this table'
    ELSE
        INSERT INTO Employee
        SELECT * FROM inserted
END

INSERT INTO Employee (Fname, Lname, SSN, Address, Sex, Salary)
VALUES ('Yousef', 'Abdullah', 101099, 'Cairo', 'M', 50000)

-- 9) Create a trigger on student table after insert to 
-- add Row in Student Audit table (Server User Name , Date, Note) 
-- where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”