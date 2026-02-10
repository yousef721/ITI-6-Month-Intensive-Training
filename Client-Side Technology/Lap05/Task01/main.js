let n;
// Validation Set Only Number
do {
  n = Number(prompt("Enter Number Of Array"));
} while (isNaN(n));

let value;
let i = 1; // index
let arr = [];

while (i <= n) {
  let value = Number(prompt(`Enter Value #${i}`));
  // Validation Set Only Number
  if (!isNaN(value)) {
    arr.push(value); // storage in array
    i++;
  }
}

arr.sort((a, b) => a - b); // result --> negative second is biggest, positive first is biggest, 0 are equal

console.log("Ascending : ", arr);
console.log("Descending : ", arr.reverse());
