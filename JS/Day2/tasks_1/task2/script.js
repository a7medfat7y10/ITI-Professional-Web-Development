var str,issensitive;

str = prompt("Enter a string");
issensitive = prompt("do you want to consider the character's sensitivity? y or n? ");

var len = str.length;

var counter = 0;

if(len%2 == 0)
{
    if (issensitive === 'y')
    {
        for (i=0;i<len/2;i++)
        {       
            if(str[i] === str[len-i-1])
            {
                counter++;                
            }
        }
    }
    else
    {
        str2= str.toLowerCase();
        for (i=0;i<len/2;i++)
        {       
            if(str2[i] === str2[len-i-1])
            {
                counter++;
            }
        }
    }

    if(counter === len/2)
    {
        document.write("palindrome");
    }
    else
    {
        document.write("not palindrome");
    }

}
else
{
    document.write("not palindrome");
}

    





