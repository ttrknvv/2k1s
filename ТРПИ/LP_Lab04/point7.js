/* 7 задание генератор, next, naxt().value, yeild, function*, object, свойства, значения */

function *generatePointRightTop(point, hands) {
    yield ++point
}

function *generatePointLeftDown(point, hands) {
    yield --point;
}

let Person = {
    x: 0,
    y: 0
};

let choise;
for(let i = 0; i < 5; i++) {
    choise = prompt("Выберите куда пойдем: ", "");
    switch(choise) {
        case "right": Person.x = generatePointRightTop(Person.x, choise).next().value;
                      break;
        case "left": Person.x = generatePointLeftDown(Person.x, choise).next().value;
                     break;
        case "top": Person.y = generatePointRightTop(Person.y, choise).next().value;
                    break;
        case "down": Person.y = generatePointLeftDown(Person.y, choise).next().value;
                     break;
        default: alert("Неправильно задано навравление!");
                 --i;
                 break;
    }
}

alert(`Координаты, на который вы пришли:\nx = ${Person.x}\ny = ${Person.y}`);