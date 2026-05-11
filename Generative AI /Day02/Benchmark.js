const { quickSortRecursive, quickSortIterative } = require("./main");

/**
 * Benchmark configuration
 */
const ITERATIONS = {
  small: 1000,
  medium: 100,
  large: 10,
};

const DATASET_SIZES = [100, 1000, 10000, 100000];

/**
 * Generate test datasets with different patterns
 */
const generateDataset = (size, pattern = "random") => {
  const data = [];

  switch (pattern) {
    case "random":
      for (let i = 0; i < size; i++) {
        data.push(Math.floor(Math.random() * 100000));
      }
      break;

    case "sorted":
      for (let i = 0; i < size; i++) {
        data.push(i);
      }
      break;

    case "reverse":
      for (let i = size - 1; i >= 0; i--) {
        data.push(i);
      }
      break;

    case "duplicates":
      for (let i = 0; i < size; i++) {
        data.push(Math.floor(Math.random() * 10));
      }
      break;

    default:
      throw new Error(`Unknown pattern: ${pattern}`);
  }

  return data;
};

/**
 * High-precision timing function
 */
const measureTime = (fn, iterations = 1) => {
  const start = process.hrtime.bigint();

  for (let i = 0; i < iterations; i++) {
    fn();
  }

  const end = process.hrtime.bigint();
  const nanoseconds = end - start;
  const milliseconds = Number(nanoseconds) / 1000000;

  return {
    nanoseconds,
    milliseconds,
    microseconds: Number(nanoseconds) / 1000,
  };
};

/**
 * Benchmark a sorting function
 */
const benchmarkSort = (name, sortFn, dataset, iterations) => {
  const dataCopy = [...dataset];

  const result = measureTime(() => {
    sortFn(dataCopy);
  }, iterations);

  return {
    name,
    iterations,
    avgMs: result.milliseconds / iterations,
    totalMs: result.milliseconds,
    opsPerSec: (iterations * 1000) / result.milliseconds,
  };
};

/**
 * Format benchmark results for display
 */
const formatResults = (results, dataSize, pattern) => {
  console.log(`\n${"=".repeat(80)}`);
  console.log(
    `Dataset: ${dataSize} elements | Pattern: ${pattern.toUpperCase()}`,
  );
  console.log(`${"=".repeat(80)}`);
  console.log(
    `${"Algorithm".padEnd(30)} ${"Avg Time (ms)".padEnd(18)} ${"Ops/Sec".padEnd(15)} ${"Total Time (ms)".padEnd(15)}`,
  );
  console.log(`${"-".repeat(80)}`);

  results.forEach((result) => {
    const avgTime = result.avgMs.toFixed(6);
    const opsPerSec = result.opsPerSec.toFixed(0);
    const totalTime = result.totalMs.toFixed(2);

    console.log(
      `${result.name.padEnd(30)} ${avgTime.padStart(17)} ${opsPerSec.padStart(14)} ${totalTime.padStart(14)}`,
    );
  });
};

/**
 * Run comprehensive benchmark suite
 */
const runBenchmarks = () => {
  console.log(
    "\n╔════════════════════════════════════════════════════════════════════════════╗",
  );
  console.log(
    "║                    QuickSort Performance Benchmark                         ║",
  );
  console.log(
    "╚════════════════════════════════════════════════════════════════════════════╝\n",
  );

  const patterns = ["random", "sorted", "reverse", "duplicates"];

  for (const size of DATASET_SIZES) {
    console.log(`\n${"█".repeat(80)}`);
    console.log(`TESTING DATASET SIZE: ${size} elements`);
    console.log(`${"█".repeat(80)}`);

    for (const pattern of patterns) {
      const dataset = generateDataset(size, pattern);
      const iterations =
        size <= 1000
          ? ITERATIONS.small
          : size <= 10000
            ? ITERATIONS.medium
            : ITERATIONS.large;

      const results = [
        benchmarkSort(
          "QuickSort (Recursive)",
          quickSortRecursive,
          dataset,
          iterations,
        ),
        benchmarkSort(
          "QuickSort (Iterative)",
          quickSortIterative,
          dataset,
          iterations,
        ),
        benchmarkSort(
          "Built-in sort()",
          (arr) => arr.sort((a, b) => a - b),
          dataset,
          iterations,
        ),
      ];

      formatResults(results, size, pattern);

      // Calculate and display speedup
      const builtInTime = results[2].avgMs;
      const recursiveSpeedup = (builtInTime / results[0].avgMs).toFixed(2);
      const iterativeSpeedup = (builtInTime / results[1].avgMs).toFixed(2);

      console.log(`\nSpeedup vs Built-in:`);
      console.log(
        `  Recursive: ${recursiveSpeedup}x ${
          recursiveSpeedup > 1 ? "FASTER" : "SLOWER"
        }`,
      );
      console.log(
        `  Iterative: ${iterativeSpeedup}x ${
          iterativeSpeedup > 1 ? "FASTER" : "SLOWER"
        }`,
      );
    }
  }

  // Summary statistics
  displaySummary();
};

/**
 * Display summary and analysis
 */
const displaySummary = () => {
  console.log(
    `\n\n╔════════════════════════════════════════════════════════════════════════════╗`,
  );
  console.log(
    `║                          Benchmark Summary                                 ║`,
  );
  console.log(
    `╚════════════════════════════════════════════════════════════════════════════╝\n`,
  );

  console.log(`Key Findings:`);
  console.log(
    `  • QuickSort implementations use median-of-three pivot selection`,
  );
  console.log(`  • Insertion sort cutoff of 16 elements for small partitions`);
  console.log(`  • Iterative version avoids recursion depth limitations`);
  console.log(`  • Built-in sort is optimized and highly tuned by engine`);
  console.log(
    `  • Random data typically shows QuickSort's O(n log n) performance`,
  );
  console.log(
    `  • Pre-sorted data benefits from insertion sort cutoff optimization`,
  );

  console.log(`\nRecommendations:`);
  console.log(`  ✓ Use built-in sort() for production code (highly optimized)`);
  console.log(
    `  ✓ Use QuickSort (iterative) for educational purposes or limited stack`,
  );
  console.log(`  ✓ Test with your specific data patterns before optimizing`);
  console.log(`  ✓ Consider hybrid algorithms for mixed workloads\n`);
};

/**
 * Memory usage estimation
 */
const estimateMemory = () => {
  console.log(
    `\n╔════════════════════════════════════════════════════════════════════════════╗`,
  );
  console.log(
    `║                        Memory Usage Analysis                               ║`,
  );
  console.log(
    `╚════════════════════════════════════════════════════════════════════════════╝\n`,
  );

  const sizes = [1000, 10000, 100000];

  console.log(`Array Size | Approx Memory Used`);
  console.log(`${"-".repeat(40)}`);

  sizes.forEach((size) => {
    const bytes = size * 8;
    const kb = (bytes / 1024).toFixed(2);
    const mb = (bytes / (1024 * 1024)).toFixed(2);

    console.log(
      `${size.toString().padEnd(10)} | ${kb.padStart(6)} KB (${mb} MB)`,
    );
  });

  console.log(`\nNote: QuickSort (recursive) uses O(log n) extra stack space`);
  console.log(
    `      QuickSort (iterative) uses O(log n) heap space for stack array`,
  );
  console.log(`      Built-in sort may use O(n) auxiliary space for merging\n`);
};

// Run benchmarks
runBenchmarks();

// Display memory analysis
estimateMemory();

console.log(
  `\n✓ Benchmark complete! Timestamps use Node.js hrtime for nanosecond precision.\n`,
);
