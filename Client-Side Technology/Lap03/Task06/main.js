var rows = Number(prompt("Enter Number Of Rows: "));

document.writeln("<hr/>");
for (let i = 0; i < rows; i++) {
  for (let j = rows - i - 1; j < rows; j++) { // 2 < 3 // 3 - 1 - 1 = 1 // 3 - 2 - 1 = 0 
    document.writeln("* ");
  }
  document.writeln("<hr/>");
}
