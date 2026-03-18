import Shape from "./shape.js";

export default class Rectangle extends Shape {
  constructor(dim1, dim2) {
    super(dim1, dim2);
  }

  area() {
    return this.dim1 * this.dim2;
  }

  perimeter() {
    return 2 * (this.dim1 + this.dim2);
  }

  toString() {
    return `Rectangle -> Area: ${this.area()} , Perimeter: ${this.perimeter()}`;
  }
}
