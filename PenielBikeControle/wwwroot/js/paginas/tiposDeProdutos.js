(function () {
    const inputDescricao = '#Descricao';
    const btnSalvar = '.btn-salvar';
    const btnEditar = '.editarTipoProduto';
    const btnRemover = '.removerTipoProduto';
    const modalTipoProduto = 'modalTipoProduto';
    const modalEdicaoTipoProduto = 'modalEdicaoTipoProduto';

    IniciaElementos();
    

    function IniciaElementos() {
        $(document).on('click', btnSalvar, function () {
            let _this = this;
            let elModalTipoProduto = document.getElementById(modalTipoProduto);
            let elModalEdicaoTipoProduto = document.getElementById(modalEdicaoTipoProduto);

            if (elModalTipoProduto.contains(_this)) {
                Salvar(elModalTipoProduto);
            } else if (elModalEdicaoTipoProduto.contains(_this)) {
                Salvar(elModalEdicaoTipoProduto);
            } 

        });

        $(document).on('click', btnRemover, function () {
            Remover(this);
        });

        $(document).on('click', btnEditar, function () {
            ObterTipoProdutoEdicao(this);
        });
    }

    function Salvar(modal) {
        let tipoProduto = ObterDadosTipoProduto(modal);

        $.ajax({
            url: '/TipoProdutoEstoque/Salvar',
            type: 'post',
            data: tipoProduto,
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            beforeSend: function () {
            }
        }).done(function (result) {
            if (result.sucesso) {
                Global.emitirAlertaFlutuante('success', result.mensagem);
                Global.fechaModal(modal.id);
                Global.atualizaPagina(3000);
            } else if (result.listaErros != undefined && result.listaErros.length > 0) {
                Global.emitirAlertaDeAtencao(result.listaErros);
            } else {
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o Tipo de Produto', result.mensagem);
            }
        }).fail(function (jqXHR, textStatus, msg) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o Tipo de Produto', msg);
        });
    }

    function ObterDadosTipoProduto(modal) {
        let id = modal.querySelector('#Id').value;
        let descricao = modal.querySelector(inputDescricao).value;

        let tipoProduto = {
            Id: id,
            Descricao: descricao
        }

        return tipoProduto;
    }

    function Remover(el) {
        let id = el.dataset.idTipoProduto;
        //let isConfirmed = Global.emitirAlertaDeConfirmacaoDeRemocao('Tem certeza que deseja remover este produto?');

        Swal.fire({
            title: 'Tem certeza que deseja remover este Tipo de Produto?',
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
                    url: "/TipoProdutoEstoque/Remover",
                    type: 'delete',
                    data: { id: id },
                    headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
                }).done(function (result) {
                    if (result.sucesso) {
                        Global.emitirAlertaCentralFixo('success', 'Removido!', result.mensagem);
                        Global.atualizaPagina(3000);
                    } else {
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover o Tipo de Produto', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover o Tipo de Produto', result.mensagem);
                });
            }
        });
    }

    function ObterTipoProdutoEdicao(el) {
        let id = el.dataset.idTipoProduto;

        $.ajax({
            url: "/TipoProdutoEstoque/ObterTipoProdutoEdicao",
            type: 'get',
            data: { id: id }
        }).done(function (result) {
            $("#modalEdicaoTipoProduto").html(result);
            $("#modalEdicaoTipoProduto").modal("show");
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao buscar o Tipo de Produto', result.mensagem);
        });
    }

})();