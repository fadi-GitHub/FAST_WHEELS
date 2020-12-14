// JavaScript Document
	
function postAd()
{
	window.open("sellCar.html");
}

function loginCondition()
{
	//@Html.ActionLink("Used Car", "UsedCar", "Home");
	alert("You must Login First!");
}

var attempt = 3; // Variable to count number of attempts.
// Below function Executes on click of login button.
function login_validate() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    if (username == "Formget" && password == "formget#123") {
        alert("Login successfully");
        window.location = "success.html"; // Redirecting to other page.
        return false;
    }
    else {
        attempt--;// Decrementing by one.
        alert("You have left " + attempt + " attempt;");
        // Disabling fields after 3 attempts.
        if (attempt == 0) {
            document.getElementById("username").disabled = true;
            document.getElementById("password").disabled = true;
            document.getElementById("submit").disabled = true;
            return false;
        }
    }
}

function contact()
{
	window.open("http://www.gmail.com");
}

function openHome()
{
	window.open("home.html","_self");
}
function register() {

	alert("Login Successfull");
}
function func() {

    console.log("hello");
}
function pictureURL() {
	var img = document.getElementById("upload");

}