-- 1 Display the Department id, name and id and the name of its manager.
SELECT dept.Dnum, dept.Dname, Emp.SSN, Emp.Fname + ' ' + Emp.Lname [FULL NAME] 
FROM Departments dept INNER JOIN Employee Emp
ON dept.Dnum = emp.Dno

-- 2 Display the name of the departments and the name of the projects under its control.
SELECT dept.Dname, Pro.Pname
FROM Departments dept INNER JOIN  Project Pro
ON dept.Dnum = Pro.Dnum

-- 3 Display the full data about all the dependence associated with the name of the employee they depend on him/her.
SELECT Emp.Fname + ' ' + Emp.Lname [Employee Name], Dep.*
FROM Employee Emp INNER JOIN Dependent Dep
ON Emp.SSN = Dep.ESSN

--4 Display the Id, name and location of the projects in Cairo or Alex city.
SELECT Pnumber, Pname, Plocation 
FROM Project
WHERE City IN('Cairo', 'Alex city')

--5 Display the Projects full data of the projects with a name starts with "a" letter.
SELECT *
FROM Project
WHERE Pname Like('a%')

-- 6 display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
SELECT Emp.* 
FROM Employee Emp
WHERE Emp.Dno = 30 AND Emp.Salary BETWEEN 1000 AND 2000

-- 7 Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
SELECT Emp.Fname + ' ' + Emp. Lname [Employee Name], Work.[Hours]
FROM Employee Emp INNER JOIN Works_for Work
ON Emp.SSN = Work.ESSN AND Emp.Dno = 10 AND Work.Hours >= 10
INNER JOIN Project Pro
ON Pro.Pnumber = Work.Pno
WHERE Pro.Pname In('AL Rabwah')

-- 8 Find the names of the employees who directly supervised with Kamel Mohamed.
SELECT Emp.Fname + ' ' + Emp. Lname [Employee Name], EmpSup.Superssn
FROM Employee Emp JOIN Employee EmpSup
ON EmpSup.SSN = Emp.Superssn
WHERE EmpSup.Fname + ' ' + EmpSup.Lname IN('Kamel Mohamed') 

-- 9 Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
SELECT Emp.Fname + ' ' + Emp. Lname [Employee Name], Pro.Pname
FROM Employee Emp INNER JOIN Departments Dept
ON Dept.Dnum = Emp.Dno
INNER JOIN Project Pro 
ON Dept.Dnum = Pro.Dnum
ORDER BY Pro.Pname

-- 10 For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
SELECT Pro.Pname, pro.City, Dept.Dname, Emp.Lname, Emp.Address, Emp.Bdate
FROM Project Pro INNER JOIN Departments Dept
ON Dept.Dnum = Pro.Dnum
INNER JOIN Employee Emp 
ON Emp.SSN = Dept.MGRSSN
WHERE Pro.City = 'Cairo'

-- 11 Display All Data of the managers
SELECT DISTINCT Emp.* 
FROM Employee Emp JOIN Employee EmpSup
ON EmpSup.Superssn = Emp.SSN

-- 12 Display All Employees data and the data of their dependents even if they have no dependents
SELECT DISTINCT Emp.*, Dep.*
FROM Employee Emp FULL OUTER JOIN Dependent Dep -- LEFT OUTER JOIN can also be used --> due to the Weak entity
ON Emp.SSN = Dep.ESSN

-- 13 Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000
INSERT INTO Employee
VALUES('Yousef', 'Abdullah', 102672, 2001-07-10, 'Qalybai Obour City El-Maged', 'M', 3000, 112233, 30)

-- 14 Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
INSERT INTO Employee(Fname, Lname, SSN, Bdate, Address, Sex, Dno)
VALUES('Ahmed', 'Mohamed', 102660, 2001-07-10, 'Qalybai Obour City second district', 'M', 30)

-- 15 Upgrade your salary by 20 % of its last value. And display your data .
UPDATE Employee
Set Salary = Salary + (Salary * 0.2) 
SELECT *
FROM Employee