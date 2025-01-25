use ExaminationSystem
INSERT INTO Instructor_Track (ins_id, track_id) VALUES (1, 2);
INSERT INTO Instructor_Track (ins_id, track_id) VALUES (1, 3);
INSERT INTO Track_Course (co_id, track_id) VALUES (1, 2);
INSERT INTO Track_Course (co_id, track_id) VALUES (1, 3);

-- All track for instructor in course to select track
SELECT t.track_name
FROM Track t
INNER JOIN Instructor_Track IT ON t.track_id = IT.track_id
INNER JOIN Track_Course TC ON t.track_id = TC.track_id
WHERE IT.ins_id = 1 and TC.co_id = 1

