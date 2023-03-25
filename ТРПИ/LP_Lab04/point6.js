/* 6 задание каррирование*/

function getParallelepipedSquare(a) {
    return(b) => {
        return(c) => {
            return a * b * c;
        }
    }
}

let choise = 1;
while(choise) {
    choise = +prompt("Выберите:\n1) Рассчитать площадь по 3 длинам\n2) Рассчитать площадь по 2 длинам(высота по умолчанию)\n0) Выход");
    let lenghts = [];
    switch(choise) {
        case 0: break;
        case 1:  for(let i = 0; i < 3; i++) {
                    lenghts[i] = +prompt(`Bведите длину ${i + 1} стороны: `, "");
                }
                alert(`Площадь: ${getParallelepipedSquare(lenghts[0])(lenghts[1])(lenghts[2])}`)
                break;
        case 2: let constFunc = getParallelepipedSquare(2);
                for(let i = 0; i < 2; i++) {
                    lenghts[i] = +prompt(`Bведите длину ${i + 1} стороны: `, "");
                }
                alert(`Площадь с высотой по умолчанию: ${constFunc(lenghts[0])(lenghts[1])}`);
                break;
        default: alert("Неправильно задан номер!");
                break;
    }
}