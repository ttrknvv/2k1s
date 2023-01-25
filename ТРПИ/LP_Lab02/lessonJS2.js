/*
* 2 задание
*/

function getParametrs(firstP = 2, secondP, thirdP = 1) {
    alert(`Ваши параметры: ${firstP} , ${secondP} , ${thirdP}`)
}

getParametrs(undefined, undefined, prompt("Введите 3-ий параметр: "));

