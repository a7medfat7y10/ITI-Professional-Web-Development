var go = document.getElementById("go");
var reset = document.getElementById("reset");

var img_right = document.getElementsByTagName("img")[0];
var img_left = document.getElementsByTagName("img")[1];
var img_bottom = document.getElementsByTagName("img")[2];

var top_of_img_bottom ;
var left_of_img_left;
var top_of_img_bottom;

var timer;

//flag for image right
var isopposite = false;
//flag for image left
var isopposite_2 = false;
//flag for image bottom
var isopposite_3 = false;

//flag to know if the button go has been clicked
var isStopped = false;

//when go clicked 
go.onclick = function()
{
    if(isStopped)
    {
        go.value = "Go";
            stop_moving();
            isStopped = false;
    } else{
        go.value = "Stop";
            play();
            isStopped = true;
    }
}

//when reset clicked
reset.onclick = reset_moving;




function play()
{
    
    timer = setInterval(function(){
        
        left_of_img_right = getComputedStyle(img_right).left;
        left_of_img_left = getComputedStyle(img_left).left;
        top_of_img_bottom = getComputedStyle(img_bottom).top;

        document.getElementById("tags").innerHTML = "&lt;img src= \"imgs/icon1.gif\" " + "style = \" left:" 
        + left_of_img_left + "\" &gt; &lt;img&gt;" ;
        document.getElementById("tags").innerHTML += "<br>&lt;img src= \"imgs/icon2.gif\" " + "style = \" left:" 
        + left_of_img_right + "\" &gt; &lt;img&gt;" ;
        document.getElementById("tags").innerHTML += "<br>&lt;img src= \"imgs/TOP.gif\" " + "style = \" top:" 
        + top_of_img_bottom + "\" &gt; &lt;img&gt;" ;


        //image one(right)
        if(parseInt(left_of_img_right) >= 0 && isopposite == false)
        {
            img_right.style.left = parseInt(left_of_img_right) - 10 + "px";
        }
        else if(parseInt(left_of_img_right) > 355 && isopposite == true)
        {
            img_right.style.left = parseInt(left_of_img_right) - 10 + "px";
            isopposite = false;
        }   
        else 
        {
            isopposite = true;
            img_right.style.left = parseInt(left_of_img_right) + 10 + "px";
        }
        




        //image two(left)
        if(parseInt(left_of_img_left) <=355 && isopposite_2 == false)
        {
            img_left.style.left = parseInt(left_of_img_left) + 10 + "px";
        }
        else if(parseInt(left_of_img_left) <0 && isopposite_2 == true)
        {
            img_left.style.left = parseInt(left_of_img_left) + 10 + "px";
            isopposite_2 = false;
        }   
        else 
        {
            isopposite_2 = true;
            img_left.style.left = parseInt(left_of_img_left) - 10 + "px";
        }
        




        //image three(top)
        if(parseInt(top_of_img_bottom) >=0 && isopposite_3 == false)
        {
            img_bottom.style.top = parseInt(top_of_img_bottom) - 10 + "px";
        }
        else if(parseInt(top_of_img_bottom) >360 && isopposite_3 == true)
        {
            img_bottom.style.top = parseInt(top_of_img_bottom) - 10 + "px";
            isopposite_3 = false;
        }   
        else 
        {
            isopposite_3 = true;
            img_bottom.style.top = parseInt(top_of_img_bottom) + 10 + "px";
        }






    }, 100);
}



function stop_moving()
{
    clearInterval(timer);

}


function reset_moving()
{
    clearInterval(timer);
    img_right.style.left ="355px";

    img_left.style.left = 0;

    img_bottom.style.top = "360px";
}