let answerInput = document.getElementById("Answer");
let operators = "+-*/";
let value = 0;

function EnterNumber(val) {
  answerInput.value += val;
}

function EnterOperator(val) {
  //If the input is empty
  if (answerInput.value === "" && operators.includes(val)) {
    return;
  }
  //  If the last character in the input is an operator AND the new value is also an operator
  if (
    operators.includes(answerInput.value.slice(-1)) &&
    operators.includes(val)
  ) {
    return;
  }

  answerInput.value += val;
}

function EnterEqual() {
  // answerInput.value = eval(answerInput.value);
}

function EnterClear() {
  answerInput.value = "";
}
