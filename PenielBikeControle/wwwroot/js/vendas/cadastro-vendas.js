(function () {
    const btnAddProduto = '#btnAddProduto';
    const btnRemoverProduto = '.btn-remover';
    const tabelaOrcamento = '#tabela-orcamento';
    const selectProtudo = '#selectProduto';
    const selectQtde = '#selectQtde';
    const dataPreco = 'data-preco';
    const dataPrecoMaoDeObra = 'data-precoMaoDeObra';
    const tdRemover = 'td-remover';
    const rowTable = 'row-table';
    const tdCodigo = 'codigo';
    const inputTotal = '#totalVenda';
    const inputResumo = '.input-resumo';
    const inputSubTotal = '#subTotalVenda';
    const inputDesconto = '#descontoVenda';
    const msgAlertaDesconto = '#msgAlertaDesconto';
    const btnSalvar = '#btnSalvar';
    const selectFuncionario = '#FuncionarioId';
    const selectCliente = '#ClienteId';
    const selectProdutoCliente = '#ProdutoClienteId';
    const inputDataVenda = '#Venda_Data';
    const checkVendaPaga = '#Venda_VendaPaga';
    const checkProdutoEntregue = '#Venda_ProdutoEstoqueEntregue';

    IniciaElementos();

    function IniciaElementos() {
        $(inputResumo).maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: true });

        $(tabelaOrcamento).DataTable({
            "paging": false,
            "scrollY": "200px",
            "scrollCollapse": true,
            "bInfo": false
        });
        EditaMsgDtTablesEmpty();

        $(document).on('click', btnAddProduto, function () {
            let produtoSelecionado = $(selectProtudo)[0];
            let qtdeProdutos = $(document).find(selectQtde).val();
            if (produtoSelecionado.selectedIndex > 0 && qtdeProdutos > 0) {
                AddProdTable();
                AdicionaRetiraFocoElementos();
            }
        });

        $(document).on('click', btnRemoverProduto, function () {
            let idTr = this.parentElement.parentElement.id;
            let table = $(tabelaOrcamento);
            let dtTable = table.DataTable();
            dtTable.row($('#' + idTr)).remove().draw();
            ReordenaRowTable();
            EditaMsgDtTablesEmpty();
            AtualizaValoresResumo();
        });

        $(document).on('keyup', inputDesconto, function () {
            CalculaResumo();
        });

        $(document).on('change', inputDesconto, function () {
            let elInputDesconto = $(inputDesconto);
            if (elInputDesconto[0].value == "0" || elInputDesconto[0].value == "") {
                elInputDesconto[0].value = "R$ 0,00";
            }
        });

        $(document).on('click', btnSalvar, function () {
            SalvarVenda()
        });
    }

    function AddProdTable() {
        let table = $(tabelaOrcamento);
        let dtTable = table.DataTable();
        let selectProduto = $(selectProtudo)[0];
        let elSelectQtde = $(selectQtde)[0];
        let selectedProdOption = selectProduto.options[selectProduto.selectedIndex];
        let selectedQtdeOption = elSelectQtde.options[elSelectQtde.selectedIndex];
        let preco = parseInt(selectedProdOption.getAttribute(dataPreco));
        let precoMaoDeObra = parseInt(selectedProdOption.getAttribute(dataPrecoMaoDeObra));
        let cod = selectedProdOption.value;
        let nome = selectedProdOption.text;
        let qtde = parseInt(selectedQtdeOption.text);
        let elInputDesconto = $(inputDesconto);

        table = table[0];

        let totalRows = table.rows[1].cells[0].className.includes('dataTables_empty') ? 1 : table.rows.length;
        let newRow = dtTable.row.add([
            totalRows,                                   // row
            qtde,                                        // Qtde
            cod,                                         // Cód.
            nome,                                        // Protudo
            `R$ ${preco},00`,                            // Valor Unit.
            `R$ ${precoMaoDeObra},00`,                   // Valor Mão de Obra
            `R$ ${qtde * (preco + precoMaoDeObra)},00`,  // Valor Total
            "Remover"                                    // ...
        ]).node().id = 'tr-' + totalRows + cod;

        dtTable.draw();

        $(dtTable.cell($('#' + newRow), 0).node()).addClass(rowTable);
        $(dtTable.cell($('#' + newRow), 2).node()).addClass(tdCodigo);
        $(dtTable.cell($('#' + newRow), 7).node()).addClass(tdRemover);
        $(dtTable.cell($('#' + newRow), 7).node()).html('<a class="btn btn-danger btn-remover" href="#">remover</a>');

        const elementsTdRemover = document.querySelectorAll(`.${tdRemover}`);
        elementsTdRemover.forEach(elemento => elemento.style.verticalAlign = 'middle');

        elInputDesconto[0].disabled = false;
        AtualizaValoresResumo();
    }

    function EditaMsgDtTablesEmpty() {
        let table = $(tabelaOrcamento)[0];
        let elInputDesconto = $(inputDesconto);
        if (table.rows.length > 0) {
            if (table.rows[1].cells[0].className.includes('dataTables_empty')) {
                table.rows[1].cells[0].textContent = 'Nenhum produto adicionado'
                elInputDesconto[0].disabled = true;
                elInputDesconto[0].value = "R$ 0,00";
            } else {
                elInputDesconto[0].disabled = false;
            }

        }
    }

    function SalvarVenda() {
        let venda = ObterDadosDaVenda();
        
        $.ajax({
            url: '/Vendas/Salvar',
            type: 'post',
            data: venda,
            beforeSend: function () {
            }
        }).done(function (result) {
            if (result.sucesso) {
                Global.emitirAlertaCentralFixo('success', result.mensagem, "");
                Global.atualizaPagina(3000);
            } else if (result.listaErros != undefined && result.listaErros.length > 0) {
                Global.emitirAlertaDeAtencao(result.listaErros);
            } else {
                Global.emitirAlertaCentralFixo('error', 'Erro ao salvar a venda', result.mensagem);
            } 
        }).fail(function (jqXHR) {
            Global.emitirAlertaCentralFixo('error', 'Erro ao salvar a venda', jqXHR.responseText);
        });
    }

    function ReordenaRowTable() {
        let table = $(tabelaOrcamento);
        let dtTable = table.DataTable();
        let rows_sorting = $(`.${rowTable}`);
        for (let index = 0; index < rows_sorting.length; index++) {
            let newIndex = index + 1;
            let row_table = rows_sorting[index].parentElement;
            let codigo = row_table.getElementsByClassName(tdCodigo)[0].innerHTML;
            rows_sorting[index].innerHTML = newIndex;
            row_table.id = `tr-${newIndex}${codigo}`
        }

        dtTable.order([1, 'asc']).draw();
        // corrigir: A sequência numérica da primeira coluna está correta mas a posição/ordem das linhas não estão. 
    }

    function AtualizaValoresResumo() {
        let table = $(tabelaOrcamento);
        let dtTable = table.DataTable();
        let elInputTotal = $(inputTotal);
        let elInputSubTotal = $(inputSubTotal);
        let total = 0;

        dtTable.column(6).data().each(function (value, index) {
            value = value.replace('R$ ', '');
            if (value.includes('.') && value.replace(',')) {
                value = value.replace('.', '').replace(',', '.');
            }
            total += parseFloat(value);
        });

        elInputTotal[0].value = total == 0 ? "R$ 0,00" : total;
        elInputSubTotal[0].value = total == 0 ? "R$ 0,00" : total;

        CalculaResumo();
    }

    function AdicionaRetiraFocoElementos() {
        let elInputTotal = $(inputTotal);
        let elInputSubTotal = $(inputSubTotal);

        if (elInputTotal[0].value != "0" && elInputTotal[0].value != "R$ 0,00") {
            elInputTotal.focus();
            elInputTotal.blur();
        }
        if (elInputSubTotal[0].value != "0" && elInputSubTotal[0].value != "R$ 0,00") {
            elInputSubTotal.focus();
            elInputSubTotal.blur();
        }
    }

    function CalculaResumo() {
        let elMsgAlertaDesconto = $(msgAlertaDesconto);
        let valueDesconto = $(document).find(inputDesconto).val();
        let valueSubTotal = $(document).find(inputSubTotal).val();
        let subTotal = 0;
        let desconto = 0;
        let total = 0;

        desconto = parseFloat(ToDecimal(valueDesconto).replace(',', '.'));
        subTotal = parseFloat(ToDecimal(valueSubTotal).replace(',', '.'));

        total = subTotal - desconto;
        if (total.toString().includes('.') && total.toString().split('.')[1].length > 2) {
            total = parseFloat(total.toFixed(2));
        }

        if (total < 0) {
            elMsgAlertaDesconto[0].innerHTML = "Atenção! <br>O Valor do desconto é maior que o valor SubTotal.";
        } else {
            elMsgAlertaDesconto[0].innerHTML = "";
        }

        let totalValue = total == 0 ? "R$ 0,00" : total.toString().replace('.', ',')
        $(document).find(inputTotal).val(totalValue);

        AdicionaRetiraFocoElementos();
    }

    function ObterDadosDaVenda() {
        let funcionarioId = $(document).find(selectFuncionario).val();
        let clienteId = $(document).find(selectCliente).val();
        let produtoClienteId = $(document).find(selectProdutoCliente).val();
        let dataDaVenda = $(document).find(inputDataVenda).val();
        let vendaPaga = $(checkVendaPaga).is(':checked');
        let produtoEntregue = $(checkProdutoEntregue).is(':checked');
        let tabOrcamento = $(document).find(tabelaOrcamento);
        let desconto = $(document).find(inputDesconto).val();
        let itensVenda = [];
        let dtTable = tabOrcamento.DataTable();

        dtTable.rows().data().each(function (col, index) {
            let codigo = col[2];
            let qtde = col[1];

            itensVenda.push(`${codigo};${qtde};${produtoClienteId}`);
        });

        let result = {
            DataVenda: dataDaVenda,
            ClienteId: clienteId,
            FuncionarioId: funcionarioId,
            VendaPaga: vendaPaga,
            ProdutoEntregue: produtoEntregue,
            Desconto: ToDecimal(desconto),
            ItensVenda: itensVenda
        }
        return result;
    }

    function ToDecimal(num) {
        let value = num.replace('R$ ', '');

        if (value.includes('.') && value.includes(',')) {
            value = value.replace('.', '');
        }

        return value;
    }

})();