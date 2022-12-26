$(function(){
    function hideAll(){
        $(".component").hide();
    }
    hideAll();

    $(".about-li").click(function(){
        hideAll();
        $(".about").fadeIn();
    })
    $(".services-li").click(function(){
        hideAll();
        $(".services").show(1000);
    })
    $(".gallery-li").click(function(){
        hideAll();
        $(".gallery").show();
        $(".image").hide();
        $(".image").eq(0).show();
    })
    $(".complain-li").click(function(){
        hideAll();
        $(".complain").show();
        $(".preview").hide();
    })




    $("#send").click(function(){
        $(".form").hide();
        $(".preview").fadeIn();
        $(".name").html("<b>your name is: </b>" + $("#name").val());
        $(".email").html("<b>your email is: </b>" + $("#email").val());
        $(".phone").html("<b>your phone is: </b>" + $("#phone").val());
        $(".msg").html("<b>your complain is: </b>" + $("#msg").val());

    })
    $("#back").click(function(){
        $(".preview").hide();
        $(".form").fadeIn();
    })


    
    var counter = 0;

    $(".left").click(function(){
        slideLeft();
        
    })
    
    $(".right").click(function(){
        slideRight();
    })

    function slideLeft() {
        if(counter == 0)
        {
            counter = 0;
        } else{
            counter--;
        }
        $(".image").hide();
        $(".image").eq(counter).show();
    }

    function slideRight() {
        if(counter == 7)
        {
            counter = 7;
        } else{
            counter++;
        }
        $(".image").hide();
        $(".image").eq(counter).show();
    }
    

})