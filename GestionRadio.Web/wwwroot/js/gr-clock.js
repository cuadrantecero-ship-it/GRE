"use strict";

function actualizarReloj() {

    const reloj = document.getElementById("grClock");

    if (!reloj)
        return;

    const ahora = new Date();

    reloj.innerHTML =
        ahora.toLocaleTimeString("es-MX", {
            hour12: false
        });
}

setInterval(actualizarReloj, 1000);

actualizarReloj();