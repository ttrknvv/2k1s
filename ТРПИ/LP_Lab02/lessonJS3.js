/*
* 3 задание
*/

let nameStudent = prompt("Введите имена студентов через пробел: ");

let countStudent = 0;

for(let i = 0; i < nameStudent.length; i++) {
    if(nameStudent[i] == " ") { countStudent++; }
}

if(countStudent) { countStudent++; }

alert(`Количество присутствующих студентов: ${countStudent}`);