var img = document.querySelector("img");

let i = 1;

function nextImg() {
  if (i < 6) {
    img.src = `./images/${++i}.jpg`;
  }
}

function PrevImg() {
  if (i > 1) {
    img.src = `./images/${--i}.jpg`;
  }
}

var intervalId;
var j = 0;

function slideImg() {
  clearInterval(intervalId); // Prevent more setInterval as same time
  j = i; // start from current image
  intervalId = setInterval(function () {
    img.src = `./images/${j}.jpg`;
    j++;
    if (j == 7) {
      j = 1;
    }
  }, 500);
}

function stopImg() {
  clearInterval(intervalId);
  // j is always one step ahead, so subtract 1 to get the current image index
  // If j == 1, it means we wrapped from the last image //
  i = j === 1 ? 6 : j - 1;
}
