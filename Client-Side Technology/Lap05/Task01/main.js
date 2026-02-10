let n;
do {
  n = Number(prompt("Enter Number Of Array"));
} while (isNaN(n));

let value;
let i = 1;
let arr = [];

while (i <= n) {
  let value = Number(prompt(`Enter Value #${i}`));
  if (!isNaN(value)) {
    arr.push(value);
    i++;
  }
}

arr.sort((a, b) => a - b); // result --> negative second is biggest, positive first is biggest, 0 are equal

console.log("Ascending : ", arr);
console.log("Descending : ", arr.reverse());
