const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");

canvas.width = canvas.offsetWidth;
canvas.height = 450;

const arrayInput = document.getElementById("arrayInput");
const algorithmSelect = document.getElementById("algorithmSelect");

const comparisonsEl = document.getElementById("comparisons");
const swapsEl = document.getElementById("swaps");
const timeEl = document.getElementById("time");
const algorithmInfoEl = document.getElementById("algorithmInfo");

const sortBtn = document.getElementById("sortBtn");
const randomBtn = document.getElementById("randomBtn");
const parallelBtn = document.getElementById("parallelBtn");
const pauseBtn = document.getElementById("pauseBtn");
const resetBtn = document.getElementById("resetBtn");
const speedSlider = document.getElementById("speedSlider");
const speedValue = document.getElementById("speedValue");
const arraySizeSlider = document.getElementById("arraySizeSlider");
const arraySizeValue = document.getElementById("arraySizeValue");
const patternSelect = document.getElementById("patternSelect");
const soundToggle = document.getElementById("soundToggle");
const themeToggle = document.getElementById("themeToggle");

let comparisons = 0;
let swaps = 0;
let isSorting = false;
let isPaused = false;
let currentArray = [];
let animationSpeed = 50;
let soundEnabled = true;
let isDarkTheme = true;

// Audio context for sound effects
let audioContext;
try {
  audioContext = new (window.AudioContext || window.webkitAudioContext)();
} catch (e) {
  console.warn("Web Audio API not supported");
}

const algorithmInfo = {
  bubble: {
    name: "Bubble Sort",
    complexity: "O(n²)",
    description:
      "Simple comparison sort that repeatedly steps through the list, compares adjacent elements and swaps them if they are in the wrong order.",
  },
  selection: {
    name: "Selection Sort",
    complexity: "O(n²)",
    description:
      "Sorts an array by repeatedly finding the minimum element from unsorted portion and putting it at the beginning.",
  },
  insertion: {
    name: "Insertion Sort",
    complexity: "O(n²)",
    description:
      "Builds the final sorted array one item at a time, efficient for small data sets or nearly sorted arrays.",
  },
  merge: {
    name: "Merge Sort",
    complexity: "O(n log n)",
    description:
      "Divide and conquer algorithm that divides the array into two halves, sorts them, and then merges them.",
  },
  quick: {
    name: "Quick Sort",
    complexity: "O(n log n) avg, O(n²) worst",
    description:
      "Highly efficient sorting algorithm using divide and conquer strategy with pivot element.",
  },
  heap: {
    name: "Heap Sort",
    complexity: "O(n log n)",
    description: "Comparison-based sorting using binary heap data structure.",
  },
  shell: {
    name: "Shell Sort",
    complexity: "O(n log² n)",
    description:
      "Generalization of insertion sort that allows exchange of items far apart.",
  },
  counting: {
    name: "Counting Sort",
    complexity: "O(n + k)",
    description:
      "Non-comparison sort that counts occurrences of each element and uses this info to place them in order.",
  },
  radix: {
    name: "Radix Sort",
    complexity: "O(n * d)",
    description:
      "Non-comparison sort that sorts numbers by processing individual digits from least significant to most.",
  },
};

function playSound(frequency = 440, duration = 100) {
  if (!soundEnabled || !audioContext) return;

  try {
    const oscillator = audioContext.createOscillator();
    const gainNode = audioContext.createGain();

    oscillator.connect(gainNode);
    gainNode.connect(audioContext.destination);

    oscillator.frequency.setValueAtTime(frequency, audioContext.currentTime);
    oscillator.type = "sine";

    gainNode.gain.setValueAtTime(0.1, audioContext.currentTime);
    gainNode.gain.exponentialRampToValueAtTime(
      0.01,
      audioContext.currentTime + duration / 1000,
    );

    oscillator.start(audioContext.currentTime);
    oscillator.stop(audioContext.currentTime + duration / 1000);
  } catch (e) {
    console.warn("Sound playback failed");
  }
}

