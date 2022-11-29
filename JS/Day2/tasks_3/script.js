//area of circle
var r = prompt("Enter the value of your circle's radius");

var area = Math.PI * Math.pow(r,2);

alert("The area of the circle is " + area);

//square root of a number
var value = prompt("Enter the value to take square root");

var sqrt = Math.sqrt(value);

alert("The square root is " + sqrt);

//cos angle
var ang = prompt("Enter the angle to get the cosine");

var pi = Math.PI.toFixed(2);

var rad_angle = (parseInt(ang) * pi )/180;

var cosine = Math.cos(rad_angle);

document.write("Cos " + ang  +" is " + cosine.toFixed(4));
