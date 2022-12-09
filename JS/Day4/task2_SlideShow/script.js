var image = document.images[0];
var current = 1;
var timer;

function nextSlide()
{
    if(current >= 6)
        current = 5;
    current++;
    image.src= "imgs/" + current+ ".jpg";
}

function prevSlide()
{
    if(current <=1)
        current = 2;
    current--;
    image.src= "imgs/" + current+ ".jpg";


}

function slideShow()
{
    timer = setInterval(function(){
        if(current == 6)
            current = 0;
        nextSlide();
    },500)
}

function stop()
{
    clearInterval(timer);
}