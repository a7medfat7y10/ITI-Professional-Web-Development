db.getName();

// • Create student collection that has (FirstName, lastName, IsFired, FacultyID, array of objects, each object has CourseID, grade).
db.createCollection("students",{
    validator:{
        $jsonSchema: {
            bsonType:"object",
            properties: {
                FirstName: {bsonType: "string"},
                lastName: {bsonType: "string"},
                IsFired: {bsonType: "bool"},
                FacultyID: {bsonType: "number"},
                Courses: {bsonType: "array"}
            }
        }
    }
});

// • Create Faculty collection that has (Faculty Name, Address). 
db.createCollection("faculty",{
    validator:{
        $jsonSchema: {
            bsonType:"object",
            properties: {
                FacultyID: {bsonType: "number"},
                FacultyName: {bsonType: "string"},
                Address: {bsonType: "string"}
            }
        }
    }
});


// • Create Course collection, which has (Course Name, Final Mark). 
db.createCollection("courses",{
    validator:{
        $jsonSchema: {
            bsonType:"object",
            properties: {
                CourseID: {bsonType: "number"},
                CourseName: {bsonType: "string"},
                FinalMark: {bsonType: "number"}
            }
        }
    }
});


// • Insert some data in previous collections.
//  students collection
db.students.insertOne({FirstName: "Hafsa", lastName: "Ebrahim", IsFired: false, FacultyID: 1, Courses:[{CourseID: 1, grade: 140}]});
db.students.insertOne({FirstName: "Ahmed", lastName: "M7md", IsFired: false, FacultyID: 2, Courses:[{CourseID: 2, grade: 150}]});
db.students.insertOne({FirstName: "Mona", lastName: "Ebrahim", IsFired: false, FacultyID: 2, Courses:[{CourseID: 1, grade: 120}]});
db.students.insertOne({FirstName: "Omar", lastName: "Ebrahim", IsFired: false, FacultyID: 1, Courses:[{CourseID: 1, grade: 140}]});

db.students.find();

//  faculty collection
db.faculty.insertOne({FacultyID: 1, FacultyName: "CE", Address: "cairo"});
db.faculty.insertOne({FacultyID: 2, FacultyName: "PE", Address: "cairo"});

db.faculty.find();


// course collection
db.courses.insertOne({CourseID: 1, CourseName: "js", FinalMark: 150});
db.courses.insertOne({CourseID: 2, CourseName: "Dp", FinalMark: 200});

db.courses.find();


// 2. Display each student Full Name along with his average grade in all courses. $concat
db.students.aggregate([{$project: {fullName: {$concat: ["$FirstName", " ", "$lastName"]}, gradesAvg: {$avg: "$Courses.grade"} }}]);


// 3. Using aggregation display the sum of final mark for all courses in Course collection.
db.courses.aggregate([{$group:{_id: null, 
                       totalFinalMark: {$sum: "$FinalMark"}}
                      },
                      {$project: {_id: 0, totalFinalMark: 1}}
]);
 
// 4. Implement (one to many) relation between Student and Course, by adding array of Courses IDs in the student object. 
// • Select specific student with his name, and then display his courses.
db.students.aggregate([{
    $lookup: {
        from: "courses",
        localField: "Courses.CourseID",
        foreignField: "CourseID",
        as: "stdCrs"
    }
}]);

// 4. Implement relation between Student and faculty by adding the faculty object in the student using _id Relation using $Lookup. 
// • Select specific student with his name, and then display his faculty.
db.students.aggregate([{
    $lookup: {
        from: "faculty",
        localField: "FacultyID",
        foreignField: "FacultyID",
        as: "stdFaculty"
    }
}]);


