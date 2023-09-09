(function () {
    const btnRemover = '.removerVenda';
    const btnEditar = '.editarVenda';
    const btnVisualizar = '.visualizarVenda';
    const btnSalvar = '.btn-salvar';
    const modalEdicao = '#modalVendaEdicao';
    const modalVisualizacao = '#modalVendaVisualizacao';
    const tableVisualizaocao = '#tableVendaModalVisualizacao';

    IniciaElementos();

    function IniciaElementos() {
        $(document).on('click', btnSalvar, function () {
            Salvar(this);
        });

        $(document).on('click', btnRemover, function () {
            Remover(this);
        });

        $(document).on('click', btnEditar, function () {
            ObterVendaVisualizacao(this, true);
        });

        $(document).on('click', btnVisualizar, function() {
            ObterVendaVisualizacao(this, false);
        });
    }

    function ObterVendaVisualizacao(el, modoEdicao) {
        let id = el.dataset.idVenda;

            $.ajax({
                url: "/Vendas/ObterVenda",
                type: 'get',
                data: { vendaId: id, modoEdicao: modoEdicao }
            }).done(function (result) {
                if (result.sucesso == false) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao buscar a venda', result.mensagem);    
                } else {
                    $(modalVisualizacao).html(result);
                    $(modalVisualizacao).modal("show");
                    AplicaEstilizacao(tableVisualizaocao);
                }
            }).fail(function (jqXHR, textStatus, result) {
                Global.emitirAlertaCentralFixo('error', 'Erro ao buscar venda', result.mensagem);
            });        
    }

    function AplicaEstilizacao(tableId) {
        setTimeout(function () {
            $(tableId).DataTable({
                aging: $(tableId + " tr").length > 5,
                scrollY: "180px",
                bInfo: false,
                lengthChange: false, 
                searching: false,
                ordering: false,
                paging: false
            });

            $('[data-toggle="tooltip"]').tooltip();
        }, 200);
    }

})();