--1. Triggers Assignments
-- Assignment 1 – Audit Trigger for Students
CREATE TABLE StudentAudit(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
StudentID INT,
ActionType VARCHAR(10),
ActionDate DATETIME
)
GO

CREATE TRIGGER trg_StudentInsertAudit
ON Students
AFTER INSERT
AS
INSERT INTO StudentAudit(StudentID,ActionType,ActionDate)
SELECT StudentID,'INSERT',GETDATE()
FROM inserted
GO

-- Assignment 2 – Prevent Deleting Students
CREATE TRIGGER trg_PreventStudentDelete
ON Students
INSTEAD OF DELETE
AS
IF EXISTS(
SELECT 1
FROM deleted d
JOIN Enrollments e
ON d.StudentID = e.StudentID
)
BEGIN
RAISERROR('Student has course enrollments and cannot be deleted',16,1)
ROLLBACK TRANSACTION
END
ELSE
DELETE FROM Students
WHERE StudentID IN (SELECT StudentID FROM deleted)
GO

-- Assignment 3 – Update Marks Trigger
CREATE TABLE MarksAudit(
AuditID INT IDENTITY(1,1) PRIMARY KEY,
StudentID INT,
ExamID INT,
OldMarks INT,
NewMarks INT,
UpdatedDate DATETIME
)
GO

CREATE TRIGGER trg_UpdateMarksAudit
ON Marks
AFTER UPDATE
AS
INSERT INTO MarksAudit(StudentID,ExamID,OldMarks,NewMarks,UpdatedDate)
SELECT d.StudentID,d.ExamID,d.MarksObtained,i.MarksObtained,GETDATE()
FROM deleted d
JOIN inserted i
ON d.MarkID=i.MarkID
GO

--2. Exception Handling Assignments
-- Assignment 1 – Insert Student Procedure with Exception Handling
CREATE PROCEDURE sp_AddStudent
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@DepartmentID INT,
@Gender CHAR(1),
@AdmissionDate DATE
AS
BEGIN
BEGIN TRY

INSERT INTO Students(FirstName,LastName,DepartmentID,Gender,AdmissionDate)
VALUES(@FirstName,@LastName,@DepartmentID,@Gender,@AdmissionDate)

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage

END CATCH
END
GO

-- Assignment 2 – Marks Validation Procedure
CREATE PROCEDURE sp_InsertMarks
@StudentID INT,
@ExamID INT,
@MarksObtained INT
AS
BEGIN

IF @MarksObtained < 0 OR @MarksObtained > 100
RAISERROR('Invalid Marks',16,1)

ELSE
INSERT INTO Marks(StudentID,ExamID,MarksObtained)
VALUES(@StudentID,@ExamID,@MarksObtained)

END
GO

-- Assignment 3 – Safe Delete Procedure
CREATE PROCEDURE sp_DeleteStudent
@StudentID INT
AS
BEGIN

BEGIN TRY

DELETE FROM Students
WHERE StudentID=@StudentID

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE() AS ErrorMessage

END CATCH

END
GO

--3. Cursors Assignments (Basic)
-- Assignment 1 – Display Student Names Cursor
CREATE PROCEDURE sp_DisplayStudentsCursor
AS

DECLARE @ID INT
DECLARE @Name VARCHAR(100)

DECLARE student_cursor CURSOR FOR
SELECT StudentID,FirstName+' '+LastName
FROM Students

OPEN student_cursor

FETCH NEXT FROM student_cursor INTO @ID,@Name

WHILE @@FETCH_STATUS = 0
BEGIN

PRINT CAST(@ID AS VARCHAR)+' '+@Name

FETCH NEXT FROM student_cursor INTO @ID,@Name

END

CLOSE student_cursor
DEALLOCATE student_cursor
GO

-- Assignment 2 – Calculate Total Marks Per Student
CREATE PROCEDURE sp_CalculateStudentTotalMarks
AS

DECLARE @ID INT
DECLARE @Name VARCHAR(100)
DECLARE @Total INT

DECLARE cur CURSOR FOR
SELECT StudentID,FirstName+' '+LastName
FROM Students

OPEN cur

FETCH NEXT FROM cur INTO @ID,@Name

WHILE @@FETCH_STATUS=0
BEGIN

SELECT @Total = SUM(MarksObtained)
FROM Marks
WHERE StudentID=@ID

PRINT @Name+' Total Marks: '+CAST(ISNULL(@Total,0) AS VARCHAR)

FETCH NEXT FROM cur INTO @ID,@Name

END

CLOSE cur
DEALLOCATE cur
GO

-- Assignment 3 – Update Course Credits Using Cursor
CREATE PROCEDURE sp_UpdateCourseCredits
AS

DECLARE @CourseID INT
DECLARE @Credits INT

DECLARE course_cursor CURSOR FOR
SELECT CourseID,Credits
FROM Courses
WHERE Credits<3

OPEN course_cursor

FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

WHILE @@FETCH_STATUS=0
BEGIN

UPDATE Courses
SET Credits = Credits+1
WHERE CourseID=@CourseID

FETCH NEXT FROM course_cursor INTO @CourseID,@Credits

END

CLOSE course_cursor
DEALLOCATE course_cursor
GO

--4. Transactions Assignments
-- Assignment 1 – Student Enrollment Transaction
CREATE PROCEDURE sp_EnrollStudentTransaction
@StudentID INT,
@CourseID INT
AS

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Enrollments(StudentID,CourseID,EnrollmentDate)
VALUES(@StudentID,@CourseID,GETDATE())

COMMIT

END TRY

BEGIN CATCH

ROLLBACK
SELECT ERROR_MESSAGE()

END CATCH
GO

-- Assignment 2 – Exam Marks Transaction
CREATE PROCEDURE sp_RecordExamMarks
@StudentID INT,
@ExamID INT,
@Marks INT
AS

BEGIN TRANSACTION

BEGIN TRY

INSERT INTO Marks(StudentID,ExamID,MarksObtained)
VALUES(@StudentID,@ExamID,@Marks)

UPDATE Exams
SET ExamDate = GETDATE()
WHERE ExamID=@ExamID

COMMIT

END TRY

BEGIN CATCH

ROLLBACK
SELECT ERROR_MESSAGE()

END CATCH
GO

-- Assignment 3 – Department Transfer Transaction
CREATE PROCEDURE sp_TransferStudentDepartment
@StudentID INT,
@NewDepartmentID INT
AS

BEGIN TRANSACTION

BEGIN TRY

IF NOT EXISTS(
SELECT 1
FROM Departments
WHERE DepartmentID=@NewDepartmentID
)

RAISERROR('Department does not exist',16,1)

UPDATE Students
SET DepartmentID=@NewDepartmentID
WHERE StudentID=@StudentID

COMMIT

END TRY

BEGIN CATCH

ROLLBACK
SELECT ERROR_MESSAGE()

END CATCH
GO