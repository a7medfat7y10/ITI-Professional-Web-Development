$(function(){
    $(".car").animate({
        "left" : "1300px"
    }, 20000);

    var timer = setInterval(function(){
        var leftvalue = Math.round($(".car").offset().left);
        $(".movement").text("<img src='12.gif' style='left: " + leftvalue + "'/>" );
    },1 )
    

})

