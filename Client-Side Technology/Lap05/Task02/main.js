obj = {
  street: "ABC street",
  buildingNum: 189,
  city: "Obour",
};

function showAddr(obj) {
  let d = new Date();
  
  let date = `${d.toLocaleDateString()}`; // 10/02/2026

  return `${obj.buildingNum} ${obj.street}, ${obj.city} city registered in ${date}`;
}

console.log(showAddr(obj));
