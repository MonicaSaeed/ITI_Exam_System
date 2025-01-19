--Retrieve all students and their associated track and branch

SELECT 
    s.st_name AS StudentName,
    s.st_email AS Email,
    t.track_name AS TrackName,
    b.branch_name AS BranchName
FROM 
    Student s
JOIN 
    Track t ON s.track_id = t.track_id
JOIN 
    Branch b ON t.branch_id = b.branch_id;



-- List all instructors assigned to a specific track
SELECT 
    i.ins_name AS InstructorName,
    t.track_name AS TrackName
FROM 
    Instructor i
JOIN 
    Instructor_Track it ON i.ins_id = it.ins_id
JOIN 
    Track t ON it.track_id = t.track_id
WHERE 
    t.track_name = 'Mobile Applications Development (Cross Platform)';


-- List all courses in a specific track
SELECT 
    c.co_name AS CourseName,
    t.track_name AS TrackName
FROM 
    Course c
JOIN 
    Track_Course tc ON c.co_id = tc.co_id
JOIN 
    Track t ON tc.track_id = t.track_id
WHERE 
    t.track_name = 'Mobile Applications Development (Cross Platform)';


--Find all questions and their options for a specific exam
SELECT 
    q.q_type AS QuestionType,
    q.text AS QuestionText,
    o.op_text AS OptionText,
    o.is_correct AS IsCorrect
FROM 
    Question q
JOIN 
    [Option] o ON q.q_id = o.q_id
WHERE 
    q.ex_id = 1;


--Get all students and their answers in a specific exam
SELECT 
    s.st_name AS StudentName,
    q.text AS QuestionText,
    o.op_text AS SelectedOption,
    o.is_correct AS IsCorrect
FROM 
    Student s
JOIN 
    Student_Answer sa ON s.st_id = sa.st_id
JOIN 
    Question q ON sa.q_id = q.q_id
JOIN 
    [Option] o ON sa.op_id = o.op_id
WHERE 
    q.ex_id = 1;

--Find the total number of questions and total grade for a specific exam
SELECT 
    e.ex_id AS ExamID,
    COUNT(q.q_id) AS TotalQuestions,
    SUM(q.grade) AS TotalGrade
FROM 
    Exam e
JOIN 
    Question q ON e.ex_id = q.ex_id
WHERE 
    e.ex_id = 1
GROUP BY 
    e.ex_id;


--List topics for a specific course
SELECT 
    t.topic_name AS TopicName,
    c.co_name AS CourseName
FROM 
    Topic t
JOIN 
    Course c ON t.co_id = c.co_id
WHERE 
    c.co_name = 'Database';


--Count the number of students in each track
SELECT 
    t.track_name AS TrackName,
    COUNT(s.st_id) AS NumberOfStudents
FROM 
    Track t
LEFT JOIN 
    Student s ON t.track_id = s.track_id
GROUP BY 
    t.track_name;


--retrieve the name of the courses taught by an instructor along with the number of students enrolled in each course.
SELECT 
    i.ins_name AS InstructorName,
    c.co_name AS CourseName,
    COUNT(DISTINCT s.st_id) AS NumberOfStudents
FROM 
    Instructor i
INNER JOIN 
    Instructor_Course ic ON i.ins_id = ic.ins_id
INNER JOIN 
    Course c ON ic.co_id = c.co_id
INNER JOIN 
    Track_Course tc ON c.co_id = tc.co_id
INNER JOIN 
    Track t ON tc.track_id = t.track_id
INNER JOIN 
    Student s ON s.track_id = t.track_id
GROUP BY 
    i.ins_name, c.co_name
ORDER BY 
    i.ins_name, c.co_name;


--retrieve the questions in a specific exam and the student's answers to those questions
SELECT 
    q.text AS Question,
    o.op_text AS StudentAnswer,
	s.st_name
FROM 
    Question q
LEFT JOIN 
    Exam e ON q.ex_id = e.ex_id
LEFT JOIN 
    student_Answer a ON q.q_id = a.q_id 
LEFT JOIN 
	[Option] o ON a.op_id = o.op_id
LEFT JOIN 
	student s ON s.st_id = a.st_id
WHERE 
    e.ex_id = 1



-- Repor 4: Report that takes course ID and returns its topics  
DECLARE @id AS INT
SET @id = 1;

SELECT 
	t.topic_name, co.co_name
FROM
	Topic t
INNER JOIN
	Course co ON t.co_id = co.co_id
WHERE
	co.co_id = @id


-- Report 5: Report that takes exam number and returns the Questions in it and chocies [freeform report] 
DECLARE @e_id AS INT
SET @e_id = 1;

SELECT 
    q.q_type AS QuestionType,
    q.text AS QuestionText,
    STRING_AGG(o.op_text + ' (' + CAST(o.is_correct AS VARCHAR) + ')', ', ') AS Options
FROM 
    Question q
JOIN 
    [Option] o ON q.q_id = o.q_id
WHERE 
    q.ex_id = @e_id
GROUP BY 
    q.q_type, q.text;

SELECT DISTINCT 
	ex_id
FROM 
	Question


-- Report 6: Report that takes exam number and the student ID then returns the Questions in this exam with the student answers.  
DECLARE @e_id AS INT
SET @e_id = 1;
DECLARE @s_id AS INT
SET @s_id = 1;

SELECT
	q.text, o.op_text
FROM 
	Student_Answer sa
INNER JOIN 
	Question q ON sa.q_id = q.q_id
INNER JOIN
	[Option] o ON o.op_id = sa.op_id
WHERE
	sa.st_id = @s_id AND q.ex_id = @e_id
	
SELECT DISTINCT
	sa.st_id
FROM 
	Student_Answer sa


SELECT DISTINCT
	q.ex_id
FROM 
	Student_Answer sa
INNER JOIN 
	Question q ON sa.q_id = q.q_id


