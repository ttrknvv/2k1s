/* 2 задание object, свойства, значение, for..in, undefined */

let days = {
    "1": "Понедельник",
    "2": "Вторник",
    "3": "Среда",
    "4": "Четверг",
    "5": "Пятница",
    "6": "Суббота",
    "7": "Воскресенье",
};
let choise = prompt("Введите цифру для недели: ", "");
days[choise] === undefined ? alert("Такого дня не существует!") : alert(days[choise]);

alert("Все нечетные дни: ");
let count = 0;
for(key in days) {
    if(key % 2 != 0) {
        alert(days[key]);
        count++;
    }
}
alert(`Количество: ${count}`)