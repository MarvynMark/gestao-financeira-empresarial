(function () {
    const inputNome = '#Nome';
    const inputCpf = '.cpf';
    const inputTelefone = '#Telefone';
    const inputEndereco = '#Endereco';
    const inputDataNascimento = '#DataDeNascimentoStr';
    const btnSalvar = '.btn-salvar';
    const btnEditar = '.editarCliente';
    const btnRemover = '.deletarCliente';
    const btnAddCliente = '#btnAddCliente';
    const modalCliente = 'modalCliente';
    const modalEdicaoCliente = 'modalEdicaoCliente';

    IniciaElementos();
    

    function IniciaElementos() {
        $(document).on('click', btnSalvar, function () {
            let _this = this;
            let elModalCliente = document.getElementById(modalCliente);
            let elModalEdicaoCliente = document.getElementById(modalEdicaoCliente);

            if (elModalCliente.contains(_this)) {
                SalvarCliente(elModalCliente);
            } else if (elModalEdicaoCliente.contains(_this)) {
                SalvarCliente(elModalEdicaoCliente);
            } 

        });

        $(document).on('click', btnRemover, function () {
            RemoverCliente(this);
        });

        $(document).on('click', btnEditar, function () {
            ObterClienteEdicao(this);
        });

        $(document).on('keyup', inputCpf, function() {
            Global.validaCpf(this);
        });

        $(document).on('keyup', inputTelefone, function() {
            this.value = Global.phoneMask(this.value);
        });
    }

    function SalvarCliente(modal) {
        let cliente = ObterDadosCliente(modal);

        if (cliente.Cpf.length != 0 && !Global.cpfEhValido(cliente.Cpf)) {
            Global.emitirAlertaDeAtencao('CPF informado é inválido!');
            return;
        }

        $.ajax({
            url: '/Clientes/Salvar',
            type: 'post',
            data: cliente,
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
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o cliente', result.mensagem);
            }
        }).fail(function (jqXHR, textStatus, msg) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar o cliente', msg);
        });
    }

    function ObterDadosCliente(modal) {
        let id = modal.querySelector('#Id').value;
        let nome = modal.querySelector(inputNome).value;
        let dataNascimento = modal.querySelector(inputDataNascimento).value;
        let cpf = modal.querySelector(inputCpf).value;
        let endereco = modal.querySelector(inputEndereco).value;
        let telefone = modal.querySelector(inputTelefone).value.replace(/[\(\)\-\s]/g, "");

        let cliente = {
            Id: id,
            Nome: nome,
            DataDeNascimentoStr: dataNascimento,
            Cpf: cpf,
            Telefone: telefone,
            Endereco: endereco
        }

        return cliente;
    }

    function RemoverCliente(el) {
        let id = el.dataset.idCliente;
        //let isConfirmed = Global.emitirAlertaDeConfirmacaoDeRemocao('Tem certeza que deseja remover este produto?');

        Swal.fire({
            title: 'Tem certeza que deseja remover este cliente?',
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
                    url: "/Clientes/Remover",
                    type: 'delete',
                    data: { id: id }
                }).done(function (result) {
                    if (result.sucesso) {
                        Global.emitirAlertaCentralFixo('success', 'Removido!', result.mensagem);
                        Global.atualizaPagina(3000);
                    } else {
                        Global.emitirAlertaCentralFixo('error', 'Erro ao remover o cliente', result.mensagem);    
                    }
                }).fail(function (jqXHR, textStatus, result) {
                    Global.emitirAlertaCentralFixo('error', 'Erro ao remover o cliente', result.mensagem);
                });
            }
        });
    }

    function ObterClienteEdicao(el) {
        let id = el.dataset.idCliente;

        $.ajax({
            url: "/Clientes/ObterClienteEdicao",
            type: 'get',
            data: { id: id }
        }).done(function (result) {
            $("#modalEdicaoCliente").html(result);
            $("#modalEdicaoCliente").modal("show");
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao buscar cliente', result.mensagem);
        });
    }

})();