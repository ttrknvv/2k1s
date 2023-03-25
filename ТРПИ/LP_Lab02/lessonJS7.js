/*
* 7 задание
*/
function FindSquare(firstLeg, secondLeg) { // Площадь
    return firstLeg * secondLeg * 0.5;
}

function FindPerimeter(firstLeg, secondLeg, hypotenuse) { // периметр
    return firstLeg + secondLeg + hypotenuse;
}

function FindHeight(firstLeg, secondLeg, hypotenuse) { // высота
    return firstLeg * secondLeg / hypotenuse
}

function FindCOS(firstLeg, hypotenuse ) { // косинус
    return firstLeg / hypotenuse;
}

function FindSIN(secondLeg, hypotenuse ) { // синус
    return secondLeg / hypotenuse;
}

function FindTG(firstLeg, secondLeg) {
    return firstLeg / secondLeg;
}

function FindCTG(secondLeg, firstLeg) {
    return secondLeg / firstLeg;
}

let firstLeg = +prompt("Введите длину первого катета:");
let secondLeg = +prompt("Введите длину второго катета:");
let hypotenuse = Math.sqrt(firstLeg * firstLeg + secondLeg * secondLeg);
let choise = +prompt("Выберите: 1 - Площадь, 2 - Периметр, 3 - Высота\n4 - cos, 5 - sin, 6 - tg\n7 - ctg, 0 - Выход");

while(choise) {
    switch(choise) {
        case 1: alert(`Площадь: ${FindSquare(firstLeg, secondLeg).toFixed(2)}`);
                break;
        case 2: alert(`Периметр: ${FindPerimeter(firstLeg, secondLeg, hypotenuse).toFixed(2)}`);
                break;
        case 3: alert(`Высота: ${FindHeight(firstLeg, secondLeg, hypotenuse).toFixed(2)}`);
                break;
        case 4: alert(`COS: ${FindCOS(firstLeg, hypotenuse).toFixed(2)}`);
                break;
        case 5: alert(`SIN: ${FindSIN(secondLeg, hypotenuse).toFixed(2)}`);
                break;
        case 6: alert(`TG: ${FindTG(firstLeg, secondLeg).toFixed(2)}`);
                break;
        case 7: alert(`CTG: ${FindCTG(secondLeg, firstLeg).toFixed(2)}`);
                break;
        case 0: break;
        default: alert("Неправильный ввод.");
                break;
    }
    choise = +prompt("Выберите: 1 - Площадь, 2 - Периметр, 3 - Высота\n4 - cos, 5 - sin, 6 - tg\n7 - ctg, 0 - Выход");
}