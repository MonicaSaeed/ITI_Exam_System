USE ExaminationSystem

-- Insert data for Tracks
INSERT INTO Track (track_name)
VALUES
('Mobile Development(Cross-Platforms)'),
('Android Mobile Development'),
('Web Development (Full-Stack)'),
('MERN'),
('Java');



-- Insert into Course
INSERT INTO Course (co_name)
VALUES 
('Object-Oriented Programming (OOP)'),
('Structured Query Language (SQL)'),
('Database Design'),
('Mobile App Development Basics'),
('Flutter Development'),
('React Development'),
('Node.js Development'),
('Java Basics'),
('Advanced Java Programming'),
('Web Development Fundamentals');




-- Assign Courses to Tracks
INSERT INTO Track_Course (track_id, co_id)
VALUES 
(1, 1), (1, 2), (1, 4), (1, 5),
(2, 1), (2, 2), (2, 4), (2, 5),
(3, 1), (3, 2), (3, 3), (3, 6),
(4, 3), (4, 6), (4, 7),
(5, 1), (5, 8), (5, 9);



-- Insert data for Instructors
INSERT INTO Instructor (ins_name, ins_email, ins_password)
VALUES 
('Ahmed Ali', 'ahmed.ali@example.com', 'password1'),
('Mona Hassan', 'mona.hassan@example.com', 'password2'),
('Khaled Mostafa', 'khaled.mostafa@example.com', 'password3'),
('Salma Youssef', 'salma.youssef@example.com', 'password4'),
('Omar Farouk', 'omar.farouk@example.com', 'password5');



-- Assign Instructors to Courses
INSERT INTO Instructor_Course (ins_id, co_id)
VALUES 
(1, 1), (1, 8),
(2, 2),
(3, 3),
(4, 4), (4, 5),
(5, 6), (5, 7), (5, 9);





-- Insert data for Students
INSERT INTO Student (st_name, st_email, st_phoneNo, track_id, st_password)
VALUES 
('Mohamed Youssef', 'mohamed.youssef@example.com', '0123456789', 1, 'password1'), --1
('Hanaa Ibrahim', 'hanaa.ibrahim@example.com', '0123456790', 1, 'password2'),	--2
('Youssef Tamer', 'youssef.tamer@example.com', '0123456791', 1, 'password3'),		--3
('Aya Samir', 'aya.samir@example.com', '0123456792', 1, 'password4'),				--4
('Amr Adel', 'amr.adel@example.com', '0123456793', 1, 'password5'),					--5
('Dina Salah', 'dina.salah@example.com', '0123456794', 1, 'password6'),				--6
('Ali Mahmoud', 'ali.mahmoud@example.com', '0123456795', 1, 'password7'),			--7
('Laila Ahmed', 'laila.ahmed@example.com', '0123456796', 1, 'password8'),			--8
('Salem Gamal', 'salem.gamal@example.com', '0123456797', 2, 'password9'),			--9
('Noura Hassan', 'noura.hassan@example.com', '0123456798', 2, 'password10'),		--10
('Omar Elmasry', 'omar.elmasry@example.com', '0123456799', 2, 'password11'),		--11
('Hend Elshahawy', 'hend.elshahawy@example.com', '0123456800', 2, 'password12'),	--12
('Mahmoud Tarek', 'mahmoud.tarek@example.com', '0123456801', 2, 'password13'),		--13
('Fatma Ali', 'fatma.ali@example.com', '0123456802', 2, 'password14'),				--14
('Yara Hossam', 'yara.hossam@example.com', '0123456803', 2, 'password15'),			--15
('Khaled Fathy', 'khaled.fathy@example.com', '0123456804', 2, 'password16'),		--16
('Sarah Lotfy', 'sarah.lotfy@example.com', '0123456805', 3, 'password17'),			--17
('Tamer Nabil', 'tamer.nabil@example.com', '0123456806', 3, 'password18'),			--18
('Ramy Essam', 'ramy.essam@example.com', '0123456807', 3, 'password19'),			--19
('Nesma Ibrahim', 'nesma.ibrahim@example.com', '0123456808', 3, 'password20'),		--20
('Mohamed Adel', 'mohamed.adel@example.com', '0123456809', 3, 'password21'),
('Rana Sameh', 'rana.sameh@example.com', '0123456810', 3, 'password22'),
('Hossam Khaled', 'hossam.khaled@example.com', '0123456811', 3, 'password23'),
('Yasmine Salah', 'yasmine.salah@example.com', '0123456812', 3, 'password24'),
('Hisham Gamal', 'hisham.gamal@example.com', '0123456813', 4, 'password25'),
('Sally Mohamed', 'sally.mohamed@example.com', '0123456814', 4, 'password26'),
('Fady Anwar', 'fady.anwar@example.com', '0123456815', 4, 'password27'),
('Reem Ahmed', 'reem.ahmed@example.com', '0123456816', 4, 'password28'),
('Mina Samir', 'mina.samir@example.com', '0123456817', 4, 'password29'),
('Lama Hany', 'lama.hany@example.com', '0123456818', 4, 'password30'),
('Adham Hossam', 'adham.hossam@example.com', '0123456819', 4, 'password31'),
('Nada Fathy', 'nada.fathy@example.com', '0123456820', 4, 'password32'),
('Mostafa Sayed', 'mostafa.sayed@example.com', '0123456821', 5, 'password33'),
('Yasmin Hamed', 'yasmin.hamed@example.com', '0123456822', 5, 'password34'),
('Ahmed Sherif', 'ahmed.sherif@example.com', '0123456823', 5, 'password35'),
('Nourhan Salah', 'nourhan.salah@example.com', '0123456824', 5, 'password36'),
('Karim Atef', 'karim.atef@example.com', '0123456825', 5, 'password37'),
('Nada Khalil', 'nada.khalil@example.com', '0123456826', 5, 'password38'),
('Hassan Ramy', 'hassan.ramy@example.com', '0123456827', 5, 'password39'),
('Rehab Samy', 'rehab.samy@example.com', '0123456828', 5, 'password40');





