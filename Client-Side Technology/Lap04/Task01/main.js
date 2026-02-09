var text = prompt("Enter a string:");
var char = prompt("Enter the character to count:");

var caseSensitive = confirm(
  "Do you want to consider letter case?\nOK = Yes (Case Sensitive)\nCancel = No (Ignore Case Sensitive)",
);

var flags = caseSensitive ? "g" : "gi";

var regex = new RegExp(char, flags);

// Match and count
var matches = text.match(regex); // match --> returns an array of matches [a,A,a]
console.log(matches);
var count = matches ? matches.length : 0;

alert("The character '" + char + "' appears " + count + " times.");
