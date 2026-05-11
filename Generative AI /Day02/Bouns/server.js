const express = require("express");
const cors = require("cors");

const app = express();
const PORT = process.env.PORT || 3000;

app.use(cors());
app.use(express.json({ limit: "50mb" }));
app.use(express.urlencoded({ extended: true, limit: "50mb" }));

// Utility functions
function validateArray(arr) {
  if (!Array.isArray(arr)) return false;
  if (arr.length === 0) return false;
  if (arr.length > 100000) return false; // Prevent memory issues
  return arr.every(
    (item) => typeof item === "number" && !isNaN(item) && isFinite(item),
  );
}

function parseArrayParam(param) {
  try {
    const parsed = JSON.parse(param);
    return Array.isArray(parsed) ? parsed : null;
  } catch {
    return null;
  }
}

// Sorting algorithms
function bubbleSort(arr) {
  const result = [...arr];
  const n = result.length;
  let comparisons = 0;
  let swaps = 0;

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < n - i - 1; j++) {
      comparisons++;
      if (result[j] > result[j + 1]) {
        [result[j], result[j + 1]] = [result[j + 1], result[j]];
        swaps++;
      }
    }
  }

  return { result, comparisons, swaps };
}

function selectionSort(arr) {
  const result = [...arr];
  const n = result.length;
  let comparisons = 0;
  let swaps = 0;

  for (let i = 0; i < n; i++) {
    let minIdx = i;
    for (let j = i + 1; j < n; j++) {
      comparisons++;
      if (result[j] < result[minIdx]) {
        minIdx = j;
      }
    }
    if (minIdx !== i) {
      [result[i], result[minIdx]] = [result[minIdx], result[i]];
      swaps++;
    }
  }

  return { result, comparisons, swaps };
}

function insertionSort(arr) {
  const result = [...arr];
  const n = result.length;
  let comparisons = 0;
  let swaps = 0;

  for (let i = 1; i < n; i++) {
    const key = result[i];
    let j = i - 1;

    while (j >= 0 && result[j] > key) {
      comparisons++;
      result[j + 1] = result[j];
      swaps++;
      j--;
    }
    result[j + 1] = key;
  }

  return { result, comparisons, swaps };
}

function mergeSort(arr) {
  let comparisons = 0;
  let swaps = 0;

  function merge(left, right) {
    const result = [];
    let i = 0,
      j = 0;

    while (i < left.length && j < right.length) {
      comparisons++;
      if (left[i] < right[j]) {
        result.push(left[i++]);
      } else {
        result.push(right[j++]);
      }
      swaps++;
    }

    return [...result, ...left.slice(i), ...right.slice(j)];
  }

  function sort(arr) {
    if (arr.length <= 1) return arr;

    const mid = Math.floor(arr.length / 2);
    const left = sort(arr.slice(0, mid));
    const right = sort(arr.slice(mid));

    return merge(left, right);
  }

  const result = sort([...arr]);
  return { result, comparisons, swaps };
}

function quickSort(arr) {
  let comparisons = 0;
  let swaps = 0;

  function sort(arr, low = 0, high = arr.length - 1) {
    if (low < high) {
      const pivotIdx = partition(arr, low, high);
      sort(arr, low, pivotIdx - 1);
      sort(arr, pivotIdx + 1, high);
    }
  }

  function partition(arr, low, high) {
    const pivot = arr[high];
    let i = low - 1;

    for (let j = low; j < high; j++) {
      comparisons++;
      if (arr[j] < pivot) {
        i++;
        [arr[i], arr[j]] = [arr[j], arr[i]];
        swaps++;
      }
    }

    [arr[i + 1], arr[high]] = [arr[high], arr[i + 1]];
    swaps++;
    return i + 1;
  }

  const result = [...arr];
  sort(result);
  return { result, comparisons, swaps };
}

function heapSort(arr) {
  const result = [...arr];
  let comparisons = 0;
  let swaps = 0;

  function heapify(arr, n, i) {
    let largest = i;
    const left = 2 * i + 1;
    const right = 2 * i + 2;

    if (left < n) {
      comparisons++;
      if (arr[left] > arr[largest]) {
        largest = left;
      }
    }

    if (right < n) {
      comparisons++;
      if (arr[right] > arr[largest]) {
        largest = right;
      }
    }

    if (largest !== i) {
      [arr[i], arr[largest]] = [arr[largest], arr[i]];
      swaps++;
      heapify(arr, n, largest);
    }
  }

  // Build max heap
  for (let i = Math.floor(result.length / 2) - 1; i >= 0; i--) {
    heapify(result, result.length, i);
  }

  // Extract elements
  for (let i = result.length - 1; i > 0; i--) {
    [result[0], result[i]] = [result[i], result[0]];
    swaps++;
    heapify(result, i, 0);
  }

  return { result, comparisons, swaps };
}

