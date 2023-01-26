var my_video = document.getElementById("my_video");
var my_sound = document.getElementById("sound");
var my_speed = document.getElementById("speed");

var my_bar = document.getElementById("progress");
var my_time = document.getElementById("time");    
setInterval(function(){
    my_bar.value = my_video.currentTime;
    if(parseInt(my_video.currentTime)<10)
    {
        my_time.innerHTML ="00:0" +parseInt(my_video.currentTime)
    }
    else if(parseInt(my_video.currentTime)<60){
        my_time.innerHTML ="00:" +parseInt(my_video.currentTime)
    } else if(parseInt(my_video.currentTime)<70){
        my_time.innerHTML ="01:0" +( parseInt(my_video.currentTime) - 60)
    }
    else
    {
        my_time.innerHTML ="01:" + (parseInt(my_video.currentTime) - 60)
    }
}, 1000);

my_bar.oninput = function(){
    my_video.currentTime = my_bar.value;
}

function fullscreen(){
    my_video.requestFullscreen()
}

function vid_play(){
    my_video.play();
}
function vid_stop(){
    my_video.pause();
}
function to_start(){
    my_video.currentTime = 0;
}
function to_end(){
    my_video.currentTime = my_video.duration -1;
}
function backfive(){
    my_video.currentTime -= 5; 
}
function forwardfive(){
    my_video.currentTime += 5; 
}
function mute(){
    if(!my_video.muted)
        my_video.muted=true
    else if(my_video.muted){
        my_video.muted=false;
        my_video.volume = .5;
    }
}
function sound(){
    my_video.volume = my_sound.value / 100;
}
function speed(){
    my_video.playbackRate =my_speed.value;
}
