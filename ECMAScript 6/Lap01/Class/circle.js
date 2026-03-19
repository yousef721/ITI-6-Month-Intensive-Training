import  Shape  from "./shape.js";

export default class Circle extends Shape {
  constructor(radius) {
    super(radius, radius);
  }

  area() {
    return Math.PI * this.dim1 * this.dim1; // πr²
  }

  perimeter() {
    return 2 * Math.PI * this.dim1; // 2πr
  }
}
