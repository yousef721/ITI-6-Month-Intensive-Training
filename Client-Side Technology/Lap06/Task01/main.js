function addVal(obj) {
  document.querySelector("#txt").value += obj.value;
}

function clearInput() {
  document.querySelector("#txt").value = "";
}

function shift() {
  var input = document.querySelector("#txt");
  input.value = input.value.slice(0, -1);
}