-- Insert data for Exams
INSERT INTO Exam (start_date, duration)
VALUES 
-- Past Exams (before 2025-02-07)
('2025-01-20 10:00:00', 90),  -- ex_id = 1
('2025-01-25 09:00:00', 120), -- ex_id = 2
('2025-02-01 11:00:00', 100), -- ex_id = 3

-- Future Exams (after 2025-02-07)
('2025-02-15 10:00:00', 90),  -- ex_id = 4
('2025-02-20 09:00:00', 120), -- ex_id = 5
('2025-02-20 09:00:00', 90); -- ex_id = 6






-- Assign Exams to Courses

INSERT INTO Course_Exam (ex_id, co_id, track_id)
VALUES 
-- Past Exams
(1, 1, 1),  -- OOP for Track 1
(2, 2, 1),  -- SQL for Track 1
(3, 1, 3),  -- OOP for Track 3

-- Future Exams
(4, 6, 4),  -- React Development for Track 4
(5, 9, 5),  ---- Advanced Java Programming for Track 5
(6, 1, 2),  -- OOP for Track 2
(6, 1, 4);  -- OOP for Track 4





-----Insert Questions for Exams:

-------------------------------------------Exam1 ---------------------------
-- Insert Questions for Exam 1
INSERT INTO Question (q_type, text, grade, ex_id)
VALUES 
-- MCQ Questions
('MCQ', 'What is encapsulation in OOP?', 5, 1), -- q_id: 1
('MCQ', 'What is polymorphism in OOP?', 5, 1), -- q_id: 2
('MCQ', 'What is inheritance in OOP?', 5, 1), -- q_id: 3
('MCQ', 'What is abstraction in OOP?', 5, 1), -- q_id: 4
('MCQ', 'Which of the following are access modifiers in Java?', 5, 1), -- q_id: 5
-- True/False Questions
('TF', 'An object is an instance of a class.', 5, 1), -- q_id: 6
('TF', 'In OOP, a class defines the blueprint of an object.', 5, 1), -- q_id: 7
('TF', 'Java supports multiple inheritance using classes.', 5, 1), -- q_id: 8
('TF', 'A constructor can return a value.', 5, 1), -- q_id: 9
('TF', 'Abstraction and encapsulation are the same thing.', 5, 1); -- q_id: 10

-- Insert Options for Exam 1 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES 
-- Q1: What is encapsulation in OOP?
('Hiding implementation details', 1, 1), -- op_id: 1
('Making all variables public', 0, 1), -- op_id: 2
('Allowing multiple inheritances', 0, 1), -- op_id: 3
('Overloading functions', 0, 1), -- op_id: 4
-- Q2: What is polymorphism in OOP?
('Overloading functions', 1, 2), -- op_id: 5
('Using private constructors', 0, 2), -- op_id: 6
('Sharing code among classes', 0, 2), -- op_id: 7
('Creating standalone tables', 0, 2), -- op_id: 8
-- Q3: What is inheritance in OOP?
('Sharing code among classes', 1, 3), -- op_id: 9
('Creating standalone tables', 0, 3), -- op_id: 10
('Removing duplicates', 0, 3), -- op_id: 11
('Primary key references another table', 0, 3), -- op_id: 12
-- Q4: What is abstraction in OOP?
('Hiding implementation details', 1, 4), -- op_id: 13
('Making all variables public', 0, 4), -- op_id: 14
('Allowing multiple inheritances', 0, 4), -- op_id: 15
('Overloading functions', 0, 4), -- op_id: 16
-- Q5: Which of the following are access modifiers in Java?
('public', 1, 5), -- op_id: 17
('private', 1, 5), -- op_id: 18
('protected', 1, 5), -- op_id: 19
('static', 0, 5), -- op_id: 20

-- Q6: An object is an instance of a class.
('True', 1, 6), -- op_id: 21
('False', 0, 6), -- op_id: 22

-- Q7: In OOP, a class defines the blueprint of an object.
('True', 1, 7), -- op_id: 23
('False', 0, 7), -- op_id: 24

-- Q8: Java supports multiple inheritance using classes.
('True', 0, 8), -- op_id: 25
('False', 1, 8), -- op_id: 26

-- Q9: A constructor can return a value.
('True', 0, 9), -- op_id: 27
('False', 1, 9), -- op_id: 28

-- Q10: Abstraction and encapsulation are the same thing.
('True', 0, 10), -- op_id: 29
('False', 1, 10); -- op_id: 30





-----------------------------------------Exam2-----------------------------------
-- Insert Questions for Exam 2
INSERT INTO Question (q_type, text, grade, ex_id)
VALUES 
-- MCQ Questions
('MCQ', 'Which SQL clause is used to filter records?', 4, 2), -- q_id: 11
('MCQ', 'What is a foreign key in SQL?', 4, 2), -- q_id: 12
('MCQ', 'Which command is used to create a table in SQL?', 4, 2), -- q_id: 13
('MCQ', 'What is the purpose of the GROUP BY clause?', 4, 2), -- q_id: 14
('MCQ', 'Which of the following are SQL aggregate functions?', 4, 2), -- q_id: 15
-- True/False Questions
('TF', 'SQL is used to interact with databases.', 4, 2), -- q_id: 16
('TF', 'A primary key can contain NULL values.', 4, 2), -- q_id: 17
('TF', 'The WHERE clause is used to filter rows.', 4, 2), -- q_id: 18
('TF', 'The DELETE command removes a table from the database.', 4, 2), -- q_id: 19
('TF', 'The UPDATE command modifies existing records.', 4, 2); -- q_id: 20


