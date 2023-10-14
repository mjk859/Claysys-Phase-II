CREATE DATABASE EMPLOYEEMANAGEMENT;
USE EMPLOYEEMANAGEMENT;

CREATE TABLE EMPLOYEES
(
	EMPLOYEEID		INT			PRIMARY KEY,
	FIRSTNAME		VARCHAR(50),
	LASTNAME		VARCHAR(50),
	DATEOFBIRTH		DATETIME,
	EMAIL			VARCHAR(100),
	PHONENUMBER		VARCHAR(20),
	ADDRESS			TEXT,
	DEPARTMENTID	INT,
	HIREDATE		DATE,
	SALARY			FLOAT
);

CREATE TABLE DEPARTEMENTS
(
	DEPARTMENTID	INT			PRIMARY KEY,
	DEPARTMENTNAME	VARCHAR(50),
	MANAGERID		INT,
	LOCATION		VARCHAR(100),
	BUDGET			FLOAT
);

INSERT INTO EMPLOYEES(EMPLOYEEID, FIRSTNAME, LASTNAME, DATEOFBIRTH, EMAIL, PHONENUMBER, ADDRESS, DEPARTMENTID, HIREDATE, SALARY)
VALUES (1, 'Rahul', 'KP', '1990-05-15', 'rahulkp@email.com', '9876543210', 'Church Street, Banglore', 1, '2023-01-10', 60000.00);

UPDATE EMPLOYEES
SET SALARY = 65000.00
WHERE EMPLOYEEID = 1;

SELECT * FROM EMPLOYEES WHERE EMPLOYEEID = 1;

DELETE FROM EMPLOYEES WHERE EMPLOYEEID = 1;

SELECT * FROM EMPLOYEES;

INSERT INTO EMPLOYEES(EmployeeID, FirstName, LastName, Salary)
VALUES
    (1, 'Rahul', 'KP', 50000.00),
    (2, 'Sahal', 'Abdul', 60000.00),
    (3, 'Sandesh', 'Jhingan', 75000.00),
    (4, 'Jeakson', 'Singh', 65000.00);

use employeemanagement;

SELECT * FROM Employees;
SELECT * FROM DEPARTEMENTS;

SELECT DISTINCT TOP 1 Salary
FROM (
    SELECT DISTINCT TOP 2 Salary
    FROM EMPLOYEES
    ORDER BY Salary DESC
) AS SecondHighestSalary
ORDER BY Salary ASC;

TRUNCATE TABLE Employees;

INSERT INTO Employees (EmployeeID, FirstName, LastName, DateOfBirth, Email, PhoneNumber, Address, DepartmentID, HireDate, Salary)
VALUES
	(1, 'Rahul', 'KP', '1990-05-15', 'rahulkp@email.com', '9876543210', 'Church Street, Banglore', 1, '2023-01-10', 50000.00),
    (2, 'Sahal', 'Abdul', '1992-08-20', 'sahal@email.com', '9876543211', 'Main Street, Banglore', 1, '2023-01-15', 60000.00),
    (3, 'Sandesh', 'Jhingan', '1989-07-05', 'sandesh@email.com', '9876543212', 'Park Avenue, Banglore', 2, '2023-02-01', 75000.00),
    (4, 'Jeakson', 'Singh', '1997-03-25', 'jeakson@email.com', '9876543213', 'Oak Street, Banglore', 1, '2023-03-10', 65000.00);

SELECT DepartmentID, COUNT(*) AS NumberOfEmployees
FROM Employees
GROUP BY DepartmentID;

INSERT INTO DEPARTEMENTS (DepartmentID, DepartmentName, ManagerID, Location, Budget)
VALUES
    (1, 'Engineering', 1, 'Bangalore', 1000000.00),
    (2, 'Marketing', 3, 'Bangalore', 800000.00);

SELECT E.FirstName, E.LastName, D.DepartmentName
FROM Employees E
INNER JOIN Departements D ON E.DepartmentID = D.DepartmentID;

SELECT E.FirstName, E.LastName, D.DepartmentName
FROM Employees E
LEFT JOIN Departements D ON E.DepartmentID = D.DepartmentID;

SELECT E.FirstName, E.LastName, D.DepartmentName
FROM Employees E
RIGHT JOIN Departements D ON E.DepartmentID = D.DepartmentID;

SELECT E.FirstName, E.LastName, D.DepartmentName
FROM Employees E
FULL JOIN Departements D ON E.DepartmentID = D.DepartmentID;

ALTER TABLE Employees
ADD PRIMARY KEY (EmployeeID);

DROP Table Employees, Departements;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT
);

SELECT * FROM Employees;

CREATE TABLE DEPARTMENTS (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(50),
    ManagerID INT
);

SELECT * FROM Employees;

