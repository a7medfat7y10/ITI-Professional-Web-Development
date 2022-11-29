function sum()
{
    var sum = 0; 
    do
    {
        x = prompt("Enter another number");
        input = parseInt(x);
        if(isNaN(x))
        {
            document.write("Enter a number please <br>");
            input = 0;
        }
        else
        {
            //console.log(1);
            sum = sum+input;
            //console.log(sum);
        }

    }
    while(sum<100 && input!=0);

    document.write("The sum is:" + sum);

}


sum();