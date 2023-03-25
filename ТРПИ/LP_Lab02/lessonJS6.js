/*
* 6 задание
*/

let dictionaryWord = "ежовый";
let data = prompt("Введите правильно: еж-вый");

if(dictionaryWord == data) {
    alert("Правильно!");
}

if(dictionaryWord.length == data.length) {
    for(let i = 0; i < dictionaryWord.length; i++) {
        if(dictionaryWord[i] != data[i]) {
            alert(`У вас ошибка в ${i + 1} символе`);
            break;
        }
    }
}
else {
    alert("Введите слово полностью!");
}