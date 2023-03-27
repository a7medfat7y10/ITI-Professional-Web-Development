const http = require("http");
const fs = require("fs");

const port = http.createServer((req, res)=>{
    if(req.url != "/favicon.ico"){
        console.log(req.url);
        var arr = req.url.split("/");
        console.log(arr);
        
        if(arr[1] == "add"){
            var result = 0;
            for(var i = 2; i < arr.length; i++){
                result += (Number.parseInt(arr[i]));
            }
            fs.appendFile("result.txt",  req.url + " → " + result.toString() + "\n", ()=>{});
            res.write(req.url + " => " + result.toString());
        }

        else if(arr[1] == "sub"){
            var result = arr[2] - arr[3];
            for(var i = 4; i < arr.length; i++){
                result -= (Number.parseInt(arr[i]));
            }
            fs.appendFile("result.txt", req.url + " → " +  result.toString() + "\n", ()=>{});
            res.write(req.url + " => " + result.toString());
        }

        else if(arr[1] == "mul"){
            var result = 1;
            for(var i = 2; i < arr.length; i++){
                result *= (Number.parseInt(arr[i]));
            }
            fs.appendFile("result.txt", req.url + " → " + result.toString() + "\n", ()=>{});
            res.write(req.url + " => " + result.toString());
        }

        // /div/0/1
        // /div/4/2
        // /div/4/2/0/1
        else if(arr[1] == "div"){
            var result = arr[2];
            for(var i = 3; i < arr.length; i++){
                if(arr[i] == 0){
                    result = "Not valid";
                    break;
                }
                else{
                    result /= (Number.parseInt(arr[i]));
                }   
            }
            fs.appendFile("result.txt", req.url + " → " +  result.toString() + "\n", ()=>{});
            res.write(req.url + " => " + result.toString());
        }

        res.end();
    }
})

port.listen(7000);
