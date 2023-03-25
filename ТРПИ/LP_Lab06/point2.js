/* 2 задание DOM*/
class Product {
    constructor() {}
    codeProduct = 0;
    startPosition = document.querySelector(".list"); // получить элемент для гибкой вставки продуктов
    addProduct(img, name, cost) {
        let productForDiv = document.createElement("div");;
        productForDiv.setAttribute("data-code", this.codeProduct++);
        productForDiv.innerHTML = `<img src=\"${img}\" /><p class = \"name\">${name}</p><p class=\"money\">${cost}</p>`;
        this.startPosition.append(productForDiv.cloneNode(true));
    }
    delProduct(code) {
        let delPr = document.querySelector(`div[data-code=\"${code}\"]`);
        delPr.remove();
    }
    changeImg(code, str) {
        let changePr = document.querySelector(`div[data-code=\"${code}\"] > img`);
        changePr.setAttribute("src", str);
    }
    changeName(code, str) {
        let changePr = document.querySelector(`div[data-code=\"${code}\"] > p.name`);
        changePr.textContent = str;
    }
    changeMoney(code, str) {
        let changePr = document.querySelector(`div[data-code=\"${code}\"] > p.money`);
        changePr.textContent = str;
    }
}

class Button {
    constructor() {}
    codeButton = 0;
    addButton(width, height, text, color, code) {
        let button = document.createElement("button");
        let pos;
        if(code === undefined) {
            pos = document.querySelector(".list");
            button.style.width = width;
            button.style.height = height;
            button.style.backgroundColor = color;
            button.textContent = text;
            button.setAttribute("data-code", this.codeButton);
            pos.before(button);
        }
        else {
            pos = document.querySelector(`div[data-code=\"${code}\"]`);
            button.style.width = width;
            button.style.height = height;
            button.style.backgroundColor = color;
            button.textContent = text;
            pos.append(button);
        }
    }
    delButton(flag, code) {
        let pos;
        if(+flag == 1) {
            pos = document.querySelector(`div[data-code=\"${code}\"] > button`);
            pos.remove();
        }
        else {
            pos = document.querySelector(`button[data-code =\"${code}\"]`)
            pos.remove();
        }
    }
    setSize(flag, code, width, height) {
        let pos;
        if(+flag == 1) {
            pos = document.querySelector(`div[data-code=\"${code}\"] > button`);
            pos.style.width = width;
            pos.style.height = height;
        }
        else {
            pos = document.querySelector(`button[data-code =\"${code}\"]`);
            pos.style.width = width;
            pos.style.height = height;
        }
    }
    setBackgroundColor(flag, code, color) {
        let pos;
        if(+flag == 1) {
            pos = document.querySelector(`div[data-code=\"${code}\"] > button`);
            pos.style.backgroundColor = color;
        }
        else {
            pos = document.querySelector(`button[data-code =\"${code}\"]`);
            pos.style.backgroundColor = color;
        }
    }
    setText(flag, code, text) {
        let pos;
        if(+flag == 1) {
            pos = document.querySelector(`div[data-code=\"${code}\"] > button`);
            pos.textContent = text;
        }
        else {
            pos = document.querySelector(`button[data-code =\"${code}\"]`);
            pos.textContent = text;
        }
    }
}

let product = new Product();
let button = new Button();

product.addProduct("luk.png", "Лук репчатый", "12$"); // добавление продуктов
product.addProduct("potato.jpg", "Картошка", "13$");
product.addProduct("svekla.jpg", "Свекла", "122$");
product.addProduct("cucumber.jpg", "Огурец", "192$");
product.addProduct("chesnok.jpg", "Чеснок", "15$");
product.addProduct("carrot.jpg", "Морковь", "22$");


product.delProduct(2); // удаление продукта
//product.addProduct("svekla.jpg", "Свекла", "12$");

product.changeImg(0, "cucumber.jpg"); // установка фото
product.changeImg(0, "luk.png");

product.changeName(0, 'Лук королевский'); // изменение имени

product.changeMoney(0, "20$");

button.addButton("200px", "80px", "В корзину", "#3366CC", 0); // добавление кнопок
button.addButton("200px", "80px", "В корзину", "#3366CC", 1);
button.addButton("200px", "80px", "В корзину", "#3366CC", 3);
button.addButton("200px", "80px", "В корзину", "#3366CC", 4);
button.addButton("200px", "80px", "В корзину", "#3366CC", 5);
//button.addButton("200px", "80px", "В корзину", "#3366CC", 6);
button.addButton("200px", "80px", "Корзина", "#3366CC");

button.delButton(0,0); // удаление кнопки
button.addButton("200px", "90px", "Корзина", "green");
//button.delButton(0,0); // удаление кнопки
//button.delButton(1,6); // удаление кнопки
button.delButton(1,1); // удаление кнопки
button.delButton(1,4); // удаление кнопки

button.setSize(1, 0, "100px", "200px"); // изменение размера кнопки
button.setSize(1, 0, "200px", "80px");

button.setText(1, 0, "В мою корзину"); // изменение текста кнопки

button.setBackgroundColor(1, 0, "black"); // изменение цвета кнопки
button.setBackgroundColor(1, 0, "#3366CC");


let oddProd = document.querySelectorAll("div[data-code]"); // получение всел объектов продуктов
oddProd.forEach((item, index, oddProd) => { // изменение цвета нечетный элементов
    if(+index % 2 == 0) {
        item.style.backgroundColor = "gray";
    }
})

