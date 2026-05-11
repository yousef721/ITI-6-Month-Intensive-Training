/**
 * Calculate the sum of numbers in an array with comprehensive error handling.
 * @param {number[]} numbers - Array of numbers to sum
 * @returns {number} The sum of all numbers
 * @throws {TypeError} If input is not an array or contains non-numeric values
 */
function calculateSum(numbers) {
  // Validate input is an array
  if (!Array.isArray(numbers)) {
    throw new TypeError(
      `calculateSum: Expected array, received ${typeof numbers}`
    );
  }

  // Handle empty array
  if (numbers.length === 0) {
    console.warn("calculateSum: Empty array provided, returning 0");
    return 0;
  }

  let sum = 0;

  // Fixed: Use i < (not i <=) to avoid off-by-one error and undefined access
  for (let i = 0; i < numbers.length; i++) {
    const value = numbers[i];

    // Validate each element is a valid number
    if (typeof value !== "number" || Number.isNaN(value)) {
      throw new TypeError(
        `calculateSum: Invalid number at index ${i}: ${value} (type: ${typeof value})`
      );
    }

    // Check for infinite values
    if (!Number.isFinite(value)) {
      throw new Error(
        `calculateSum: Non-finite number at index ${i}: ${value}`
      );
    }

    sum += value;
  }

  return sum;
}

/**
 * Divide two numbers with zero division protection and input validation.
 * @param {number} a - Dividend
 * @param {number} b - Divisor
 * @returns {number} Result of a / b
 * @throws {TypeError} If inputs are not valid numbers
 * @throws {Error} If divisor is zero or inputs are infinite/NaN
 */
function divide(a, b) {
  // Validate first argument is a number
  if (typeof a !== "number" || Number.isNaN(a)) {
    throw new TypeError(
      `divide: First argument must be a valid number, got: ${a} (type: ${typeof a})`
    );
  }

  // Validate second argument is a number
  if (typeof b !== "number" || Number.isNaN(b)) {
    throw new TypeError(
      `divide: Second argument must be a valid number, got: ${b} (type: ${typeof b})`
    );
  }

  // Check for infinite values
  if (!Number.isFinite(a)) {
    throw new Error(`divide: First argument is not finite: ${a}`);
  }

  if (!Number.isFinite(b)) {
    throw new Error(`divide: Second argument is not finite: ${b}`);
  }

  // Fixed: Check for division by zero
  if (b === 0) {
    throw new Error("divide: Division by zero is not allowed");
  }

  return a / b;
}

/**
 * Display user information with comprehensive null and property checking.
 * @param {Object} user - User object with name property
 * @returns {void}
 * @throws {TypeError} If user is null, undefined, or missing/invalid name property
 */
function showUser(user) {
  // Fixed: Validate user exists (both null and undefined)
  if (user === null) {
    throw new TypeError("showUser: User object cannot be null");
  }

  if (user === undefined) {
    throw new TypeError("showUser: User object is undefined");
  }

  // Validate user is an object
  if (typeof user !== "object") {
    throw new TypeError(
      `showUser: Expected object, received ${typeof user}`
    );
  }

  // Validate user has a name property
  if (!Object.prototype.hasOwnProperty.call(user, "name")) {
    throw new TypeError("showUser: User object must have a name property");
  }

  // Validate name is not null
  if (user.name === null) {
    throw new TypeError("showUser: User name cannot be null");
  }

  // Validate name is a string
  if (typeof user.name !== "string") {
    throw new TypeError(
      `showUser: User name must be a string, received ${typeof user.name}`
    );
  }

  // Validate name is not empty
  if (user.name.trim().length === 0) {
    throw new Error("showUser: User name cannot be empty or whitespace-only");
  }

  console.log(user.name.toUpperCase());
}

// ===== Comprehensive Tests =====
console.log("=== Testing calculateSum ===\n");

try {
  console.log("✓ calculateSum([1, 2, 3]):", calculateSum([1, 2, 3]));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✓ calculateSum([]):", calculateSum([]));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✓ calculateSum([-5, 10, 3]):", calculateSum([-5, 10, 3]));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log('✗ calculateSum([1, "2", 3]):');
  calculateSum([1, "2", 3]);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ calculateSum(null):");
  calculateSum(null);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ calculateSum([1, 2, NaN]):");
  calculateSum([1, 2, NaN]);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

console.log("\n=== Testing divide ===\n");

try {
  console.log("✓ divide(10, 2):", divide(10, 2));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✓ divide(-20, 4):", divide(-20, 4));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✓ divide(7, 2):", divide(7, 2));
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✗ divide(10, 0):");
  divide(10, 0);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log('✗ divide("10", 2):');
  divide("10", 2);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ divide(Infinity, 2):");
  divide(Infinity, 2);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

console.log("\n=== Testing showUser ===\n");

try {
  console.log("✓ showUser({ name: 'john' }):");
  showUser({ name: "john" });
} catch (error) {
  console.error("✗ Error:", error.message);
}

try {
  console.log("✗ showUser(null):");
  showUser(null);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ showUser(undefined):");
  showUser(undefined);
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ showUser({}):");
  showUser({});
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ showUser({ name: null }):");
  showUser({ name: null });
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ showUser({ name: '' }):");
  showUser({ name: "" });
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✗ showUser({ name: 123 }):");
  showUser({ name: 123 });
} catch (error) {
  console.error("✓ Caught expected error:", error.message);
}

try {
  console.log("✓ showUser({ name: 'alice', age: 30 }):");
  showUser({ name: "alice", age: 30 });
} catch (error) {
  console.error("✗ Error:", error.message);
}
