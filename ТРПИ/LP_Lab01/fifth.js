/*
* 9, 10, 11, 12 задание
* Функция проверки ответа на вопрос
*
* @param {string} question Вопрос в модальном окне
* @param {number} rightAnswer Правильный ответ на вопрос
*/
function askQuestion(question, rightAnswer) {
    let answer = prompt(question, "");
    answer == rightAnswer ? alert("Ответ правильный!") : alert("Ответ неправильный!");
}

let question = "Очень секретный вопрос... Сколько у здорового человека пальцев на руках?";
let rightAnswer = 10;
askQuestion(question, rightAnswer);

function checkData(data, rightData) {
    if(data != rightData)  return false;
    return true;
}

let login = "ttrknvv";
let passwords = "7411803";
let loginUser = prompt("Введите логин:", "");
let passwordsUser = prompt("Введите пароль");
if(checkData(login, loginUser) && checkData(passwords, passwordsUser)) alert("Вход успешный!");
else alert("Неправильно введен логин/ пароль.");

let markRussian = prompt("Введите оценку за русский язык:", "");
let markBelarussian = prompt("Введите оценку за белорусский язык:", "");
let markMath = prompt("Введите оценку за математику:", "");
if(markRussian >= 4 && markBelarussian >= 4 && markMath >= 4) {
    alert("Вы пережили сессию!");
}
else if(markRussian < 4 && markBelarussian < 4 && markMath < 4) {
    alert("Ты не сдал сессию и подлежишь отчислению((((");
}
else {
    alert("Тебя ожидает пересдача! Готовься!");
}

let a = prompt("Введите число a:", "");
let b = prompt("Введите число b", "");
let sum = (a, b) => +a + +b;
alert(`Cумма чисел a и b = ${sum(a, b)}.`);