// Get Cookie
function getCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string") {
    throw "getCookie needs a string parameter";
  }

  var cookies = document.cookie.split("; ");

  for (var i = 0; i < cookies.length; i++) {
    var parts = cookies[i].split("=");
    if (parts[0] == cookieName) {
      return decodeURIComponent(parts[1]);
    }
  }

  return null;
}

// Set Cookie
function setCookie(cookieName, cookieValue, expiryDate) {
  if (!cookieName || typeof cookieName !== "string") {
    throw "setCookie needs cookieName as string";
  }

  if (cookieValue == undefined) {
    throw "setCookie needs cookieValue";
  }

  var cookieString = cookieName + "=" + encodeURIComponent(cookieValue);

  if (expiryDate) {
    if (!(expiryDate instanceof Date)) {
      throw "expiryDate must be Date object";
    }

    cookieString += ";expires=" + expiryDate.toUTCString();
  }

  document.cookie = cookieString;
}

// Delete Cookie
function deleteCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string") {
    throw "deleteCookie needs string parameter";
  }

  var pastDate = new Date();
  pastDate.setDate(pastDate.getDate() - 1);

  document.cookie = cookieName + "=;expires=" + pastDate.toUTCString();
}

// All Cookies
function allCookieList() {
  if (document.cookie == "") {
    return [];
  }

  var cookies = document.cookie.split("; ");
  var names = [];

  for (var i = 0; i < cookies.length; i++) {
    var parts = cookies[i].split("=");
    names.push(parts[0]);
  }

  return names;
}

// Has Cookie
function hasCookie(cookieName) {
  if (!cookieName || typeof cookieName !== "string") {
    throw "hasCookie needs string parameter";
  }

  if (getCookie(cookieName) != null) {
    return true;
  }

  return false;
}

function registerUser() {
  var name = document.getElementById("username").value;
  var age = document.getElementById("age").value;
  var color = document.getElementById("color").value;

  var genderElements = document.getElementsByName("gender");
  var gender = null;

  for (var i = 0; i < genderElements.length; i++) {
    if (genderElements[i].checked) {
      gender = genderElements[i].value;
    }
  }

  if (name == "" || age == "" || gender == null) {
    alert("Please complete all fields");
    return;
  }

  var expiry = new Date();
  expiry.setDate(expiry.getDate() + 30);

  setCookie("username", name, expiry);
  setCookie("age", age, expiry);
  setCookie("color", color, expiry);
  setCookie("gender", gender, expiry);

  // Visit Counter
  if (hasCookie("visits")) {
    var visits = parseInt(getCookie("visits"));
    visits = visits + 1;

    setCookie("visits", visits, expiry);
  } else {
    setCookie("visits", 1, expiry);
  }

  location.replace("profile.html");
}

window.onload = function () {
  if (location.pathname.indexOf("profile.html") != -1) {
    var name = getCookie("username");
    var color = getCookie("color");
    var gender = getCookie("gender");
    
    var visits;

    if (hasCookie("visits")) {
      visits = parseInt(getCookie("visits"));
      visits++;
    } else {
      visits = 1;
    }

    var expiry = new Date();
    expiry.setDate(expiry.getDate() + 30);

    setCookie("visits", visits, expiry);

    document.getElementById("userName").innerHTML = name;
    document.getElementById("visitNumber").innerHTML = visits;

    document.getElementById("userName").style.color = color;
    document.getElementById("visitNumber").style.color = color;

    var img = document.getElementById("profilePic");

    if (gender == "male") {
      img.src = "images/1.jpg";
    } else {
      img.src = "images/2.jpg";
    }
  }
};
