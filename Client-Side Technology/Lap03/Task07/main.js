var range1 = Number(prompt("Enter Range From: "));
var range2 = Number(prompt("To : "));

var question = prompt("What do you want to display? 'odd', 'even', 'no' ");
while (!(question == "no" || question == "odd" || question == "even")) {
  question = prompt("Choose only from these options: 'odd', 'even', 'no' ");
}

var sum = 0;
var index = 0;

var arr = [];

for (let i = range1; i <= range2; i++) {
  if (question == "no") {
    arr[index] = i;
    sum += i;
    index++;
  } else if (question == "even") {
    if (i % 2 == 0) {
      arr[index] = i;
      sum += i;
      index++;
    }
  } else if (question == "odd") {
    if (i % 2 != 0) {
      arr[index] = i;
      sum += i;
      index++;
    }
  }
}

console.log("Number Of Array Is: ", arr);
console.log("Sum = ", sum);
