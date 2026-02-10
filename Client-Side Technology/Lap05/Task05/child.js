let direction = 1;
let y = 0;
function winChild() {
  let maxY = document.body.scrollHeight - innerHeight; // maxHeight = Page length - Screen height = scrollY  

  setInterval(function () {
    y += direction;

    if (y > maxY || y < 0) direction *= -1; // reverse

    scrollTo(0, y);
  }, 5);
}

winChild();

// ================= SetTimeOut =================

// function winChildSetTimeOut() {
//   let maxY = document.body.scrollHeight - innerHeight; // maxHeight
//   function scrollLoop() {
//     y += direction; // 0

//     if (y > maxY || y < 0) direction *= -1; // reverse

//     scrollTo(0, y);

//     setTimeout(scrollLoop, 5);
//   }

//   scrollLoop();
// }

// winChildSetTimeOut();
