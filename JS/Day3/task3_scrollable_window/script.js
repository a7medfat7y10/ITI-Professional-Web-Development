var counter = 0;
var timer;
function showMessage() {
    win = open("child.html", "", "width=300,height=300");
    win.moveBy(200,200);
    win.focus();

    timer = setInterval(function(){
        win.resizeTo(300,300);
        win.scrollTo(0, counter );
        //win.scrollBy(0,10);
        counter++;
    }, 30)
}