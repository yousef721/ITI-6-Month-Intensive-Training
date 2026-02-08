var num1;
var num2;

while (isNaN(num1)) {
  num1 = Number(prompt("Enter Number 1"));
}
while (isNaN(num2)) {
  num2 = Number(prompt("Enter Number 2"));
}

if (num1 == num2) {
  document.writeln(`
      <div style="padding:10px; border:2px solid #ddd; margin:5px; font-weight:bold; color:green;">
        The Two Numbers Are Equal
      </div>
    `);
} else {
  var max = num1 > num2 ? num1 : num2;
  var min = num1 < num2 ? num1 : num2;

  var maxTextNum = num1 > num2 ? "First" : "Second";
  var minTextNum = num1 < num2 ? "First" : "Second";

  document.writeln(`
      <div style="padding:10px; border:2px solid #ddd; margin:5px; font-weight:bold; color:blue;">
        The Maximum Number Is ${maxTextNum} Number = ${max}
      </div>
    `);

  document.writeln(`
      <div style="padding:10px; border:2px solid #ddd; margin:5px; font-weight:bold; color:red;">
        The Minimum Number Is ${minTextNum} Number = ${min}
      </div>
    `);
}
