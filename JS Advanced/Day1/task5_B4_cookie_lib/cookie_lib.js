function getCookie(cookieName)
{
    if(arguments.length !=1)
    {
        var errorNumParam = new Error("this function takes one parameter only");
        throw errorNumParam;
    }
    if(typeof cookieName != "string")
    {
        var errtype = new Error("Enter string only");
        throw errtype;
    }

    //the name of cookie you want to get its value
    var name = cookieName + "=";
    //array of the cookies and its values [username=ahmed, ]
    var cookie_array = document.cookie.split(';');
    

    if(document.cookie.indexOf(name) == -1)
    {
        var errNotExisting = new Error("Cookie doesnot exist");
        throw errNotExisting;
    }

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
    if(arguments.length>3 || arguments.length<2)
    {
        var errorNumParam = new Error("this function takes two parameters and one optional");
        throw errorNumParam;
    }
    //get date
    var date = new Date();
    //turn the days into milliseconds
    date.setTime(date.getTime() + (expirydays*24*60*60*1000));
    //set cookie
    document.cookie = cookieName + "=" + cookieValue + ";" + "expires="+ date.toUTCString();
}

function deleteCookie(cookieName)
{
    if(arguments.length !=1)
    {
        var errorNumParam = new Error("this function takes one parameter only");
        throw errorNumParam;
    }
    if(typeof cookieName != "string")
    {
        var errtype = new Error("Enter string only");
        throw errtype;
    }
    if(hasCookie(cookieName))
        document.cookie = cookieName + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC";
    else{
        var errNotExisting = new Error("Cookie doesnot exist");
        throw errNotExisting;
    }

}

function allCookieList()
{
    if(arguments.length !=0)
    {
        var errorNumParam = new Error("this function takes no parameters");
        throw errorNumParam;
    }
    var arr_cookies = [];
    for(ind in document.cookie.split(";"))
    {
        arr_cookies[document.cookie.split(";")[ind].split("=")[0]] = document.cookie.split(";")[ind].split("=")[1];
    }
    return arr_cookies;
}

function hasCookie(cookieName)
{
    if(arguments.length !=1)
    {
        var errorNumParam = new Error("this function takes one parameter only");
        throw errorNumParam;
    }
    if(typeof cookieName != "string")
    {
        var errtype = new Error("Enter string only");
        throw errtype;
    }

    var value = getCookie(cookieName);
    if (value != "") {
        return true;
    } else {
        return false;
    }
}
