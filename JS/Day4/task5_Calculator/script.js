var answer = document.getElementById("Answer");
var first_num;
var second_num;
var operator;

var isempty = true;

function EnterNumber(num)
{
    if(!isempty)
    {
        answer.value = "";
        isempty = true;
    }
    answer.value+=num;
}

function EnterEqual()
{
    second_num = answer.value;
    answer.value = "";
    if(second_num.includes("."))
    {
        decimal = second_num.split(".")[1];
        second_num = parseInt(second_num) + parseInt(decimal) * Math.pow(10, -parseInt(decimal.length));
    }
    if(operator == "+")
    {
        answer.value = parseFloat(first_num) + parseFloat(second_num);
    }
    if(operator == "-")
    {
        answer.value = parseFloat(first_num) - parseFloat(second_num);
    }
    if(operator == "*")
    {
        answer.value = parseFloat(first_num) * parseFloat(second_num);
    }
    if(operator == "/")
    {
        answer.value = parseFloat(first_num) / parseFloat(second_num);
    }

    isempty = false;
}

function EnterOperator(op)
{
    first_num = answer.value;
    answer.value = "";
    operator = op;

    if(first_num.includes("."))
    {
        decimal = first_num.split(".")[1];
        first_num = parseInt(first_num) + parseInt(decimal) * Math.pow(10, -parseInt(decimal.length));
    }
}

function EnterClear ()
{
    isempty = true;
    answer.value = answer.value.substr(0, answer.value.length-1);
}