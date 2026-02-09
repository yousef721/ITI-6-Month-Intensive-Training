var text = prompt("Enter a string:");

function getLargestWord(text) {
  var words = text.split(" ");
  var largestWord = words[0];

  for (var i = 1; i < words.length; i++) {
    if (words[i].length > largestWord.length) {
      largestWord = words[i];
    }
  }

  return largestWord;
}

alert(getLargestWord(text));
