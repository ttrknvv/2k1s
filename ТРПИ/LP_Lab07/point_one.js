/*querySelector, события, onmousemove, onclick, onmousedown, event*/

const dart = document.querySelector('.dart');
const wrapper = document.querySelector('.game-block');
let startX = -480;
let startY = -100;
let x = startX;
let y = startY;
let wasClicked = false;

dart.onmousedown = function(event) {
    if (wasClicked) {
        document.body.onmousemove = null;
        document.body.onclick = () => animate(x, y, startX, startY);
        return;
    }
    dart.style.zIndex = '1000';
    wasClicked = wasClicked ? false : true;
    document.body.onmousemove = function(event) {
        if (startX === -480 && startY === -100) {
            startX = event.clientX - 5;
            dart.style.left = `${startX}px`;
            startY = event.clientY + 6;
            dart.style.top = `${startY}px`;
            dart.style.cursor = "none";
            document.body.append(dart);
        }
        if (Math.abs(startX - event.clientX) < 480) {
            x = event.clientX - 5;
        }
        if (Math.abs(startY - event.clientY) < 90) {
            y = event.clientY - 10;
            dart.style.backgroundColor = `#${Math.abs(startY - event.clientY)}${100 - Math.abs(startY - event.clientY)}00`;
        }
        dart.style.left = `${x}px`;
        dart.style.top = `${y}px`;
    };
};

function animate(x, y, startX, startY) {
    dart.style.backgroundColor = `#009900`;
    let dx = (startX - x);
    let dy = (startY - y);
    let tg = dy / dx;
    startX = dx < 0 ? startX - 3 * Math.abs(dx) : startX + 3 * Math.abs(dx);
    startY = dy < 0 ? startY - 3 * Math.abs(tg * dx) : startY + 3 * Math.abs(tg * dx);
    dart.style.left = `${startX}px`;
    dart.style.top = `${startY}px`;
}