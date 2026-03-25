//#region Task Enum
enum Direction {
  Up = 1,
  Right = 2,
  Down = 6,
  Left,
}

console.log("Enum Values:");
console.log("Up:", Direction.Up); // 1
console.log("Right:", Direction.Right); // 2
console.log("Down:", Direction.Down); // 6
console.log("Left:", Direction.Left); // 7
//#endregion
console.log("===================================================");
//#region Task Generics
class GenericsData<T> {
  data: T[];

  constructor(d: T[]) {
    this.data = d;
  }
  getFirst(): T {
    return this.data[0];
  }
}
let NumberData = new GenericsData<number>([1, 2, 3, 4]);
let StringData = new GenericsData<string>(["A", "b", "c", "d"]);

console.log("Generics:");
console.log("Number Data:", NumberData.data);
console.log("First Number:", NumberData.getFirst());

console.log("String Data:", StringData.data);
console.log("First String:", StringData.getFirst());
//#endregion
console.log("===================================================");
//#region Task Modules
import sum from "./sum.js";

console.log("Modules:");
let res = sum(10, 20);
console.log("Sum Result:", res); // 30
//#endregion
console.log("===================================================");
//#region Task Decorator
function Logger(constructor: Function) {
  console.log("Decorator:");
  console.log("Class created:", constructor.name);
}

@Logger
class Person {
  name = "Yousef";
}

let p = new Person();
console.log("Person Instance:", p);
console.log("Person Name:", p.name);
//#endregion
