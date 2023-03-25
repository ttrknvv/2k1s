/* 4 задание Set, set.add, set.delete, set.has, set.size*/

let products = new Set();
let choise = 1;

while(+choise) {
    choise = prompt("Выберите действие:\n1) Добавить товар\n2) Удалить товар\n3) Проверить наличие товара\n4) Вывести количество товаров\n0) Выход")
    switch(+choise){
        case 0: break;
        case 1: products.add(prompt("Введите название товара:", ""));
                break;
        case 2: let name = prompt("Введите название товара:", "");
                products.has(name) ? products.delete(name) : alert("У вас нет такого товара!");
                break;
        case 3: products.has(prompt("Введите название товара:", "")) ? alert("У вас есть такой товар!") : alert("У вас нет такого товара!");
                break;
        case 4: alert(products.size);
                break;
        default: alert("Неправильный выбор.");
                break;
    }
}

