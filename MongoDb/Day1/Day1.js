//5- Create database with name ITI  by typing use ITI
use ITI

//get db name
db.getName();

//6- start create new collection named instructors following with inserts
db.createCollection("instructors");
// a- Insert your own data
db.instructors.insertOne({id:1, name:"Hany"});
db.instructors.insertOne({id:2, name:"Mostafa"});
db.instructors.insertOne({id:3, name:"Hadeer"});
db.instructors.insertOne({id:4, name:"Nada"});


// b- Insert instructor without firstName and LastName (mongo will raise an error or not ?) 
// no errors
db.instructors.insertOne({_id:5,
                age:21,salary:7500,
                address:{city:"mansoura",street:14,building:3},
                courses:["js","html5","signalR","expressjs","bootstrap"]}  );

// c- Using array contained with lab folder instructors.txt file.
db.instructors.insertMany([
                {_id:6,firstName:"noha",lastName:"hesham",
                age:21,salary:3500,
                address:{city:"cairo",street:10,building:8},
                courses:["js","mvc","signalR","expressjs"]},
                
                {_id:7,firstName:"mona",lastName:"ahmed",
                age:21,salary:3600,
                address:{city:"cairo",street:20,building:8},
                courses:["es6","mvc","signalR","expressjs"]},
                
                {_id:8,firstName:"mazen",lastName:"mohammed",
                age:21,salary:7040,
                address:{city:"Ismailia",street:10,building:8},
                courses:["asp.net","mvc","EF"]},
                
                {_id:9,firstName:"ebtesam",lastName:"hesham",
                age:21,salary:7500,
                address:{city:"mansoura",street:14,building:3},
                courses:["js","html5","signalR","expressjs","bootstrap"]}   
    ]);
    
    
// 7- Try the following queries: (all queries should be run using find or findOne)
// a- Display all documents for instructors collection  
db.instructors.find();    
    
// b- Display all instructors with fields firstName, lastName and address
db.instructors.find({}, {firstName: 1, lastName: 1, address: 1});

// c- Display firstName and city(not full address) for instructors with age 21.     
db.instructors.find({age: 21}, {firstName: 1, "address.city": 1});

// d- Display firstName and age for instructors live in Mansoura city.
db.instructors.find({"address.city": "mansoura"}, {firstName: 1, age: 1});

// e- Try to run these commands
// 1-
db.instructors.find({firstName: "mona"}, {lastName: "ahmed"}, {firstName: 1, lastName: 1})
// Explain the output!! 
// Ans: will display the lastName = "ahmed" for each row with firstName = "mona" and will ignore the third parameter.

//2- 
db.instructors.find({courses: "mvc"}, {firstName: 1, courses: 1})
// Explain the output!
// will display the firstName, courses for each row contains "mvc" in courses