-- Insert Options for Exam 2 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES 
-- Q1: Which SQL clause is used to filter records?
('WHERE', 1, 11), -- op_id: 31
('SELECT', 0, 11), -- op_id: 32
('FROM', 0, 11), -- op_id: 33
('GROUP BY', 0, 11), -- op_id: 34
-- Q2: What is a foreign key in SQL?
('A key that references another table', 1, 12), -- op_id: 35
('A unique identifier for a table', 0, 12), -- op_id: 36
('A key that ensures uniqueness', 0, 12), -- op_id: 37
('A key that sorts records', 0, 12), -- op_id: 38
-- Q3: Which command is used to create a table in SQL?
('CREATE TABLE', 1, 13), -- op_id: 39
('ALTER TABLE', 0, 13), -- op_id: 40
('DROP TABLE', 0, 13), -- op_id: 41
('INSERT INTO', 0, 13), -- op_id: 42
-- Q4: What is the purpose of the GROUP BY clause?
('To group rows with the same values', 1, 14), -- op_id: 43
('To filter rows', 0, 14), -- op_id: 44
('To sort rows', 0, 14), -- op_id: 45
('To join tables', 0, 14), -- op_id: 46
-- Q5: Which of the following are SQL aggregate functions?
('COUNT', 1, 15), -- op_id: 47
('SUM', 1, 15), -- op_id: 48
('AVG', 1, 15), -- op_id: 49
('DELETE', 0, 15), -- op_id: 50

-- Q6: SQL is used to interact with databases.
('True', 1, 16), -- op_id: 51
('False', 0, 16), -- op_id: 52

-- Q7: A primary key can contain NULL values.
('True', 0, 17), -- op_id: 53
('False', 1, 17), -- op_id: 54

-- Q8: The WHERE clause is used to filter rows.
('True', 1, 18), -- op_id: 55
('False', 0, 18), -- op_id: 56

-- Q9: The DELETE command removes a table from the database.
('True', 0, 19), -- op_id: 57
('False', 1, 19), -- op_id: 58

-- Q10: The UPDATE command modifies existing records.
('True', 1, 20), -- op_id: 59
('False', 0, 20); -- op_id: 60



-----------------------------------------------Exam3--------------------------------------
-- Insert Questions for Exam 3
INSERT INTO Question (q_type, text, grade, ex_id) 
VALUES 
-- MCQ Questions
('MCQ', 'Which of the following is used to define a class in C++?', 5, 3), -- q_id: 21
('MCQ', 'Which concept allows multiple functions with the same name but different parameters?', 5, 3), -- q_id: 22
('MCQ', 'What is encapsulation in Object-Oriented Programming?', 5, 3), -- q_id: 23
('MCQ', 'Which access specifier restricts access to within the same class only?', 5, 3), -- q_id: 24
('MCQ', 'Which function is called when an object is created?', 5, 3), -- q_id: 25
-- True/False Questions
('TF', 'A destructor is called automatically when an object goes out of scope.', 5, 3), -- q_id: 26
('TF', 'Inheritance allows a class to use properties and methods of another class.', 5, 3), -- q_id: 27
('TF', 'Polymorphism allows objects to be treated as instances of their parent class.', 5, 3), -- q_id: 28
('TF', 'Abstraction focuses on hiding implementation details from the user.', 5, 3), -- q_id: 29
('TF', 'A class in C++ can have multiple constructors.', 5, 3); -- q_id: 30

-- Insert Options for Exam 3 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES 
-- Q1: Which of the following is used to define a class in C++?
('class', 1, 21), -- op_id: 61
('struct', 0, 21), -- op_id: 62
('def', 0, 21), -- op_id: 63
('function', 0, 21), -- op_id: 64

-- Q2: Which concept allows multiple functions with the same name but different parameters?
('Function Overloading', 1, 22), -- op_id: 65
('Encapsulation', 0, 22), -- op_id: 66
('Abstraction', 0, 22), -- op_id: 67
('Inheritance', 0, 22), -- op_id: 68

-- Q3: What is encapsulation in Object-Oriented Programming?
('Binding data and methods together in a single unit', 1, 23), -- op_id: 69
('Providing access to private members', 0, 23), -- op_id: 70
('Allowing multiple inheritances', 0, 23), -- op_id: 71
('Creating multiple objects', 0, 23), -- op_id: 72

-- Q4: Which access specifier restricts access to within the same class only?
('private', 1, 24), -- op_id: 73
('public', 0, 24), -- op_id: 74
('protected', 0, 24), -- op_id: 75
('internal', 0, 24), -- op_id: 76

-- Q5: Which function is called when an object is created?
('Constructor', 1, 25), -- op_id: 77
('Destructor', 0, 25), -- op_id: 78
('Overloaded function', 0, 25), -- op_id: 79
('Static function', 0, 25), -- op_id: 80

-- Q6: A destructor is called automatically when an object goes out of scope.
('True', 1, 26), -- op_id: 81
('False', 0, 26), -- op_id: 82

-- Q7: Inheritance allows a class to use properties and methods of another class.
('True', 1, 27), -- op_id: 83
('False', 0, 27), -- op_id: 84

-- Q8: Polymorphism allows objects to be treated as instances of their parent class.
('True', 1, 28), -- op_id: 85
('False', 0, 28), -- op_id: 86

