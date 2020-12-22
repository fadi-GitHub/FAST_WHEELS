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
function checkPswd() {
    var newPass = document.getElementById("newPswd");
    var confirm = document.getElementById("cnfrm");

    if (newPass.value.length < 6 || newPass.value.length > 15) {
        alert("Enter 6 to 15 characters Password!");
        return false;
    }

    if (newPass.value != confirm.value) {
        alert("Password not matched!");
    }

}

function save(form,userPassword) {
   
    var uPass = userPassword.toString();
    var oldPassword = form.oldPassword.value;
    if (uPass != oldPassword) {
      
        alert("Unable to save Changes");
        return false;
    }
    else
    {
        alert("Password Changed");
        return true;
    }
}

function validationUC() {
    var ddl = document.getElementById("dummy_form");
    var selectedValue = ddl.options[ddl.selectedIndex].value;
    if (selectedValue == "select") {
        alert("Please select all options");
        return false;
    }
    return true;
}
