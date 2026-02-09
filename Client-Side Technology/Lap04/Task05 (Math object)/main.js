// 1) Calculate area of a circle
var radius = Number(prompt("Enter the radius of the circle:"));

var circleArea = Math.PI * Math.pow(radius, 2); // πr2

alert("Circle Area = " + circleArea);

// ===================================================================================

// 2) Calculate square root
  var number = Number(prompt("Enter a number to calculate its square root:"));

  var squareRoot = Math.sqrt(number);

  alert("Square Root = " + squareRoot);

// ===================================================================================

// 3) Calculate cosine of an angle
var angle = Number(prompt("Enter an angle in degrees to calculate cos value:"));

var radians = angle * (Math.PI / 180); // convert to radians --> (π/180) * degree
var cosValue = Math.cos(radians);

alert("Cos(" + angle + ") = " + cosValue);
