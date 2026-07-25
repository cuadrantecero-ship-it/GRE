document.addEventListener("DOMContentLoaded", () => {
    inicializarVersiones();
});

function inicializarVersiones() {
    configurarBotonNuevaVersion();
}

//==========================================================
// NUEVA VERSION
//==========================================================

function configurarBotonNuevaVersion() {

    const boton = document.getElementById("btnNuevaVersion");

    if (!boton)
        return;

    boton.addEventListener("click", abrirModalNuevaVersion);
}

async function abrirModalNuevaVersion() {

    try {

        const response = await fetch("/Versiones/Nueva");

        if (!response.ok)
            throw new Error("No fue posible abrir el formulario.");

        const html = await response.text();

        document.getElementById("contenedorModalVersion").innerHTML = html;

        const modalElement = document.getElementById("modalNuevaVersion");

        const modal = new bootstrap.Modal(modalElement);

        modal.show();

        configurarBotonGuardar();
        configurarBotonBuscarMaterial();

    }
    catch (error) {

        console.error(error);

        alert(error.message);

    }

}

//==========================================================
// BUSCAR MATERIAL
//==========================================================

function configurarBotonBuscarMaterial() {

    const boton = document.getElementById("btnBuscarMaterial");

    if (!boton)
        return;

    boton.addEventListener("click", buscarMaterial);

}

async function buscarMaterial() {

    try {

        const codigo = document
            .getElementById("txtBuscarMaterial")
            .value
            .trim();

        if (codigo === "") {

            alert("Capture un código de material.");

            return;

        }

        const response = await fetch(
            `/Versiones/BuscarMaterial?codigo=${encodeURIComponent(codigo)}`
        );

        if (!response.ok)
            throw new Error("No fue posible consultar Dinesat.");

        const resultado = await response.json();

        if (!resultado.ok) {

            alert(resultado.mensaje);

            return;

        }

        document.getElementById("MaterialId").value =
            resultado.materialId;

        document.getElementById("CodigoMaterial").value =
            resultado.codigo;

        document.getElementById("TituloMaterial").value =
            resultado.titulo;

        document.getElementById("DuracionSegundos").value =
            resultado.duracion;

    }
    catch (error) {

        console.error(error);

        alert(error.message);

    }

}

//==========================================================
// GUARDAR VERSION
//==========================================================

function configurarBotonGuardar() {

    const boton = document.getElementById("btnGuardarVersion");

    if (!boton)
        return;

    boton.addEventListener("click", guardarVersion);

}

async function guardarVersion() {

    try {

        const modelo = {

            idCampania: Number(document.getElementById("IdCampania").value),

            materialId: Number(document.getElementById("MaterialId").value),

            codigoMaterial: document.getElementById("CodigoMaterial").value,

            tituloMaterial: document.getElementById("TituloMaterial").value,

            duracionSegundos: Number(document.getElementById("DuracionSegundos").value),

            ordenRotacion: Number(document.getElementById("OrdenRotacion").value),

            preferente: document.getElementById("Preferente").checked

        };

        const response = await fetch("/Versiones/Guardar", {

            method: "POST",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(modelo)

        });

        if (!response.ok)
            throw new Error("No fue posible guardar la versión.");

        const resultado = await response.json();

        if (!resultado.ok) {

            alert(resultado.mensaje);

            return;

        }

        bootstrap.Modal
            .getInstance(document.getElementById("modalNuevaVersion"))
            .hide();

        location.reload();

    }
    catch (error) {

        console.error(error);

        alert(error.message);

    }

}