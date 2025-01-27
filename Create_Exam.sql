use ExaminationSystem

INSERT INTO Instructor_Course (ins_id, co_id) VALUES (1, 3);

INSERT INTO Instructor_Track (ins_id, track_id) VALUES (1, 2);
INSERT INTO Instructor_Track (ins_id, track_id) VALUES (1, 3);
INSERT INTO Track_Course (co_id, track_id) VALUES (1, 2);
INSERT INTO Track_Course (co_id, track_id) VALUES (1, 3);

INSERT INTO Track_Course (co_id, track_id) VALUES (3, 3);
INSERT INTO Track_Course (co_id, track_id) VALUES (3, 4);

-- Courses name for instructor
SELECT c.co_name
FROM Course c
INNER JOIN Instructor_Course IC ON c.co_id = IC.co_id
WHERE IC.ins_id = 1

-- get course id
SELECT co_id
FROM Course
WHERE co_name = 'Database' -->1 --> TC.co_id = 1

-- All track for instructor in course to select track
SELECT t.track_name
FROM Track t
INNER JOIN Instructor_Track IT ON t.track_id = IT.track_id
INNER JOIN Track_Course TC ON t.track_id = TC.track_id
WHERE IT.ins_id = 1 and TC.co_id = 1


-- get track id for all selected tracks
SELECT track_id FROM Track WHERE track_name = 'Mobile Applications Development (Cross Platform)'

-- last exam 
-- ins-coursename-trackname(more than one for each)
--INSERT INTO Exam (start_date, duration) VALUES (2025-01-20', 60); ---> step 1 -> ex-id
--INSERT INTO Course_Exam (ex_id, co_id, track_id) VALUES (1, 1, 1); --> step 2 

-- Define a table type for Track IDs
CREATE TYPE dbo.TrackIDList AS TABLE
(
    track_id INT
);

DECLARE @TrackIDList dbo.TrackIDList;
INSERT INTO @TrackIDList (track_id)
VALUES (1), (2); 

BEGIN TRANSACTION;

BEGIN TRY
    -- Insert Exam
    INSERT INTO Exam (start_date, duration)
    VALUES ('2025-05-05', 90);  -- Correct date format

    DECLARE @NewExamID INT = SCOPE_IDENTITY();

    -- Insert into Course_Exam for each track_id in the list
    INSERT INTO Course_Exam (ex_id, co_id, track_id)
    SELECT @NewExamID, 1, track_id
    FROM @TrackIDList;

    -- Commit Transaction
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    -- Rollback Transaction on Error
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;


------------Step 2 Create questions
SELECT q.q_id, q.q_type, q.text, q.grade, o.op_text, o.is_correct
FROM Question q
INNER JOIN [Option] o ON q.q_id = o.q_id
WHERE q.ex_id = 1
ORDER BY q.q_id


INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('T/F', 'Encapsulation binds together data and functions that manipulate that data.', 10, 2);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A unique identifier for a record', 1, 1);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A duplicate value for reference', 0, 1);
