
$(document).ready(function () {
    getTabela();
    $('#txt_preco_custo,#txt_preco_venda').mask('#.##0,00', { reverse: true });
    $('#txt_quant_estoque').mask('00000');
})

var linha;

var simple_checkbox = function (data, type, full, meta) {
    var is_checked = data == true ? "checked disabled" : "disabled";
    return '<input type="checkbox" class="checkbox" ' +
        is_checked + ' />';
}

function getTabela() {
    var table = $('#TabelaProduto').DataTable(
        {
            dom: "<'row'<'col-sm-2'l><'col-sm-7'B><'col-sm-3'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
            buttons: [
                {
                    text: '<i class="fa fa-file-pdf-o"></i>',
                    titleAttr: 'PDF',
                    extend: 'pdfHtml5',
                    filename: 'dt_custom_pdf',

                    exportOptions: {
                        columns: [1, 2, 3, 4],
                        search: 'applied',
                        order: 'applied',
                    },
                    className: 'btn btn-default'
                },
                {
                    extend: 'print',
                    text: '<i class="fa fa-print"></i>',
                    titleAttr: 'Imprimir',
                    className: 'btn btn-default',
                    exportOptions: {
                        columns: [1, 2, 3, 4]
                    }
                }
            ],
            ajax: '/Produto/GetProdutos',
            columns: [
                { "data": "ProdutoId", "visible": false },
                { "data": "Codigo" },
                { "data": "Descricao", className: "descricao_produto" },
                { "data": "PrecoCusto" },
                { "data": "PrecoVenda" },
                { "data": "Ativo", "render": simple_checkbox },
                {
                    data: null,
                    className: "center",
                    width: "20%",
                    defaultContent:
                        '<a class="btn btn-default btn-exibir-imagem" role="button"><i class="glyphicon glyphicon-picture"></i></a>' +
                        '&nbsp <a class="btn btn-primary btn-alterar" role="button"><i class="glyphicon glyphicon-pencil"></i> Alterar</a>' +
                        '&nbsp <a class="btn btn-danger btn-excluir" role="button"><i class="glyphicon glyphicon-trash"></i> Excluir</a>'
                }
            ],
            "language": {
                sEmptyTable: "Nenhum registro encontrado",
                sInfo: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                sInfoEmpty: "Mostrando 0 até 0 de 0 registros",
                sInfoFiltered: "(Filtrados de _MAX_ registros)",
                sInfoPostFix: "",
                sInfoThousands: ".",
                sLengthMenu: "_MENU_ resultados por página",
                sLoadingRecords: "Carregando...",
                sProcessing: "Processando...",
                sZeroRecords: "Nenhum registro encontrado",
                sSearch: "Pesquisar:",
                oPaginate: {
                    sNext: "Próximo",
                    sPrevious: "Anterior",
                    sFirst: "Primeiro",
                    sLast: "Último"
                },
                oAria: {
                    sSortAscending: ": Ordenar colunas de forma ascendente",
                    sSortDescending: ": Ordenar colunas de forma descendente"
                }
            }
        });

    $("#TabelaProduto")
        .on('click', 'a.btn-alterar', function () {
            var tr = $(this).closest('tr'),
                id = table.row(tr).data().ProdutoId,
                url = '/Produto/Details',
                param = { 'id': id };
            $.post(url, param, function (f) {
                abrir_form(f.data);
                linha = table.row(tr);
            })
        })
        //Excluir Linha
        .on('click', 'a.btn-excluir', function () {
            var tr = $(this).closest('tr'),
                id = table.row(tr).data().ProdutoId,
                url = '/Produto/Delete',
                param = { 'id': id };

            swal({
                title: 'Você tem certeza?',
                text: "Você não poderá reverter isso!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sim, exclua!',
                cancelButtonText: 'Não, cancelar!',
                reverseButtons: true,
                focusCancel: true
            }).then((result) => {
                if (result.value) {
                    $.post(url, add_anti_forgery_token(param), function (response) {
                        if (response) {
                            table.row(tr).remove().draw(false);
                            swal(
                                'Excluído!',
                                'Seu dado foi excluído.',
                                'success'
                            )
                        }
                    })
                        .fail(function () {
                            swal('Aviso', 'Não foi possível excluir. Tente novamente em instantes.', 'warning');
                        })

                } else {
                    swal(
                        'Cancelado',
                        'Seu arquivo imaginário está seguro :)',
                        'error'
                    )
                }
            })
        })
        .on('click', '.btn-exibir-imagem', function () {
            var descricao_imagem = $(this).closest('tr').find('td.descricao_produto').text();

            let tr = $(this).closest('tr'),
                id = table.row(tr).data().ProdutoId,
                url = '/Produto/GetImagemPeloId',
                request = $.ajax({
                    url: url,
                    type: 'GET',
                    data: { 'id': id },
                    contentType: 'application/json; charset=utf-8'
                });

            request.done(function (f) {
                let nome_imagem = f.data,
                    modal_imagem = $('#modal_imagem');

                modal_imagem.find('img').attr('src', '/Content/Imagens/' + nome_imagem);

                bootbox.dialog({
                    title: 'Imagem de ' + descricao_imagem,
                    message: modal_imagem,
                    className: 'dialogo'
                })
                    .on('shown.bs.modal', function () {
                        modal_imagem.show();
                    })
                    .on('hidden.bs.modal', function () {
                        modal_imagem.hide().appendTo('body');
                    });
            });

        });

    //Adicionar Linha
    $(document).on('click', '.btn-adicionar', function () {
        abrir_form(get_dados_inclusao());
    })
        .on('click', '#btn_confirmar', function () {
            var param = get_dados_form(),
                dados = get_param(),
                url = dados.ProdutoId == 0 ? '/Produto/Create' : '/Produto/Edit';

            $.ajax({
                type: 'POST',
                processData: false,
                contentType: false,
                data: param,
                url: url,
                dataType: 'json',
                success: function (f) {
                    if (f.Resultado == "OK") {
                        if (dados.ProdutoId == 0) {
                            dados.ProdutoId = f.IdSalvo;
                            table.row.add(dados).draw(false);
                        } else {
                            linha.data(f.data).invalidate().draw();
                        }
                        $('#modal_cadastro').parents('.bootbox').modal('hide');
                    }
                    else if (f.Resultado == "ERRO") {
                        $('#msg_aviso').hide();
                        $('#msg_mensagem_aviso').hide();
                        $('#msg_erro').show();
                    }
                    else if (f.Resultado == "AVISO") {
                        $('#msg_mensagem_aviso').html(formatar_mensagem_aviso(f.Mensagens));
                        $('#msg_aviso').show();
                        $('#msg_mensagem_aviso').show();
                        $('#msg_erro').hide();
                    }
                },
                error: function () {
                    swal('Aviso', 'Não foi possível salvar. Tente novamente em instantes.', 'warning');
                }
            });
        })
}

