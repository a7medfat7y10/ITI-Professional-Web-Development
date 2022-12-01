//new window
var win;
//timer to set interval
var timer;
//values to move window by
var y = 10, x = 10;
//the position of the window at each interval
var current_height = 0, current_width = 0;

function winOpen()
{
    //open new window
    win = open("child.html", "", "width=150,height=150");
    win.focus();
    
    timer = setInterval(() => {
        win.resizeTo(150,150);
        //start (0, 0) then add x, y
        win.moveTo(current_width, current_height);

        if((current_height) >= (screen.height - 200) || (current_width)>=(screen.width - 200) )
        {
            y = -y;
            x = -x;
        }
        //update current position
        current_width+=x;
        current_height+=y;
    }, 100);
}
winOpen();

function winStop()
{
    clearInterval(timer);
    win.focus();
}