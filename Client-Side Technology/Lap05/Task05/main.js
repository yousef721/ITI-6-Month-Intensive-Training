let win;

function openWin() {
  win = window.open(
    "child.html",
    "blank",
    "width=600,height=400,top=100,left=100",
  );

  //   win.addEventListener("load", function () {
  //   let maxY = win.document.body.scrollHeight - win.innerHeight; // maxHeight

  //   setInterval(function () {
  //     y += direction; // 0

  //     if (y > maxY || y < 0) direction *= -1; // reverse

  //     win.scrollTo(0, y);
  //   }, 5);
  //   });
}

// ================= SetTimeOut =================

// let win;
// let direction = 1;
// let y = 0;

// function openWin() {
//   win = window.open(
//     "child.html",
//     "blank",
//     "width=600,height=400,top=100,left=100",
//   );
//   win.addEventListener("load", function () {
//     let maxY = win.document.body.scrollHeight - win.innerHeight; // maxHeight

//     function scrollLoop() {
//       y += direction; // 0

//       if (y > maxY || y < 0) direction *= -1; // reverse

//       win.scrollTo(0, y);

//       setTimeout(scrollLoop, 5);
//     }

//     scrollLoop();
//   });
// }