function sleep(ms) {
  return new Promise((resolve) => {
    if (isPaused) {
      const checkPaused = () => {
        if (!isPaused) {
          resolve();
        } else {
          setTimeout(checkPaused, 100);
        }
      };
      checkPaused();
    } else {
      setTimeout(resolve, ms);
    }
  });
}

function parseArray() {
  try {
    const arr = arrayInput.value
      .split(/[,\s]+/)
      .filter((x) => x !== "" && !isNaN(Number(x)))
      .map(Number);

    currentArray = [...arr];
    document.getElementById("arraySize").textContent =
      arr.length.toLocaleString();
    return arr;
  } catch (e) {
    return [];
  }
}

function drawArray(arr, active = [], sorted = [], comparing = []) {
  ctx.clearRect(0, 0, canvas.width, canvas.height);

  if (arr.length === 0) return;

  const width = canvas.width / arr.length;
  const max = Math.max(...arr);
  const min = Math.min(...arr);

  arr.forEach((value, index) => {
    const height = max === min ? 200 : ((value - min) / (max - min)) * 400;

    let color;
    if (sorted.includes(index)) {
      color = "#10b981"; // Green for sorted
    } else if (active.includes(index)) {
      color = "#ef4444"; // Red for active
    } else if (comparing.includes(index)) {
      color = "#f59e0b"; // Orange for comparing
    } else {
      color = isDarkTheme ? "#60a5fa" : "#3b82f6"; // Blue for normal
    }

    ctx.fillStyle = color;
    ctx.fillRect(index * width, canvas.height - height, width - 2, height);

    // Add value labels for small arrays
    if (arr.length <= 20) {
      ctx.fillStyle = isDarkTheme ? "#ffffff" : "#000000";
      ctx.font = "12px Arial";
      ctx.textAlign = "center";
      ctx.fillText(
        value.toString(),
        index * width + width / 2,
        canvas.height - height - 5,
      );
    }
  });
}

function updateStats() {
  comparisonsEl.textContent = comparisons.toLocaleString();
  swapsEl.textContent = swaps.toLocaleString();
}

function updateAlgorithmInfo() {
  const algo = algorithmSelect.value;
  const info = algorithmInfo[algo];
  if (info) {
    algorithmInfoEl.innerHTML = `
            <h3>${info.name}</h3>
            <p><strong>Time Complexity:</strong> ${info.complexity}</p>
            <p>${info.description}</p>
        `;
  }
}

function generateArray(size, pattern = "random") {
  let arr = [];

  switch (pattern) {
    case "random":
      for (let i = 0; i < size; i++) {
        arr.push(Math.floor(Math.random() * 100) + 1);
      }
      break;
    case "nearly-sorted":
      for (let i = 0; i < size; i++) {
        arr.push(i + 1);
      }
      // Swap a few elements
      for (let i = 0; i < Math.floor(size * 0.1); i++) {
        const idx1 = Math.floor(Math.random() * size);
        const idx2 = Math.floor(Math.random() * size);
        [arr[idx1], arr[idx2]] = [arr[idx2], arr[idx1]];
      }
      break;
    case "reverse":
      for (let i = size; i > 0; i--) {
        arr.push(i);
      }
      break;
    case "few-unique":
      const uniqueValues = [10, 20, 30, 40, 50];
      for (let i = 0; i < size; i++) {
        arr.push(uniqueValues[Math.floor(Math.random() * uniqueValues.length)]);
      }
      break;
  }

  return arr;
}

async function bubbleSort(arr) {
  const n = arr.length;
  const sortedIndices = [];

  for (let i = 0; i < n; i++) {
    for (let j = 0; j < n - i - 1; j++) {
      if (!isSorting) return;

      comparisons++;
      drawArray(arr, [], sortedIndices, [j, j + 1]);
      updateStats();
      playSound(200 + arr[j] * 2, 50);

      await sleep(animationSpeed);

      if (arr[j] > arr[j + 1]) {
        swaps++;
        [arr[j], arr[j + 1]] = [arr[j + 1], arr[j]];
        drawArray(arr, [j, j + 1], sortedIndices, []);
        updateStats();
        playSound(400 + arr[j] * 2, 100);
        await sleep(animationSpeed);
      }
    }
    sortedIndices.push(n - i - 1);
  }
  return arr;
}

