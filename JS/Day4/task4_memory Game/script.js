var images = [];
for (i in document.images)
    images[i] = document.images[i];

var srcs = ["5.gif", "3.gif", "2.gif", "4.gif", "4.gif", "1.gif", "5.gif", "6.gif", "1.gif", "3.gif", "6.gif" , "2.gif"];
var imgOpened;
var isSecond = false;

function play(imgObj)
{
    if(isSecond == false)
    {
        var indx = images.indexOf(imgObj);
        isSecond = true;
        images[indx].src = "imgs/" + srcs[indx];
        imgOpened = indx;
    } 
    else if(isSecond)
    {
        var indx = images.indexOf(imgObj);
        isSecond = false;
        images[indx].src = "imgs/" + srcs[indx];
        if(images[indx].src !== images[imgOpened].src)
        {
            setTimeout(function(){
                images[indx].src = "imgs/moon.gif";
                images[imgOpened].src = "imgs/moon.gif";
            }, 1000)
        }
    }
}