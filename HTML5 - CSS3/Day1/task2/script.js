var red = document.getElementById('red');
    var green = document.getElementById('green');
    var blue = document.getElementById('blue');
    var p = document.getElementById('paragraph');

    red.addEventListener('mouseup',function(){
        p.style.color = "rgb(" + red.value+"," + green.value +","+blue.value+")";
    })
    green.addEventListener('mouseup',function(){
        p.style.color = "rgb(" + red.value+"," + green.value +","+blue.value+")";
    })
    blue.addEventListener('mouseup',function(){
        p.style.color = "rgb(" + red.value+"," + green.value +","+blue.value+")";
    })