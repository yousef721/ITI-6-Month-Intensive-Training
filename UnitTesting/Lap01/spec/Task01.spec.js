const {
  capitalizeTextFirstChar,
  createArray,
  random,
} = require("../Task01");

describe("Test capitalizeTextFirstChar", () => {
  it("should return string type", () => {
    expect(capitalizeTextFirstChar("hello world")).toEqual(jasmine.any(String));
  });

  it("should capitalize first character of each word", () => {
    expect(capitalizeTextFirstChar("i'm ahmed ali")).toBe("I'm Ahmed Ali");
  });

  it("should throw TypeError when parameter is number", () => {
    expect(() => {
      capitalizeTextFirstChar(10);
    }).toThrowError(TypeError, "parameters should be string");
  });
});

describe("Test createArray", () => {
  it("should return array", () => {
    expect(createArray(3)).toEqual(jasmine.any(Array));
  });

  it("should return array of length 2 and include 1", () => {
    const arr = createArray(2);

    expect(arr.length).toBe(2);
    expect(arr).toContain(1);
  });

  it("should return array of length 3 and not include 3", () => {
    const arr = createArray(3);

    expect(arr.length).toBe(3);
    expect(arr).not.toContain(3);
  });
});

describe("Test random", () => {
  it("should return number", () => {
    expect(typeof random(1, 5)).toBe("number");
  });

  it("should return value between 5 and 7", () => {
    const result = random(5, 7);

    expect(result).toBeGreaterThanOrEqual(5);
    expect(result).toBeLessThanOrEqual(7);
  });

  it("should return NaN when one parameter is passed", () => {
    expect(random(5)).toBeNaN();
  });
});