async function selectionSort(arr) {
  const n = arr.length;
  const sortedIndices = [];

  for (let i = 0; i < n; i++) {
    let minIdx = i;

    for (let j = i + 1; j < n; j++) {
      if (!isSorting) return;

      comparisons++;
      drawArray(arr, [minIdx], sortedIndices, [j]);
      updateStats();
      playSound(300 + arr[j] * 2, 50);

      await sleep(animationSpeed);

      if (arr[j] < arr[minIdx]) {
        minIdx = j;
      }
    }

    if (minIdx !== i) {
      swaps++;
      [arr[i], arr[minIdx]] = [arr[minIdx], arr[i]];
      drawArray(arr, [i, minIdx], sortedIndices, []);
      updateStats();
      playSound(500 + arr[i] * 2, 100);
      await sleep(animationSpeed);
    }

    sortedIndices.push(i);
  }
  return arr;
}

async function insertionSort(arr) {
  const n = arr.length;
  const sortedIndices = [0];

  for (let i = 1; i < n; i++) {
    const key = arr[i];
    let j = i - 1;

    while (j >= 0 && arr[j] > key) {
      if (!isSorting) return;

      comparisons++;
      drawArray(arr, [j + 1], sortedIndices, [j]);
      updateStats();
      playSound(250 + arr[j] * 2, 50);

      await sleep(animationSpeed);

      arr[j + 1] = arr[j];
      swaps++;
      j--;
    }

    arr[j + 1] = key;
    sortedIndices.push(i);
    drawArray(arr, [], sortedIndices, []);
    updateStats();
    playSound(450 + key * 2, 100);
    await sleep(animationSpeed);
  }
  return arr;
}

async function mergeSort(arr) {
  async function merge(left, right, startIdx) {
    const result = [];
    let i = 0,
      j = 0;

    while (i < left.length && j < right.length) {
      if (!isSorting) return [];

      comparisons++;
      const leftIdx = startIdx + i;
      const rightIdx = startIdx + left.length + j;

      drawArray(arr, [], [], [leftIdx, rightIdx]);
      updateStats();
      playSound(350 + (left[i] + right[j]) * 1.5, 50);

      await sleep(animationSpeed);

      if (left[i] < right[j]) {
        result.push(left[i++]);
      } else {
        result.push(right[j++]);
      }
    }

    return [...result, ...left.slice(i), ...right.slice(j)];
  }

  async function sort(arr, startIdx = 0) {
    if (arr.length <= 1) return arr;

    const mid = Math.floor(arr.length / 2);
    const left = await sort(arr.slice(0, mid), startIdx);
    const right = await sort(arr.slice(mid), startIdx + mid);

    return await merge(left, right, startIdx);
  }

  return await sort(arr);
}

async function quickSort(arr, low = 0, high = arr.length - 1) {
  if (low < high) {
    const pivotIdx = await partition(arr, low, high);
    await quickSort(arr, low, pivotIdx - 1);
    await quickSort(arr, pivotIdx + 1, high);
  }
  return arr;
}

async function partition(arr, low, high) {
  const pivot = arr[high];
  let i = low - 1;

  for (let j = low; j < high; j++) {
    if (!isSorting) return i + 1;

    comparisons++;
    drawArray(arr, [high], [], [i + 1, j]);
    updateStats();
    playSound(300 + arr[j] * 2, 50);

    await sleep(animationSpeed);

    if (arr[j] < pivot) {
      i++;
      swaps++;
      [arr[i], arr[j]] = [arr[j], arr[i]];
      drawArray(arr, [high, i], [], []);
      updateStats();
      playSound(500 + arr[i] * 2, 100);
      await sleep(animationSpeed);
    }
  }

  swaps++;
  [arr[i + 1], arr[high]] = [arr[high], arr[i + 1]];
  drawArray(arr, [i + 1], [], []);
  updateStats();
  playSound(600 + arr[i + 1] * 2, 100);
  await sleep(animationSpeed);

  return i + 1;
}

