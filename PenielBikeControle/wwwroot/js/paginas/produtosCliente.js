(function () {
    const inputNome = '#Nome';
    const inputModelo = '#Modelo';
    const inputMarca = '#Marca';
    const inputDescricao = '#Descricao';
    const btnSalvar = '.btn-salvar';
    const btnEditar = '.editarProdutoCliente';
    const btnRemover = '.removerProdutoCliente';
    const modalProdutoCliente = 'modalProdutoCliente';
    const modalEdicaoProdutoCliente = 'modalEdicaoProdutoCliente';
    const selectCliente = '#ClienteId';

    IniciaElementos();
    

    function IniciaElementos() {
        $(document).on('click', btnSalvar, function () {
            let _this = this;
            let elModalProdutoCliente = document.getElementById(modalProdutoCliente);
            let elModalEdicaoProdutoCliente = document.getElementById(modalEdicaoProdutoCliente);

            if (elModalProdutoCliente.contains(_this)) {
                Salvar(elModalProdutoCliente);
            } else if (elModalEdicaoProdutoCliente.contains(_this)) {
                Salvar(elModalEdicaoProdutoCliente);
            } 

        });

        $(document).on('click', btnRemover, function () {
            Remover(this);
        });

        $(document).on('click', btnEditar, function () {
            ObterProdutoClienteEdicao(this);
        });
    }

    function Salvar(modal) {
        let produtoCliente = ObterDadosProdutoCliente(modal);

        $.ajax({
            url: '/ProdutosCliente/Salvar',
            type: 'post',
            data: produtoCliente,
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
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o produto do cliente', result.mensagem);
            } 
        }).fail(function (jqXHR) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o produto do cliente', jqXHR.responseText);
        });
    }

    function ObterDadosProdutoCliente(modal) {
        let id = modal.querySelector('#Id').value;
        let nome = modal.querySelector(inputNome).value;
        let marca = modal.querySelector(inputMarca).value;
        let modelo = modal.querySelector(inputModelo).value;
        let descricao = modal.querySelector(inputDescricao).value;
        let clienteId = modal.querySelector(selectCliente).value;

        let produtoCliente = {
                Id: id,
                Nome: nome,
                Marca: marca,
                Modelo: modelo,
                Descricao: descricao,
                ClienteId: clienteId
        }
        
        return produtoCliente;
    }

    function Remover(el) {
        let id = el.dataset.idProdutoCliente;
        //let isConfirmed = Global.emitirAlertaDeConfirmacaoDeRemocao('Tem certeza que deseja remover este produto?');

        Swal.fire({
            title: 'Tem certeza que deseja remover este produto do cliente?',
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
                    url: "/ProdutosCliente/Remover",
                    type: 'delete',
                    data: { id: id }
                }).done(function (result) {
                    if (result.sucesso) {
                        Global.emitirAlertaCentralFixo('success', 'Removido!', result.mensagem);
                        Global.atualizaPagina(3000);
                    } else {
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover o produto do cliente', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover o produto do cliente', jqXHR.responseText);
                });
            }
        });
    }

    function ObterProdutoClienteEdicao(el) {
        let id = el.dataset.idProdutoCliente;

        $.ajax({
            url: "/ProdutosCliente/ObterProdutoClienteEdicao",
            type: 'get',
            data: { id: id }
        }).done(function (result) {
            if (result.sucesso == false) {
                Global.emitirAlertaCentralFixo('error', 'Erro ao obter o produto do cliente', result.mensagem);    
            } else {
                $("#modalEdicaoProdutoCliente").html(result);
                $("#modalEdicaoProdutoCliente").modal("show");
            }
        }).fail(function (jqXHR) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao buscar o produto do cliente', jqXHR.responseText);
        });
    }

})();