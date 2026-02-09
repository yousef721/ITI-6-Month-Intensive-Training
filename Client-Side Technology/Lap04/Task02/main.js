var text = prompt("Enter a string:");

var caseSensitive = confirm(
  "Do you want to consider letter case?\nOK = Yes (Case Sensitive)\nCancel = No (Ignore Case)",
);

if (!caseSensitive) {
  text = text.toLowerCase();
}

var reversed = text.split("").reverse();
var temp = text.split("");
var isPalindrome = true;

for (let index = 0; index < temp.length; index++) {
  if (reversed[index] !== temp[index]) {
    isPalindrome = false;
    break;
  }
}

// Check palindrome
if (isPalindrome) {
  alert("The entered string is a PALINDROME.");
} else {
  alert("The entered string is NOT a PALINDROME.");
}
