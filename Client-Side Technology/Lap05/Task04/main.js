let win;
let y = 0;
let x = 0;
let direction = 1; // 1 = down, -1 = up

function openWin() {
  win = window.open("child.html", "blank", "width=200,height=100,top=0,left=0");

  setInterval(function () {
    const screenHeight = window.screen.availHeight - 100; // Device screen - child height

    y += direction;
    x += direction;

    if (y >= screenHeight || y <= 0) direction *= -1; // reverse

    win.moveTo(x, y);
  }, 5);
}

function closeWin() {
  win.focus();
  win.close();
}

// ================= SetTimeOut =================

// let win;
// let y = 0;
// let x = 0;
// let direction = 1; // 1 = down, -1 = up

// function openWin() {
//   win = window.open("child.html", "blank", "width=200,height=100,top=0,left=0");

//   function moveLoop() {
//     const screenHeight = window.screen.availHeight - 100; // child height
//     y += direction;
//     x += direction;

//     if (y >= screenHeight || y <= 0) direction *= -1; // reverse

//     win.moveTo(x, y);

//     setTimeout(moveLoop, 5);
//   }

//   moveLoop();
// }

// function closeWin() {
//   win.focus();
//   win.close();
// }
