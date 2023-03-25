/*
* 13, 14, 15, 16 задание
*/
let sum1 = true + true; // 2
let sum2 = 0 + "5"; // "05"
let sum3 = 5 + "мм"; // "5мм"
let sum4 = 8 / Infinity; // 0
let sum5 = 9 * "\n9"; // 81
let sum6 = null - 1; // -1
let sum7 = "5" - 2; // 3
let sum8 = "5px" - 3; // NaN
let sum9 = true - 3; // -2
let sum10 = 7 || 0; // 7

for(let i = 1; i <= 10; i++) {
    if(!(i % 2)) {
        console.log(i + 2);
        continue;
    }
    console.log(i + "мм");
}

let inputData = 1;
while(inputData < 100) {
    inputData = prompt("Введите число(< 100):", "");
}

let dayNumber = prompt("Введите день недели, а я выведу его название!", "");
switch(+dayNumber) {
    case 1: alert("Понедельник!");
            break;
    case 2: alert("Вторник!");
            break;
    case 3: alert("Среда!");
            break;
    case 4: alert("Четверг!");
            break;
    case 5: alert("Пятница!");
            break;
    case 6: alert("Суббота!");
            break;
    case 7: alert("Воскресенье!");
            break;
    default: alert("Неправильно введен номер!");
            break;
}