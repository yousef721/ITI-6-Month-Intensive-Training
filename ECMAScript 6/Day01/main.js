// #region Task 1
// 1
function swap(a, b) {
  return [b, a];
}

var [a, b] = swap(10, 20);

console.log(a);
console.log(b);
// 2
var a = 10;
var b = 20;

[a, b] = [b, a];

console.log(a);
console.log(b);
// #endregion

//#region Task 2
import { Rectangle } from "./rectangle.js";
import { Square } from "./square.js";
import { Circle } from "./circle.js";

let r = new Rectangle(10, 5);
let s = new Square(4);
let c = new Circle(3);

console.log(r.toString());
console.log(s.toString());
console.log(c.toString());
//#endregion
