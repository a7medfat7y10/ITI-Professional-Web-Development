var paragraph = document.getElementById("PAR");

function ChangeFont(font)
{
    paragraph.style.fontFamily = font;
}

function ChangeAlign(value)
{
    paragraph.style.textAlign = value;
}

function ChangeHeight(value)
{
    paragraph.style.lineHeight = value;
}

function ChangeLSpace (value)
{
    paragraph.style.letterSpacing = value;
}

function ChangeIndent(value)
{
    paragraph.style.textIndent = value;
}

function ChangeTransform(value)
{
    paragraph.style.textTransform = value;
}

function ChangeDecorate(value)
{
    paragraph.style.textDecoration = value;
}


var border_color = "#000";

function ChangeBorder(value)
{
    paragraph.style.border = "5px " + value + " " + border_color;
}

function ChangeBorderColor(c)
{
    paragraph.style.borderColor = c;
    border_color= c;
}