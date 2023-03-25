/*
* 1 задание
*/

function getSquareCircle(radius) {
    return Math.pow(radius, 2) * Math.PI; // function - declaration
}
let getLenghtCircle = (radius) => 2 * Math.PI * radius; // функция - стрелка
let getDiameter = function(radius) { return radius * 2; } // function - expression

let radius = prompt("Введите радиус окружности:");

alert(`Диаметр окружности: ${getDiameter(radius)}\nПлощадь окружности: ${getSquareCircle(radius)}\nДлина окружности: ${getLenghtCircle(radius)}`)