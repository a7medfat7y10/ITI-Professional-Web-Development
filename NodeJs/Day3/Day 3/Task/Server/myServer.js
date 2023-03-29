const exp = require("express");
const fs = require("fs");

const app = exp();
const path = require("path");
let PORT = process.env.PORT || 7008;
const bodyParser = require("body-parser");

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({extended:true}))

app.get("/",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/main.html"))
})
app.get("/main.html",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/main.html"))
})
app.get("/Client/main.html",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/main.html"))
})
app.get("/wlecome.html",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/welcome.html"))
})
app.get("/Client/welcome.html",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/welcome.html"))
})
app.get("/style.css",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/style.css"))
})
app.get("/Client/style.css",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/style.css"))
})
app.get("/script.js",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/script.js"))
})
app.get("/Client/script.js",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/script.js"))
})
app.get("/favicon.ico",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Icons/favicon.ico"))
})
app.get("/Client/favicon.ico",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Icons/favicon.ico"))
})
app.get("/Client/Icons/favicon.ico",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/Icons/favicon.ico"))
})
app.get("/client.json",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/client.json"))
})
app.get("/Client/client.json",(req,res)=>{
    res.sendFile(path.join(__dirname,"../Client/client.json"))
})


app.post("/",(req,res)=>{
    var welcomeFile = fs.readFileSync("../Client/welcome.html").toString();

    res.write(welcomeFile.replace("{clientName}", req.body.clientName)
    .replace("{MobileNum}", req.body.mobile)
    .replace("{Address}", req.body.address)
    .replace("{Email}", req.body.email));
    console.log(req.body.clientName);

    var fileJson = fs.readFileSync("../Client/client.json").toString();
            var allData = JSON.parse(fileJson);
            var newClient =   {
                "clientName": req.body.clientName,
                "mobileNum": req.body.mobile,
                "address": req.body.address,
                "email": req.body.email
            }
            var arr = [];
            for(var i = 0; i < allData.length; i++){
                arr.push(allData[i]);
            }
            arr.push(newClient);
            console.log(arr);
            fs.writeFileSync("../Client/client.json", JSON.stringify(arr));

    res.end();
})

app.all("*",(req,res)=>{
    console.log("MiddleWare Called");
    // res.send("");
    res.send("Please Check ur URL")
})

app.listen(PORT,()=>{console.log("http://www.localhost:"+PORT)});