# 🚀 Advanced Sorting Algorithm Visualizer

A comprehensive web-based sorting algorithm visualizer with multiple algorithms, real-time animations, performance analysis, and REST API capabilities.

## ✨ Features

### 🎨 Interactive Visualization

- **9 Sorting Algorithms**: Bubble, Selection, Insertion, Merge, Quick, Heap, Shell, Counting, and Radix Sort
- **Real-time Animation**: Step-by-step visualization with color-coded elements
- **Speed Control**: Adjustable animation speed (1-100)
- **Pause/Resume**: Control animation playback
- **Sound Effects**: Optional audio feedback during sorting

### 🎯 Array Generation

- **Multiple Patterns**: Random, Nearly Sorted, Reverse Sorted, Few Unique Values
- **Dynamic Sizing**: Arrays from 5 to 200 elements
- **Manual Input**: Enter custom arrays via textarea

### 📊 Performance Analysis

- **Live Statistics**: Comparisons, swaps, execution time, and array size
- **Algorithm Information**: Time complexity and descriptions for each algorithm
- **Performance Comparison**: Compare different algorithms on the same data

### 🌙 User Experience

- **Dark/Light Theme**: Toggle between themes
- **Responsive Design**: Works on desktop and mobile
- **Parallel Processing**: Web Workers for large array sorting
- **Modern UI**: Clean, intuitive interface with smooth animations

### 🔧 REST API

- **Multiple Endpoints**: POST `/sort` and GET `/sort/:array`
- **All Algorithms**: Support for all 9 sorting algorithms
- **Detailed Response**: Includes statistics and performance metrics
- **Error Handling**: Comprehensive validation and error responses

## 🚀 Quick Start

### Prerequisites

- Node.js (v14 or higher)
- Modern web browser with ES6 support

### Installation

1. **Clone or download** the project files
2. **Install dependencies**:
   ```bash
   npm install
   ```
3. **Start the server**:
   ```bash
   npm start
   # or
   node server.js
   ```
4. **Open your browser** and navigate to `http://localhost:3000`

### Usage

1. **Enter an array** in the input field or click "Generate" for random data
2. **Select an algorithm** from the dropdown
3. **Adjust speed** and other settings as needed
4. **Click "Sort"** to start the visualization
5. **Use controls** to pause, resume, or reset as needed

## 📚 API Documentation

### POST /sort

Sort an array using a specified algorithm.

**Request Body:**

```json
{
  "array": [5, 2, 8, 1, 9, 3, 7],
  "algorithm": "quick"
}
```

**Response:**

```json
{
  "success": true,
  "algorithm": "quick",
  "original": [5, 2, 8, 1, 9, 3, 7],
  "sorted": [1, 2, 3, 5, 7, 8, 9],
  "statistics": {
    "comparisons": 12,
    "swaps": 8,
    "executionTimeMs": "0.123",
    "arraySize": 7
  }
}
```

### GET /sort/:array

Sort an array using query parameters.

**Example:**

```
GET /sort/[5,2,8,1,9,3,7]?algorithm=merge
```

### Supported Algorithms

- `bubble` - Bubble Sort
- `selection` - Selection Sort
- `insertion` - Insertion Sort
- `merge` - Merge Sort
- `quick` - Quick Sort
- `heap` - Heap Sort
- `shell` - Shell Sort
- `counting` - Counting Sort
- `radix` - Radix Sort

## 🏗️ Architecture

### Frontend (`index.html`, `script.js`, `style.css`)

- **HTML5 Canvas** for visualizations
- **ES6 Classes** for algorithm implementations
- **Web Workers** for parallel processing
- **Responsive CSS** with CSS Grid and Flexbox

### Backend (`server.js`)

- **Express.js** web framework
- **CORS** enabled for cross-origin requests
- **Input validation** and error handling
- **Performance timing** with high-resolution timers

### Web Workers (`sortWorker.js`)

- **Parallel QuickSort** implementation
- **Message passing** for worker communication
- **Error handling** and result reporting

## 🔍 Algorithm Details

| Algorithm      | Time Complexity             | Space Complexity | Stable |
| -------------- | --------------------------- | ---------------- | ------ |
| Bubble Sort    | O(n²)                       | O(1)             | Yes    |
| Selection Sort | O(n²)                       | O(1)             | No     |
| Insertion Sort | O(n²)                       | O(1)             | Yes    |
| Merge Sort     | O(n log n)                  | O(n)             | Yes    |
| Quick Sort     | O(n log n) avg, O(n²) worst | O(log n)         | No     |
| Heap Sort      | O(n log n)                  | O(1)             | No     |
| Shell Sort     | O(n log² n)                 | O(1)             | No     |
| Counting Sort  | O(n + k)                    | O(n + k)         | Yes    |
| Radix Sort     | O(n \* d)                   | O(n + k)         | Yes    |

## 🎮 Controls

- **Sort**: Start the sorting animation
- **Pause/Resume**: Control animation playback
- **Reset**: Stop and reset the visualization
- **Generate**: Create a new random array
- **Parallel QuickSort**: Use Web Workers for large arrays
- **Sound On/Off**: Toggle audio feedback
- **Dark/Light**: Switch between themes

## 📱 Browser Support

- Chrome 70+
- Firefox 65+
- Safari 12+
- Edge 79+

## 🔧 Development

### Project Structure

```
/
├── index.html          # Main web interface
├── script.js           # Frontend logic and algorithms
├── style.css           # Styling and themes
├── server.js           # REST API server
├── sortWorker.js       # Web Worker for parallel sorting
└── package.json        # Dependencies and scripts
```

### Adding New Algorithms

1. **Implement the algorithm** in `script.js`
2. **Add visualization logic** with proper async/await
3. **Update the algorithm selector** in `index.html`
4. **Add API support** in `server.js`
5. **Update algorithm info** in `script.js`

### Performance Optimization

- **Web Workers** for CPU-intensive operations
- **RequestAnimationFrame** for smooth animations
- **Efficient canvas rendering** with minimal redraws
- **Memory management** for large arrays

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

## 📄 License

This project is open source and available under the MIT License.

## 🙏 Acknowledgments

- Built with modern web technologies
- Inspired by various sorting algorithm visualizations
- Uses HTML5 Canvas for smooth animations
- Web Workers for parallel processing capabilities

---

**Enjoy exploring sorting algorithms! 🎉**
