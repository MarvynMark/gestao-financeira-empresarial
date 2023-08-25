(function () {
    const modalFuncionario = 'modalFuncionario'
    const modalEdicaoFuncionario = 'modalEdicaoFuncionario'
    const btnSalvar = '.btn-salvar';
    const inputNome = '#Nome';
    const inputDataNascimento = '#DataDeNascimentoStr';
    const inputCpf = '.cpf';
    const inputEndereco = '#Endereco';
    const btnRemover = '.deletarFuncionario';
    const btnEditarFuncionario = '.editarFuncionario';

    IniciaElementos();

    function IniciaElementos() {

        $(document).on('click', btnSalvar, function () {
            let _this = this;
            let elModalFuncionario = document.getElementById(modalFuncionario);
            let elModalEdicaoFuncionario = document.getElementById(modalEdicaoFuncionario);

            if (elModalFuncionario.contains(_this)) {
                SalvarFuncionario(elModalFuncionario);
            } else if (elModalEdicaoFuncionario.contains(_this)) {
                SalvarFuncionario(elModalEdicaoFuncionario);
            } 

        });

        $(document).on('click', btnRemover, function () {
            RemoverFuncionario(this);
        });

        $(document).on('click', btnEditarFuncionario, function () {
            ObterFuncionarioEdicao(this);
        });

        $(document).on('keyup', inputCpf, function() {
            Global.validaCpf(this);
        });

    }

    function SalvarFuncionario(modal) {
        let funcionario = ObterDadosFuncionario(modal);

        if (funcionario.Cpf.length != 0 && !Global.cpfEhValido(funcionario.Cpf)) {
            Global.emitirAlertaDeAtencao('CPF informado é inválido!');
            return;
        }

        $.ajax({
            url: '/Funcionarios/Salvar',
            type: 'post',
            data: funcionario,
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
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o funcionário', result.mensagem);
            }
        }).fail(function (jqXHR, textStatus, msg) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o funcionário', msg);
        });
    }

    function ObterDadosFuncionario(modal) {
        let id = modal.querySelector('#Id').value;
        let nome = modal.querySelector(inputNome).value;
        let dataNascimento = modal.querySelector(inputDataNascimento).value;
        let cpf = modal.querySelector(inputCpf).value;
        let endereco = modal.querySelector(inputEndereco).value;

        let funcionario = {
            Id: id,
            Nome: nome,
            DataDeNascimentoStr: dataNascimento,
            Cpf: cpf,
            Endereco: endereco
        }

        return funcionario;
    }

    function RemoverFuncionario(el) {
        let id = el.dataset.idFuncionario;
        //let isConfirmed = Global.emitirAlertaDeConfirmacaoDeRemocao('Tem certeza que deseja remover este produto?');

        Swal.fire({
            title: 'Tem certeza que deseja remover este funcionário?',
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
                    url: "/Funcionarios/Remover",
                    type: 'delete',
                    data: { id: id }
                }).done(function (result) {
                    if (result.sucesso) {
                        Global.emitirAlertaCentralFixo('success', 'Removido!', result.mensagem);
                        Global.atualizaPagina(3000);
                    } else {
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover o funcionário', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover o funcionário', result.mensagem);
                });
            }
        });
    }

    function ObterFuncionarioEdicao(el) {
        let id = el.dataset.idFuncionario;

        $.ajax({
            url: "/Funcionarios/ObterFuncionarioEdicao",
            type: 'get',
            data: {
                id: id
            },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            $("#modalEdicaoFuncionario").html(result);
            $("#modalEdicaoFuncionario").modal("show");
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao buscar funcionário', result.mensagem);
        });
    }

})();