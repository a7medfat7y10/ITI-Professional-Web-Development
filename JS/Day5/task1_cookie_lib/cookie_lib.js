function getCookie(cookieName)
{
    //the name of cookie you want to get its value
    var name = cookieName + "=";
    //array of the cookies and its values [username=ahmed, ]
    var cookie_array = document.cookie.split(';');
    
    for(var i = 0; i <cookie_array.length; i++) {
        //c is the cookie with = and its value
        var c = cookie_array[i];
        //to trim any spaces before the cookie name
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        //get the value
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    //else return empty
    return "";
    
}

function setCookie(cookieName, cookieValue, expirydays)
{
    //get date
    var date = new Date();
    //turn the days into milliseconds
    date.setTime(date.getTime() + (expirydays*24*60*60*1000));
    //set cookie
    document.cookie = cookieName + "=" + cookieValue + ";" + "expires="+ date.toUTCString();
}

function deleteCookie(cookieName)
{
    document.cookie = cookieName + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
}

function allCookieList()
{
    var arr_cookies = [];
    for(ind in document.cookie.split(";"))
    {
        arr_cookies[document.cookie.split(";")[ind].split("=")[0]] = document.cookie.split(";")[ind].split("=")[1];
    }
    return arr_cookies;
}

function hasCookie(cookieName)
{
    var value = getCookie(cookieName);
    if (value != "") {
        return true;
    } else {
        return false;
    }
}