-- Q9: Abstraction focuses on hiding implementation details from the user.
('True', 1, 29), -- op_id: 87
('False', 0, 29), -- op_id: 88

-- Q10: A class in C++ can have multiple constructors.
('True', 1, 30), -- op_id: 89
('False', 0, 30); -- op_id: 90




-----------------------------------------Exam 4----------------------------------
-- Insert Questions for Exam 4
INSERT INTO Question (q_type, text, grade, ex_id)
VALUES 
-- MCQ Questions
('MCQ', 'What is React?', 5, 4), -- q_id: 31
('MCQ', 'What is JSX?', 5, 4), -- q_id: 32
('MCQ', 'What is the purpose of state in React?', 5, 4), -- q_id: 33
('MCQ', 'What is the virtual DOM?', 5, 4), -- q_id: 34
('MCQ', 'Which of the following are React hooks?', 5, 4), -- q_id: 35
('MCQ', 'What is the purpose of useEffect in React?', 5, 4), -- q_id: 36
('MCQ', 'What is the difference between props and state?', 5, 4), -- q_id: 37
('MCQ', 'What is a React component?', 5, 4), -- q_id: 38
('MCQ', 'What is the purpose of keys in React lists?', 5, 4), -- q_id: 39
('MCQ', 'What is React Router used for?', 5, 4), -- q_id: 40
-- True/False Questions
('TF', 'React is a backend framework.', 5, 4), -- q_id: 41
('TF', 'JSX is mandatory for writing React components.', 5, 4), -- q_id: 42
('TF', 'State in React is immutable.', 5, 4), -- q_id: 43
('TF', 'The virtual DOM improves performance.', 5, 4), -- q_id: 44
('TF', 'useState is a React hook.', 5, 4), -- q_id: 45
('TF', 'useEffect runs after every render by default.', 5, 4), -- q_id: 46
('TF', 'Props are used to pass data from parent to child components.', 5, 4), -- q_id: 47
('TF', 'A functional component can have state.', 5, 4), -- q_id: 48
('TF', 'React Router is used for state management.', 5, 4), -- q_id: 49
('TF', 'Keys help React identify which items have changed in a list.', 5, 4); -- q_id: 50


-- Insert Options for Exam 4 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES 
-- Q1: What is React?
('A JavaScript library for building user interfaces', 1, 31),
('A backend framework', 0, 31),
('A database management system', 0, 31),
('A programming language', 0, 31),
-- Q2: What is JSX?
('A syntax extension for JavaScript', 1, 32),
('A state management library', 0, 32),
('A database query language', 0, 32),
('A testing framework', 0, 32),
-- Q3: What is the purpose of state in React?
('To manage dynamic data in a component', 1, 33),
('To define static data', 0, 33),
('To handle routing', 0, 33),
('To manage global state', 0, 33),
-- Q4: What is the virtual DOM?
('A lightweight copy of the real DOM', 1, 34),
('A database', 0, 34),
('A state management tool', 0, 34),
('A testing framework', 0, 34),
-- Q5: Which of the following are React hooks?
('useState', 1, 35),
('useEffect', 1, 35),
('useContext', 1, 35),
('useRouter', 0, 35),
-- Q6: What is the purpose of useEffect in React?
('To perform side effects in functional components', 1, 36),
('To define state', 0, 36),
('To handle routing', 0, 36),
('To manage global state', 0, 36),
-- Q7: What is the difference between props and state?
('Props are immutable, state is mutable', 1, 37),
('State is passed from parent to child', 0, 37),
('Props are used for routing', 0, 37),
('State is immutable', 0, 37),
-- Q8: What is a React component?
('A reusable piece of UI', 1, 38),
('A database table', 0, 38),
('A state management tool', 0, 38),
('A testing framework', 0, 38),
-- Q9: What is the purpose of keys in React lists?
('To uniquely identify list items', 1, 39),
('To style list items', 0, 39),
('To manage state', 0, 39),
('To handle routing', 0, 39),
-- Q10: What is React Router used for?
('To handle navigation in a React app', 1, 40),
('To manage state', 0, 40),
('To perform side effects', 0, 40),
('To define components', 0, 40),
-- Q11: React is a backend framework.
('FALSE', 1, 41),
('TRUE', 0, 41),
-- Q12: JSX is mandatory for writing React components.
('FALSE', 1, 42),
('TRUE', 0, 42),
-- Q13: State in React is immutable.
('FALSE', 1, 43),
('TRUE', 0, 43),
-- Q14: The virtual DOM improves performance.
('TRUE', 1, 44),
('FALSE', 0, 44),
-- Q15: useState is a React hook.
('TRUE', 1, 45),
('FALSE', 0, 45),
-- Q16: useEffect runs after every render by default.
('TRUE', 1, 46),
('FALSE', 0, 46),
-- Q17: Props are used to pass data from parent to child components.
('TRUE', 1, 47),
('FALSE', 0, 47),
-- Q18: A functional component can have state.
('TRUE', 1, 48),
('FALSE', 0, 48),
-- Q19: React Router is used for state management.
('FALSE', 1, 49),
('TRUE', 0, 49),
-- Q20: Keys help React identify which items have changed in a list.
('TRUE', 1, 50),
('FALSE', 0, 50);


