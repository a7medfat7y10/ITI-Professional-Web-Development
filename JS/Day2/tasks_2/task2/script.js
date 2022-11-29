var inputs = [];
for (var i=0;i<5;i++)
{
    inputs [i] = prompt("enter the " + (i+1) + " value");
}

document.write(
    "<font color='red'>You have entered the values:</font>" + 
        inputs[0] + " , " + inputs[1] +  " , " + inputs[2] + " , " + inputs[3] + " , " + inputs[4]
    );

inputs.sort(function(a,b) {return a-b;});

document.write("<br> <font color='red'> Sorted values: </font>"  + 
        inputs[0] + " , " + inputs[1] +  " , " + inputs[2] + " , " + inputs[3] + " , " + inputs[4]
    );

inputs.sort(function(a,b) {return a-b;}).reverse();

document.write("<br> <font color='red'> Sorted Valued in desc order: </font>" + 
        inputs[0] + " , " + inputs[1] +  " , " + inputs[2] + " , " + inputs[3] + " , " + inputs[4]
    );