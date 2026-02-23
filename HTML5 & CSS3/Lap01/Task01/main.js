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

// Chatgpt 
//   var video = document.getElementById("video");
//   var videoTime = document.getElementById("video-time");

//   var playBtn = document.getElementById("play");
//   var stopBtn = document.getElementById("stop");
//   var dec10Btn = document.getElementById("dec10");
//   var dec5Btn = document.getElementById("dec5");
//   var inc10Btn = document.getElementById("inc10");
//   var inc5Btn = document.getElementById("inc5");
//   var muteBtn = document.getElementById("mute");
//   var volumeSlider = document.getElementById("volume");
//   var speedSlider = document.getElementById("speed");
//   var timeDisplay = document.getElementById("time-display");

//   function formatTime(time) {
//     var minutes = Math.floor(time / 60);
//     var seconds = Math.floor(time % 60);
//     if (seconds < 10) seconds = "0" + seconds;
//     return minutes + ":" + seconds;
//   }

//   video.addEventListener("loadedmetadata", function () {
//     videoTime.max = video.duration;
//     timeDisplay.textContent =
//       formatTime(0) + " / " + formatTime(video.duration);
//   });

//   video.addEventListener("timeupdate", function () {
//     videoTime.value = video.currentTime;
//     timeDisplay.textContent =
//       formatTime(video.currentTime) +
//       " / " +
//       formatTime(video.duration);
//   });

//   videoTime.addEventListener("input", function () {
//     video.currentTime = videoTime.value;
//   });

//   playBtn.addEventListener("click", function () {
//     video.play();
//   });

//   stopBtn.addEventListener("click", function () {
//     video.pause();
//     video.currentTime = 0;
//   });

//   dec10Btn.addEventListener("click", function () {
//     video.currentTime -= 10;
//   });

//   dec5Btn.addEventListener("click", function () {
//     video.currentTime -= 5;
//   });

//   inc10Btn.addEventListener("click", function () {
//     video.currentTime += 10;
//   });

//   inc5Btn.addEventListener("click", function () {
//     video.currentTime += 5;
//   });

//   muteBtn.addEventListener("click", function () {
//     video.muted = !video.muted;
//     muteBtn.textContent = video.muted ? "Unmute" : "Mute";
//   });

//   volumeSlider.addEventListener("input", function () {
//     video.volume = volumeSlider.value;
//     video.muted = volumeSlider.value == 0;
//     muteBtn.textContent = video.muted ? "Unmute" : "Mute";
//   });

//   speedSlider.addEventListener("input", function () {
//     video.playbackRate = speedSlider.value;
//   });

//   document.addEventListener("keydown", function (e) {
//     if (e.code === "Space") {
//       e.preventDefault();
//       if (video.paused) {
//         video.play();
//       } else {
//         video.pause();
//       }
//     }
//   });