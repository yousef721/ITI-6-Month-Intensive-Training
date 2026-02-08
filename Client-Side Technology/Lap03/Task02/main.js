var num;
var sum = 0;
var innerContent;

do {
  num = Number(prompt("Enter Number: "));

  while (isNaN(num)) {
    num = Number(prompt("Enter Valid Number: "));
  }

  if (num == 0) {
    break;
  }

  sum += num;
} while (sum <= 100);

if (sum > 100) {
  innerContent = "The Total Exceeds 100";
} else {
  innerContent = "Stop Receiving Values";
}

document.writeln(
  `<div style='color: red; text-align: center; padding: 10px; border: 2px solid #ddd'><h1 >${innerContent} <span style='color: black; text-decoration: underline; display: block'>SUM = ${sum}</span></h1></div>`,
);

// Entered values in console.
console.log(sum);
