

function newEvent(elemento, evento, fn) {
    if (elemento.addEventListener) {
        elemento.addEventListener(evento, fn, false);
    } else {
        elemento.attachEvent('on' + evento, fn);
    }
}

