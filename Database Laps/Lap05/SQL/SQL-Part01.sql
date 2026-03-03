-- 1) Retrieve number of students who have a value in their age
SELECT COUNT(*) [Number Of Students] FROM Student WHERE St_Age IS NOT NULL

-- 2) Get all instructors Names without repetition
SELECT DISTINCT Ins_Name FROM Instructor

-- 3) Display student with the following Format (use isNull function)
SELECT s.St_Id [Student ID], 
ISNULL(CONCAT(s.St_Fname, ' ', s.St_Lname), 'No Name') [Student Full Name], 
ISNULL(d.Dept_Name, 'No Department') [Department name]  
FROM Student AS s LEFT JOIN Department AS d
ON s.Dept_Id = d.Dept_Id

-- 4) Display instructor Name and Department Name 
--    Note: display all the instructors if they are attached to a department or not
SELECT Ins_Name, ISNULL(d.Dept_Name, 'No Department') [Department name]  
FROM Instructor AS i LEFT JOIN Department AS d
ON i.Dept_Id = d.Dept_Id

-- 5) Display student full name and the name of the course he is taking 
--    For only courses which have a grade  
SELECT CONCAT(s.St_fName, ' ', s.St_lName) [Student Name], c.Crs_Name [Course Name ]
FROM Student AS s 
INNER JOIN Stud_Course AS sc
ON s.St_Id = sc.St_Id
INNER JOIN Course As c
ON sc.Crs_Id = c.Crs_Id
WHERE sc.Grade IS NOT NULL

-- 6) Display number of courses for each topic name
SELECT t.Top_Name, COUNT(c.Crs_Id) AS [Number Of Courses]
FROM Topic t
LEFT JOIN Course c
ON t.Top_Id = c.Top_Id
GROUP BY t.Top_Name;

-- 7) Display max and min salary for instructors
SELECT MIN(Salary) [Minimum Salary], MAX(Salary) [Maximium Salary]
FROM Instructor 

-- 8) Display instructors who have salaries less than the average salary of all instructors
SELECT Ins_Name
FROM Instructor 
WHERE Salary < (SELECT AVG(Salary) FROM Instructor)


-- 9) Display the Department name that contains the instructor who receives the minimum salary.
SELECT d.Dept_Name
FROM Instructor i
INNER JOIN Department d
ON i.Dept_Id = d.Dept_Id
WHERE i.Salary = (SELECT MIN(Salary) FROM Instructor);

-- 10) Select max two salaries in instructor table.
SELECT TOP(2) Salary
FROM Instructor 
ORDER BY Salary DESC

-- 11) Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function”
SELECT Ins_Name, COALESCE(CAST(Salary AS VARCHAR(10)), 'Bonus') AS [Salary or Bonus]
FROM Instructor;

-- 12) Select Average Salary for instructors 
SELECT AVG(ISNULL(Salary, 0))
FROM Instructor

-- 13) Select Student first name and the data of his supervisor 
SELECT TOP(1) 
    CONCAT(std.St_Fname, ' ', std.St_lname) [Full Name Student] , 
    CONCAT(super.St_Fname, ' ', super.St_Lname) [Supervisor Name],
    super.St_Age,
    super.St_Address,
    super.Dept_Id
FROM Student std INNER JOIN Student super
ON super.St_Id = std.St_super


-- 14) Write a query to select the highest two salaries in Each Department for instructors who have salaries. 
-- “using one of Ranking Functions”
SELECT * FROM
(SELECT Ins_Name, Salary, d.Dept_Id, Dept_Name, ROW_NUMBER() OVER (PARTITION BY d.dept_Id ORDER BY Salary DESC) highest
FROM Instructor i INNER JOIN Department d
ON d.Dept_Id = i.Dept_Id) t
WHERE highest <= 2

-- 15) Write a query to select a random student from each department.  “using one of Ranking Functions”
SELECT *
FROM (SELECT  St_Id, St_Fname, Dept_Id, ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) rn
    FROM Student) t
WHERE rn = 1;