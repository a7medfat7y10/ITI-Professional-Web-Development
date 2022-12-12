//set interval 
var timer;
//the collection of marble images
var images = document.images;
//var to get the current marble
var current = 0;
//at start, the marble 3 is the first marble
images[0].src = "imgs/marble3.jpg";

function animate()
{
    timer = setInterval(function(){
        if(current == images.length-1)
        {
            images[current].src = "imgs/marble1.jpg";
            current = 0;
            images[0].src = "imgs/marble3.jpg";
        }  
        else{
            images[current].src = "imgs/marble1.jpg";
            current++;
            images[current].src = "imgs/marble3.jpg";
        }        
    }, 1000)
}

animate();

var marbles = document.getElementById("marbles");
marbles.onmouseover = function(){
    clearInterval(timer);
}
marbles.onmouseout = animate;