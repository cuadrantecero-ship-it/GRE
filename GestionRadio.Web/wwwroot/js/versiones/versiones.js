document.addEventListener("DOMContentLoaded", () => {
    inicializarVersiones();
});

function inicializarVersiones() {

    const btnNueva = document.getElementById("btnNuevaVersion");

    if (!btnNueva)
        return;

    btnNueva.addEventListener("click", abrirModalNuevaVersion);
}

async function abrirModalNuevaVersion() {

    try {

        const response = await fetch("/Versiones/Nueva");

        if (!response.ok)
            throw new Error("No fue posible abrir el formulario.");

        const html = await response.text();

        document.getElementById("contenedorModalVersion").innerHTML = html;

        inicializarModalVersion();

        const modal = new bootstrap.Modal(
            document.getElementById("modalNuevaVersion")
        );

        modal.show();

    }
    catch (error) {

        console.error(error);
        alert(error.message);

    }
}

function inicializarModalVersion() {

    const btnBuscar = document.getElementById("btnBuscarMaterial");
    const txtBuscar = document.getElementById("txtBuscarMaterial");
    const btnGuardar = document.getElementById("btnGuardarVersion");

    if (btnBuscar)
        btnBuscar.addEventListener("click", buscarMaterial);

    if (txtBuscar) {

        txtBuscar.addEventListener("keydown", function (e) {

            if (e.key === "Enter") {
                e.preventDefault();
                buscarMaterial();
            }

        });

    }

    if (btnGuardar)
        btnGuardar.addEventListener("click", guardarVersion);
}

async function buscarMaterial() {

    const txtBuscar = document.getElementById("txtBuscarMaterial");

    const codigo = txtBuscar.value.trim();

    if (codigo === "") {

        alert("Capture un código Dinesat.");

        txtBuscar.focus();

        return;
    }

    limpiarMaterial();

    try {

        const response = await fetch(
            "/Versiones/BuscarMaterial?codigo=" +
            encodeURIComponent(codigo));

        const resultado = await response.json();

        if (!response.ok || resultado.ok === false) {

            alert(resultado.mensaje);

            txtBuscar.focus();

            return;
        }

        document.getElementById("MaterialIdDinesat").value = resultado.materialId;
        document.getElementById("CodigoMaterial").value = resultado.codigoMaterial;
        document.getElementById("TituloMaterial").value = resultado.tituloMaterial;
        document.getElementById("DuracionSegundos").value = resultado.duracionSegundos;

    }
    catch (error) {

        console.error(error);

        alert("Error consultando Dinesat.");
    }
}

async function guardarVersion() {

    const dto = {

        idCampania:
            parseInt(document.getElementById("IdCampania").value),

        materialIdDinesat:
            parseInt(document.getElementById("MaterialIdDinesat").value),

        codigoMaterial:
            document.getElementById("CodigoMaterial").value,

        tituloMaterial:
            document.getElementById("TituloMaterial").value,

        duracionSegundos:
            parseInt(document.getElementById("DuracionSegundos").value),

        ordenRotacion:
            parseInt(document.getElementById("OrdenRotacion").value),

        preferente:
            document.getElementById("Preferente").checked

    };

    if (isNaN(dto.idCampania)) {

        alert("Seleccione una campaña.");

        return;
    }

    if (isNaN(dto.materialIdDinesat)) {

        alert("Debe seleccionar un material de Dinesat.");

        return;
    }

    if (isNaN(dto.ordenRotacion))
        dto.ordenRotacion = 1;

    try {

        const response = await fetch("/Versiones/Guardar", {

            method: "POST",

            headers: {
                "Content-Type": "application/json"
            },

            body: JSON.stringify(dto)

        });

        const resultado = await response.json();

        if (resultado.ok) {

            alert(resultado.mensaje);

            const modal = bootstrap.Modal.getInstance(
                document.getElementById("modalNuevaVersion"));

            if (modal)
                modal.hide();

            location.reload();

            return;
        }

        alert(resultado.mensaje);

    }
    catch (error) {

        console.error(error);

        alert("No fue posible guardar la versión.");
    }
}

function limpiarMaterial() {

    document.getElementById("MaterialIdDinesat").value = "";
    document.getElementById("CodigoMaterial").value = "";
    document.getElementById("TituloMaterial").value = "";
    document.getElementById("DuracionSegundos").value = "";
}