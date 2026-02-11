var imgs = document.getElementsByTagName("img");
let intervalId;
let i = 0;
function mouseHover() {
  clearInterval(intervalId);

  intervalId = setInterval(function () {
    // Return All To Original Photo
    for (let j = 0; j < imgs.length; j++) {
      imgs[j].src = "./images/marble1.jpg";
    }
    // Change Photo
    imgs[i].src = "./images/marble3.jpg";

    i++;

    if (i === imgs.length) {
      i = 0;
    }
  }, 500);
}

function mouseLeave() {
  clearInterval(intervalId);

  // Return All To Original Photo
  for (let j = 0; j < imgs.length; j++) {
    imgs[j].src = "./images/marble1.jpg";
  }
}
