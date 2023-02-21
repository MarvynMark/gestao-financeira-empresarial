// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function Start() {
    
}

Start()


$(document).ready(function () {
    $('.table').DataTable()

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
