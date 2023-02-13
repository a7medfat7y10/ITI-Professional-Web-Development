var myobj ={
    name : "ahmed",
    address : "124",
    age : 24
}
var handler ={
    set(target, prop, value){
        if(prop == "name"){
            if(value.length == 7 && typeof value == "string")
            {
                target[prop] = value;
            } else {
                throw "name must be string of 7 characters";
            }
        }
        if(prop == "address"){
            if(typeof value == "string")
            {
                target[prop] = value;
            } else {
                throw "address must be string ";
            }
        }
        if(prop == "age"){
            if(typeof value == "number" && value >= 25 && value <=60)
            {
                target[prop] = value;
            } else {
                throw "age must be numerical between 25 and 60 ";
            }
        }
    }
}

var proxy1 = new Proxy(myobj, handler);
proxy1.name = "ahmed";
proxy1.address = "123";
proxy1.age = 26;