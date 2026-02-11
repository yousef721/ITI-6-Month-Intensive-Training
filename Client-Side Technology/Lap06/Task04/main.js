// Recommend Browser
if (window.navigator.userAgent.includes("Chrome")) {
  alert("Good Browser");
} else {
  alert("Recommend opening in Google Chrome");
}

var href = window.location.search
  .replaceAll("%2C", ",")
  .replaceAll("+", " ")
  .replaceAll("%", "@")
  .replace("?", "");

/*
  name=Yousef&
  email=Yousef@40gmail.com&
  password=Yousef1234&
  job=Front End&
  mobile=012345678&
  gender=male&
  address=Cairo, Obour City, El-maged, ABCst, 189, 13b
*/

var arrInfo = href.split("&");

var objInfo = {
  uName: arrInfo[0].replace("name=", ""),
  email: arrInfo[1].replace("email=", ""),
  password: arrInfo[2].replace("password=", ""),
  job: arrInfo[3].replace("job=", ""),
  mobile: arrInfo[4].replace("mobile=", ""),
  gender: arrInfo[5].replace("gender=", ""),
  address: arrInfo[6].replace("address=", ""),
};

document.getElementById("name").innerText = objInfo.uName;
document.getElementById("email").innerText = objInfo.email;
document.getElementById("password").innerText = objInfo.password;
document.getElementById("job").innerText = objInfo.job;
document.getElementById("mobile").innerText = objInfo.mobile;
document.getElementById("gender").innerText = objInfo.gender;
document.getElementById("address").innerText = objInfo.address;

let image = document.querySelector("img");

if (objInfo.gender == "male") {
  image.src = "./images/man.png";
} else {
  image.src = "./images/woman.png";
}

document.querySelector("#welcome").textContent += ` ${objInfo.uName}`;