-----------------------------------------Exam 5----------------------------------
-- Insert Questions for Exam 5
INSERT INTO Question (q_type, text, grade, ex_id)
VALUES 
-- MCQ Questions
('MCQ', 'What is the default value of a boolean in Java?', 5, 5), -- q_id: 51
('MCQ', 'Which method is used to start a thread in Java?', 5, 5), -- q_id: 52
('MCQ', 'What is a Java Virtual Machine?', 5, 5), -- q_id: 53
('MCQ', 'What is the purpose of the final keyword in Java?', 5, 5), -- q_id: 54
('MCQ', 'Which of the following are Java collections?', 5, 5), -- q_id: 55
('MCQ', 'What is the purpose of the synchronized keyword in Java?', 5, 5), -- q_id: 56
('MCQ', 'What is the difference between == and .equals() in Java?', 5, 5), -- q_id: 57
('MCQ', 'What is the purpose of the static keyword in Java?', 5, 5), -- q_id: 58
('MCQ', 'What is a lambda expression in Java?', 5, 5), -- q_id: 59
('MCQ', 'What is the purpose of the try-catch block in Java?', 5, 5), -- q_id: 60
-- True/False Questions
('TF', 'Java supports multiple inheritance using interfaces.', 5, 5), -- q_id: 61
('TF', 'Java is platform-independent.', 5, 5), -- q_id: 62
('TF', 'A final class cannot be subclassed.', 5, 5), -- q_id: 63
('TF', 'The static keyword can be used with local variables.', 5, 5), -- q_id: 64
('TF', 'Lambda expressions are only available in Java 8 and later.', 5, 5), -- q_id: 65
('TF', 'The synchronized keyword is used for thread safety.', 5, 5), -- q_id: 66
('TF', 'The == operator compares object references.', 5, 5), -- q_id: 67
('TF', 'The .equals() method compares object contents.', 5, 5), -- q_id: 68
('TF', 'A try-catch block is used for exception handling.', 5, 5), -- q_id: 69
('TF', 'Java collections are thread-safe by default.', 5, 5); -- q_id: 70


-- Insert Options for Exam 5 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES 
-- Q1: What is the default value of a boolean in Java?
('false', 1, 51),
('true', 0, 51),
('0', 0, 51),
('1', 0, 51),
-- Q2: Which method is used to start a thread in Java?
('start()', 1, 52),
('run()', 0, 52),
('execute()', 0, 52),
('begin()', 0, 52),
-- Q3: What is a Java Virtual Machine?
('A runtime environment for executing Java bytecode', 1, 53),
('A compiler', 0, 53),
('A database', 0, 53),
('A testing framework', 0, 53),
-- Q4: What is the purpose of the final keyword in Java?
('To prevent modification', 1, 54),
('To allow inheritance', 0, 54),
('To enable polymorphism', 0, 54),
('To define constants', 1, 54),
-- Q5: Which of the following are Java collections?
('ArrayList', 1, 55),
('HashMap', 1, 55),
('LinkedList', 1, 55),
('String', 0, 55),
-- Q6: What is the purpose of the synchronized keyword in Java?
('To ensure thread safety', 1, 56),
('To improve performance', 0, 56),
('To define constants', 0, 56),
('To enable inheritance', 0, 56),
-- Q7: What is the difference between == and .equals() in Java?
('== compares references, .equals() compares contents', 1, 57),
('== compares contents, .equals() compares references', 0, 57),
('Both compare references', 0, 57),
('Both compare contents', 0, 57),
-- Q8: What is the purpose of the static keyword in Java?
('To define class-level variables and methods', 1, 58),
('To define instance variables', 0, 58),
('To enable polymorphism', 0, 58),
('To prevent inheritance', 0, 58),
-- Q9: What is a lambda expression in Java?
('A concise way to represent anonymous functions', 1, 59),
('A type of exception', 0, 59),
('A database query', 0, 59),
('A testing framework', 0, 59),
-- Q10: What is the purpose of the try-catch block in Java?
('To handle exceptions', 1, 60),
('To define constants', 0, 60),
('To enable inheritance', 0, 60),
('To improve performance', 0, 60),
-- Q11: Java supports multiple inheritance using interfaces.
('TRUE', 1, 61),
('FALSE', 0, 61),
-- Q12: Java is platform-independent.
('TRUE', 1, 62),
('FALSE', 0, 62),
-- Q13: A final class cannot be subclassed.
('TRUE', 1, 63),
('FALSE', 0, 63),
-- Q14: The static keyword can be used with local variables.
('FALSE', 1, 64),
('TRUE', 0, 64),
-- Q15: Lambda expressions are only available in Java 8 and later.
('TRUE', 1, 65),
('FALSE', 0, 65),
-- Q16: The synchronized keyword is used for thread safety.
('TRUE', 1, 66),
('FALSE', 0, 66),
-- Q17: The == operator compares object references.
('TRUE', 1, 67),
('FALSE', 0, 67),
-- Q18: The .equals() method compares object contents.
('TRUE', 1, 68),
('FALSE', 0, 68),
-- Q19: A try-catch block is used for exception handling.
('TRUE', 1, 69),
('FALSE', 0, 69),
-- Q20: Java collections are thread-safe by default.
('FALSE', 1, 70),
('TRUE', 0, 70);

