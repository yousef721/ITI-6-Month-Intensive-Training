var range1 = Number(prompt("Enter Range From: "));
var range2 = Number(prompt("To : "));
var sum = 0;
var indexArr1 = 0;
var indexArr2 = 0;

var arr1 = [];
var arr2 = [];

for (let i = range1; i <= range2; i++) {
  // When a number is divisible by both 3 and 5, it is added to both matrices, 
  if (i % 3 == 0 && i % 5 == 0) { 
    // it is added to both array
    arr1[indexArr1] = i;
    arr2[indexArr2] = i;
    // but one of them is added to the total number.
    sum += i;
    indexArr1++;
    indexArr2++;
  } else if (i % 3 == 0) {
    arr1[indexArr1] = i;
    sum += i;
    indexArr1++;
  } else if (i % 5 == 0) {
    arr2[indexArr2] = i;
    sum += i;
    indexArr2++;
  }
}

console.log("Number multiple of 3:", arr1);
console.log("Number multiple of 5:", arr2);
console.log("Total Sum = ", sum);
