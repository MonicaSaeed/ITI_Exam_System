# ITI Exam System

## Overview
The ITI Exam System is a comprehensive platform designed to manage exams. It integrates an efficient database structure, an intuitive user interface, and detailed reporting capabilities to support various administrative and academic tasks.

---

## Key Resources
### 2. ERD (Entity-Relationship Diagram)
- **Link**: [ERD](https://github.com/user-attachments/assets/007abf49-8a15-4406-8c17-043ba2972308)
- **Purpose**: The ERD defines the database structure, showing relationships between entities like Students, Courses, Exams, Tracks, and Instructors. It is the foundation for building and maintaining the system’s database.

### 3. Mapping Document
- **Link**: [Mapping](https://github.com/user-attachments/assets/dd12f09c-c501-4a84-8520-1d0b40f089a4)
- **Purpose**: The mapping document provides detailed relationships and data flow between the database tables. It specifies how tables interact and what keys are used to establish these connections.

---

## System Features

1. **Student Management**:
   - Enroll students in specific tracks and courses.
   - Track student progress and exam performance.

2. **Instructor Management**:
   - Assign instructors to specific tracks and courses.
   - View course enrollment and student counts.

3. **Exam and Question Management**:
   - Create, schedule, and manage exams.
   - Define and assign questions (multiple-choice options or True/False) to exams.

4. **Reporting**:
   - Generate reports for:
     - Students based on department.
     - Student grades across courses.
     - Instructor course assignments and enrollment numbers.
     - Course topics and associated exams.
     - Exam details including questions and student answers.

5. **User Interface**:
   - Intuitive UI for administrators, instructors, and students to interact with the system.

---

## Reports
The system includes the following reports:

1. **Students by Department**:
   - Displays student information filtered by department.

2. **Student Grades**:
   - Displays all grades of a specific student across courses.

3. **Instructor Course Assignment**:
   - Displays courses taught by an instructor and the number of students enrolled in each.

4. **Course Topics**:
   - Displays the topics covered in a specific course.

5. **Exam Questions and Choices**:
   - Displays all questions and choices in a specific exam.

6. **Student Exam Answers**:
   - Displays all questions and student answers for a specific exam.

---

## How to Run the ITI Exam System

### 1. Set Up the Database
1. Create a new database named `ExaminationSystem` in your SQL Server.
2. Run the `tableCreation.sql` script to create the necessary tables.
3. Run the `insertdata.sql` script to populate the database with initial data.

### 2. Run the Application
1. Navigate to the folder where the executable (`setup.exe`) file of the ITI Exam System is located.
2. Double-click the `setup.exe` file to launch the application.
3. Log in using the provided credentials to access the system features.

---

## Conclusion
The ITI Exam System is designed to streamline exam management. With its detailed database structure, user-friendly UI, and robust reporting capabilities, it supports educational institutions in achieving operational efficiency.

