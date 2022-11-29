var inputs = [];
for (var i=0;i<3;i++)
{
    inputs [i] = prompt("enter the " + (i+1) + " value");
}

var sum = parseInt(inputs[0]) + parseInt(inputs[1]) + parseInt(inputs[2]) ;
var multiplication = parseInt(inputs[0]) * parseInt(inputs[1]) * parseInt(inputs[2]) ;
var division = parseInt(inputs[0]) / parseInt(inputs[1]) / parseInt(inputs[2]) ;

document.write(
    "<font color='red'> Sum of " + inputs[0] + "+" + inputs[1] + "+" + inputs[2] +  " : </font>" + sum + 
    "<br><font color='red'>Multiplication of "  + inputs[0] + "*" + inputs[1] + "*" + inputs[2] +  ": </font>" + multiplication + 
    "<br><font color='red'>Division of " + inputs[0] + "/" + inputs[1] + "/" + inputs[2] +  ": </font>" + division 
    );