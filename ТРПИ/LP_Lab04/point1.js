/* 1 задание функция без параметров, функции и замыкания, arguments, typeof */

function argumentsFunc() {
    let str = "";
    if(arguments.length <= 3) {
        for(let i = 0; arguments[i] !== undefined; i++) {
            str += arguments[i] + " ";
        }
        alert(str);
    } 
    if(arguments.length > 3 && arguments.length <= 5) {
        for(let i = 0; arguments[i] !== undefined; i++) {
            str += typeof(arguments[i]) + " ";
        }
        alert(str);
    }
    if(arguments.length > 5 && arguments.length <= 7) {
        alert(arguments.length);
    }
    if(arguments.length > 7) {
        alert("Превышено количество аргументов!");
    }
}

let choise = 1;
while(choise) {
    choise = +prompt("Выберите:\n1) вызвать функцию с менее 3-мя параметрами\n2) Вызвать функцию с более 3 и менее 5 параметрами\n3) Вызвать функцию с более 5 и менее 7 параметрами\n4) Вызвать функцию с более 7 параметрами\n0) Выход")
    switch(choise) {
        case 0: break;
        case 1: alert("Вызов с 0 параметров: "); argumentsFunc();
                alert("Вызов с 1 параметром: "); argumentsFunc(2);
                alert("Вызов с 2 параметрами: "); argumentsFunc(3, 4);
                alert("Вызов с 3 параметрами: "); argumentsFunc(1, 2, 3);
                break;
        case 2: alert("Вызов с 4 параметрами: "); argumentsFunc(1, [1, 2, 3], "monk", 12);
                alert("Вызов с 5 параметрами: "); argumentsFunc(1, 2, "monk", 12, "rrr");
                break;
        case 3: alert("Вызов с 6 параметрами: "); argumentsFunc(1, 2, "monk", 12, "rrr", 9);
                alert("Вызов с 7 параметрами: "); argumentsFunc(1, 2, "monk", 12, "rrr", 7, 9);
                break;
        case 4: alert("Вызов с 8 параметрами: "); argumentsFunc(1, 2, "monk", 12, "rrr", 7, 9, 10);
                alert("Вызов с 9 параметрами: "); argumentsFunc(1, 2, "monk", 12, "rrr", 7, 9, 10, 1);
                break;
        default: alert("Неправильно задан номер выбора!");
                break;
    }
}