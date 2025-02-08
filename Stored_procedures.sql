-- All Operations for Student Table:
	-- Select spacific student by st_is
	CREATE PROCEDURE SelectSpacificStudent
		@st_id INT
	AS
	BEGIN
		SELECT * FROM Student
		WHERE st_id = @st_id;
	END;
	GO -- Ends the batch, allowing a new procedure to be created.

	-- Select all students in spacific track
	CREATE PROCEDURE SelectAllStudentsInSpacificTrack
		@track_id INT
	AS
	BEGIN
		SELECT * FROM Student
		WHERE track_id = @track_id;
	END;
	GO

	-- Insert a new student
	CREATE PROCEDURE InsertStudent
		@st_name VARCHAR(255),
		@st_email VARCHAR(255),
		@st_phoneNo VARCHAR(20),
		@track_id INT,
		@st_password VARCHAR(255)
	AS
	BEGIN
		INSERT INTO Student (st_name, st_email, st_phoneNo, track_id, st_password)
		VALUES (@st_name, @st_email, @st_phoneNo, @track_id, @st_password);
	END;
	GO

	-- Update student data
	CREATE PROCEDURE UpdateStudent
		@st_id INT,
		@st_name VARCHAR(255),
		@st_email VARCHAR(255),
		@st_phoneNo VARCHAR(20),
		@track_id INT
	AS
	BEGIN
		UPDATE Student
		SET st_name = @st_name, st_email = @st_email, st_phoneNo = @st_phoneNo, track_id = @track_id
		WHERE st_id = @st_id;
	END;
	GO

	-- Delete a student
	CREATE PROCEDURE DeleteStudent
		@st_id INT
	AS
	BEGIN
		DELETE FROM Student_Answer WHERE st_id = @st_id;

		DELETE FROM Student_Exam_Attempt WHERE st_id = @st_id;

		DELETE FROM Student WHERE st_id = @st_id;
	END;
	GO


-- All Operations for Instructors Table:
	--Get Instructors By Id
	CREATE PROCEDURE GetInstructorsById
		@ins_id INT
	AS
	BEGIN
		SELECT *
		FROM Instructor
		WHERE ins_id = @ins_id;
	END;
	GO

	--Add New Instructor
	CREATE PROCEDURE AddInstructor
		@ins_name NVARCHAR(100),
		@ins_email NVARCHAR(100),
		@ins_password NVARCHAR(50)
	AS
	BEGIN
		INSERT INTO Instructor (ins_name, ins_email, ins_password)
		VALUES (@ins_name, @ins_email, @ins_password);
	END
	GO

	--Update Instructor data
	CREATE PROCEDURE UpdateInstructor
		@ins_id INT,
		@ins_name NVARCHAR(100),
		@ins_email NVARCHAR(100),
		@ins_password NVARCHAR(50)
	AS
	BEGIN
		UPDATE Instructor
		SET ins_name = @ins_name,
			ins_email = @ins_email,
			ins_password = @ins_password
		WHERE ins_id = @ins_id;
	END
	GO

	-- Get Instructor's Courses
	CREATE PROCEDURE GetInstructorCourses
    @instructor_id INT
	AS
	BEGIN
		SELECT 
			c.co_name
		FROM Instructor_Course ic
		JOIN Course c ON ic.co_id = c.co_id
		WHERE ic.ins_id = @instructor_id;
	END;
	GO

	--Delete Instructor by Id
	CREATE PROCEDURE DeleteInstructor
	  @inst_id INT
	AS
	BEGIN
		DELETE FROM Instructor_Course WHERE ins_id = @inst_id;

		DELETE FROM Instructor_Track WHERE ins_id = @inst_id;

		DELETE FROM Instructor WHERE ins_id = @inst_id;
	END;
	GO


-- All Operations for Course Table:
	--Get course data by id
	CREATE PROCEDURE GetCourseData
	@co_id INT
	AS
	BEGIN
		SELECT *
		FROM Course
		WHERE co_id =@co_id;
	END
	GO

	--Add New Course
	CREATE PROCEDURE AddCourse
    @co_name NVARCHAR(100)
	AS
	BEGIN
		INSERT INTO Course (co_name)
		VALUES (@co_name);
	END
	GO

	--Update Course data by id
	CREATE PROCEDURE UpdateCourse
    @co_id INT,
    @co_name NVARCHAR(100)
	AS
	BEGIN
		UPDATE Course
		SET co_name = @co_name
		WHERE co_id = @co_id;
	END
	GO

	CREATE PROCEDURE GetCourseTopics
    @co_id INT
	AS
	BEGIN
		SELECT 
			t.topic_name
		FROM Topic t
		WHERE t.co_id = @co_id;
	END;
	GO