async function heapSort(arr) {
  const n = arr.length;

  // Build max heap
  for (let i = Math.floor(n / 2) - 1; i >= 0; i--) {
    await heapify(arr, n, i);
  }

  // Extract elements from heap
  for (let i = n - 1; i > 0; i--) {
    if (!isSorting) return;

    swaps++;
    [arr[0], arr[i]] = [arr[i], arr[0]];
    drawArray(arr, [0, i], [], []);
    updateStats();
    playSound(400 + arr[0] * 2, 100);
    await sleep(animationSpeed);

    await heapify(arr, i, 0);
  }

  return arr;
}

async function heapify(arr, n, i) {
  let largest = i;
  const left = 2 * i + 1;
  const right = 2 * i + 2;

  if (left < n) {
    comparisons++;
    drawArray(arr, [largest, left], [], []);
    updateStats();
    playSound(350 + arr[left] * 2, 50);
    await sleep(animationSpeed);

    if (arr[left] > arr[largest]) {
      largest = left;
    }
  }

  if (right < n) {
    comparisons++;
    drawArray(arr, [largest, right], [], []);
    updateStats();
    playSound(350 + arr[right] * 2, 50);
    await sleep(animationSpeed);

    if (arr[right] > arr[largest]) {
      largest = right;
    }
  }

  if (largest !== i) {
    swaps++;
    [arr[i], arr[largest]] = [arr[largest], arr[i]];
    drawArray(arr, [i, largest], [], []);
    updateStats();
    playSound(500 + arr[i] * 2, 100);
    await sleep(animationSpeed);

    await heapify(arr, n, largest);
  }
}

async function shellSort(arr) {
  const n = arr.length;
  let gap = Math.floor(n / 2);

  while (gap > 0) {
    for (let i = gap; i < n; i++) {
      const temp = arr[i];
      let j = i;

      while (j >= gap && arr[j - gap] > temp) {
        if (!isSorting) return;

        comparisons++;
        drawArray(arr, [j, j - gap], [], []);
        updateStats();
        playSound(300 + arr[j - gap] * 2, 50);
        await sleep(animationSpeed);

        arr[j] = arr[j - gap];
        swaps++;
        j -= gap;
      }

      arr[j] = temp;
      drawArray(arr, [j], [], []);
      updateStats();
      playSound(450 + temp * 2, 100);
      await sleep(animationSpeed);
    }
    gap = Math.floor(gap / 2);
  }

  return arr;
}

async function countingSort(arr) {
  const n = arr.length;
  const max = Math.max(...arr);
  const min = Math.min(...arr);
  const range = max - min + 1;

  const count = new Array(range).fill(0);
  const output = new Array(n);

  // Count occurrences
  for (let i = 0; i < n; i++) {
    if (!isSorting) return;
    count[arr[i] - min]++;
    drawArray(arr, [i], [], []);
    updateStats();
    playSound(200 + arr[i] * 2, 50);
    await sleep(animationSpeed);
  }

  // Cumulative count
  for (let i = 1; i < range; i++) {
    count[i] += count[i - 1];
  }

  // Build output array
  for (let i = n - 1; i >= 0; i--) {
    if (!isSorting) return;
    const index = count[arr[i] - min] - 1;
    output[index] = arr[i];
    count[arr[i] - min]--;
    swaps++;
    drawArray(arr, [i], [], []);
    updateStats();
    playSound(400 + arr[i] * 2, 100);
    await sleep(animationSpeed);
  }

  // Copy back to original array
  for (let i = 0; i < n; i++) {
    arr[i] = output[i];
  }

  return arr;
}

