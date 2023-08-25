(function () {
    const tituloDaPagina = '#titulo-da-pagina';
    const tituloDaPaginaLayout = "titulo-da-pagina-layout";
    const btnFecharModal = '.btn-fechar-modal';

    IniciaElementos();


    function IniciaElementos() {
        defineTituloDaPagina();
        aplicaEstiloAosElementos();

        $(document).on('click', btnFecharModal, function () {
            fecharModal(this);
        });
    }

    function aplicaEstiloAosElementos() {
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
    }



    function defineTituloDaPagina() {
        let elTituloDaPagina = $(tituloDaPagina);
        let elTituloDaPaginaLayout = document.getElementById(tituloDaPaginaLayout)

        elTituloDaPaginaLayout.innerHTML = elTituloDaPagina.val();
    }

    function fecharModal(btnClicado) {
        let modal = $('.modal');

        for (let index = 0; index < modal.length; index++) {
            let elModal = modal[index];
            if (elModal.contains(btnClicado)) {
                $('#' + elModal.id).modal('hide');
                break;
            }
        }
    }


    // $(document).ready(function () {
    //     $('.table').DataTable();

    //     $(".select").select2({
    //         placeholder: 'Selecione...',
    //         theme: "classic",
    //         language: {
    //             noResults: function () {
    //                 return "Informação não encontrada!";
    //             }
    //         }
    //     })
    //     $(".select-one").select2({
    //         theme: "classic",
    //         tags: true
    //     })
    // })
})();