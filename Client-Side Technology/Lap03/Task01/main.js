var yourName = prompt("Whats Your Name?");

document.writeln(`<p style='font-weight: bold; font-size: 2em;'>Heading</p> <hr/>`);
if (yourName == null) {
  document.writeln(
    `<p style='font-weight: bold; font-size: 2em; color: red;'>UnKnown User</p>`,
  );
} else {
  document.writeln(
    `<p style='font-weight: bold; font-size: 2em; color: red;'> Hello, ${yourName}</p>`,
  );
}

for (let i = 1; i <= 6; i++) {
  document.writeln(`<h${i}>This is header number ${i}</h${i}>`);
}
