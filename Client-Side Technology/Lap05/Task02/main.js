obj = {
  street: "ABC street",
  buildingNum: 189,
  city: "Obour",
};

function showAddr(obj) {
  let d = new Date();
  let date = `${d.toLocaleString()}`;

  return `${obj.buildingNum} ${obj.street}, ${obj.city} city registered in ${date}`;
}

console.log(showAddr(obj));
