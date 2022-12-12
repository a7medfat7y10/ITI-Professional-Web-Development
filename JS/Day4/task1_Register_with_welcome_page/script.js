//function to get the queries splitted
// function getUrlQueries() {
//     var queries = {};
//     var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
//         queries[key] = value;
//     });
//     return queries;
// }

// var queries = getUrlQueries();


var queries = [];
var url = location.search;
url = url.substring(1, url.length);
url = url.split("&");
for(i in url)
{
    queries[url[i].split("=")[0]] = url[i].split("=")[1];
}

console.log(url);

var username = queries.username;
var title = queries.title;
var email = queries.email.replace("%40", "@");
var gender = queries.gender;
var address = queries.address;
var mobile = queries.mobile;


document.getElementById("welcome").innerHTML = "Welcome " + username + " " + title;

document.getElementById("display").innerHTML = 
    "<h3>your data is:</h3>" +
    "<div > your address is: " + address + "</div>" + 
    "<div> your email is: " + email + "</div>" +
    "<div> your mobile is: " + mobile + "</div>" +
    "<div> your gender is: " + gender + "</div>";  



var isChrome = /Chrome/.test(navigator.userAgent);

if(!isChrome)
{
    document.getElementById("chrome_message").innerText = "Chrome Browser is recommended";
}

