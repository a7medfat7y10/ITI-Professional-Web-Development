//registeration page
document.getElementById("submit").onclick = function(e){
    e.preventDefault();
    window.location.replace("profile.html");

    setCookie("username", document.getElementById("username").value);
    setCookie("age", document.getElementById("age").value);
    if(document.getElementsByName("gender")[0].checked)
    {
        setCookie("gender", document.getElementsByName("gender")[0].value);
    } 
    else
    {
        setCookie("gender", document.getElementsByName("gender")[1].value);
    }
    setCookie("color", document.getElementById('fav_color').value);
    setCookie("num_of_visits", "1");
}

