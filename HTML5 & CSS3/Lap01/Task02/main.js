var rgbCard = document.getElementById("rgb-card");
var red = document.getElementById("red");
var green = document.getElementById("green");
var blue = document.getElementById("blue");
var text = document.getElementById("text");

rgbCard.addEventListener("input", function () {
  text.style.color = `rgb(${red.value}, ${green.value}, ${blue.value})`;
});