function countingSort(arr) {
  const max = Math.max(...arr);
  const min = Math.min(...arr);
  const range = max - min + 1;

  const count = new Array(range).fill(0);
  const output = new Array(arr.length);

  // Count occurrences
  for (let i = 0; i < arr.length; i++) {
    count[arr[i] - min]++;
  }

  // Cumulative count
  for (let i = 1; i < range; i++) {
    count[i] += count[i - 1];
  }

  // Build output
  for (let i = arr.length - 1; i >= 0; i--) {
    const index = count[arr[i] - min] - 1;
    output[index] = arr[i];
    count[arr[i] - min]--;
  }

  return { result: output, comparisons: 0, swaps: arr.length };
}

function radixSort(arr) {
  const max = Math.max(...arr);
  let exp = 1;
  let result = [...arr];
  let totalComparisons = 0;
  let totalSwaps = 0;

  while (Math.floor(max / exp) > 0) {
    const sortResult = countingSortByDigit(result, exp);
    result = sortResult.result;
    totalComparisons += sortResult.comparisons;
    totalSwaps += sortResult.swaps;
    exp *= 10;
  }

  return { result, comparisons: totalComparisons, swaps: totalSwaps };
}

function countingSortByDigit(arr, exp) {
  const n = arr.length;
  const output = new Array(n);
  const count = new Array(10).fill(0);

  for (let i = 0; i < n; i++) {
    const digit = Math.floor(arr[i] / exp) % 10;
    count[digit]++;
  }

  for (let i = 1; i < 10; i++) {
    count[i] += count[i - 1];
  }

  for (let i = n - 1; i >= 0; i--) {
    const digit = Math.floor(arr[i] / exp) % 10;
    const index = count[digit] - 1;
    output[index] = arr[i];
    count[digit]--;
  }

  return { result: output, comparisons: 0, swaps: n };
}

// API Routes
app.get("/health", (req, res) => {
  res.json({
    status: "healthy",
    timestamp: new Date().toISOString(),
    version: "2.0.0",
  });
});

app.post("/sort", (req, res) => {
  try {
    const { array, algorithm = "quick" } = req.body;

    if (!validateArray(array)) {
      return res.status(400).json({
        error:
          "Invalid array. Must be an array of numbers with length 1-100000.",
      });
    }

    const startTime = process.hrtime.bigint();

    let sortResult;
    switch (algorithm.toLowerCase()) {
      case "bubble":
        sortResult = bubbleSort(array);
        break;
      case "selection":
        sortResult = selectionSort(array);
        break;
      case "insertion":
        sortResult = insertionSort(array);
        break;
      case "merge":
        sortResult = mergeSort(array);
        break;
      case "quick":
        sortResult = quickSort(array);
        break;
      case "heap":
        sortResult = heapSort(array);
        break;
      case "counting":
        sortResult = countingSort(array);
        break;
      case "radix":
        sortResult = radixSort(array);
        break;
      default:
        return res.status(400).json({
          error:
            "Unsupported algorithm. Supported: bubble, selection, insertion, merge, quick, heap, counting, radix",
        });
    }

    const endTime = process.hrtime.bigint();
    const executionTimeMs = Number(endTime - startTime) / 1000000;

    res.json({
      success: true,
      algorithm: algorithm.toLowerCase(),
      original: array,
      sorted: sortResult.result,
      statistics: {
        comparisons: sortResult.comparisons,
        swaps: sortResult.swaps,
        executionTimeMs: executionTimeMs.toFixed(3),
        arraySize: array.length,
      },
    });
  } catch (error) {
    console.error("Sort error:", error);
    res.status(500).json({
      error: "Internal server error during sorting",
    });
  }
});

// Legacy endpoint for backward compatibility
app.post("/quicksort", (req, res) => {
  req.body.algorithm = "quick";
  return app._router.handle(req, res);
});

// GET endpoint for simple sorting
app.get("/sort/:array", (req, res) => {
  try {
    const array = parseArrayParam(req.params.array);
    const algorithm = req.query.algorithm || "quick";

    if (!array || !validateArray(array)) {
      return res.status(400).json({
        error: "Invalid array format. Use JSON array syntax.",
      });
    }

    req.body = { array, algorithm };
    return app._router.handle(req, res);
  } catch (error) {
    res.status(400).json({
      error: "Invalid request format",
    });
  }
});

// Error handling middleware
app.use((error, req, res, next) => {
  console.error("Unhandled error:", error);
  res.status(500).json({
    error: "Internal server error",
  });
});

// 404 handler
app.use((req, res) => {
  res.status(404).json({
    error: "Endpoint not found",
  });
});

app.listen(PORT, () => {
  console.log(`🚀 Sorting API server running on port ${PORT}`);
  console.log(`📊 Health check: http://localhost:${PORT}/health`);
  console.log(`🔀 Sort endpoint: POST http://localhost:${PORT}/sort`);
});
