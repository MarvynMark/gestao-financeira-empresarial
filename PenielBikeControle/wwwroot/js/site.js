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
        if ($('.table').length > 0) {
            $('.table').DataTable();
        }

        if ($(".select").length > 0) {
            $(".select").select2({
                placeholder: 'Selecione...',
                theme: "classic",
                language: {
                    noResults: function () {
                        return "Informação não encontrada!";
                    }
                }
            })
        }
        
        if ($(".select-one").length > 0) {
            $(".select-one").select2({
                theme: "classic",
                tags: true
            })
        }
        
        $('[data-toggle="tooltip"]').tooltip();
    }



    function defineTituloDaPagina() {
        let elTituloDaPagina = $(tituloDaPagina);
        let elTituloDaPaginaLayout = document.getElementById(tituloDaPaginaLayout)

        if (elTituloDaPaginaLayout != null) {
            elTituloDaPaginaLayout.innerHTML = elTituloDaPagina.val();
        }
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

    $(document).on('click', '#logout', function (e) {
        e.preventDefault(); 
        $.ajax({
            url: "/Login/Logout",
            type: "POST",
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            success: function (response) {
                if (response.success) {
                    window.location.href = response.redirectUrl; 
                }
            },
            error: function (e) {
                alert("Erro ao fazer logout. Tente novamente.");
            }
        });
    });

})();