------------------------------------------------------Exam 6-----------------------------------
-- Insert Questions for Exam 6
INSERT INTO Question (q_type, text, grade, ex_id)
VALUES
-- MCQ Questions
('MCQ', 'What is the purpose of encapsulation in OOP?', 5, 6), -- q_id: 71
('MCQ', 'Which of the following is an example of polymorphism in OOP?', 5, 6), -- q_id: 72
('MCQ', 'In OOP, what does inheritance allow you to do?', 5, 6), -- q_id: 73
('MCQ', 'What is the difference between an abstract class and an interface?', 5, 6), -- q_id: 74
('MCQ', 'What is the purpose of the super keyword in Java?', 5, 6), -- q_id: 75
('MCQ', 'Which of the following is NOT a feature of object-oriented programming?', 5, 6), -- q_id: 76
('MCQ', 'What is the output of calling a method on an object reference that is null?', 5, 6), -- q_id: 77
('MCQ', 'Which access modifier allows a class member to be accessible only within the same package?', 5, 6), -- q_id: 78
('MCQ', 'What does method overloading refer to in OOP?', 5, 6), -- q_id: 79
('MCQ', 'What is method overriding in Java?', 5, 6), -- q_id: 80
-- True/False Questions
('TF', 'A constructor can be overridden in Java.', 5, 6), -- q_id: 81
('TF', 'A class can implement multiple interfaces in Java.', 5, 6), -- q_id: 82
('TF', 'In OOP, polymorphism allows different objects to respond to the same method in different ways.', 5, 6), -- q_id: 83
('TF', 'An interface can have concrete methods in Java 8 and later.', 5, 6), -- q_id: 84
('TF', 'Private methods can be inherited in Java.', 5, 6), -- q_id: 85
('TF', 'A class can inherit from multiple classes in Java.', 5, 6), -- q_id: 86
('TF', 'Encapsulation hides the internal state of an object and only exposes behavior.', 5, 6), -- q_id: 87
('TF', 'In Java, a subclass can access private methods of its superclass.', 5, 6), -- q_id: 88
('TF', 'Polymorphism is only achieved by inheritance in OOP.', 5, 6), -- q_id: 89
('TF', 'Abstract classes can be instantiated in Java.', 5, 6); -- q_id: 90

-- Insert Options for Exam 6 Questions
INSERT INTO [Option] (op_text, is_correct, q_id)
VALUES
-- Q1: What is the purpose of encapsulation in OOP?
('To hide the internal details and expose only necessary parts of the object', 1, 71),
('To allow multiple inheritance', 0, 71),
('To prevent polymorphism', 0, 71),
('To make the code run faster', 0, 71),
-- Q2: Which of the following is an example of polymorphism in OOP?
('Method overriding', 1, 72),
('Method overloading', 0, 72),
('Static methods', 0, 72),
('Constructors', 0, 72),
-- Q3: In OOP, what does inheritance allow you to do?
('Reuse code from another class', 1, 73),
('Create new objects', 0, 73),
('Define new classes without inheritance', 0, 73),
('Hide internal object details', 0, 73),
-- Q4: What is the difference between an abstract class and an interface?
('An abstract class can have both abstract and concrete methods, while an interface can only have abstract methods', 1, 74),
('An interface can have both abstract and concrete methods, while an abstract class can only have abstract methods', 0, 74),
('Both abstract classes and interfaces cannot have concrete methods', 0, 74),
('There is no difference between them', 0, 74),
-- Q5: What is the purpose of the super keyword in Java?
('To refer to the superclass constructor or methods', 1, 75),
('To refer to a method in the current class', 0, 75),
('To create a new instance of the current class', 0, 75),
('To make a method private', 0, 75),
-- Q6: Which of the following is NOT a feature of object-oriented programming?
('Global variables', 1, 76),
('Encapsulation', 0, 76),
('Polymorphism', 0, 76),
('Inheritance', 0, 76),
-- Q7: What is the output of calling a method on an object reference that is null?
('NullPointerException', 1, 77),
('Nothing happens', 0, 77),
('The method executes normally', 0, 77),
('Compilation error', 0, 77),
-- Q8: Which access modifier allows a class member to be accessible only within the same package?
('default', 1, 78),
('private', 0, 78),
('protected', 0, 78),
('public', 0, 78),
-- Q9: What does method overloading refer to in OOP?
('Defining multiple methods with the same name but different parameters', 1, 79),
('Defining multiple methods with the same name and parameters', 0, 79),
('Changing the method return type', 0, 79),
('Method overloading is not supported in OOP', 0, 79),
-- Q10: What is method overriding in Java?
('A subclass redefining a method inherited from a superclass', 1, 80),
('Changing the return type of a method', 0, 80),
('Overloading a method with the same name and parameters', 0, 80),
('Method overriding is not supported in Java', 0, 80),
-- Q11: A constructor can be overridden in Java.
('FALSE', 1, 81),
('TRUE', 0, 81),
-- Q12: A class can implement multiple interfaces in Java.
('TRUE', 1, 82),
('FALSE', 0, 82),
-- Q13: In OOP, polymorphism allows different objects to respond to the same method in different ways.
('TRUE', 1, 83),
('FALSE', 0, 83),
-- Q14: An interface can have concrete methods in Java 8 and later.
('TRUE', 1, 84),
('FALSE', 0, 84),
-- Q15: Private methods can be inherited in Java.
('FALSE', 1, 85),
('TRUE', 0, 85),
-- Q16: A class can inherit from multiple classes in Java.
('FALSE', 1, 86),
('TRUE', 0, 86),
-- Q17: Encapsulation hides the internal state of an object and only exposes behavior.
('TRUE', 1, 87),
('FALSE', 0, 87),
-- Q18: In Java, a subclass can access private methods of its superclass.
('FALSE', 1, 88),
('TRUE', 0, 88),
-- Q19: Polymorphism is only achieved by inheritance in OOP.
('FALSE', 1, 89),
('TRUE', 0, 89),
-- Q20: Abstract classes can be instantiated in Java.
('FALSE', 1, 90),
('TRUE', 0, 90);






----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------



-- Insert into Topic Table
INSERT INTO Topic (topic_name, co_id)
VALUES 
('Encapsulation', 1),
('Polymorphism', 1),
('Inheritance', 1),
('Abstraction', 1),
('SQL Basics', 2),
('Database Normalization', 3),
('Flutter Widgets', 5),
('React Components', 6),
('Node.js Modules', 7),
('Java Threads', 9);


-------------------------------------------------------------------------------------
--  Insert into Student_Answer Table

