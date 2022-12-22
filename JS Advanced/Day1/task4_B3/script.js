function adding()
{
    if(arguments.length == 0)
    {
        throw 'parameters must be entered';
    }
    var sum=0;
    for(var i =0; i<arguments.length; i++)
    {
        if(isNaN(arguments[i]))
            throw 'Only Numbers';
        sum+=arguments[i];
    }
    return sum;
}