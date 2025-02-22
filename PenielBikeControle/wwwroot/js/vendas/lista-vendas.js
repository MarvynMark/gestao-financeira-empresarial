(function () {
    const btnRemover = '.removerVenda';
    const btnEditar = '.editarVenda';
    const btnVisualizar = '.visualizarVenda';
    const btnSalvar = '.btn-salvar';
    const modalVisualizacao = '#modalVendaVisualizacao';
    const tableVisualizaocao = '#tableVendaModalVisualizacao';
    const inputId = '#VendaId';
    const inputDataVenda = '#DataDaVenda';
    const inputDesconto = '#Desconto';
    const checkVendaPaga = '#VendaPaga';
    const checkProdutoEntregue = '#ProdutoEntregue';
    


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

    function obtemDadosDaVenda() {
        let modal = document.getElementById(modalVisualizacao.replace('#', ''));

        let id = modal.querySelector(inputId).value;
        let dataDaVenda = modal.querySelector(inputDataVenda).value;
        let desconto = modal.querySelector(inputDesconto).value.replace("R$ ", '');
        let vendaPaga = modal.querySelector(checkVendaPaga).value;
        let produtoEntregue = modal.querySelector(checkProdutoEntregue).value;

        let venda = {
            VendaId: id,
            DataDaVenda: dataDaVenda,
            Desconto: desconto,
            VendaPaga: vendaPaga,
            ProdutoEntregue: produtoEntregue
        }

        return venda;
    }

    function Remover(el) {
        let id = el.dataset.idVenda;

        Swal.fire({
            title: 'Tem certeza que deseja remover esta venda?',
            text: "Você não poderá reverter isso!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim, remover!',
            cancelButtonText: 'Cancelar'
          }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/Vendas/Remover",
                    type: 'delete',
                    data: {
                        id: id
                    },
                    beforeSend: function () {
                        //$("#resultado").html("ENVIANDO...");
                    }
                }).done(function (result) {
                    if (result.sucesso) {
                        Global.emitirAlertaCentralFixo('success', 'Removido!', result.mensagem);
                        Global.atualizaPagina(3000);
                    } else {
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover a venda', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover a venda', result.mensagem);
                });
            }
        });
    }

    function Salvar() {
        let data = obtemDadosDaVenda();

        $.ajax({
            url: "/Vendas/SalvarEdicao",
            type: 'post',
            data: { edicaoVendaDTO: data },
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            if (result.sucesso) {
                Global.emitirAlertaFlutuante('success', result.mensagem);
                Global.atualizaPagina(3000);
            } else {
                Global.emitirAlertaDeAtencao(result.mensagem);
            }
        }).fail(function (jqXHR, textStatus, msg) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao editar a venda', msg);
        });
    }

})();