/* 5 задание Map, map.set, map.get, map.has, key, value, map.keys() */

function addProd(basket, id) {
    let info = [];
    let name = prompt("Введите название товара: ", "");
    info[0] = id;
    info[1] = prompt("Введите количество: ", "");
    while(+info[1] <= 0) {
        alert("Неправильно задано количество товаров!");
        info[1] = prompt("Введите количество: ", "");
    }
    info[2] = prompt("Введите цену:", "");
    while(+info[2] <= 0) {
        alert("Неправильно задана цена!");
        info[2] = prompt("Введите цену: ", "");
    }
    basket.set(name, info);
}

function delProd(basket) {
    let name = prompt("Введите название товара: ", "");
    basket.has(name) ? basket.delete(name) : alert("У вас нет такого товара!");
}

function findProd(basket) {
    let name = prompt("Введите название товара: ", "");
    if(basket.has(name)) {
        alert(`Информация о товаре:\nНазвание: ${name}\nId: ${basket.get(name)[0]}\nКоличество: ${basket.get(name)[1]}\nЦена: ${basket.get(name)[2]}`);
    }
    else {
        alert("У вас нет такого товара!");
    }
}
function getInfoBasket(basket) {
    let count = 0;
    let sum = 0;
    for(let key of basket.keys()) {
        count += +basket.get(key)[1];
        sum += +basket.get(key)[2] * +basket.get(key)[1];
    }
    alert(`Общее количество: ${count}\nОбщая цена: ${sum}`);
}

function replaceCount(basket) {
    let name = prompt("Введите название товара: ", "");
    if(basket.has(name)) {
        let count = prompt("Введите количество: ", "");
        while(count <= 0) {
            alert("Неправильно задано количество товаров!");
            count = +prompt("Введите количество: ", "");
        }
        basket.get(name)[1] = count;
    }
    else {
        alert("У вас нет такого товара!");
    }
 }
let product = [];
let basket = new Map();
let id = 0;

let choise = 1;

while(+choise) {
    choise = prompt("Выберите действие:\n1) Добавить товар\n2) Удалить товар\n3) Найти товар\n4) Вывести количество и общую сумму\n5) Изменить количество товара\n0) Выход", "");
    switch(+choise) {
        case 0: break;
        case 1: addProd(basket, id++);
                break;
        case 2: delProd(basket);
                break;
        case 3: findProd(basket);
                break;
        case 4: getInfoBasket(basket);
                break;
        case 5: replaceCount(basket);
                break;
        default: alert("Неправильный выбор.");
                break;
    }

}