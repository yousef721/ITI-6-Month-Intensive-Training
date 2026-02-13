// ==================== A.1.1. Prevent Context Menu ====================
addEventListener("contextmenu", (event) => {
  alert("Context Menu Disabled!");
  event.preventDefault();
});

// ==================== A.2.1. Form Confirm ====================
document.querySelector("#Form").addEventListener("submit", function (e) {
  var isConfirmed = confirm("Are You Sure To Submit?");

  if (!isConfirmed) {
    e.preventDefault();
  }
});

// ==================== A.2.2. Custom Event ====================
const input = document.getElementById("name");

const customEvent = new CustomEvent("customEvent");

let hasTyped = false;

input.addEventListener("input", function () {
  if (input.value.trim() !== "") {
    hasTyped = true; // User entered data
  }
});

setTimeout(function () {
  if (!hasTyped) {
    document.dispatchEvent(customEvent); // Fire custom event
  }
}, 30000);

// custom event
document.addEventListener("customEvent", function () {
  alert("You have not entered any data for 30 seconds!");
});

// ==================== A.2.1 Difference Keydown And Keypress ====================

// keydown → fires for ALL keys (Ctrl, Alt, Shift, letters, etc.)
document.addEventListener("keydown", function (e) {
  console.log("keydown event fired");
  console.log("Key:", e.key); // Character printed
  console.log("Ctrl pressed?", e.ctrlKey);
  console.log("Alt pressed?", e.altKey);
  console.log("Shift pressed?", e.shiftKey);
  console.log("-----------------------");
});

// keypress → characters only (Deprecated)
document.addEventListener("keypress", function (e) {
  console.log("keypress event fired");
  console.log("Key:", e.key);
});

// ==================== A.3.2. Physical Key Pressed ====================
document.addEventListener("keydown", function (e) {
  // e.code → physical key (example: KeyA)
  console.log("Physical Key:", e.code);

  // e.key → actual character shown (example: a or A)
  console.log("Character Printed:", e.key);
});

// ==================== Bonus: prevent browser behavior ====================

// Prevent Ctrl + S (disable browser Save shortcut)
document.addEventListener("keydown", function (e) {
  if (e.ctrlKey && e.key === "s") {
    e.preventDefault();
    alert("Save Disabled!");
  }
});

// Prevent Ctrl + P (disable browser Print shortcut)
document.addEventListener("keydown", function (e) {
  if (e.ctrlKey && e.key === "p") {
    e.preventDefault();
    alert("Print Disabled!");
  }
});
