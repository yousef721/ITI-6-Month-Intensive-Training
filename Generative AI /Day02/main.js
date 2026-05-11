/**
 * In-place recursive QuickSort with median-of-three pivot selection
 * and an insertion sort cutoff for small partitions.
 * @param {number[]} input - Array to sort
 * @returns {number[]} Sorted array
 */
function quickSortRecursive(input) {
  if (!Array.isArray(input)) {
    throw new Error("Input must be an array");
  }

  const arr = [...input];
  const CUTOFF = 16;

  const swap = (i, j) => {
    const temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
  };

  const insertionSort = (left, right) => {
    for (let i = left + 1; i <= right; i++) {
      const value = arr[i];
      let j = i - 1;
      while (j >= left && arr[j] > value) {
        arr[j + 1] = arr[j];
        j -= 1;
      }
      arr[j + 1] = value;
    }
  };

  const choosePivot = (left, right) => {
    const mid = left + ((right - left) >> 1);
    if (arr[left] > arr[mid]) swap(left, mid);
    if (arr[left] > arr[right]) swap(left, right);
    if (arr[mid] > arr[right]) swap(mid, right);
    swap(mid, right - 1);
    return arr[right - 1];
  };

  const partition = (left, right, pivot) => {
    let i = left;
    let j = right - 1;

    while (true) {
      while (arr[++i] < pivot) {}
      while (arr[--j] > pivot) {}
      if (i >= j) break;
      swap(i, j);
    }

    swap(i, right - 1);
    return i;
  };

  const sortRange = (left, right) => {
    if (right - left + 1 <= CUTOFF) {
      insertionSort(left, right);
      return;
    }

    const pivot = choosePivot(left, right);
    const partitionIndex = partition(left, right, pivot);

    // Recursively sort the smaller partition first to reduce call stack depth.
    if (partitionIndex - left < right - partitionIndex) {
      sortRange(left, partitionIndex - 1);
      sortRange(partitionIndex + 1, right);
    } else {
      sortRange(partitionIndex + 1, right);
      sortRange(left, partitionIndex - 1);
    }
  };

  if (arr.length > 1) {
    sortRange(0, arr.length - 1);
  }

  return arr;
}

/**
 * Iterative QuickSort using an explicit stack instead of recursion.
 * This version is useful for very large arrays or environments with restricted call stack depth.
 * @param {number[]} input - Array to sort
 * @returns {number[]} Sorted array
 */
function quickSortIterative(input) {
  if (!Array.isArray(input)) {
    throw new Error("Input must be an array");
  }

  const arr = [...input];
  const CUTOFF = 16;

  const swap = (i, j) => {
    const temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
  };

  const insertionSort = (left, right) => {
    for (let i = left + 1; i <= right; i++) {
      const value = arr[i];
      let j = i - 1;
      while (j >= left && arr[j] > value) {
        arr[j + 1] = arr[j];
        j -= 1;
      }
      arr[j + 1] = value;
    }
  };

  const choosePivot = (left, right) => {
    const mid = left + ((right - left) >> 1);
    if (arr[left] > arr[mid]) swap(left, mid);
    if (arr[left] > arr[right]) swap(left, right);
    if (arr[mid] > arr[right]) swap(mid, right);
    swap(mid, right - 1);
    return arr[right - 1];
  };

  const partition = (left, right, pivot) => {
    let i = left;
    let j = right - 1;

    while (true) {
      while (arr[++i] < pivot) {}
      while (arr[--j] > pivot) {}
      if (i >= j) break;
      swap(i, j);
    }

    swap(i, right - 1);
    return i;
  };

  const stack = [[0, arr.length - 1]];

  while (stack.length > 0) {
    const [left, right] = stack.pop();
    if (left >= right) continue;

    if (right - left + 1 <= CUTOFF) {
      insertionSort(left, right);
      continue;
    }

    const pivot = choosePivot(left, right);
    const partitionIndex = partition(left, right, pivot);

    // Push larger partition first so smaller partition is processed next
    // and stack depth stays low.
    if (partitionIndex - 1 - left > right - (partitionIndex + 1)) {
      stack.push([left, partitionIndex - 1]);
      stack.push([partitionIndex + 1, right]);
    } else {
      stack.push([partitionIndex + 1, right]);
      stack.push([left, partitionIndex - 1]);
    }
  }

  return arr;
}

/**
 * Compare the results of recursive and iterative QuickSort implementations.
 */
function compareQuickSorts(input) {
  const recursiveResult = quickSortRecursive(input);
  const iterativeResult = quickSortIterative(input);

  console.log("Original:", input);
  console.log("Recursive result:", recursiveResult);
  console.log("Iterative result:", iterativeResult);
  console.log(
    "Same output:",
    JSON.stringify(recursiveResult) === JSON.stringify(iterativeResult),
  );
}

const arr = [3, 6, 8, 10, 1, 2, 1];
compareQuickSorts(arr);

module.exports = {
  quickSortRecursive,
  quickSortIterative,
};
compareQuickSorts(arr);
