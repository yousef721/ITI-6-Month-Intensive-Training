var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
console.log("========================Enum========================");
//#region Task Enum
var Direction;
(function (Direction) {
    Direction[Direction["Up"] = 1] = "Up";
    Direction[Direction["Right"] = 2] = "Right";
    Direction[Direction["Down"] = 6] = "Down";
    Direction[Direction["Left"] = 7] = "Left";
})(Direction || (Direction = {}));
console.log("Up:", Direction.Up); // 1
console.log("Right:", Direction.Right); // 2
console.log("Down:", Direction.Down); // 6
console.log("Left:", Direction.Left); // 7
//#endregion
console.log("========================Generics========================");
//#region Task Generics
class GenericsData {
    constructor(d) {
        this.data = d;
    }
    getFirst() {
        return this.data[0];
    }
}
let NumberData = new GenericsData([1, 2, 3, 4]);
let StringData = new GenericsData(["A", "b", "c", "d"]);
console.log("Number Data:", NumberData.data);
console.log("First Number:", NumberData.getFirst());
console.log("String Data:", StringData.data);
console.log("First String:", StringData.getFirst());
//#endregion
console.log("========================Modules========================");
//#region Task Modules
import sum from "./sum.js";
let res = sum(10, 20);
console.log("Sum Result:", res);
//#endregion
console.log("========================Decorator========================");
//#region Task Decorator
function Logger(constructor) {
    console.log("Class created:", constructor.name);
}
let Person = class Person {
    constructor() {
        this.name = "Yousef";
    }
};
Person = __decorate([
    Logger
], Person);
let p = new Person();
console.log("Person Instance:", p);
console.log("Person Name:", p.name);
//#endregion
