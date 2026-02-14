// B.1.1 — Function that accepts exactly 2 parameters
function checkTwoParams(a, b) {
  if (arguments.length !== 2) {
    throw new Error("This function requires exactly 2 parameters.");
  }
  console.log("Parameters accepted:", a, b);
}

// Examples:
try {
  checkTwoParams(1, 2); // Works
  checkTwoParams(1); // Throws error // less than 2
  checkTwoParams(1, 2, 3); // Throws error // more than 2
} catch (err) {
  console.error(err.message);
}

// B.1.2 — Adding function that adds n numbers
function addNumbers() {
  if (arguments.length === 0) {
    throw "You must pass at least one number.";
  }

  var sum = 0;
  for (var i = 0; i < arguments.length; i++) {
    if (typeof arguments[i] !== "number") {
      throw "All parameters must be numbers.";
    }
    sum += arguments[i];
  }

  return sum;
}

// Examples:
try {
  console.log(addNumbers(1, 2, 3)); // 6
  console.log(addNumbers()); // Throws error // zero param
  console.log(addNumbers(1, "2")); // Throws error // string param
} catch (err) {
  console.error(err);
}
