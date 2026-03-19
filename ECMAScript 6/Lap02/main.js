//#region Task 1
// var obj = MinMax(10, 50, 70, 20, 100, 90, 1, 40)
// function MinMax(...numbers) { // rest parameter
//     let Min = Math.min(...numbers) // spread operator
//     let Max = Math.max(...numbers) // spread operator

//     return {"Min": Min , "Max": Max}
// }
// console.log("Max:", obj.Max);
// console.log("Min:", obj.Min);
//#endregion

//#region Task 2
// var fruits = ["apple", "strawberry", "banana", "orange", "mango"];
// var allStrings = fruits.every((ele) => typeof ele === "string");
// var startWithA = fruits.some((ele) => ele.startsWith("a"));
// var filterArray = fruits.filter(
//   (ele) => ele.startsWith("b") || ele.startsWith("s"),
// );
// var iLike = fruits.map((ele) => `I like ${ele}`);

// console.log(`Are all elements strings: ${allStrings}`);
// console.log(`Is there any element starts with 'a': ${startWithA}`);
// console.log(`Filtered array (b or s): ${filterArray}`);
// iLike.forEach((ele) => {
//   console.log(ele);
// });
//#endregion

//#region Task 3
// Promise
var getUsers = new Promise((resolve, reject) => {
  fetch("https://jsonplaceholder.typicode.com/users")
    .then((response) => response.json())
    .then((data) => resolve(data))
    .catch((error) => reject(error));
});

getUsers.then((users) => displayTabs(users)).catch((err) => console.error(err));

function displayTabs(users) {
  let tabs = document.getElementById("tabs");

  users.forEach((user) => {
    let btn = document.createElement("Button");
    btn.className = "btn";
    btn.textContent = user.name;

    btn.addEventListener("click", () => {
      setActive(btn);
      getPosts(user.id);
    });

    tabs.appendChild(btn);
  });
}
function setActive(selected) {
  document.querySelectorAll(".btn").forEach((btn) => {
    btn.classList.remove("active");
  });

  selected.classList.add("active");
}

// async await
async function getPosts(userId) {
  try {
    var fetchPosts = await fetch(
      `https://jsonplaceholder.typicode.com/posts?userId=${userId}`,
    );
    var posts = await fetchPosts.json();

    displayPosts(posts);
  } catch (err) {
    console.error(err);
  }
}
function displayPosts(posts) {
  const ul = document.getElementById("posts");
  ul.innerHTML = "";

  posts.forEach((post) => {
    const li = document.createElement("li");
    li.textContent = post.title;
    ul.appendChild(li);
  });
}

//#endregion
