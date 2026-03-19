import Shape from "./shape.js";

export default class Square extends Shape {
  constructor(side) {
    super(side, side);
  }

  area() {
    return this.dim1 * this.dim1; // s * s
  }

  perimeter() {
    return 4 * this.dim1; // 4 * s
  }

}
