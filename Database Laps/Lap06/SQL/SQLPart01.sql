-- 1) Create a view that displays student full name, course name if the student has a grade more than 50. 
CREATE VIEW Std_Crs AS
SELECT CONCAT(St_Fname, ' ', St_Lname) AS [FULL NAME], Crs_Name , Grade
FROM Student s 
INNER JOIN Stud_Course sc
ON sc.St_Id = s.St_Id
INNER JOIN Course c
ON sc.Crs_Id = c.Crs_Id
WHERE Grade > 50;

GO

SELECT * 
FROM Std_Crs

GO
-- 2) Create an Encrypted view that displays manager names and the topics they teach. 
-- Instructor --> Ins-Course --> Course --> Topic
CREATE VIEW Ins_Topic
WITH ENCRYPTION
AS
SELECT Ins_Name, Top_Name
FROM Instructor i 
INNER JOIN Ins_Course ic
ON ic.Ins_Id = i.Ins_Id
INNER JOIN Course c
ON c.Crs_Id = ic.Crs_Id
INNER JOIN Topic t
ON t.Top_Id = c.Top_Id

GO 

SELECT * 
FROM Ins_Topic

GO

-- 3) Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
SELECT Ins_Name, Dept_Name
FROM Instructor i 
INNER JOIN Department d
ON i.Dept_Id = d.Dept_Id
WHERE Dept_Name IN('SD', 'Java')

GO

-- 4)  Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
-- Note: Prevent the users to run the following query 
-- Update V1 set st_address=’tanta’
-- Where st_address=’alex’;
CREATE VIEW V1 AS
SELECT St_Fname, St_Address 
FROM Student
WHERE St_Address IN('Alex', 'Cairo')
WITH CHECK OPTION

GO

SELECT * 
FROM V1

UPDATE V1
SET St_Address = 'tanta'
WHERE St_Address = 'Alex'

GO

-- 5 Create a view that will display the project name and the number of employees work on it. “Use Company DB”
-- Project --> Department --> Employees
CREATE VIEW Pro_Emp AS
SELECT p.Pname, e.Fname
FROM Company_SD.dbo.Project p 
INNER JOIN Company_SD.dbo.Departments d
ON p.Dnum = d.Dnum
INNER JOIN Company_SD.dbo.Employee e
ON e.Dno = d.Dnum

GO 

SELECT * 
FROM Pro_Emp

-- 6) Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
CREATE CLUSTERED INDEX Idx_Hiredate ON  Department(Manager_Hiredate)
-- Cannot create more than one clustered index on Departments

-- 7) Create index that allow u to enter unique ages in student table. What will happen?
CREATE UNIQUE INDEX Idx_ages ON Student(St_Age)
--  duplicate key was found for the object name 'dbo.Student'