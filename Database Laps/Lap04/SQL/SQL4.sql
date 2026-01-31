-- 1 Display sum salary of employees who work in department number  10
SELECT Fname, SUM(Salary)
FROM Employee
WHERE Dno IN(10)
GROUP BY Fname

-- 2 Display average salaries of employees 
SELECT AVG(Salary)
FROM Employee


-- 3 Display average salaries of employees in department number 10
SELECT AVG(Salary), Dno
FROM Employee
WHERE Dno IN(10)
GROUP BY Dno

-- 4 Count the employees who work in project number 100
SELECT Fname, Count(*) [No Of Employees] 
FROM Employee
WHERE Dno IN(SELECT Dnum FROM Project WHERE Pnumber = 100)
GROUP BY Fname

-- 5 Count the employees depends on their departments
SELECT Count(*) [No Of Employees], Dno
FROM Employee
GROUP BY Dno

-- 6 Sum hours of each project 
SELECT SUM(hours) [Sum Hours], Pno
FROM Works_for
GROUP BY Pno

-- 7 Display employee full name and project name where city of project = Cairo and the and the address of its employees has Giza
SELECT CONCAT(Fname,' ',Lname), Pro.Pname, City, Address
FROM Employee Emp INNER JOIN Departments Dept
ON Dept.Dnum = Emp.Dno
INNER JOIN Project Pro
ON Dept.Dnum = Pro.Dnum
WHERE City IN('Cairo') AND Emp.Address LIKE('%Giza%')

-- 8 Display full name of employees and their salaries when salary greater than average of salaries 
SELECT CONCAT(Fname,' ',Lname), salary 
FROM Employee
WHERE Salary > (SELECT AVG(Salary) FROM Employee) 

-- 9 Display the super visor names without duplication
SELECT DISTINCT CONCAT(empSuper.Fname,' ',empSuper.Lname) 
FROM Employee emp INNER JOIN Employee empSuper
ON empSuper.SSN = emp.Superssn


-- 10 Try to map the ERD and then create DB with the following Constraints:
-- • All Ids are Identity
-- • All Foreign keys are not identity
-- • All foreign keys have cascade rule on delete and update
-- • Age and Netsalary are calculated attributes but it will be on instructor table creation
-- • Netsalary = salary + overtime
-- • Age = current year – birthdate year
-- • Address has only cairo or alex value
-- • All salaries in the range from 1000 to 5000
-- • Salary has a default value = 3000
-- • Overtime is unique
-- • Capacity of each lab under 20 seats
-- • Lab is weak entity
-- • Hiredate has a default value = current system data
-- • Duration of each course is unique

CREATE TABLE Instructor(
    ID INT PRIMARY KEY IDENTITY,
    FName NVARCHAR(20),
    LName NVARCHAR(20),
    Salary MONEY DEFAULT(3000),
    HierDate DATE DEFAULT(GETDATE()),
    Address NVARCHAR(50),
    OverTime INT UNIQUE,
    BD DATE,
    Age AS(YEAR(GETDATE()) - YEAR(BD)),
    Netsalary AS(Salary + OverTime),

    CONSTRAINT AddressCon CHECK(Address IN('Cairo', 'Alex')),
    CONSTRAINT SalaryCon CHECK(Salary BETWEEN 1000 AND 3000),
)

CREATE TABLE Course(
    CID INT PRIMARY KEY IDENTITY,
    CName NVARCHAR(50),
    Duration INT UNIQUE
)

CREATE TABLE Lap(
    LID INT PRIMARY KEY IDENTITY,
    CID INT,
    Location NVARCHAR(100),
    Capacity INT CHECK(Capacity <= 20),

    CONSTRAINT FK_Lap_Course FOREIGN KEY(CID) REFERENCES Course(CID)
    ON DELETE CASCADE ON UPDATE CASCADE,
)


CREATE TABLE Instructor_Course(
    CID INT,
    IID INT

    CONSTRAINT Instructor_Course_Composite_Key PRIMARY KEY(CID, IID)

    CONSTRAINT FK_Lap_10 FOREIGN KEY(CID) REFERENCES Course(CID)
    ON DELETE CASCADE ON UPDATE CASCADE,

    CONSTRAINT FK_Instructor_10 FOREIGN KEY(IID) REFERENCES Instructor(ID)
    ON DELETE CASCADE ON UPDATE CASCADE,
)

