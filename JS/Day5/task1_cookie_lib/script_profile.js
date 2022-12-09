//profile page
console.log(getCookie("username"));
console.log(getCookie("age"));
console.log(getCookie("gender"));
console.log(getCookie("color"));
console.log(getCookie("num_of_visits"));
console.log(allCookieList());



var img = document.images[0];
img.src=getCookie("gender");

window.onload = function ()
{
    setCookie("num_of_visits", parseInt(getCookie("num_of_visits"))+1);
}

var display = document.getElementById("display");
display.innerHTML = "Welcome <span style='color:" + getCookie("color") + ";'> " + getCookie("username") + 
"</span> You Have visited this site <span style='color:" + getCookie("color") + ";'> " + getCookie("num_of_visits") + "</span> times";