SELECT E.FirstName, E.LastName, D.DepartmentName
FROM EMPLOYEES E
INNER JOIN DEPARTMENTS D ON E.DepartmentID = D.DepartmentID;

-- Create (INSERT) Operation:
CREATE PROCEDURE InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT
AS
BEGIN
    INSERT INTO EMPLOYEES (FirstName, LastName, DepartmentID)
    VALUES (@FirstName, @LastName, @DepartmentID);
END;

-- Read (SELECT) Operation:
CREATE PROCEDURE GetEmployeeByID
    @EmployeeID INT
AS
BEGIN
    SELECT * FROM EMPLOYEES WHERE EmployeeID = @EmployeeID;
END;

-- Update Operation:
CREATE PROCEDURE UpdateEmployee
    @EmployeeID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @DateOfBirth DATETIME,
    @Email VARCHAR(100),
    @PhoneNumber VARCHAR(20),
    @Address TEXT,
    @HireDate DATE,
    @Salary FLOAT
AS
BEGIN
    UPDATE EMPLOYEES
    SET FirstName = @FirstName, LastName = @LastName, DepartmentID = @DepartmentID
    WHERE EmployeeID = @EmployeeID;
END;

-- Delete Operation:
CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM EMPLOYEES WHERE EmployeeID = @EmployeeID;
END;

CREATE PROCEDURE ManageEmployee
    @Operation VARCHAR(10),
    @EmployeeID INT = NULL,
    @FirstName VARCHAR(50) = NULL,
    @LastName VARCHAR(50) = NULL,
    @DepartmentID INT = NULL
    
AS
BEGIN
    IF @Operation = 'INSERT'
    BEGIN
        INSERT INTO Employees (FirstName, LastName, DepartmentID)
        VALUES (@FirstName, @LastName, @DepartmentID);
    END
    ELSE IF @Operation = 'UPDATE'
    BEGIN
        UPDATE Employees
        SET FirstName = ISNULL(@FirstName, FirstName),
            LastName = ISNULL(@LastName, LastName),
            DepartmentID = ISNULL(@DepartmentID, DepartmentID)
        WHERE EmployeeID = @EmployeeID;
    END
    ELSE IF @Operation = 'DELETE'
    BEGIN
        DELETE FROM Employees WHERE EmployeeID = @EmployeeID;
    END
    ELSE IF @Operation = 'SELECT'
    BEGIN
        SELECT * FROM Employees WHERE EmployeeID = @EmployeeID;
    END
END;

-- Insert a new employee:
EXEC ManageEmployee 'INSERT', 'John', 'Doe', 1;

EXEC ManageEmployee 'UPDATE', 1, 'UpdatedFirstName';

EXEC ManageEmployee 'DELETE', 1;

EXEC ManageEmployee 'SELECT', 1;

CREATE TABLE Sales (
    ProductName VARCHAR(50),
    SalesDate DATE,
    SalesAmount DECIMAL(10, 2)
);

INSERT INTO Sales (ProductName, SalesDate, SalesAmount)
VALUES
    ('Product A', '2023-01-01', 100.00),
    ('Product B', '2023-01-01', 150.00),
    ('Product A', '2023-01-02', 120.00),
    ('Product B', '2023-01-02', 160.00);

SELECT *
FROM Sales
PIVOT (
    SUM(SalesAmount)
    FOR SalesDate IN ([2023-01-01], [2023-01-02])
) AS PivotTable;

SELECT ProductName, SalesDate, SalesAmount
FROM PivotTable
UNPIVOT (
    SalesAmount FOR SalesDate IN ([2023-01-01], [2023-01-02])
) AS UnpivotTable;

WITH PivotTable AS (
    -- Your pivot query here
    SELECT *
    FROM Sales
    PIVOT (
        SUM(SalesAmount)
        FOR SalesDate IN ([2023-01-01], [2023-01-02])
    ) AS PivotTable
)

SELECT ProductName, SalesDate, SalesAmount
FROM PivotTable
UNPIVOT (
    SalesAmount FOR SalesDate IN ([2023-01-01], [2023-01-02])
) AS UnpivotTable;

-- Create the source and target tables
CREATE TABLE SourceData (
    ID INT PRIMARY KEY,
    Value INT
);

CREATE TABLE TargetData (
    ID INT PRIMARY KEY,
    Value INT
);

-- Insert sample data into both tables
INSERT INTO SourceData (ID, Value)
VALUES (1, 100), (2, 200), (3, 300);

INSERT INTO TargetData (ID, Value)
VALUES (1, 150), (2, 200);

MERGE INTO TargetData AS Target
USING SourceData AS Source
ON Target.ID = Source.ID
WHEN MATCHED THEN
    UPDATE SET Value = Source.Value
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ID, Value) VALUES (Source.ID, Source.Value)
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

SELECT * FROM TargetData;
