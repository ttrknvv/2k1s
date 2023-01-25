/* 5 задание  func.name */

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
let s = 5;
function sum() {
    alert(s);
}

function makeCounter() {
    let currentCounter = 1;
     return function() {
         return currentCounter++;
     };
}

let str = argumentsFunc.name + " " + sum.name + " " + makeCounter.name;

alert(`Имена: ${str}`);