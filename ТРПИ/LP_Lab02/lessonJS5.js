/*
* 5 задание
*/

let data = prompt("Введите данные: ");
if(!isNaN(data)) {
    data = +data;
    if(!Number.isInteger(data)) {
        alert(`Округление до большего: ${Math.ceil(data)}, \nОкругление до меньшего: ${Math.floor(data)}, \nОкругление до ближайшего целого: ${Math.round(data)}`);
    }
    else {
        alert(`Число в 16-ричной системе счисления: ${data.toString(16).toUpperCase()}`);
    }
}
else {
    alert(`Текст в верхнем регистре: ${data.toUpperCase()}, \nТекст в малом регистре: ${data.toLowerCase()}`);
}

