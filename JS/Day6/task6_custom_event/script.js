var username = document.getElementById("username");
var address = document.getElementById("address");
var email = document.getElementById("email");
var submit = document.getElementById("submit");
var form = document.getElementById("myForm");

var timeout_event = new Event("timeout");

form.addEventListener("timeout", function () {
        alert("Time Out! You havn't written anything, please reload!");
        username.disabled = true;
        email.disabled = true;
        address.disabled = true;
        submit.disabled = true;
})

setTimeout(function () {
    if (username.value === "" && email.value =="" && address.value == ""){
        document.getElementById("myForm").dispatchEvent(timeout_event);
    }
}, 30000);


form.addEventListener("submit", function (e) {
  var confirmed = confirm("Are you sure you want to submit?");
  if (!confirmed) {
      e.preventDefault();
  }
});