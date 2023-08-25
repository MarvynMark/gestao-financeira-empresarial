(function () {
    const inputDescricaoTipoProdutoModal = '#Descricao'
    const btnSalvar = '.btn-salvar';
    const modalProduto = 'modalProduto';
    const modalTipoProduto = 'modalTipoProduto';
    const selectTipoProduto = 'TipoDeProdutoId';
    const inputMoeda = '.input-moeda';
    const inputId = '#Produto_Id';
    const inputNome = '#Produto_Nome';
    const inputMarca = '#Produto_Marca';
    const inputModelo = '#Produto_Modelo';
    const inputQtdeEstoque = '#Produto_QtdeEmEstoque';
    const inputPrecoCusto = '#Produto_PrecoCusto';
    const inputPrecoVenda = '#Produto_PrecoFinal';
    const inputPrecoMaoDeObra = '#Produto_PrecoMaoDeObra';
    const inputDescricao = '#Produto_Descricao';
    const btnEditarProduto = '.editarProduto';
    const modalEdicaoProduto = 'modalEdicaoProduto';
    const btnRemoverProduto = '.removerProduto';


    IniciaElementos();

    function IniciaElementos() {
        $(inputMoeda).maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });

        // $("#TipoDeProdutoId").select2({
        //     placeholder: 'Selecione...',
        //     language: {
        //         noResults: function () {
        //             return "Informação não encontrada!";
        //         }
        //     }
        // })


        $(document).on('click', btnRemoverProduto, function () {
            RemoverProduto(this);
        });

        $(document).on('click', btnSalvar, function () {
            let _this = this;
            let elModalProduto = document.getElementById(modalProduto);
            let elModalTipoProduto = document.getElementById(modalTipoProduto);
            let elModalEdicaoProduto = document.getElementById(modalEdicaoProduto);

            if (elModalProduto.contains(_this)) {
                SalvarProduto(elModalProduto);
            } else if (elModalEdicaoProduto.contains(_this)) {
                EditarProduto(elModalEdicaoProduto);
            } else if (elModalTipoProduto.contains(_this)) {
                SalvarTipoProduto();
            }
        });

        $(document).on('click', btnEditarProduto, function () {
            ObterProdutoEdicao(this);
        });

    }

    function SalvarTipoProduto() {
        let descricao = $(inputDescricaoTipoProdutoModal).val()

        $.ajax({
            url: "/TipoProdutoEstoque/Cadastro",
            type: 'post',
            data: {
                descricao: descricao
            },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            if (result.sucesso) {
                AdicionaNovaOpcaoAoTipoProduto(result.id, descricao);
                Global.emitirAlertaFlutuante('success', result.mensagem);
                Global.fechaModal(modalTipoProduto);
            } else {
                Global.emitirAlertaDeAtencao(result.mensagem);
            }
        }).fail(function (jqXHR, textStatus, msg) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar tipo de produto', msg);
        });
    }

    function SalvarProduto(modal) {
        if (ValidaFomularioProduto()) {

            $.ajax({
                url: "/ProdutosEstoque/Cadastro",
                type: 'post',
                data: {
                    produtoEstoqueViewModel: obtemObjProduto(modal)
                },
                beforeSend: function () {
                    //$("#resultado").html("ENVIANDO...");
                }
            }).done(function (result) {
                if (result.sucesso) {
                    Global.emitirAlertaFlutuante('success', result.mensagem);
                    Global.fechaModal(modalProduto);
                    Global.atualizaPagina(3000);
                } else if (result.listaErros.length > 0) {
                    Global.emitirAlertaDeAtencao(result.listaErros);
                } else {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao salvar produto', result.mensagem);
                }
            }).fail(function (jqXHR, textStatus, msg) {
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar produto', msg);
            });
        }
    }

    function EditarProduto(modal) {
        $.ajax({
            url: "/ProdutosEstoque/Editar",
            type: 'post',
            data: {
                produtoEstoqueViewModel: obtemObjProduto(modal)
            },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            if (result.sucesso) {
                Global.emitirAlertaFlutuante('success', result.mensagem)
                Global.fechaModal(modalEdicaoProduto);
                Global.atualizaPagina(3000);
            } else {
                Global.emitirAlertaCentralFixo('error', 'Erro ao atualizar produto', result.mensagem)
            }
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao atualizar produto', result.mensagem)
        });
    }

    function AdicionaNovaOpcaoAoTipoProduto(id, descricao) {
        let elSelectTipoProduto = document.getElementById(selectTipoProduto);
        let option = document.createElement('option');

        option.text = descricao;
        option.value = id;
        elSelectTipoProduto.appendChild(option);
    }

    function obtemObjProduto(modal) {
        let id = modal.querySelector(inputId).value;
        let nome = modal.querySelector(inputNome).value;
        let marca = modal.querySelector(inputMarca).value;
        let modelo = modal.querySelector(inputModelo).value;
        let descricao = modal.querySelector(inputDescricao).value;
        let precoCusto = modal.querySelector(inputPrecoCusto).value.replace("R$ ", '');
        let precoFinal = modal.querySelector(inputPrecoVenda).value.replace('R$ ', '');
        let precoMaoDeObra = modal.querySelector(inputPrecoMaoDeObra).value.replace('R$', '');
        let qtdeEmEstoque = modal.querySelector(inputQtdeEstoque).value;
        let tipoProdutoId = modal.querySelector(`#${selectTipoProduto}`).value;


        let produto = {
            Produto: {
                Id: id,
                Nome: nome,
                Marca: marca,
                Modelo: modelo,
                Descricao: descricao,
                PrecoCusto: precoCusto,
                PrecoFinal: precoFinal,
                PrecoMaoDeObra: precoMaoDeObra,
                QtdeEmEstoque: qtdeEmEstoque
            },
            TipoDeProdutoId: tipoProdutoId
        }

        return produto;
    }

    // function FechaModal(modalId) {
    //     $('#' + modalId).modal('hide');
    // }

    // function AtualizaPagina(timeout = 0) {
    //     setTimeout(function () {
    //         location.reload();
    //     }, timeout);
    // }

    function ValidaFomularioProduto() {
        return true
        let precoCusto = $(inputPrecoCusto).val().replace('R$ ', '');
        let precoVenda = $(inputPrecoVenda).val().replace('R$ ', '');
        let precoMaoDeObra = $(inputPrecoMaoDeObra).val().replace('R$ ', '');

        if ($(inputNome).val() == "") {
            return false;
        }
        if ($(inputPrecoCusto).val() == "") {
            return false;
        }
        if (parseInt($(inputQtdeEstoque).val()) == 0 || parseInt($(inputQtdeEstoque).val()) < 0) {
            return false;
        }
        if (parseInt(precoCusto) < 1 || parseInt(precoVenda) < 1) {
            return false;
        }

        return true;
    }

    function ObterProdutoEdicao(el) {
        let id = el.dataset.idProduto;

        $.ajax({
            url: "/ProdutosEstoque/ObterProdutoEdicao",
            type: 'get',
            data: {
                id: id
            },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            $("#modalEdicaoProduto").html(result);
            $("#modalEdicaoProduto").modal("show");
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao buscar protudo', result.mensagem);
        });
    }

    function RemoverProduto(el) {
        let id = el.dataset.idProduto;
        //let isConfirmed = Global.emitirAlertaDeConfirmacaoDeRemocao('Tem certeza que deseja remover este produto?');

        Swal.fire({
            title: 'Tem certeza que deseja remover este produto?',
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
                    url: "/ProdutosEstoque/Remover",
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
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover o protudo', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover o protudo', result.mensagem);
                });
            }
        });
    }

})();