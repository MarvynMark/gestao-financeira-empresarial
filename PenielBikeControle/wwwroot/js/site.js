const tituloDaPagina = '#titulo-da-pagina';
const tituloDaPaginaLayout = "#titulo-da-pagina-layout";

IniciaElementos();

$(document).ready(function () {
    $('.table').DataTable();

    $(".select").select2({
        placeholder: 'Selecione...',
        theme: "classic",
        language: {
            noResults: function () {
                return "Informação não encontrada!";
            }
        }
    })
    $(".select-one").select2({
        theme: "classic",
        tags: true
    })
})

function IniciaElementos() {
    let elTituloDaPagina = $(tituloDaPagina);
    let elTituloDaPaginaLayout = $(tituloDaPaginaLayout);

    elTituloDaPaginaLayout[0].innerHTML =  elTituloDaPagina[0].value;
}