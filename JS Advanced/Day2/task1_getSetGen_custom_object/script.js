var generator = {
    id: 'sd-10',
    location: "sv",
    addr: "123 st.",
    description: "This object generates setters and getters methods for any other caller object" ,
    
    getSetGen: function(){
        for (var prop in this)
        {
            //using IIFE Design Pattern to solve the closure problem
            //invoke the function immediately and pass the for loop variable to it 
            //and return a function that make the logic
            this['get' + prop] = (function(p){
                return function(){
                    console.log(this[p]);
                }
            })(prop);

            this['set' + prop] = (function(p){
                return function(){
                    for(var i=0;i < arguments.length; i++)
                    {
                        this[p] = arguments[i];
                    }
                }
            })(prop);
        }
    }
}
//using getSetGen on the generator object
generator.getSetGen();
generator.getid();
generator.getdescription();

//call the function from the user object
var user = { name: "Ali", age:10};

generator.getSetGen.call(user);
console.log(user);

user.getname();
user.getage();

user.setname("ahmed");
user.setage(23);

user.getname();
user.getage();

console.log(user);

