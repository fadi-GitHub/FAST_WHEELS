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
    var dd1 = document.getElementById("Make").value;
    var dd2 = document.getElementById("Model").value;
    var dd3 = document.getElementById("Price").value;
    var dd4 = document.getElementById("City").value;
    //var selectedValue1 = dd1.options[ddl.selectedIndex].value;
    //var selectedValue2= dd2.options[dd2.selectedIndex].value;
    //var selectedValue3 = dd3.options[dd3.selectedIndex].value;
    //var selectedValue4 = dd4.options[dd4.selectedIndex].value;
    if (dd1 == "select" || dd2 == "select" || dd3 == "select" ||dd4 == "select") {
        alert("Please select all options");
        return false;
    }
    return true;
}

function validationNC() {
    var dd1 = document.getElementById("Make").value;
    var dd2 = document.getElementById("Model").value;
    var dd3 = document.getElementById("Price").value;
    if (dd1 == "select" || dd2 == "select" || dd3 == "select") {
        alert("Please select all options");
        return false;
    }
    return true;
}
function validationAS() {
    var dd1 = document.getElementById("Make").value;
    var dd2 = document.getElementById("Name").value;
    var dd3 = document.getElementById("itemName").value;
    if (dd1 == "select" || dd2 == "select" || dd3 == "select") {
        alert("Please select all options");
        return false;
    }
    return true;
}

function postAddValidation() {
    var phone_no = document.getElementById("mobileno").value;
    var phone_no_regex = /^[0-9+]{11}$/;

    if (phone_no_regex.test(phone_no)) {
        return true;
    }
    else {
        alert('Wrong Phone number entered');
        return false;

    }
    return true;
}
function signUpValidation() {
    var cnic_no = document.getElementById("cnic").value;
    var cnic_no_regex = /^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$/;

    if (cnic_no_regex.test(cnic_no)) {
        return true;
    }
    else {
        alert('Wrong CNIC number entered');
        return false;

    }
    return true;
}
