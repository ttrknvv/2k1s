/* 1 задание object, for..in */

let bigCircle = {
    width: "20px",
    height: "20px",
    border: "2px solid black",
    backgroundColor: "white",
    borderRadius: "50%"
}
let bigSquare = {
    width: "20px",
    height: "20px",
    border: "2px solid black",
    backgroundColor: "yellow",
}
let bigTriangl = {
    width: "0px",
    height: "0px",
    backgroundColor: "white",
    borderWidth: "0 20px 20px 20px",
    borderColor: "transparent transparent white transparent",
    midlineCount: "3"
}
let bigCircle2 = {
    width: "20px",
    height: "20px",
    border: "2px solid black",
    backgroundColor: "green",
    borderRadius: "50%"
}
let smallSquare = {
    width: "10px",
    height: "10px",
    border: "2px solid black",
    backgroundColor: "yellow",
}
let bigTriangle2 = {
    width: "0px",
    height: "0px",
    backgroundColor: "white",
    borderWidth: "0 20px 20px 20px",
    borderColor: "transparent transparent white transparent",
    midlineCount: "3"
}

function printDiffCircle(circle1, circle2) { // различие зеленого круга
    for(let key in circle1) {
        if(circle1[key] != circle2[key]) {
            alert(`Различия кругов:\nСвойство и значение circle1: ${key} : ${circle1[key]}\nСвойство и значение circle2: ${key} : ${circle2[key]}`);
        }
    }
}

function printPropTriangle(triangle) {
    for(let key in triangle) {
        alert(`Свойство и значение треугольник: ${key} : ${triangle[key]}`);
    }
}

function printPropSquare(square) {
    for(let key in square) {
        if(key == "backgroundColor") {
            alert(`Свойство определяющее цвет квадрата есть!\n${key} : ${square[key]}`);
            return;
        }
    }
    alert("Такого свойства нет!");
}

printDiffCircle(bigCircle, bigCircle2);
printPropTriangle(bigTriangle2);
printPropSquare(smallSquare);