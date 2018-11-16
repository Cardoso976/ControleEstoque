var sequencia = 1,
    produtos = [];

var getProdutos = function () {
    $.ajax({
        type: "GET",
        url: "/SaidaProduto/GetProdutos",
        async: false,
        success: function (result) {
            if (result.Entidade == null || result.Entidade.length == 0) {
                iziToast.info({
                    title: 'Info',
                    message: 'Nenhum Produto Encontrado',
                    position: 'topRight'
                });
            }
            if (result.Erro != null) {
                iziToast.erro({
                    title: 'Erro',
                    message: result.Erro,
                    position: 'topRight'
                });
            }
            else {
                produtos = result.Entidade;
            }
        }
    });
};

getProdutos();

var formatarData = function (data) {
    var dia = ("0" + data.getDate()).slice(-2);
    var mes = ("0" + (data.getMonth() + 1)).slice(-2);
    return data.getFullYear() + "-" + mes + "-" + dia;
};


var incluirLinhaProduto = function () {
    $("#grid tbody").append(getNovaLinha(sequencia));
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
            '       <input type="number" id="txt_quantidade_' + linha + '" class="form-control" value="" min=0>' +
            '    </td>' +
            '    <td>' +
            '        <a class="btn btn-warning btn_remover" role="button">' +
            '            <i class="glyphicon glyphicon-trash"></i>' +
            '        </a>' +
            '    </td>' +
            '</tr>';
    return texto;
};

var limparTela = function () {
    $("#txt_numero").val("");
    $("#grid tbody").empty();
    incluirLinhaProduto();
};

var obterListaProdutos = function () {
    var ret = [];

    $("#grid tbody tr").each(function (index, item) {
        var txt_quantidade = $(this).find("input"),
            ddl_produto = $(this).find("select"),
            quantidade = parseInt(txt_quantidade.val()),
            produto = parseInt(ddl_produto.val());

        if (quantidade > 0) {
            ret.push({ ProdutoId: produto, Quantidade: quantidade });
        }
    });

    return ret;
};

$(document)
    .ready(function () {
        var hoje = new Date();
        $("#txt_data").val(formatarData(hoje));

        limparTela();
    })
    .on("click", "#btn_incluir", function () {
        incluirLinhaProduto();
    })
    .on("click", "#btn_salvar", function () {
        var btn = $(this);
        var listaSaidas = obterListaProdutos();

        if (listaSaidas.length == 0) {
            swal(
                "Aviso",
                "Para salvar, você deve informar produtos com quantidades.",
                "warning"
            );
        } else {
            var url = '/SaidaProduto/Salvar',
                dados = {
                    data: $("#txt_data").val(),
                    produtos: JSON.stringify(listaSaidas)
                };

            $.post(url, add_anti_forgery_token(dados), function (response) {
                if (response.Sucesso != null) {
                    $("#txt_numero").val(response.Sucesso);
                    iziToast.success({
                        title: 'Sucesso',
                        message: 'saída de produtos salva com sucesso.',
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
    .on("click", "#btn_cancelar", function () {
        var listaSaidas = obterListaProdutos();

        if (listaSaidas.length == 0 || $("#txt_numero").val() != "") {
            limparTela();
        } else {
            swal({
                text: "Deseja realmente cancelar a saída dos produtos?",
                type: "info",
                showCancelButton: true,
                allowEscapeKey: false,
                allowOutsideClick: false,
                cancelButtonText: "Não",
                confirmButtonClass: "btn-primary",
                confirmButtonText: "Sim"
            }).then(function (opcao) {
                if (opcao.value) {
                    limparTela();
                }
            });
        }
    })
    .on("click", ".btn_remover", function () {
        var linha = $(this).closest("tr");
        linha.remove();
    });
