let yourName = prompt("Enter your name");
let yourAge = Number(prompt("Enter your age"));
let key = prompt("What do you want to display? 'name', 'age' ").toLowerCase();

let obj = {
  name: yourName,
  age: yourAge,
};

function dispVal(obj, key) {
  // Validation If User Enter Wrong Key
  if (!(key in obj)) {
    return "Invalid Key";
  }

  if (key === "age") {
    return `${obj[key]} Years Old`;
  } else {
    return `Your Name Is ${obj[key]}`;
  }
}

alert(dispVal(obj, key));
console.log(dispVal(obj, key));