--Exam1 (OOP for Track1)
INSERT INTO Student_Answer (st_id, q_id, op_id)
VALUES 
-- Student 1's answers
(1, 1, 1),  -- Correct
(1, 2, 5),  -- Correct
(1, 3, 10), -- Incorrect
(1, 4, 13), -- Correct
(1, 5, 17), -- Correct
(1, 6, 21), -- Correct
(1, 7, 23), -- Correct
(1, 8, 25), -- Incorrect
(1, 9, 28), -- Correct
(1, 10, 30), -- Correct

-- Student 2's answers
(2, 1, 2),  -- Incorrect
(2, 2, 5),  -- Correct
(2, 3, 9),  -- Correct
(2, 4, 14), -- Incorrect
(2, 5, 19), -- Correct
(2, 6, 21), -- Correct
(2, 7, 24), -- Incorrect
(2, 8, 26), -- Correct
(2, 9, 27), -- Incorrect
(2, 10, 29), -- Incorrect

-- Student 3's answers
(3, 1, 1),  -- Correct
(3, 2, 6),  -- Incorrect
(3, 3, 9),  -- Correct
(3, 4, 16), -- Incorrect
(3, 5, 18), -- Correct
(3, 6, 22), -- Incorrect
(3, 7, 23), -- Correct
(3, 8, 26), -- Correct
(3, 9, 28), -- Correct
(3, 10, 29), -- Incorrect

-- Student 4's answers
(4, 1, 3),  -- Incorrect
(4, 2, 5),  -- Correct
(4, 3, 12), -- Incorrect
(4, 4, 13), -- Correct
(4, 5, 17), -- Correct
(4, 6, 21), -- Correct
(4, 7, 24), -- Incorrect
(4, 8, 25), -- Incorrect
(4, 9, 27), -- Incorrect
(4, 10, 30), -- Correct

-- Student 5's answers
(5, 1, 1),  -- Correct
(5, 2, 8),  -- Incorrect
(5, 3, 9),  -- Correct
(5, 4, 15), -- Incorrect
(5, 5, 19), -- Correct
(5, 6, 22), -- Incorrect
(5, 7, 23), -- Correct
(5, 8, 26), -- Correct
(5, 9, 27), -- Incorrect
(5, 10, 30), -- Correct

-- Student 6's answers
(6, 1, 1),  -- Correct
(6, 2, 5),  -- Correct
(6, 3, 11), -- Incorrect
(6, 4, 13), -- Correct
(6, 5, 18), -- Correct
(6, 6, 21), -- Correct
(6, 7, 24), -- Incorrect
(6, 8, 26), -- Correct
(6, 9, 28), -- Correct
(6, 10, 29), -- Incorrect

-- Student 7's answers
(7, 1, 4),  -- Incorrect
(7, 2, 5),  -- Correct
(7, 3, 9),  -- Correct
(7, 4, 16), -- Incorrect
(7, 5, 20), -- Incorrect
(7, 6, 22), -- Incorrect
(7, 7, 23), -- Correct
(7, 8, 25), -- Incorrect
(7, 9, 28), -- Correct
(7, 10, 30), -- Correct

-- Student 8's answers
(8, 1, 1),  -- Correct
(8, 2, 7),  -- Incorrect
(8, 3, 9),  -- Correct
(8, 4, 13), -- Correct
(8, 5, 17), -- Correct
(8, 6, 22), -- Incorrect
(8, 7, 23), -- Correct
(8, 8, 26), -- Correct
(8, 9, 27), -- Incorrect
(8, 10, 29); -- Incorrect



--Exam2 (SQL for Track1)
INSERT INTO Student_Answer (st_id, q_id, op_id)
VALUES 
-- Student 1's answers
(1, 21, 31),  -- Correct
(1, 22, 35),  -- Correct
(1, 23, 40),  -- Incorrect
(1, 24, 43),  -- Correct
(1, 25, 47),  -- Correct
(1, 26, 51),  -- Correct
(1, 27, 54),  -- Correct
(1, 28, 55),  -- Correct
(1, 29, 58),  -- Correct
(1, 30, 59),  -- Correct

-- Student 2's answers
(2, 21, 32),  -- Incorrect
(2, 22, 35),  -- Correct
(2, 23, 39),  -- Correct
(2, 24, 44),  -- Incorrect
(2, 25, 49),  -- Correct
(2, 26, 51),  -- Correct
(2, 27, 53),  -- Incorrect
(2, 28, 56),  -- Incorrect
(2, 29, 57),  -- Incorrect
(2, 30, 59),  -- Correct

-- Student 3's answers
(3, 21, 31),  -- Correct
(3, 22, 38),  -- Incorrect
(3, 23, 39),  -- Correct
(3, 24, 45),  -- Incorrect
(3, 25, 47),  -- Correct
(3, 26, 51),  -- Correct
(3, 27, 54),  -- Correct
(3, 28, 55),  -- Correct
(3, 29, 57),  -- Incorrect
(3, 30, 60),  -- Incorrect

-- Student 4's answers
(4, 21, 33),  -- Incorrect
(4, 22, 35),  -- Correct
(4, 23, 39),  -- Correct
(4, 24, 46),  -- Incorrect
(4, 25, 49),  -- Correct
(4, 26, 52),  -- Incorrect
(4, 27, 53),  -- Incorrect
(4, 28, 55),  -- Correct
(4, 29, 58),  -- Correct
(4, 30, 59),  -- Correct

-- Student 5's answers
(5, 21, 31),  -- Correct
(5, 22, 37),  -- Incorrect
(5, 23, 42),  -- Incorrect
(5, 24, 43),  -- Correct
(5, 25, 48),  -- Correct
(5, 26, 51),  -- Correct
(5, 27, 54),  -- Correct
(5, 28, 55),  -- Correct
(5, 29, 57),  -- Incorrect
(5, 30, 59),  -- Correct