async function radixSort(arr) {
  const max = Math.max(...arr);
  let exp = 1;

  while (Math.floor(max / exp) > 0) {
    await countingSortByDigit(arr, exp);
    exp *= 10;
  }

  return arr;
}

async function countingSortByDigit(arr, exp) {
  const n = arr.length;
  const output = new Array(n);
  const count = new Array(10).fill(0);

  // Count occurrences of digits
  for (let i = 0; i < n; i++) {
    if (!isSorting) return;
    const digit = Math.floor(arr[i] / exp) % 10;
    count[digit]++;
    drawArray(arr, [i], [], []);
    updateStats();
    playSound(250 + digit * 50, 50);
    await sleep(animationSpeed);
  }

  // Cumulative count
  for (let i = 1; i < 10; i++) {
    count[i] += count[i - 1];
  }

  // Build output array
  for (let i = n - 1; i >= 0; i--) {
    if (!isSorting) return;
    const digit = Math.floor(arr[i] / exp) % 10;
    const index = count[digit] - 1;
    output[index] = arr[i];
    count[digit]--;
    swaps++;
    drawArray(arr, [i], [], []);
    updateStats();
    playSound(400 + digit * 50, 100);
    await sleep(animationSpeed);
  }

  // Copy back to original array
  for (let i = 0; i < n; i++) {
    arr[i] = output[i];
  }
}

// Event Listeners
sortBtn.addEventListener("click", async () => {
  if (isSorting) return;

  isSorting = true;
  isPaused = false;
  sortBtn.disabled = true;
  pauseBtn.textContent = "Pause";
  pauseBtn.disabled = false;

  let arr = [...parseArray()];
  if (arr.length === 0) {
    alert("Please enter a valid array");
    isSorting = false;
    sortBtn.disabled = false;
    return;
  }

  currentArray = [...arr];
  comparisons = 0;
  swaps = 0;
  updateStats();
  drawArray(arr);

  const start = performance.now();
  const algorithm = algorithmSelect.value;

  try {
    switch (algorithm) {
      case "bubble":
        arr = await bubbleSort(arr);
        break;
      case "selection":
        arr = await selectionSort(arr);
        break;
      case "insertion":
        arr = await insertionSort(arr);
        break;
      case "merge":
        arr = await mergeSort(arr);
        break;
      case "quick":
        arr = await quickSort(arr);
        break;
      case "heap":
        arr = await heapSort(arr);
        break;
      case "shell":
        arr = await shellSort(arr);
        break;
      case "counting":
        arr = await countingSort(arr);
        break;
      case "radix":
        arr = await radixSort(arr);
        break;
    }

    if (isSorting) {
      drawArray(
        arr,
        [],
        Array.from({ length: arr.length }, (_, i) => i),
        [],
      );
      const end = performance.now();
      timeEl.textContent = `${(end - start).toFixed(2)} ms`;
    }
  } catch (error) {
    console.error("Sorting error:", error);
  } finally {
    isSorting = false;
    sortBtn.disabled = false;
    pauseBtn.disabled = true;
  }
});

pauseBtn.addEventListener("click", () => {
  if (!isSorting) return;

  isPaused = !isPaused;
  pauseBtn.textContent = isPaused ? "Resume" : "Pause";
});

resetBtn.addEventListener("click", () => {
  isSorting = false;
  isPaused = false;
  sortBtn.disabled = false;
  pauseBtn.disabled = true;
  pauseBtn.textContent = "Pause";

  const arr = parseArray();
  comparisons = 0;
  swaps = 0;
  timeEl.textContent = "0.00 ms";
  updateStats();
  drawArray(arr);
});

randomBtn.addEventListener("click", () => {
  const size = parseInt(arraySizeSlider.value);
  const pattern = patternSelect.value;
  const arr = generateArray(size, pattern);
  arrayInput.value = arr.join(", ");
  drawArray(arr);
  comparisons = 0;
  swaps = 0;
  timeEl.textContent = "0.00 ms";
  updateStats();
});

