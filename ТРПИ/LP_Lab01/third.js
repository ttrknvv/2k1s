/*
* 4, 5, 6, 7, 8 задание
*/

function getSquare(a, b) {
    return a * b;
}
function getCountSmallQuadrate(handRect, handRect2, handQuad) {
    return ((handRect - handRect % handQuad) / handQuad) * ((handRect2 - handRect2 % handQuad) / handQuad) ;
}


let firstSide = 45;
let secondSide = 21;
let squareA = getSquare(firstSide, secondSide);
alert(`Площадь прямоугольника А = ${squareA} мм.`);

let thirdSide = 5;
let squareB = getSquare(thirdSide, thirdSide);
let countQuadrate = getCountSmallQuadrate(firstSide, secondSide, thirdSide);
alert(`В прямоугольник A поместится ${countQuadrate} квадратов B.`);

let i = 2; // 2 => 3 => 4
let a = ++i; // 3
let b = i++; // 3
a > b ? alert("a больше") : a < b ? alert("b больше") : alert("они равны");

"Привет" > "привет" ? alert("Привет больше") :"Привет" < "привет" ? alert("привет больше") : alert("они равны"); // привет
"Привет" > "Пока" ? alert("Привет больше") : "Привет" < "Пока" ? alert("Пока больше") : alert("они равны"); // Привет
45 > "53" ? alert("45 больше") : 45 < "53" ? alert("53 больше") : alert("они равны"); // 53
true > 3 ? alert("true больше") :true < 3 ? alert("3 больше") : alert("они равны"); // 3
3 > "5мм" ? alert("3 больше") : 3 < "5мм" ? alert("5мм больше") : alert("они равны или undefined"); // они равны
null > undefined ? alert("null больше") : null < undefined ? alert("undefined больше") : alert("они равны"); // они равны

alert("Введенные данные неверны!");