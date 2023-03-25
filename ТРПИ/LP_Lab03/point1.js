/* 1 задание do..while, if, includes, split, endsWith, forEach, toUpperCase, substr, join*/

let comment;
let maxLenght = 70;
do {
    comment = prompt("Ваш комментарий:", "Комментарий"); // проверка на длину
    if(comment.length > maxLenght) {
        alert(`Максимальная длина комментария: ${maxLenght} символов. Попробуйте ещё раз.`)
    }
} while(comment.length > maxLenght)

let editableComment = comment.split(" ");
editableComment.forEach((item, index, editableComment) => { // перебор элементов с заменой слов с "кот" на "*"
    if(item.includes("кот")) {
        item.endsWith(",") ? editableComment[index] = "*," : editableComment[index] = "*";
    }
});

editableComment.forEach((item, index, editableComment) => { // перебор элементов с заменой слов с "кот" на "*"
        item.includes("собак") ? editableComment[index] = item[0].toUpperCase() + item.substring(1, item.length) : editableComment[index];
});


editableComment.forEach((item, index, editableComment) => {
    item == "пес" ? editableComment[index] = "многоуважаемый " + item : index;
});

alert(editableComment.join(" "));