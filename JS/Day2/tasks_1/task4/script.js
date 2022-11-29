do 
{
    var username = prompt("Enter name");
    // /[A-Za-z]/ => you can enter any characters capital or small
} while(!/^[A-Za-z]+$/.test(username));

do 
{
    var phone_num = prompt("Enter phone number");
    // [0-9]{8} => you can enter only eight numbers not less or more
} while(!/^[0-9]{8}$/.test(phone_num));

do 
{
    var moblie_num = prompt("Enter mobile number");
    // ^ => pattern must start
    // 01 => the first two digits in any phone number
    // [0125] => must enter one of these four at the third digit
    // [0-9]{8} => enter any eight numbers
    // $ => pattern must end
} while(!/^01[0125][0-9]{8}$/.test(moblie_num));

do 
{
    var email = prompt("Enter email");
    //  \w => character capital or small or number
    //  \w+ => character must be entered one time or more so you can enter ahmed from ahmed.fathy@gmail.com
    //  \d => number 0 - 9
    //  [a-z] => range from a to z
    //  [\.-] => you must enter one of these characters
    //  [\.-]? => ? means optional so you may enter one of these characters only one time or not enter them
    //  ()* => * means you may enter this more than one time or to not enter at all(optional)
    //  ([\.-]?\w+)*  => this means you can enter .fathy from ahmed.fathy@gmail.com
    //  @ 
    //  \w+ => to enter gmail
    //  (\.\w{2,3})+ => .com

} while(!/\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+/.test(email))

var color_format = prompt("please choose color.. red or green or blue?");

if(color_format ==="blue" || color_format ==="red" || color_format ==="green")
{
    document.write(
        "<font color=" + color_format + "> Welcome </font>" + username +
        "<br><font color=" + color_format + "> Your Email:  </font>" + email + 
        "<br><font color=" + color_format + "> Phone Number:  </font>"  + phone_num + 
        "<br><font color=" + color_format + "> Mobile Number: </font> "+moblie_num
    );
} 
else
{
    //default black
    document.write(
        "welcome " + username + 
        "<br>your email: " + email + 
        "<br>phone: " + phone_num + 
        "<br>mobile: "+moblie_num
    );
}