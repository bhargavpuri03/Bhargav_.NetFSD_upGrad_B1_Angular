--Assignment 1

CREATE VIEW vw_StudentDepartment AS
SELECT 
s.StudentID,
s.StudentFirstName + ' ' + s.LastName AS StudentName,
d.DepartmentName,
s.AdmissionDate
FROM Students s
JOIN Departments d
ON s.DepartmentID = d.DepartmentID;

SELECT * FROM vw_StudentDepartment;

SELECT * FROM vw_StudentDepartment
WHERE DepartmentName='Computer Science';

DROP VIEW vw_StudentDepartment;


--Assignment 2

CREATE VIEW vw_StudentCourses AS
SELECT
s.StudentFirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.EnrollmentDate
FROM Students s
JOIN Enrollments e ON s.StudentID=e.StudentID
JOIN Courses c ON e.CourseID=c.CourseID;

SELECT *
FROM vw_StudentCourses
WHERE StudentName IN
(
SELECT StudentFirstName + ' ' + LastName
FROM Students
WHERE StudentID=5
);

SELECT StudentName,COUNT(*) AS TotalCourses
FROM vw_StudentCourses
GROUP BY StudentName;

SELECT *
FROM vw_StudentCourses
WHERE EnrollmentDate>'2024-01-01';


--Assignment 3

CREATE VIEW vw_ExamResults AS
SELECT
s.StudentFirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID=m.StudentID
JOIN Exams e ON m.ExamID=e.ExamID
JOIN Courses c ON e.CourseID=c.CourseID;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained>80;

SELECT *
FROM vw_ExamResults
WHERE MarksObtained=
(SELECT MAX(MarksObtained) FROM Marks);

SELECT *
FROM vw_ExamResults
WHERE MarksObtained<40;


--Assignment 4

CREATE VIEW vw_DepartmentStudentCount AS
SELECT
d.DepartmentName,
COUNT(s.StudentID) AS TotalStudents
FROM Departments d
JOIN Students s
ON d.DepartmentID=s.DepartmentID
GROUP BY d.DepartmentName;

SELECT *
FROM vw_DepartmentStudentCount
WHERE TotalStudents>10;

SELECT *
FROM vw_DepartmentStudentCount
ORDER BY TotalStudents DESC;


--Assignment 5

CREATE PROCEDURE sp_InsertStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Gender CHAR(1),
@DepartmentID INT,
@AdmissionDate DATE
AS
BEGIN
INSERT INTO Students
(StudentID,StudentFirstName,LastName,Gender,DepartmentID,AdmissionDate)
VALUES
((SELECT MAX(StudentID)+1 FROM Students),
@FirstName,@LastName,@Gender,@DepartmentID,@AdmissionDate);
END;

EXEC sp_InsertStudent 'Raj','Patel','M',1,'2024-06-01';

SELECT * FROM Students;


--Assignment 6

CREATE PROCEDURE sp_GetStudentsByDepartment
@DepartmentID INT
AS
BEGIN
SELECT
StudentID,
StudentFirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students
WHERE DepartmentID=@DepartmentID;
END;

EXEC sp_GetStudentsByDepartment 2;
EXEC sp_GetStudentsByDepartment 3;


--Assignment 7

CREATE PROCEDURE sp_EnrollStudent
@StudentID INT,
@CourseID INT
AS
BEGIN
INSERT INTO Enrollments
VALUES
((SELECT MAX(EnrollmentID)+1 FROM Enrollments),
@StudentID,
@CourseID,
GETDATE());
END;

EXEC sp_EnrollStudent 1,2;


--Assignment 8

CREATE PROCEDURE sp_GetStudentMarks
@StudentID INT
AS
BEGIN
SELECT
s.StudentFirstName + ' ' + s.LastName AS StudentName,
c.CourseName,
e.ExamType,
m.MarksObtained
FROM Students s
JOIN Marks m ON s.StudentID=m.StudentID
JOIN Exams e ON m.ExamID=e.ExamID
JOIN Courses c ON e.CourseID=c.CourseID
WHERE s.StudentID=@StudentID;
END;

EXEC sp_GetStudentMarks 1;


--Assignment 9

CREATE PROCEDURE sp_UpdateMarks
@MarkID INT,
@NewMarks INT
AS
BEGIN
UPDATE Marks
SET MarksObtained=@NewMarks
WHERE MarkID=@MarkID;

SELECT * FROM Marks WHERE MarkID=@MarkID;
END;

EXEC sp_UpdateMarks 1,90;


--Assignment 10

CREATE PROCEDURE sp_DeleteEnrollment
@EnrollmentID INT
AS
BEGIN
DELETE FROM Enrollments
WHERE EnrollmentID=@EnrollmentID;
END;

EXEC sp_DeleteEnrollment 3;

SELECT * FROM Enrollments;


--Assignment 11

CREATE FUNCTION fn_GetGrade(@Marks INT)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Grade VARCHAR(10)

IF @Marks>=90
SET @Grade='A'
ELSE IF @Marks>=75
SET @Grade='B'
ELSE IF @Marks>=60
SET @Grade='C'
ELSE
SET @Grade='Fail'

RETURN @Grade
END;

SELECT StudentID,MarksObtained,dbo.fn_GetGrade(MarksObtained) AS Grade
FROM Marks;


--Assignment 12

CREATE FUNCTION fn_GetStudentAge(@DOB DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(YEAR,@DOB,GETDATE())
END;

SELECT StudentFirstName,
dbo.fn_GetStudentAge(DateOfBirth) AS Age
FROM Students;


--Assignment 13

CREATE FUNCTION fn_GetTotalMarks(@StudentID INT)
RETURNS INT
AS
BEGIN
RETURN
(
SELECT SUM(MarksObtained)
FROM Marks
WHERE StudentID=@StudentID
)
END;

SELECT StudentID,dbo.fn_GetTotalMarks(StudentID) AS TotalMarks
FROM Students;


--Assignment 14

CREATE FUNCTION fn_GetStudentCourses(@StudentID INT)
RETURNS TABLE
AS
RETURN
(
SELECT
c.CourseName,
e.EnrollmentDate
FROM Enrollments e
JOIN Courses c
ON e.CourseID=c.CourseID
WHERE e.StudentID=@StudentID
);

SELECT * FROM dbo.fn_GetStudentCourses(1);


--Assignment 15

CREATE FUNCTION fn_GetDepartmentStudents(@DepartmentID INT)
RETURNS TABLE
AS
RETURN
(
SELECT
StudentID,
StudentFirstName + ' ' + LastName AS StudentName,
AdmissionDate
FROM Students
WHERE DepartmentID=@DepartmentID
);

SELECT * FROM dbo.fn_GetDepartmentStudents(1);