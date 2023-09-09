var Global = (function () {
    
    function emitirAlertaFlutuante(tipo, titulo) {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })
        Toast.fire({
            icon: tipo,
            title: titulo
        })
    }

    function emitirAlertaCentralFixo(tipo, titulo, mensagem) {
        Swal.fire({
            icon: tipo,
            title: titulo,
            text: mensagem
          })
    }

    function emitirAlertaDeAtencao(listaDeErros) {
        let content = "";
        
        if (Array.isArray(listaDeErros)) {
            listaDeErros.forEach(element => {
                content += `- ${element}<br>`
            });
        } else {
            content = `- ${listaDeErros}`
        }

        Swal.fire({
            icon: 'error',
            title: 'Atenção!',
            html: `<div style='display: block;text-align: left;'>${content}</div>`
          })
    }

    function emitirAlertaCentralTemporario(tipo, titulo) {
        Swal.fire({
            position: 'center',
            icon: tipo,
            title: titulo,
            showConfirmButton: false,
            timer: 1500
          })
    }

    function emitirAlertaDeConfirmacaoDeRemocao(mensagem) {
        Swal.fire({
            title: mensagem,
            text: "Voê não poderá reverter isso!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim, remover!',
            cancelButtonText: 'Cancelar'
          }).then((result) => {
            return result.isConfirmed
          })
    }

    function atualizaPagina(timeout = 0) {
        setTimeout(function () {
            location.reload();
        }, timeout);
    }

    function fechaModal(modalId) {
        $('#' + modalId).modal('hide');
    }

    function validaCpf(elCampoCpf) {
        let cpf = elCampoCpf.value;

        if (cpf.length < 15) {
            cpf = MaskCpf(cpf);
            elCampoCpf.value = cpf;
        } else {
            cpf = cpf.slice(0, 14);
            elCampoCpf.value = cpf;
        }

        if (cpf.length == 14){
            if (cpfEhValido(cpf)) {
                elCampoCpf.style.borderColor = '#d1d3e2';
            } else {
                elCampoCpf.style.borderColor = 'red';
            }
        } else if (cpf.length == 0) {
            elCampoCpf.style.borderColor = '#d1d3e2';
        } else {
            elCampoCpf.style.borderColor = 'red';
        }
    }

    function cpfEhValido(cpf) {
        if (cpf == undefined) {
            return false;
        }

        cpf = cpf.replace(/\./g, "").replace("-", "");
        
        var Soma;
        var Resto;
        Soma = 0;
        if (cpf == "00000000000") return false;
    
        for (i=1; i<=9; i++) Soma = Soma + parseInt(cpf.substring(i-1, i)) * (11 - i);
        Resto = (Soma * 10) % 11;
        
        if ((Resto == 10) || (Resto == 11))  Resto = 0;
        if (Resto != parseInt(cpf.substring(9, 10)) ) return false;
        
        Soma = 0;
        for (i = 1; i <= 10; i++) Soma = Soma + parseInt(cpf.substring(i-1, i)) * (12 - i);
        Resto = (Soma * 10) % 11;
    
        if ((Resto == 10) || (Resto == 11))  Resto = 0;
        if (Resto != parseInt(cpf.substring(10, 11) ) ) return false;
        return true;
    }

    function MaskCpf(value){
        value=value.replace(/\D/g,"")                    //Remove tudo o que não é dígito
        value=value.replace(/(\d{3})(\d)/,"$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
        value=value.replace(/(\d{3})(\d)/,"$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
        value=value.replace(/(\d{3})(\d{1,2})$/,"$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
        return value
    }

    function maskMoney(className, timeout = 0) {
        setTimeout(function () {
            $(className).maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });

            $(className).each(function(el) {
                $(this).focus();
                $(this).blur();
            });
        }, timeout);
    }
  
    return {
        emitirAlertaFlutuante: emitirAlertaFlutuante,
        emitirAlertaCentralFixo: emitirAlertaCentralFixo,
        emitirAlertaCentralTemporario: emitirAlertaCentralTemporario,
        emitirAlertaDeAtencao: emitirAlertaDeAtencao,
        atualizaPagina: atualizaPagina,
        fechaModal: fechaModal,
        emitirAlertaDeConfirmacaoDeRemocao: emitirAlertaDeConfirmacaoDeRemocao,
        validaCpf: validaCpf,
        cpfEhValido: cpfEhValido,
        maskMoney: maskMoney
    };
  })();