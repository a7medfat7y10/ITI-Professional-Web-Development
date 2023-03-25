// a- Display all documents in instructors collection
db.instructors.find();	


// b- Display all instructors with salaries greater than 4000 (only show firstName and salary).
db.instructors.find({salary: {$gt: 4000}}, {firstName: 1, salary: 1});

// c- Display all instructors with ages less than or equal 25.
db.instructors.find({age: {$lte: 25}});

// d- Display all instructors with city mansoura and sreet number 10 or 14 only display (firstname, address, salary).
db.instructors.find({$and: [{"address.city": "mansoura"}, {$or: [{"address.street": 10}, {"address.street": 14}]}]}, {firstName: 1, address: 1, salary: 1});

// e- Display all instructors who have js and jquery in their courses (both of them not one of them).
db.instructors.find({$and: [{courses: "js"}, {courses: "jquery"}]});
// another solution
db.instructors.find({courses: {$all: ["js", "jquery"]}});


// f- Display number of courses for each instructor and display first name with number of courses. 
db.instructors.find({courses: {$exists: true}}).forEach(ins => {
    print(`${ins.firstName}, Courses: ${ins.courses.length}`)
});

// g- Write mongodb query to get all instructors that have firstName and lastName properties, sort them by firstName ascending then by 
// lastName descending and finally display their data FullName and age.
// Note: use mongoDb sort method not javascript array method.

db.instructors.find({firstName:{$exists:true}, lastName:{$exists:true}}).sort({firstName:1, lastName:-1}).forEach(ins => {
   print(`Full Name: ${ins.firstName} ${ins.lastName} , Age: ${ins.age}`); 
});

//Bonus: create new collection with step g values data and name it instructorsData
db.createCollection("instructorsData");

db.instructors.find({firstName:{$exists:true}, lastName:{$exists:true}}).sort({firstName:1, lastName:-1}).forEach(ins => {
   db.instructorsData.insertOne( {FullName: `${ins.firstName} ${ins.lastName}` , Age:ins.age})
});

// h- Find all instructors that have fullName that contains “mohammed”.
db.instructors.find({$or:[{firstName: "mohammed"}, {lastName: "mohammed"}]});

// i- Delete instructor with first name “ebtesam” and has only 5 courses in courses array.
db.instructors.deleteMany({$and: [{firstName: "ebtesam"}, {courses: {$size: 5}}]});

// j- Add active property to all instructors and set its value to true.
db.instructors.updateMany({}, {$set: {active: "true"}})

// k- Change “EF” course to “jquery” for “mazen mohammed” instructor (without knowing EF Index).
db.instructors.update({firstName: "mazen", lastName: "mohammed", courses: "EF"}, {$set: {"courses.$": "jquery"}});

// l- Add jquery course for “noha hesham”.
db.instructors.updateOne({firstName: "noha", lastName: "hesham"}, {$push: {courses: "jquery"}});

// m- Remove courses property for “ahmed mohammed ” instructor.
db.instructors.updateOne({firstName: "ahmed", lastName: "mohammed"}, {$unset: {courses: "bb"}});

// n- Decrease salary by 500 for all instructors that has only 3 courses in their list ($inc).
db.instructors.find({courses: {$size: 3}}).forEach(ins =>{
    db.instructors.updateMany({}, {$set: {salary: ins.salary - 500}});
});

// o- Rename address field for all instructors to fullAddress.
db.instructors.updateMany({}, {$rename: {"address": "fullAddress"}});

// p- Change street number for noha hesham to 20.
db.instructors.updateOne({firstName: "noha", lastName: "hesham"}, {$set: {street: 20}});
