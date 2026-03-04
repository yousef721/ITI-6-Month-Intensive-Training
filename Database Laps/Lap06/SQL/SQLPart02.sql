-- 2) Create the following schema and transfer the following tables to it 
    -- a) Company Schema 
        -- i) Department table (Programmatically)

        CREATE SCHEMA Company
        GO 

        ALTER SCHEMA Company
        TRANSFER Departments
        GO
        -- ii)Project table (using wizard)

        -- Click Edit in Project table
        -- Table Properties --> Schema --> Choose Company
        -- ctr + s to save --> Click update database

    -- b) Human Resource Schema
        -- i ) Employee table (Programmatically)
        CREATE SCHEMA [Human Resource]
        GO

        ALTER SCHEMA [Human Resource]
        TRANSFER Employee
        GO



-- 3) Write query to display the constraints for the Employee table.
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Employee'


-- 4) Create Synonym for table Employee as Emp and then run the following queries and describe the results
CREATE SYNONYM Emp
FOR Employee

GO

Select * from Employee -- Employee Inside Schema [Human Resource] Not In dbo Schema
Select * from [Human Resource].Employee -- Correct
Select * from Emp -- Correct
Select * from [Human Resource].Emp -- SYNONYM Emp In dbo Not [Human Resource] Schema

GO

-- 5) Increase the budget of the project where the manager number is 101022 by 10%.
UPDATE Project
SET Budget = Budget + (Budget * 0.1)
WHERE Dnum IN (SELECT Dnum FROM Company.Departments WHERE MGRSSN = 101022)

-- 6) Change the name of the department for which the employee named James works.The new department name is Sales.
UPDATE Company.Departments
SET Dname = 'Sales'
WHERE MGRSSN = (SELECT SSN FROM [Human Resource].Employee WHERE Fname = 'James')

-- 7) Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. 
-- The new date is 12.12.2007.

-- Project --> Works_for --> Employee --> Departments
UPDATE Project 
SET EnterDate = '2007-12-12'
FROM Project p
INNER JOIN Works_for w
ON p.Pnumber = w.Pno
INNER JOIN [Human Resource].Employee e
ON w.ESSn = e.SSN
INNER JOIN Company.Departments d
ON e.Dno = d.Dnum
WHERE p.Pname = 'P1' AND d.Dname = 'Sales'

-- 8) Delete the information in the works_on table for all employees who work for the department located in KW.
DELETE FROM Works_for
WHERE ESSn IN (
    SELECT SSN
    FROM [Human Resource].Employee e
    WHERE e.Dno IN ( SELECT d.Dnum FROM Company.Departments d WHERE d.Location = 'KW')
)