-- All Operations for Topic Table:
	--return topic data
	CREATE PROCEDURE GetTopicData
    @topic_id INT
	AS
	BEGIN
		Select topic_name, c.co_name
		FROM Topic t
		JOIN Course c
			ON t.co_id = c.co_id
		WHERE topic_id = @topic_id
	END;
	GO

	--Add new topic
	CREATE PROCEDURE InsertTopic
		@co_id INT,
		@topic_name NVARCHAR(100)
	AS
	BEGIN
		INSERT INTO Topic (co_id, topic_name)
		VALUES (@co_id, @topic_name);
	END;
	GO

	--update topic data
	CREATE PROCEDURE UpdateTopic
    @topic_id INT,
    @topic_name NVARCHAR(100)
	AS
	BEGIN
		UPDATE Topic
		SET topic_name = @topic_name
		WHERE topic_id = @topic_id;
	END;
	GO

	--delete topic
	CREATE PROCEDURE DeleteTopic
		@top_id INT
	AS
	BEGIN
		DELETE FROM Topic WHERE topic_id = @top_id;
	END;
	GO

-- All Operations for Track Table:
	--return track data incluse numbers of student in this track
	CREATE PROCEDURE GetTrackData
		@tr_id INT
	AS
	BEGIN
		SELECT 
			t.track_name,
			COUNT(s.st_id) AS student_count
		FROM Track t
		LEFT JOIN Student s ON t.track_id = s.track_id
		WHERE t.track_id = @tr_id
		GROUP BY t.track_name;
	END;
	GO

	--return track courses 
	CREATE PROCEDURE GetTrackCourses
		@tr_id INT
	AS
	BEGIN
		SELECT 
			c.co_name
		FROM Course c
		JOIN Track_Course tc ON c.co_id = tc.co_id
		WHERE tc.track_id = @tr_id;
	END;
	GO

	--Add nre track
	CREATE PROCEDURE AddTrack
		@track_name NVARCHAR(100)
	AS
	BEGIN
		INSERT INTO Track (track_name)
		VALUES (@track_name);
	END
	GO

	--update track data
	CREATE PROCEDURE UpdateTrack
		@track_id INT,
		@track_name NVARCHAR(100)
	AS
	BEGIN
		UPDATE Track
		SET track_name = @track_name
		WHERE track_id = @track_id;
	END
	GO


-- Exam Generation:
	--	Create Exam 
	CREATE PROCEDURE GenerateExam
		@track_id INT,
		@co_id INT,
		@start_date DATETIME,
		@duration INT
	AS
	BEGIN
		DECLARE @last_exam_id INT;
    
		INSERT INTO Exam (start_date, duration)
		VALUES (@start_date, @duration);
    
		SET @last_exam_id = SCOPE_IDENTITY();
    
		INSERT INTO Course_Exam (track_id, co_id, ex_id)
		VALUES (@track_id, @co_id, @last_exam_id);
	END;
	GO

	-- Add Question To Exam
	CREATE PROCEDURE AddQuestionToExam
		@ex_id INT,
		@q_type NVARCHAR(50),
		@text NVARCHAR(MAX),
		@grade INT
	AS
	BEGIN
		DECLARE @last_q_id INT;

		INSERT INTO Question (ex_id, q_type, text, grade)
		VALUES (@ex_id, @q_type, @text, @grade);
	END;
	GO

	--Add Option to Question 
	CREATE PROCEDURE AddQuestionOption
		@q_id INT,
		@op_text NVARCHAR(255),
		@is_correct BIT
	AS
	BEGIN
		INSERT INTO [Option] (q_id, op_text, is_correct)
		VALUES (@q_id, @op_text, @is_correct);
	END;
	GO


-- Show Exam (All Question with its Options)
CREATE PROCEDURE ShowExam
    @ex_id INT
