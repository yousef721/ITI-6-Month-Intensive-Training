var video = document.getElementById("video");
var videoTime = document.getElementById("video-time");

var timeInterval;

videoTime.addEventListener("change", function () {
  video.currentTime = videoTime.value;
});

document.getElementById("play").addEventListener("click", function () {
  video.play();
  timeInterval = setInterval(function () {
    videoTime.value = video.currentTime;
    if (video.ended) {
      clearInterval(timeInterval);
    }
  }, 100);
});

document.getElementById("stop").addEventListener("click", function () {
  video.pause();
  clearInterval(timeInterval);
});

document.getElementById("dec10").addEventListener("click", function () {
  video.currentTime -= 10;
});

document.getElementById("dec5").addEventListener("click", function () {
  video.currentTime -= 5;
});

document.getElementById("inc10").addEventListener("click", function () {
  video.currentTime += 10;
});

document.getElementById("inc5").addEventListener("click", function () {
  video.currentTime += 5;
});

document.getElementById("mute").addEventListener("click", function () {
  if (video.muted) {
    video.muted = false;
    document.getElementById("mute").value = "Mute";
  } else {
    video.muted = true;
    document.getElementById("mute").value = "Muted";
  }
});

document.getElementById("volume").addEventListener("input", function () {
  if (document.getElementById("volume").value == 0) {
    video.muted = true;
    document.getElementById("mute").value = "Muted";
  } else {
    video.muted = false;
    document.getElementById("mute").value = "Mute";
    video.volume = document.getElementById("volume").value;
  }
});

document.getElementById("speed").addEventListener("input", function () {
  video.playbackRate = document.getElementById("speed").value;
  console.log(document.getElementById("speed").value);
});
