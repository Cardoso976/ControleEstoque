var sequencia = 1,
    produtos = [];
var getProdutos = function () {
    $.ajax({
        type: "GET",
        url: "/EntradaProdutos/GetProdutos",
        async: false,
        success: function (result) {
            if (result.data == null || result.data.length == 0) {
                iziToast.info({
                    title: 'Info',
                    message: 'Nenhum Produto Encontrado',
                    position: 'topRight'
                });
            }
            else {
                produtos = result.data;
            }
        }
    });
};

getProdutos();

var incluirLinhaProduto = function () {
    $('#grid tbody').append(getNovaLinha(sequencia));
    sequencia++;
};

var getOptionsProdutos = function () {
    let linhas;
    produtos.forEach(produto => {
        linhas += '<option value="' + produto.ProdutoId + '">' + produto.Descricao + '</option>';
    });
    return linhas;
};

var getNovaLinha = function (linha) {
    let linhas = getOptionsProdutos(),
        texto =
            '<tr>' +
            '    <td>' +
            '        <select name="" id="dd_produto_' + linha + '" class="form-control">' +
            '           ' + linhas + '' +
            '        </select>' +
            '    </td>' +
            '    <td>' +
            ' <input type="number" id="txt_quantidade_' + linha + '" class="form-control" value="" min=0>' +
            '    </td>' +
            '</tr>';
    return texto;
};

var formatarData = function (data) {
    let dia = ('0' + data.getDate()).slice(-2);
    let mes = ('0' + (data.getMonth() + 1)).slice(-2);
    return data.getFullYear() + "-" + mes + "-" + dia;
};

var limparTela = function () {
    $('#txt_numero').val('');
    $('#grid tbody').empty();
    incluirLinhaProduto();
};

var obterListaEntradas = function () {
    let ret = [];
    $('#grid tbody tr').each(function (index, item) {
        var txt_quantidade = $(this).find('input'),
            ddl_produto = $(this).find('select'),
            quantidade = parseInt(txt_quantidade.val()),
            produto = parseInt(ddl_produto.val());
        if (quantidade > 0) {
            ret.push({ ProdutoId: produto, Quantidade: quantidade });
        }
    });
    return ret;
}

$(document).ready(function () {
    let hoje = new Date();
    $('#txt_data').val(formatarData(hoje));
    limparTela();
})
    .on('click', '#btn_incluir', function () {
        incluirLinhaProduto();
    })
    .on('click', '#btn_salvar', function () {
        let btn = $(this);
        var lista_entradas = obterListaEntradas();
        if (lista_entradas.length == 0) {
            swal('Aviso', 'Para salvar, você deve informar produtos com quantidades.', 'warning');
        }
        else {
            var url = '/EntradaProdutos/Salvar',
                dados = {
                    data: $('#txt_data').val(),
                    produtos: JSON.stringify(lista_entradas)
                };
            $.post(url, add_anti_forgery_token(dados), function (response) {
                if (response.Sucesso != null) {
                    $('#txt_numero').val(response.Sucesso);
                    iziToast.success({
                        title: 'Sucesso',
                        message: 'Entrada de produtos salva com sucesso.',
                        position: 'topRight'
                    });
                } else {
                    iziToast.error({
                        title: 'Erro',
                        message: response.Erro,
                        position: 'topRight'
                    });
                }
            });
        }
    })
    .on('click', '#btn_cancelar', function () {
        var lista_entradas = obterListaEntradas();
        if (lista_entradas.length == 0 || $('#txt_numero').val() != '') {
            limparTela();
        }
        else {
            swal({
                text: 'Deseja realmente cancelar a entrada dos produtos?',
                type: 'info',
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                cancelButtonText: 'Não',
                confirmButtonClass: 'btn-primary',
                confirmButtonText: 'Sim'
            }).then(function (opcao) {
                if (opcao.value) {
                    limparTela();
                }
            });
        }
    });