AS
BEGIN
    SELECT 
        q.q_id,
        q.q_type,
        q.text AS question_text,
        q.grade,
        STRING_AGG(o.op_text, ', ') AS Options
    FROM Question q
    LEFT JOIN [Option] o ON q.q_id = o.q_id
    WHERE q.ex_id = 1
    GROUP BY q.q_id, q.q_type, q.text, q.grade;
END;
GO

-- Show Exam Model Answer
CREATE PROCEDURE ShowExamModelAnswer
    @ex_id INT
AS
BEGIN
    SELECT 
        q.q_id,
        q.q_type,
        q.text AS question_text,
        q.grade,
        STRING_AGG(o.op_text, ', ') AS Correct_Answers
    FROM Question q
    JOIN [Option] o ON q.q_id = o.q_id
    WHERE q.ex_id = @ex_id AND o.is_correct = 1
    GROUP BY q.q_id, q.q_type, q.text, q.grade;
END;
GO

-- Store Exam Answers
CREATE PROCEDURE StoreExamAnswer
    @st_id INT,
    @q_id INT,
    @op_id INT
AS
BEGIN
    INSERT INTO Student_Answer (st_id, q_id, op_id)
    VALUES (@st_id, @q_id, @op_id);
END;
GO

-- Exam Correction for each student
CREATE PROCEDURE CorrectExam
    @st_id INT,
    @CourseID INT
AS
BEGIN
  SELECT 
		q.text AS Question,
		q.grade AS QuestionGrade,
		(SELECT STRING_AGG(sa.op_id, ', ') 
		 FROM Student_Answer sa 
		 WHERE sa.q_id = q.q_id AND sa.st_id = @st_id) AS StudentAnswerIDs,
		(SELECT STRING_AGG(correct_op.op_id, ', ') 
		 FROM [Option] correct_op 
		 WHERE correct_op.q_id = q.q_id AND correct_op.is_correct = 1) AS CorrectAnswerIDs
	FROM Question q
	WHERE q.ex_id IN (SELECT ex_id FROM Course_Exam WHERE co_id = @CourseID);
END;
GO

--Delete Exam
CREATE PROCEDURE DeleteExam
    @ex_id INT
AS
BEGIN
    -- Check if the exam start date is greater than the current date
    IF EXISTS (SELECT 1 FROM Exam WHERE ex_id = @ex_id AND start_date > GETDATE())
    BEGIN
        DELETE FROM Student_Answer WHERE q_id IN (SELECT q_id FROM Question WHERE ex_id = @ex_id);
        DELETE FROM [Option] WHERE q_id IN (SELECT q_id FROM Question WHERE ex_id = @ex_id);
        DELETE FROM Question WHERE ex_id = @ex_id;
        DELETE FROM Course_Exam WHERE ex_id = @ex_id;
        DELETE FROM Exam WHERE ex_id = @ex_id;   
        PRINT 'Exam deleted successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Cannot delete this exam because the start date has passed.';
    END
END;
GO

--Delete course by id
CREATE PROCEDURE DeleteCourse
@co_id INT
AS
BEGIN
	-- Check if the course has exams
	IF EXISTS (SELECT 1 FROM Course_Exam WHERE co_id = @co_id)
	BEGIN
		-- Check if any exam has a start date that has passed
		IF EXISTS (SELECT 1 FROM Exam WHERE ex_id IN (SELECT ex_id FROM Course_Exam WHERE co_id = @co_id) AND start_date <= GETDATE())
		BEGIN
			PRINT 'Cannot delete this course because it has exams with a start date that has passed.';
			RETURN;
		END
        
		-- Delete each exam related to this course using DeleteExam procedure
		DECLARE @exam_id INT;
		DECLARE exam_cursor CURSOR FOR 
		SELECT ex_id FROM Course_Exam WHERE co_id = @co_id;

		OPEN exam_cursor;
		FETCH NEXT FROM exam_cursor INTO @exam_id;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			EXEC DeleteExam @exam_id;
			FETCH NEXT FROM exam_cursor INTO @exam_id;
		END

		CLOSE exam_cursor;
		DEALLOCATE exam_cursor;
	END

	-- Delete related records from Track_Course 
	DELETE FROM Track_Course WHERE co_id = @co_id;

	-- Delete the course
	DELETE FROM Course WHERE co_id = @co_id;

	PRINT 'Course deleted successfully.';
END;
GO
