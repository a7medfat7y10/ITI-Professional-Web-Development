function reverseOne()
{
    var arr = [];

    arr.reverse.call(arguments);
    
    return arguments;
}

function reverseTwo() 
{
    var arr=[];
    
    arr.reverse.bind(arguments)();
    return arguments;
}