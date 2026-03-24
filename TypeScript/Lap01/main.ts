//#region Task 1
// Types
let num1: number = 10;
let str: string = "Yousef";
let arrNumbers: number[] = [10, 20, 30];
let arrString: string[] = ["Yousef", "Mohamed"];
let bool: boolean = true;
let nll: null = null;
let undef: undefined = undefined;

interface MyObj {
  num1: number;
  str: string;
  arr: number[];
}

let obj: MyObj = {
  num1: 10,
  str: "String",
  arr: [1, 2, 3],
};

// Union types
let idOrUserName: number | string;
idOrUserName = 555;
console.log("idOrUserName:", idOrUserName);

idOrUserName = "Yousef";
console.log("idOrUserName:", idOrUserName);

let arrStringOrNumbers: number[] | string[];
arrStringOrNumbers = [1, 2, 3, 4];
console.log("arrStringOrNumbers:", arrStringOrNumbers);

arrStringOrNumbers = ["A", "B", "C", "D"];
console.log("arrStringOrNumbers:", arrStringOrNumbers);

let arrStringAndNumbers: (number | string)[] = [1, 2, 3, 4, "A", "B", "C", "D"];
console.log("arrStringAndNumbers:", arrStringAndNumbers);

// Functions
function sayHello(): void {
  console.log("Hello World");
}

function add(x: number, y: number): number {
  return x + y;
}

function concat(a: string, b: string): string {
  return a + b;
}

function isEqual(a: string, b: string): boolean {
  return a === b;
}

function printId(id: number | string): void {
  console.log("ID:", id);
}

function greet(name: string, age?: number): string {
  return age ? `Hello ${name}, Age: ${age}` : `Hello ${name}`;
}

// Run
console.log("num1:", num1);
console.log("str:", str);
console.log("arrNumbers:", arrNumbers);
console.log("arrString:", arrString);
console.log("bool:", bool);
console.log("nll:", nll);
console.log("undef:", undef);
console.log("obj:", obj);

sayHello();

console.log("add:", add(5, 3));
console.log("concat:", concat("Hello ", "World"));
console.log("isEqual:", isEqual("A", "A"));

printId(100);
printId("ABC");

console.log("greet:", greet("Yousef"));
console.log("greet with age:", greet("Yousef", 22));

//#endregion
console.log("==================================");
//#region Task 2
class Point2D {
  constructor(
    private x: number,
    private y: number,
  ) {}

  // Getter
  get getX(): number {
    return this.x;
  }

  get getY(): number {
    return this.y;
  }

  // Setter
  set setX(value: number) {
    this.x = value;
  }

  set setY(value: number) {
    this.y = value;
  }
  lengthBetween(p: Point2D): number {
    const dx = p.x - this.x;
    const dy = p.y - this.y;
    return Math.sqrt(dx * dx + dy * dy);
  }
}
class Point3D extends Point2D {
  constructor(
    x: number,
    y: number,
    private z: number,
  ) {
    super(x, y);
  }

  // Getter
  get getZ(): number {
    return this.z;
  }

  // Setter
  set setZ(value: number) {
    this.z = value;
  }

  lengthBetween(p: Point3D): number {
    const dx = p.getX - this.getX;
    const dy = p.getY - this.getY;
    const dz = p.z - this.z;
    return Math.sqrt(dx * dx + dy * dy + dz * dz);
  }
}

// Run
const p1 = new Point2D(0, 0);
const p2 = new Point2D(3, 4);

console.log("2D Distance:", p1.lengthBetween(p2)); // 5

const p3 = new Point3D(0, 0, 0);
const p4 = new Point3D(1, 2, 2);

console.log("3D Distance:", p3.lengthBetween(p4)); // 3
//#endregion
