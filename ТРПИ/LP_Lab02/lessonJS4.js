function breakIntoTime(timeSecond) {
    let year = Math.trunc(timeSecond / (12 * 30 * 24 * 3600));
    let month  = Math.trunc((timeSecond - (year * 12 * 30 * 24 * 3600)) / (30 * 24 * 3600));
    let day = Math.trunc((timeSecond - (year * 12 * 30 * 24 * 3600) - (month * 30 * 24 * 3600)) / (24 * 3600));
    let hours = Math.trunc((timeSecond - (year * 12 * 30 * 24 * 3600) - (month * 30 * 24 * 3600) - (day * 24 * 3600)) / 3600);
    let minits = Math.trunc((timeSecond - (year * 12 * 30 * 24 * 3600) - (month * 30 * 24 * 3600) - (day * 24 * 3600) - (hours * 3600)) / 60);
    let second = Math.trunc((timeSecond - (year * 12 * 30 * 24 * 3600) - (month * 30 * 24 * 3600) - (day * 24 * 3600) - (hours * 3600) - (minits * 60)))

    alert(`Лет: ${year}, месяцев: ${month}, дней: ${day}, часов: ${hours}, минут: ${minits}, секунд: ${second}`);
}
let countLetter = 5;
let countNumber = 3;
let timePassword = 3;

let possibleCombination = Math.pow(10, countNumber) * Math.pow(26, countLetter);
let timeCombination = possibleCombination * 3; 
breakIntoTime(timeCombination);
breakIntoTime(24 * 3600);

