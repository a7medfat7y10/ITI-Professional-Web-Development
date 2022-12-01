var message = "this is message will be shown character by character";

var counter = 0;
var timer;
function showMessage() {
    win = open("child.html", "", "width=300,height=300");

    timer = setInterval(function(){
        win.document.write(message[counter]);
        counter++;
        if (counter == message.length)
        {
            clearInterval(timer);

            setTimeout(function(){
                win.close();
            }, 5000)
        }
    }, 100)
}

