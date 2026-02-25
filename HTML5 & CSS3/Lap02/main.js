function setToLocalStorage() {
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

  localStorage.setItem("username", name);
  localStorage.setItem("age", age);
  localStorage.setItem("color", color);
  localStorage.setItem("gender", gender);

  // Visit Counter
  if (localStorage.getItem("visits") == null) {
    localStorage.setItem("visits", 1);
  }

  location.assign("profile.html");
}

window.onload = function () {
  if (location.pathname.indexOf("profile.html") != -1) {
    var name = localStorage.getItem("username");
    var color = localStorage.getItem("color");
    var gender = localStorage.getItem("gender");

    var visits = localStorage.getItem("visits");

    if (visits == null) {
      visits = 1;
    } else {
      visits = parseInt(visits) + 1;
    }

    localStorage.setItem("visits", visits);

    document.getElementById("userName").textContent = name;
    document.getElementById("visitNumber").textContent = visits;

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
