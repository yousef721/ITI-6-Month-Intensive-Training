var p = document.querySelector("p");
var text = p.textContent;
var i = 0;

p.textContent = "";

var intervalId = setInterval(function () {
  p.textContent += text.charAt(i);
  i++;

  if (i === text.length) {
    clearInterval(intervalId);
  }
}, 100);

// innerText Ignore Spaces 

// var p = document.querySelector("p");
// var text = p.innerText;
// var i = 0;

// p.innerText = "";

// var timer = setInterval(function () {
//   p.innerText += text.charAt(i);
//   i++;

//   if (i === text.length) {
//     clearInterval(timer);
//   }
// }, 100);
