(function () {
    const inputNomeUsuario = '#nomeUsuario';
    const inputLogin = '#login';
    const inputEmail = '#email';
    const inputPassword = '#password';
    const inputConfirmePassword = '#confirmePassword'
    const btnRegistrarConta = '#btnRegistrarConta';

    iniciaElementos();

    function iniciaElementos() {

        $(document).on('click', btnRegistrarConta, function () {
            salvar();
        });

        $(document).on('keyup', inputLogin, function() {
            validaLogin(this);
        });

        $(document).on('keyup', inputConfirmePassword, function() {
            
        });

        $(document).on('keyup', inputEmail, function() {
            
        });
    }


    function salvar() {
        let dadosRegistro = obtemDadosDeRegistro();

        $.ajax({
            url: "/Usuarios/CadastrarConta",
            type: 'post',
            data: {
                usuarioDTO: dadosRegistro
            },
            beforeSend: function () {
                //$("#resultado").html("ENVIANDO...");
            }
        }).done(function (result) {
            if (result.sucesso) {
                Swal.fire({
                    title: 'Conta cadastrada com sucesso!',
                    text: "Agora você pode fazer login com seu usuário e senha cadastrados",
                    icon: 'success',
                    showCancelButton: false,
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'Ir para a página de login!',
                  }).then(() => {
                    window.location.href = '/Login'
                });
            } else {
                Global.emitirAlertaCentralFixo('error', 'Erro ao registrar a conta', result.mensagem)
            }
        }).fail(function (jqXHR, textStatus, result) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao registrar a conta', result.mensagem)
        });
    }

    function obtemDadosDeRegistro() {
        let nome = modal.querySelector(inputNomeUsuario).value;
        let login = modal.querySelector(inputLogin).value;
        let email = modal.querySelector(inputEmail).value;
        let password = modal.querySelector(inputPassword).value;
        let confirmePassword = modal.querySelector(inputConfirmePassword).value;

        let obj = {
            Nome: nome,
            Login: login,
            Email: email,
            Senha: password,
            ConfirmeSenha: confirmePassword
        }

        return obj;
    }

    function validaLogin(el) {
        if (el.value.length == 0) return;

        const regex = /^[a-zA-Z0-9]+$/;

        if (regex.test(el.value)) {
            if (el.value.length < 5) {
                
            } else {

            }
        } else {
            el.value = el.value.replace(/[^a-zA-Z0-9]/g, "");
            var msg = $(document).find('.login-invalido-msg');
            msg.show();
            setTimeout(function(){
                msg.hide();
            }, 2000); 
        }

    }

    

})();