-- Student 6's answers
(6, 21, 31),  -- Correct
(6, 22, 35),  -- Correct
(6, 23, 41),  -- Incorrect
(6, 24, 43),  -- Correct
(6, 25, 50),  -- Incorrect
(6, 26, 52),  -- Incorrect
(6, 27, 54),  -- Correct
(6, 28, 56),  -- Incorrect
(6, 29, 57),  -- Incorrect
(6, 30, 59),  -- Correct

-- Student 7's answers
(7, 21, 34),  -- Incorrect
(7, 22, 36),  -- Incorrect
(7, 23, 39),  -- Correct
(7, 24, 43),  -- Correct
(7, 25, 48),  -- Correct
(7, 26, 51),  -- Correct
(7, 27, 53),  -- Incorrect
(7, 28, 55),  -- Correct
(7, 29, 58),  -- Correct
(7, 30, 59),  -- Correct

-- Student 8's answers
(8, 21, 31),  -- Correct
(8, 22, 35),  -- Correct
(8, 23, 40),  -- Incorrect
(8, 24, 44),  -- Incorrect
(8, 25, 47),  -- Correct
(8, 26, 52),  -- Incorrect
(8, 27, 54),  -- Correct
(8, 28, 55),  -- Correct
(8, 29, 58),  -- Correct
(8, 30, 60);  -- Incorrect



--Exam3 (SQL for Track3) :

INSERT INTO Student_Answer (st_id, q_id, op_id)
VALUES 
-- Student 17's answers
(17, 61, 62),  -- Correct
(17, 62, 65),  -- Correct
(17, 63, 69),  -- Correct
(17, 64, 74),  -- Incorrect
(17, 65, 77),  -- Correct
(17, 66, 81),  -- Correct
(17, 67, 83),  -- Incorrect
(17, 68, 86),  -- Correct
(17, 69, 87),  -- Correct
(17, 70, 89),  -- Correct

-- Student 18's answers
(18, 61, 63),  -- Correct
(18, 62, 66),  -- Incorrect
(18, 63, 70),  -- Incorrect
(18, 64, 73),  -- Correct
(18, 65, 77),  -- Correct
(18, 66, 81),  -- Correct
(18, 67, 84),  -- Correct
(18, 68, 85),  -- Incorrect
(18, 69, 88),  -- Incorrect
(18, 70, 90),  -- Incorrect

-- Student 19's answers
(19, 61, 61),  -- Correct
(19, 62, 65),  -- Correct
(19, 63, 72),  -- Incorrect
(19, 64, 73),  -- Correct
(19, 65, 80),  -- Incorrect
(19, 66, 82),  -- Incorrect
(19, 67, 84),  -- Correct
(19, 68, 86),  -- Correct
(19, 69, 87),  -- Correct
(19, 70, 90),  -- Incorrect

-- Student 20's answers
(20, 61, 62),  -- Correct
(20, 62, 67),  -- Incorrect
(20, 63, 69),  -- Correct
(20, 64, 75),  -- Incorrect
(20, 65, 77),  -- Correct
(20, 66, 82),  -- Incorrect
(20, 67, 84),  -- Correct
(20, 68, 86),  -- Correct
(20, 69, 87),  -- Correct
(20, 70, 89),  -- Correct

-- Student 21's answers
(21, 61, 64),  -- Incorrect
(21, 62, 65),  -- Correct
(21, 63, 71),  -- Incorrect
(21, 64, 73),  -- Correct
(21, 65, 79),  -- Incorrect
(21, 66, 81),  -- Correct
(21, 67, 83),  -- Incorrect
(21, 68, 85),  -- Incorrect
(21, 69, 88),  -- Incorrect
(21, 70, 89),  -- Correct

-- Student 22's answers
(22, 61, 61),  -- Correct
(22, 62, 65),  -- Correct
(22, 63, 69),  -- Correct
(22, 64, 73),  -- Correct
(22, 65, 77),  -- Correct
(22, 66, 82),  -- Incorrect
(22, 67, 84),  -- Correct
(22, 68, 85),  -- Incorrect
(22, 69, 87),  -- Correct
(22, 70, 89),  -- Correct

-- Student 23's answers
(23, 61, 62),  -- Correct
(23, 62, 68),  -- Incorrect
(23, 63, 70),  -- Incorrect
(23, 64, 76),  -- Incorrect
(23, 65, 77),  -- Correct
(23, 66, 81),  -- Correct
(23, 67, 84),  -- Correct
(23, 68, 86),  -- Correct
(23, 69, 88),  -- Incorrect
(23, 70, 90),  -- Incorrect

-- Student 24's answers
(24, 61, 63),  -- Correct
(24, 62, 65),  -- Correct
(24, 63, 69),  -- Correct
(24, 64, 73),  -- Correct
(24, 65, 77),  -- Correct
(24, 66, 81),  -- Correct
(24, 67, 84),  -- Correct
(24, 68, 86),  -- Correct
(24, 69, 87),  -- Correct
(24, 70, 89);  -- Correct




----------------------------------------------------------------------


-- Insert into Student_Exam_Attempt Table
INSERT INTO Student_Exam_Attempt (st_id, ex_id)
VALUES 
-- Past Exam 1 (OOP for Track 1)
(1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1),

-- Past Exam 2 (SQL for Track 1)
(1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2),

-- Past Exam 3 (OOP for Track 3)
(17, 3), (18, 3), (19, 3), (20, 3), (21, 3), (22, 3), (23, 3), (24, 3);