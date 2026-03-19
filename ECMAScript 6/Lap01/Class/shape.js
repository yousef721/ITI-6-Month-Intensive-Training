export default class Shape {
  dim1;
  dim2;
  constructor(dim1, dim2) {
    if (this.constructor === Shape) {
      throw Error("Cannot create instance of abstract class");
    }
    this.dim1 = dim1;
    this.dim2 = dim2;
  }

  area() {}

  perimeter() {}

  toString() {
    return `Area: ${this.area().toFixed(2)} , Perimeter: ${this.perimeter().toFixed(2)}`;
  }
}
