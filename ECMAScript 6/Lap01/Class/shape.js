export default class Shape {
  #dim1;
  #dim2;
  constructor(dim1, dim2) {
    if (this.constructor === Shape) {
      throw Error("Cannot create instance of abstract class");
    }
    this.#dim1 = dim1;
    this.#dim2 = dim2;
  }

  set dim1(value) {
    this.#dim1 = value;
  }
  get dim1() {
    return this.#dim1;
  }

  set dim2(value) {
    this.#dim2 = value;
  }
  get dim2() {
    return this.#dim2;
  }

  area() {}

  perimeter() {}

  toString() {
    return `Area: ${this.area()} , Perimeter: ${this.perimeter()}`;
  }
}
