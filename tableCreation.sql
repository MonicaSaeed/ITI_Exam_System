-- DataBase Name ExaminationSystem 
USE ExaminationSystem


-- Table: Track
CREATE TABLE Track (
    track_id INT IDENTITY(1,1) PRIMARY KEY,
    track_name NVARCHAR(100) NOT NULL
);

-- Table: Student
CREATE TABLE Student (
    st_id INT IDENTITY(1,1) PRIMARY KEY,
    st_name NVARCHAR(100) NOT NULL,
    st_email NVARCHAR(100) NOT NULL,
    st_phoneNo NVARCHAR(15) NOT NULL,
    track_id INT NOT NULL,
	st_password NVARCHAR(50) NOT NULL,
    FOREIGN KEY (track_id) REFERENCES Track(track_id)
);

-- Table: Instructor
CREATE TABLE Instructor (
    ins_id INT IDENTITY(1,1) PRIMARY KEY,
    ins_name NVARCHAR(100) NOT NULL,
    ins_email NVARCHAR(100) NOT NULL,
	ins_password NVARCHAR(50) NOT NULL,
);

-- Table: Instructor_Track
CREATE TABLE Instructor_Track (
    ins_id INT NOT NULL,
    track_id INT NOT NULL,
    PRIMARY KEY (ins_id, track_id),
    FOREIGN KEY (ins_id) REFERENCES Instructor(ins_id),
    FOREIGN KEY (track_id) REFERENCES Track(track_id)
);

-- Table: Course
CREATE TABLE Course (
    co_id INT IDENTITY(1,1) PRIMARY KEY,
    co_name NVARCHAR(100) NOT NULL
);

-- Table: Track_Course
CREATE TABLE Track_Course (
    co_id INT NOT NULL,
    track_id INT NOT NULL,
    PRIMARY KEY (co_id, track_id),
    FOREIGN KEY (co_id) REFERENCES Course(co_id),
    FOREIGN KEY (track_id) REFERENCES Track(track_id)
);

-- Table: Topic
CREATE TABLE Topic (
    topic_id INT IDENTITY(1,1) PRIMARY KEY,
    topic_name NVARCHAR(100) NOT NULL,
    co_id INT NOT NULL,
    FOREIGN KEY (co_id) REFERENCES Course(co_id)
);

-- Table: Instructor_Course
CREATE TABLE Instructor_Course (
    ins_id INT NOT NULL,
    co_id INT NOT NULL,
    PRIMARY KEY (ins_id, co_id),
    FOREIGN KEY (ins_id) REFERENCES Instructor(ins_id),
    FOREIGN KEY (co_id) REFERENCES Course(co_id)
);

-- Table: Exam
CREATE TABLE Exam (
    ex_id INT IDENTITY(1,1) PRIMARY KEY,
    start_date DATETime NOT NULL,
    duration INT NOT NULL
);

-- Table: Course_Exam
CREATE TABLE Course_Exam (
    ex_id INT NOT NULL,
    co_id INT NOT NULL,
    track_id INT NOT NULL,
    PRIMARY KEY (ex_id, co_id, track_id),
    FOREIGN KEY (ex_id) REFERENCES Exam(ex_id),
    FOREIGN KEY (co_id) REFERENCES Course(co_id),
    FOREIGN KEY (track_id) REFERENCES Track(track_id)
);

-- Table: Question
CREATE TABLE Question (
    q_id INT IDENTITY(1,1) PRIMARY KEY,
    q_type NVARCHAR(50) NOT NULL,
    text NVARCHAR(MAX) NOT NULL,
    grade INT NOT NULL,
    ex_id INT NOT NULL,
    FOREIGN KEY (ex_id) REFERENCES Exam(ex_id)
);

-- Table: Option
CREATE TABLE [Option] (
    op_id INT IDENTITY(1,1) PRIMARY KEY,
    op_text NVARCHAR(MAX) NOT NULL,
    is_correct BIT NOT NULL,
    q_id INT NOT NULL,
    FOREIGN KEY (q_id) REFERENCES Question(q_id)
);

-- Table: Student_Answer
CREATE TABLE Student_Answer (
    st_id INT NOT NULL,
    q_id INT NOT NULL,
    op_id INT NOT NULL,
    PRIMARY KEY (st_id, q_id, op_id),
    FOREIGN KEY (st_id) REFERENCES Student(st_id),
    FOREIGN KEY (q_id) REFERENCES Question(q_id),
    FOREIGN KEY (op_id) REFERENCES [Option](op_id)
);


--Table: Stdent_Exam
CREATE TABLE Student_Exam_Attempt (
    st_id INT NOT NULL,          
    ex_id INT NOT NULL,          
    PRIMARY KEY (st_id, ex_id),  
    FOREIGN KEY (st_id) REFERENCES Student(st_id), 
    FOREIGN KEY (ex_id) REFERENCES Exam(ex_id)     
	);




