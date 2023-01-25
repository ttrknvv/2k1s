/*
* 1 задание
* Возвращает x в степени n
*
* @param {number} x Число для возведения в степень
* @param {number} n Показатель степени
* @return {number} x в степени n
*/

function pow(x, n) {
    let result = 1;

    for(let i = 0; i < n; i++) {
        result *= x;
    }

    return result;
}

let x = prompt("x?", ""); // модальное окно с заголовком @param1, и текстом-заглушкой @param2
let n = prompt("n?", "");

if(n < 0) {
    alert( `Степень ${n} не поддерживается, введите целую степень, большую 0`);
}
else {
    alert(pow(x, n));
}