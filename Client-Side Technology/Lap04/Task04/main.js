// Name validation (characters only)
var name;
do {
  name = prompt("Enter your name (characters only):");
} while (!/^[a-zA-Z\s]+$/.test(name)); 

// Phone number (8 digits)
var phone;
do {
  phone = prompt("Enter your phone number (8 digits):");
} while (!/^\d{8}$/.test(phone));

// Mobile number (11 digits, starts with 010 | 011 | 012 | 015)
var mobile;
do {
  mobile = prompt(
    "Enter your mobile number (11 digits, starts with 010 or 011 or 012):",
  );
} while (!/^(010|011|012|015)\d{8}$/.test(mobile));

// Email validation
var email;
do {
  email = prompt("Enter your email:");
} while (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email));

// Color choice
var color;
do {
  color = prompt("Choose a color: red, green, or blue").toLowerCase();
} while (color !== "red" && color !== "green" && color !== "blue");

// Today's date
var today = new Date().toDateString();

// Display message
document.write(
  `<h2 style="color:${color}">
      Welcome ${name}!<br>
      Phone: ${phone}<br>
      Mobile: ${mobile}<br>
      Email: ${email}<br>
      Date: ${today}
    </h2>`,
);
