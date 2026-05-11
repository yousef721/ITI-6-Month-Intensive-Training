const { quickSortRecursive, quickSortIterative } = require("./main");

const expectSorted = (sortFn, input) => {
  const expected = [...input].sort((a, b) => a - b);
  expect(sortFn(input)).toEqual(expected);
};

describe("QuickSort implementations", () => {
  const implementations = [
    { name: "recursive", fn: quickSortRecursive },
    { name: "iterative", fn: quickSortIterative },
  ];

  implementations.forEach(({ name, fn }) => {
    describe(name, () => {
      test("sorts an empty array", () => {
        expect(fn([])).toEqual([]);
      });

      test("sorts an already sorted array", () => {
        expect(fn([1, 2, 3, 4, 5])).toEqual([1, 2, 3, 4, 5]);
      });

      test("sorts a reverse-sorted array", () => {
        expect(fn([5, 4, 3, 2, 1])).toEqual([1, 2, 3, 4, 5]);
      });

      test("sorts an array with duplicates", () => {
        expect(fn([3, 1, 2, 3, 1, 2])).toEqual([1, 1, 2, 2, 3, 3]);
      });

      test("sorts a mixed array with negative and positive values", () => {
        expectSorted(fn, [7, -2, 4, 0, -2, 9, 1]);
      });

      test("sorts a large random dataset", () => {
        const large = Array.from({ length: 10000 }, () =>
          Math.floor(Math.random() * 10000),
        );
        expectSorted(fn, large);
      });

      test("sorts a large already sorted dataset", () => {
        const largeSorted = Array.from({ length: 5000 }, (_, i) => i);
        expect(fn(largeSorted)).toEqual(largeSorted);
      });
    });
  });
});
