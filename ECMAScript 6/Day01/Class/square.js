import Shape from "./shape.js";

export default class Square extends Shape {
  constructor(side) {
    super(side, side);
  }

  area() {
    return this.dim1 * this.dim1;
  }

  perimeter() {
    return 4 * this.dim1;
  }

  toString() {
    return `Square -> Area: ${this.area()} , Perimeter: ${this.perimeter()}`;
  }
}
