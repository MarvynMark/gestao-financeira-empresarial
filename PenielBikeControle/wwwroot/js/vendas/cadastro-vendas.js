let btnAddProduto = '#btnAddProduto';
let btnRemoverProduto = '.btn-remover';
let tabelaOrcamento = '#tabela-orcamento';
let selectProtudo = '#selectProduto';
let selectQtde = '#selectQtde';
let dataPreco = 'data-preco';
let dataPrecoMaoDeObra = 'data-precoMaoDeObra'
let tdRemover = 'td-remover';
let rowTable = 'row-table';

window.onload = function () {
     EditaMsgDtTablesEmpty();
}
$(document).on('click', btnAddProduto, function () {
     AddProdTable();
});
$(document).on('click', btnRemoverProduto, function () {
     let idTr = this.parentElement.parentElement.id;
     let table = $(tabelaOrcamento);
     let dtTable = table.DataTable();
     dtTable.row($('#' + idTr)).remove().draw();
     EditaMsgDtTablesEmpty();
     ReordenaRowTable();
});


function AddProdTable() {
     let table = $(tabelaOrcamento);
     let dtTable = table.DataTable();
     let selectProduto = $(selectProtudo)[0];
     let elSelectQtde = $(selectQtde)[0];
     table = table[0];

     let selectedProdOption = selectProduto.options[selectProduto.selectedIndex];
     let selectedQtdeOption = elSelectQtde.options[elSelectQtde.selectedIndex];

     let preco = parseInt(selectedProdOption.getAttribute(dataPreco));
     let precoMaoDeObra = parseInt(selectedProdOption.getAttribute(dataPrecoMaoDeObra));
     let cod = selectedProdOption.value;
     let nome = selectedProdOption.text;
     let Qtde = parseInt(selectedQtdeOption.text);

     let totalRows = table.rows[1].cells[0].className.includes('dataTables_empty') ? 1 : table.rows.length;
     let newRow = dtTable.row.add([
          totalRows,                                   // row
          Qtde,                                        // Qtde
          cod,                                         // Cód.
          nome,                                        // Protudo
          `R$ ${preco},00`,                            // Valor Unit.
          `R$ ${precoMaoDeObra},00`,                   // Valor Mão de Obra
          `R$ ${Qtde * (preco + precoMaoDeObra)},00`,  // Valor Total
          "Remover"                                    // ...
     //]).nodes().to$().addClass('tr-' + totalRows + cod);
     ]).node().id = 'tr-' + totalRows + cod;

     dtTable.draw();

     $(dtTable.cell($('#' + newRow), 0).node()).addClass(rowTable);
     $(dtTable.cell($('#' + newRow), 7).node()).addClass(tdRemover);
     $(dtTable.cell($('#' + newRow), 7).node()).html('<a class="btn btn-danger btn-remover" href="#">remover</a>');

     // $(dtTable.cell(newRow, 0).node()).addClass('row-table');
     // $(dtTable.cell(newRow, 7).node()).addClass('td-remover');
     // $(dtTable.cell(newRow, 7).node()).html('<a class="btn btn-danger btn-remover" href="#">remover</a>');

     //  table = table[0];
     //  //table.rows.sort(x => x._DT_RowIndex)
     //  for (var i = 1; i < table.rows.length; i++) {
     //      var rowIndex = table.rows[i]._DT_RowIndex;

     //      var arrClass = table.rows[i].cells[0].className.split(' ')
     //      var checker  = value => !['sorting_'].some(element => value.includes(element));
     //      var findClass = arrClass.filter(checker);
     //      table.rows[i].cells[0].className = '';
     //      for (let index = 0; index < findClass.length; index++) {
     //           table.rows[i].cells[0].className = table.rows[i].cells[0].className + findClass[index] + " "
     //      }
     //      table.rows[i].cells[0].className = table.rows[i].cells[0].className + 'sorting_' + rowIndex;
     //      table.rows[i].cells[0].textContent = rowIndex
     //      //table.rows[i].cells[0].className.replace(findClass[0], 'sorting_' + i)
     //  }

}

function EditaMsgDtTablesEmpty () {
     let table = $(tabelaOrcamento)[0];
     if (table.rows.length > 0) {
          if (table.rows[1].cells[0].className.includes('dataTables_empty')) {
               table.rows[1].cells[0].textContent = 'Nenhum produto adicionado'
          }
     }
}

function SalvarVenda() {
     $.ajax({
          url: "@Url.Action('Cadastro', 'Vendas')",
          type: 'post',
          data: {
               nome: "Maria Fernanda",
               salario: '3500'
          },
          beforeSend: function () {
               $("#resultado").html("ENVIANDO...");
          }
     })
          .done(function (msg) {
               $("#resultado").html(msg);
          })
          .fail(function (jqXHR, textStatus, msg) {
               alert(msg);
          });
}

function ReordenaRowTable() {
     let rows = $(`.${rowTable}`);
     for (let index = 0; index < rows.length; index++) {
          rows[index].innerHTML = index + 1;
     }
}
