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

   - Register students and manage their profiles.
   - Assign students to specific tracks and courses.
   - Monitor student progress and exam results.

2. **Instructor Management**:

   - Manage instructor profiles and assignments.
   - Assign instructors to courses and exams.
   - Track instructor performance and feedback.

3. **Exam and Question Management**:

   - Create, schedule, and manage exams dynamically.
   - Supports the following question types:
     - **Multiple Choice Questions (MCQ)**:
       - Define a variable number of options.
       - Specify one or more correct answers.
     - **True/False Questions**:
       - Define the question and the correct answer (True or False).
   - Configure time limits and grading criteria for exams.

4. **Student Features**:

   - **View Courses**:
     - Displays only the courses the student is enrolled in.
   - **View Exams**:
     - Displays exams assigned to the courses the student is taking.
   - **Solve Exam**:
     - Allows students to take exams assigned to their courses.
     - Supports multiple-choice and single-choice questions.
     - Submit answers for evaluation.
     - The arrangement of exams displayed in the view differs for each student, ensuring a personalized experience.

5. **Reporting and Analytics**:

   - Generate detailed student performance reports.
   - Track student grades across multiple courses.
   - Display instructor course assignments and enrollment data.
   - View course topics and linked exams.
   - Analyze exam details, including student responses and performance trends.

6. **User Interface**:

   - User-friendly interface for instructors, and students.
   - Dashboard views for quick insights and navigation.
   - Secure authentication and role-based access control.

---

## Reports

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

1. Navigate to the installation folder then open the Database Script folder.
2. Double-click on the `script.sql` to create the database and tables.

### 2. Run the Application

1. Navigate to the installation folder then open the Project EXE folder.
2. Double-click on the `setup.exe` to run the application.
3. The application will open, and you can start using it.

---

## Conclusion

The ITI Exam System is designed to streamline exam management. With its detailed database structure, user-friendly UI, and robust reporting capabilities, it supports educational institutions in achieving operational efficiency.
- For more information, check the documentation [Database Project.pdf](https://github.com/user-attachments/files/18725880/Database.Project.pdf)

