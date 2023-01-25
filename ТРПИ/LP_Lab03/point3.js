/* 3 задание */

function PrintPropForButton(element) {
    alert(`Свойства: \nРазмер шрифта: ${element.fontSize}\nВысота: ${element.height}\nШирина: ${element.width}\nЦвет фона: ${element.backgroundColor}`);
}
function PrintPropForReferance(element) {
    if(element.backgroundColor === undefined) {
        alert(`Свойства: \nРазмер шрифта: ${element.fontSize}\nШрифт: ${element.font}\nЦвет текста: ${element.textColor}`);
    }
    else {
        alert(`Свойства: \nРазмер шрифта: ${element.fontSize}\nШрифт: ${element.font}\nЦвет текста: ${element.textColor}\nЦвет фона: ${element.backgroundColor}`);
    }
}
let Button = {
    width: 200,
    height: 100,
    fontSize: 14,
    backgroundColor: "red",
    text: "Button"
}
let Referance = {
    fontSize: 15,
    textColor: "black",
    font: "Timew New Roman"
}
let Accent = {
    backgroundColor: "yellow"
}

if(confirm("Акцентные элементы?")) {
    let newButton = Object.assign(Button, Accent);
    let newReferance = Object.assign(Referance, Accent);
    PrintPropForButton(newButton);
    PrintPropForReferance(newReferance);
}
else {
    PrintPropForButton(Button);
    PrintPropForReferance(Referance);
}
