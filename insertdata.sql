-- Insert data into Branch
INSERT INTO Branch (branch_name) VALUES ('Smart Village');
INSERT INTO Branch (branch_name) VALUES ('New Capital');
INSERT INTO Branch (branch_name) VALUES ('Cairo University');
INSERT INTO Branch (branch_name) VALUES ('Alexandria');
INSERT INTO Branch (branch_name) VALUES ('Assiut');

-- Insert data into Track
INSERT INTO Track (track_name, branch_id) VALUES ('Mobile Applications Development (Cross Platform)', 1);
INSERT INTO Track (track_name, branch_id) VALUES ('Web & User Interface Development', 1);
INSERT INTO Track (track_name, branch_id) VALUES ('Professional Development & BI-infused CRM', 1);
INSERT INTO Track (track_name, branch_id) VALUES ('Mobile Applications Development (Native)', 1);
INSERT INTO Track (track_name, branch_id) VALUES ('Cloud Platform Development', 1);
INSERT INTO Track (track_name, branch_id) VALUES ('Mobile Applications Development (Cross Platform)', 2);
INSERT INTO Track (track_name, branch_id) VALUES ('Web & User Interface Development', 2);
INSERT INTO Track (track_name, branch_id) VALUES ('Professional Development & BI-infused CRM', 2);

-- Insert data into Student
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Monica', 'monica@example.com', '1234567890', 1);
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Heba', 'heba@example.com', '1234567890', 1);
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Mai', 'mai@example.com', '1234567890', 1);
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Wafaa', 'wafaa@example.com', '1234567890', 1);
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Yasmin', 'yasmin@example.com', '1234567890', 1);
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id) VALUES ('Ali', 'ali@example.com', '0987654321', 2);

-- Insert data into Instructor
INSERT INTO Instructor (ins_name, ins_email) VALUES ('Rami', 'r.rami@example.com');
INSERT INTO Instructor (ins_name, ins_email) VALUES ('Sheryhan', 's.sheryhan@example.com');

-- Insert data into Instructor_Track
INSERT INTO Instructor_Track (ins_id, track_id) VALUES (1, 1);
INSERT INTO Instructor_Track (ins_id, track_id) VALUES (2, 1);

-- Insert data into Course
INSERT INTO Course (co_name) VALUES ('Database');
INSERT INTO Course (co_name) VALUES ('OOP');
INSERT INTO Course (co_name) VALUES ('C#');
INSERT INTO Course (co_name) VALUES ('C++');
INSERT INTO Course (co_name) VALUES ('JavaScript');

-- Insert data into Track_Course
INSERT INTO Track_Course (co_id, track_id) VALUES (1, 1);
INSERT INTO Track_Course (co_id, track_id) VALUES (2, 1);
INSERT INTO Track_Course (co_id, track_id) VALUES (3, 1);
INSERT INTO Track_Course (co_id, track_id) VALUES (4, 1);
INSERT INTO Track_Course (co_id, track_id) VALUES (5, 1);

-- Insert data into Topic
INSERT INTO Topic (topic_name, co_id) VALUES ('ERD', 1);
INSERT INTO Topic (topic_name, co_id) VALUES ('Mapping', 1);
INSERT INTO Topic (topic_name, co_id) VALUES ('Inhertance', 2);

-- Insert data into Instructor_Course
INSERT INTO Instructor_Course (ins_id, co_id) VALUES (1, 1);
INSERT INTO Instructor_Course (ins_id, co_id) VALUES (2, 2);

-- Insert data into Exam
INSERT INTO Exam (start_date, duration) VALUES ('2025-01-20', 60);
INSERT INTO Exam (start_date, duration) VALUES ('2025-02-15', 90);

-- Insert data into Course_Exam
INSERT INTO Course_Exam (ex_id, co_id, track_id) VALUES (1, 1, 1);
INSERT INTO Course_Exam (ex_id, co_id, track_id) VALUES (2, 2, 1);

-- Insert data into Question
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('MCQ', 'What is a primary key?', 10, 1);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('MCQ', 'What is a foreign key?', 5, 1);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('T/F', 'A primary key uniquely identifies each record in a table.', 10, 1);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('T/F', 'Foreign keys establish relationships between tables.', 5, 1);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('MCQ', 'What is an object in OOP?', 10, 2);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('T/F', 'Polymorphism allows one interface to control access to a general class of actions.', 10, 2);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('MCQ', 'What is inheritance in OOP?', 10, 2);
INSERT INTO Question (q_type, text, grade, ex_id) VALUES ('T/F', 'Encapsulation binds together data and functions that manipulate that data.', 10, 2);

-- Insert data into Option
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A unique identifier for a record', 1, 1);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A duplicate value for reference', 0, 1);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A key used to relate two tables', 1, 2);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A key used for indexing only', 0, 2);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('T', 1, 3);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('F', 0, 3);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('T', 1, 4);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('F', 0, 4);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A real-world entity with attributes and behavior', 1, 5);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A programming paradigm', 0, 5);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('T', 1, 6);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('F', 0, 6);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('The process where one class acquires properties of another', 1, 7);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('A class having multiple instances', 0, 7);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('T', 1, 8);
INSERT INTO [Option] (op_text, is_correct, q_id) VALUES ('F', 0, 8);

-- Insert data into Student_Answer
INSERT INTO Student_Answer (st_id, q_id, op_id) VALUES (1, 1, 1);
INSERT INTO Student_Answer (st_id, q_id, op_id) VALUES (2, 1, 2);


