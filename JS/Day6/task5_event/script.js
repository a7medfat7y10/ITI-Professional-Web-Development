//-----------------------------1
document.body.onkeydown= function(e){
    if (e.altKey)
    {
        alert("Alt clicked");
    }
    else if (e.shiftKey)
    {
        alert("Shift clicked");
    }
    else if (e.ctrlKey)
    {
        alert("Ctrl clicked");
    }
    else
    {
        alert("You pressed the character " + e.code + " with keycode: " + e.keyCode) ;
    }


    //console.log(e.keyCode)
}


//------------------------------2
window.oncontextmenu= function(e){
    e.preventDefault();
}