function formatar_mensagem_aviso(mensagens) {
    var ret = '';

    for (var i = 0; i < mensagens.length; i++) {
        ret += '<li>' + mensagens[i] + '</li>';
    }

    return '<ul>' + ret + '</ul>';
}

function set_dados_form(dados) {
    $('#id_cadastro').val(dados.ProdutoId);
    $('#txt_codigo').val(dados.Codigo);
    $('#txt_descricao').val(dados.Descricao);
    $('#txt_preco_custo').val(dados.PrecoCusto);
    $('#txt_preco_venda').val(dados.PrecoVenda);
    $('#txt_quant_estoque').val(dados.QuantEstoque);
    $('#ddl_unidade_medida').val(dados.UnidadeMedidaId);
    $('#ddl_grupo').val(dados.GrupoProdutoId);
    $('#ddl_marca').val(dados.MarcaId);
    $('#ddl_fornecedor').val(dados.FornecedorId);
    $('#ddl_local_armazenamento').val(dados.LocalArmazenamentoId);
    $('#cbx_ativo').prop('checked', dados.Ativo);
}

function set_focus_form() {
    var alterando = (parseInt($('#id_cadastro').val()) > 0);
    $('#txt_quant_estoque').attr('readonly', alterando);

    $('#txt_codigo').focus();
}

function get_dados_inclusao() {
    return {
        ProdutoId: 0,
        Codigo: '',
        Descricao: '',
        PrecoCusto: 0,
        PrecoVenda: 0,
        QuantEstoque: 0,
        UnidadeMedidaId: 0,
        GrupoProdutoId: 0,
        MarcaId: 0,
        FornecedorId: 0,
        LocalArmazenamentoId: 0,
        Ativo: true,
        Imagem: ''
    };
}

function get_dados_form() {
    var form = new FormData();
    form.append('__RequestVerificationToken', $('[name=__RequestVerificationToken]').val());
    form.append('ProdutoId', $('#id_cadastro').val());
    form.append('Codigo', $('#txt_codigo').val());
    form.append('Descricao', $('#txt_descricao').val());
    form.append('PrecoCusto', $('#txt_preco_custo').val());
    form.append('PrecoVenda', $('#txt_preco_venda').val());
    form.append('QuantidadeEstoque', $('#txt_quant_estoque').val());
    form.append('UnidadeMedidaId', $('#ddl_unidade_medida').val());
    form.append('GrupoProdutoId', $('#ddl_grupo').val());
    form.append('MarcaId', $('#ddl_marca').val());
    form.append('FornecedorId', $('#ddl_fornecedor').val());
    form.append('LocalArmazenamentoId', $('#ddl_local_armazenamento').val());
    form.append('Ativo', $('#cbx_ativo').prop('checked'));
    form.append('Imagem', $('#txt_imagem').prop('files')[0]);
    return form;
}

function get_param() {
    return {
        ProdutoId: $('#id_cadastro').val(),
        Codigo: $('#txt_codigo').val(),
        Descricao: $('#txt_descricao').val(),
        PrecoCusto: $('#txt_preco_custo').val(),
        PrecoVenda: $('#txt_preco_venda').val(),
        QuantidadeEstoque: $('#txt_quant_estoque').val(),
        Ativo: $('#cbx_ativo').prop('checked'),
        Imagem: $('#txt_imagem').prop('files')[0]
    };
}

function abrir_form(dados) {
    set_dados_form(dados);

    var modal_cadastro = $('#modal_cadastro');

    $('#msg_mensagem_aviso').empty();
    $('#msg_aviso').hide();
    $('#msg_mensagem_aviso').hide();
    $('#msg_erro').hide();

    bootbox.dialog({
        title: 'Cadastro de Produto',
        message: modal_cadastro,
        className: 'dialogo'
    })
        .on('shown.bs.modal', function () {
            modal_cadastro.show(0, function () {
                set_focus_form();
            });
        })
        .on('hidden.bs.modal', function () {
            modal_cadastro.hide().appendTo('body');
        });
}

function add_anti_forgery_token(data) {
    data.__RequestVerificationToken = $('[name=__RequestVerificationToken]').val();
    return data;
}