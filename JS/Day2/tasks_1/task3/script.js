var str = "this is a javascript demo janascript";

function largest_word(s)
{
    var words = str.split(" ");
    var largest = words[0];
    for (i=0;i<words.length;i++)
    {
        if(words[i].length >largest.length)
        {
            largest = words[i];
        }
    }
    document.write(largest);
}


largest_word(str);




 