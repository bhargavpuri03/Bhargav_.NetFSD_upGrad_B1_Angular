use assignments
CREATE TABLE Departments(
DepartmentID INT PRIMARY KEY,
DepartmentName VARCHAR(50) UNIQUE,
Location VARCHAR(50)
);

CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY,
TeacherName VARCHAR(50),
Email VARCHAR(100) UNIQUE,
DepartmentID INT,
HireDate DATE,
Salary DECIMAL(10,2),
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
DateOfBirth DATE,
Gender CHAR(1) CHECK (Gender IN ('M','F')),
DepartmentID INT,
AdmissionDate DATE,
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Courses(
CourseID INT PRIMARY KEY,
CourseName VARCHAR(50),
Credits INT CHECK (Credits BETWEEN 1 AND 5),
DepartmentID INT,
TeacherID INT,
FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Enrollments(
EnrollmentID INT PRIMARY KEY,
StudentID INT,
CourseID INT,
EnrollmentDate DATE DEFAULT GETDATE(),
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
CourseID INT,
ExamDate DATE,
ExamType VARCHAR(50),
FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

CREATE TABLE Marks(
MarkID INT PRIMARY KEY,
StudentID INT,
ExamID INT,
MarksObtained INT CHECK (MarksObtained BETWEEN 0 AND 100),
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

INSERT INTO Departments VALUES
(1,'Computer Science','Block A'),
(2,'Mechanical','Block B'),
(3,'Electrical','Block C');

INSERT INTO Teachers VALUES
(1,'Rahul Sharma','rahul@gmail.com',1,'2022-06-10',50000),
(2,'Priya Reddy','priya@gmail.com',2,'2021-05-12',45000),
(3,'Amit Kumar','amit@gmail.com',3,'2023-02-15',40000);

INSERT INTO Students VALUES
(1,'Aarav','Sharma','2006-04-10','M',1,'2023-06-01'),
(2,'Ananya','Reddy','2005-07-15','F',1,'2023-06-01'),
(3,'Rohan','Kumar','2007-01-20','M',2,'2023-06-01'),
(4,'Priya','Nair','2006-11-05','F',3,'2023-06-01'),
(5,'Karthik','Singh','2005-02-18','M',2,'2023-06-01');

INSERT INTO Courses VALUES
(1,'Database Systems',4,1,1),
(2,'Thermodynamics',3,2,2),
(3,'Circuit Theory',3,3,3);

INSERT INTO Enrollments VALUES
(1,1,1,GETDATE()),
(2,2,1,GETDATE()),
(3,3,2,GETDATE()),
(4,4,3,GETDATE()),
(5,5,2,GETDATE());

INSERT INTO Exams VALUES
(1,1,'2024-03-10','Midterm'),
(2,2,'2024-03-15','Midterm'),
(3,3,'2024-03-20','Midterm');

INSERT INTO Marks VALUES
(1,1,1,85),
(2,2,1,78),
(3,3,2,65),
(4,4,3,88),
(5,5,2,72);

ALTER TABLE Students ADD PhoneNumber VARCHAR(15);

ALTER TABLE Teachers
ADD CONSTRAINT chk_salary CHECK (Salary > 20000);

ALTER TABLE Students DROP COLUMN PhoneNumber;

EXEC sp_rename 'Students.FirstName','StudentFirstName','COLUMN';

CREATE INDEX idx_student_lastname
ON Students(LastName);

CREATE INDEX idx_teacher_email
ON Teachers(Email);

CREATE INDEX idx_enrollment
ON Enrollments(StudentID,CourseID);

CREATE UNIQUE INDEX idx_departmentname
ON Departments(DepartmentName);

SELECT * FROM Students
WHERE DepartmentID =
(SELECT DepartmentID FROM Departments
WHERE DepartmentName='Computer Science');

SELECT * FROM Teachers
WHERE HireDate > '2022-01-01';

SELECT * FROM Students
WHERE StudentFirstName LIKE 'A%';

SELECT * FROM Courses
WHERE Credits > 3;

SELECT * FROM Students
WHERE DateOfBirth BETWEEN '2005-01-01' AND '2008-12-31';

SELECT * FROM Students
WHERE DepartmentID <>
(SELECT DepartmentID FROM Departments
WHERE DepartmentName='Mechanical');

SELECT * FROM Teachers
WHERE Salary BETWEEN 40000 AND 70000;

SELECT * FROM Courses
WHERE TeacherID <> 3;

SELECT DepartmentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY DepartmentID;

SELECT ExamID, AVG(MarksObtained) AS AvgMarks
FROM Marks
GROUP BY ExamID;

SELECT CourseID, COUNT(StudentID) AS TotalStudents
FROM Enrollments
GROUP BY CourseID;

SELECT ExamID, MAX(MarksObtained)
FROM Marks
GROUP BY ExamID;

SELECT CourseID, MIN(MarksObtained)
FROM Marks m
JOIN Exams e ON m.ExamID=e.ExamID
GROUP BY CourseID;

SELECT DepartmentID, COUNT(*) AS Total
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) > 5;

SELECT s.StudentFirstName, d.DepartmentName
FROM Students s
JOIN Departments d
ON s.DepartmentID = d.DepartmentID;

SELECT c.CourseName, t.TeacherName
FROM Courses c
JOIN Teachers t
ON c.TeacherID = t.TeacherID;

SELECT s.StudentFirstName, c.CourseName
FROM Students s
JOIN Enrollments e ON s.StudentID = e.StudentID
JOIN Courses c ON e.CourseID = c.CourseID;

SELECT s.StudentFirstName, m.MarksObtained, e.ExamType
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
JOIN Exams e ON m.ExamID = e.ExamID;

SELECT c.CourseName, t.TeacherName
FROM Courses c
LEFT JOIN Teachers t
ON c.TeacherID = t.TeacherID;

SELECT * FROM Teachers
WHERE TeacherID NOT IN
(SELECT TeacherID FROM Courses);

SELECT *
FROM Students
WHERE StudentID IN
(SELECT StudentID FROM Marks
WHERE MarksObtained >
(SELECT AVG(MarksObtained) FROM Marks));

SELECT * FROM Courses
WHERE Credits =
(SELECT MAX(Credits) FROM Courses);

SELECT StudentID
FROM Enrollments
GROUP BY StudentID
HAVING COUNT(CourseID) > 2;

SELECT *
FROM Teachers
WHERE DepartmentID =
(SELECT DepartmentID FROM Teachers
WHERE TeacherName='John');

SELECT *
FROM Marks
WHERE MarksObtained =
(SELECT MAX(MarksObtained) FROM Marks);

SELECT DepartmentID
FROM Students
GROUP BY DepartmentID
HAVING COUNT(*) =
(SELECT MAX(cnt)
FROM
(SELECT COUNT(*) cnt FROM Students GROUP BY DepartmentID) t);

CREATE VIEW StudentDepartmentView AS
SELECT s.StudentID,
s.StudentFirstName + ' ' + s.LastName AS StudentName,
d.DepartmentName
FROM Students s
JOIN Departments d
ON s.DepartmentID=d.DepartmentID;

CREATE VIEW StudentCourseView AS
SELECT s.StudentFirstName,
c.CourseName,
e.EnrollmentDate
FROM Students s
JOIN Enrollments e ON s.StudentID=e.StudentID
JOIN Courses c ON e.CourseID=c.CourseID;

CREATE VIEW ExamResultView AS
SELECT s.StudentFirstName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID=m.StudentID
JOIN Exams e ON m.ExamID=e.ExamID
JOIN Courses c ON e.CourseID=c.CourseID;

DROP VIEW StudentDepartmentView;

DROP INDEX idx_student_lastname ON Students;