speedSlider.addEventListener("input", () => {
  animationSpeed = 101 - parseInt(speedSlider.value); // Reverse scale (1 = fast, 100 = slow)
  speedValue.textContent = speedSlider.value;
});

arraySizeSlider.addEventListener("input", () => {
  arraySizeValue.textContent = arraySizeSlider.value;
});

algorithmSelect.addEventListener("change", updateAlgorithmInfo);

soundToggle.addEventListener("click", () => {
  soundEnabled = !soundEnabled;
  soundToggle.textContent = soundEnabled ? "🔊 Sound On" : "🔇 Sound Off";
  soundToggle.classList.toggle("active", soundEnabled);
});

themeToggle.addEventListener("click", () => {
  isDarkTheme = !isDarkTheme;
  document.body.classList.toggle("light-theme", !isDarkTheme);
  themeToggle.textContent = isDarkTheme ? "🌙 Dark" : "☀️ Light";
  drawArray(parseArray()); // Redraw with new theme
});

// Parallel QuickSort functionality
parallelBtn.addEventListener("click", async () => {
  if (isSorting) return;

  const arr = parseArray();
  if (arr.length < 1000) {
    alert("Parallel sorting works best with large arrays (1000+ elements)");
    return;
  }

  isSorting = true;
  sortBtn.disabled = true;

  try {
    const start = performance.now();
    const sorted = await parallelQuickSort(arr);
    const end = performance.now();

    drawArray(
      sorted,
      [],
      Array.from({ length: sorted.length }, (_, i) => i),
      [],
    );
    timeEl.textContent = `${(end - start).toFixed(2)} ms`;
    arrayInput.value = sorted.join(", ");
  } catch (error) {
    console.error("Parallel sort error:", error);
  } finally {
    isSorting = false;
    sortBtn.disabled = false;
  }
});

// Parallel QuickSort implementation
async function parallelQuickSort(arr) {
  const workers = [];
  const numWorkers = Math.min(navigator.hardwareConcurrency || 4, 8);

  // Create workers
  for (let i = 0; i < numWorkers; i++) {
    workers.push(new Worker("sortWorker.js"));
  }

  async function sortChunk(chunk, workerIndex) {
    return new Promise((resolve, reject) => {
      const worker = workers[workerIndex];

      worker.postMessage({ array: chunk, id: workerIndex });

      worker.onmessage = (e) => {
        if (e.data.error) {
          reject(e.data.error);
        } else {
          resolve(e.data.result);
        }
      };

      worker.onerror = (error) => {
        reject(error);
      };
    });
  }

  // Split array into chunks
  const chunkSize = Math.ceil(arr.length / numWorkers);
  const chunks = [];
  for (let i = 0; i < arr.length; i += chunkSize) {
    chunks.push(arr.slice(i, i + chunkSize));
  }

  // Sort chunks in parallel
  const sortedChunks = await Promise.all(
    chunks.map((chunk, index) => sortChunk(chunk, index % workers.length)),
  );

  // Merge sorted chunks
  return mergeSortedArrays(sortedChunks);
}

function mergeSortedArrays(arrays) {
  if (arrays.length === 1) return arrays[0];

  const merged = [];
  const indices = new Array(arrays.length).fill(0);

  while (true) {
    let minVal = Infinity;
    let minIndex = -1;

    for (let i = 0; i < arrays.length; i++) {
      if (indices[i] < arrays[i].length && arrays[i][indices[i]] < minVal) {
        minVal = arrays[i][indices[i]];
        minIndex = i;
      }
    }

    if (minIndex === -1) break;

    merged.push(minVal);
    indices[minIndex]++;
  }

  return merged;
}

// Initialize
updateAlgorithmInfo();
drawArray(parseArray());

parallelBtn.addEventListener("click", () => {
  alert(
    "Parallel QuickSort should use Web Workers.\n\nCreate worker.js and split array chunks between workers.",
  );
});

window.onload = () => {
  drawArray(parseArray());
};
