
const http = require("http");
const fs = require("fs");
let mainHtml = fs.readFileSync("../Client/main.html").toString();
let welcomeHtml = fs.readFileSync("../Client/welcome.html").toString();
let styleCSS = fs.readFileSync("../Client/style.css").toString();
let scriptJS = fs.readFileSync("../Client/script.js").toString();
let favIcon = fs.readFileSync("../Client/Icons/favicon.ico");
let clientJson = fs.readFileSync("../Client/client.json").toString();

const port = http.createServer((req, res) =>{

    //#region GET
    if(req.method == "GET"){
        switch(req.url){
            case '/':
            case '/main.html':
            case '/client/main.html':
                res.write(mainHtml);
            break;
            case '/':
            case '/welcome.html':
            case '/client/welcome.html':
                res.write(welcomeHtml);
            break;
            case '/style.css':
            case '/client/style.css':
                res.write(styleCSS);
            break;
            case '/script.js':
            case '/client/script.js':
                res.write(scriptJS);
            break;
            case '/favicon.ico':
            case '/client/favicon.ico':
            case '/client/Icons/favicon.ico':
                res.write(favIcon);
            break;
            case '/client.json':
            case '/client/client.json':
                res.write(clientJson);
            break;
            default:
                if(req.url.includes("?clientName")){
                    res.write(mainHtml);
                }
            break;
        }
        res.end();
    }
    //#endregion
    
    //#region POST
    else if(req.method=="POST"){
        req.on("data",(data)=>{
            console.log(data.toString());   
            clientName = data.toString().split("&")[0].split("=")[1].replace("+", " ");
            mobileNum = data.toString().split("&")[1].split("=")[1].replace("+", " ");
            address = data.toString().split("&")[2].split("=")[1].replace("+", " ");
            email = data.toString().split("&")[3].split("=")[1].replace("%40", "@");
        })
        req.on("end",()=>{
            res.write(welcomeHtml.replace("{clientName}", clientName)
            .replace("{MobileNum}", mobileNum)
            .replace("{Address}", address)
            .replace("{Email}", email)
            );

            var fileJson = fs.readFileSync("../Client/client.json").toString();
            var allData = JSON.parse(fileJson);
            var newClient =   {
                "clientName": clientName,
                "mobileNum": mobileNum,
                "address": address,
                "email": email
            }
            // console.log(newClient);
            var arr = [];
            for(var i = 0; i < allData.length; i++){
                arr.push(allData[i]);
                // console.log(allData[i]);
            }
            arr.push(newClient);
            console.log(arr);
            fs.writeFileSync("../Client/client.json", JSON.stringify(arr));

            res.end();
        })
    }
    //#endregion
})

port.listen(7000);

