var str, ch,issensitive;

str = prompt("Enter a string");
ch = prompt("Enter the character you want");
issensitive = prompt("do you want to consider the character's sensitivity? y or n? ");

if (issensitive == 'y')
{
    var regex = new RegExp(ch , "g");
    var num = str.replace(regex, "").length;//5
    var count_num = str.length - num;//6-5
    document.write(count_num);
}
else
{
    var regex = new RegExp(ch , "gi");
    var num = str.replace(regex, "").length;//4
    var count_num = str.length - num;//6-4
    document.write(count_num);
}
