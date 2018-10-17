$(document).ready(function () {
    getTabela();
});

var linha;

var simple_checkbox = function (data, type, full, meta) {
    var is_checked = data == true ? "checked disabled" : "disabled";
    return '<input type="checkbox" class="checkbox" ' +
        is_checked + ' />';
}

function getTabela() {
    var table = $('#TabelaUnidadeMedida').DataTable(
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
            ajax: '/UnidadeMedida/GetUnidadesMedidas',
            columns: [
                { "data": "UnidadeMedidaId" },
                { "data": "Descricao" },
                { "data": "Sigla" },
                { "data": "Ativo", "render": simple_checkbox },
                {
                    data: null,
                    className: "center",
                    width: "20%",
                    defaultContent:
                        '<a class="btn btn-primary btn-alterar" role="button"><i class="glyphicon glyphicon-pencil"></i> Alterar</a>' +
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

    $("#TabelaUnidadeMedida").on('click', 'a.btn-alterar', function () {
        var tr = $(this).closest('tr'),
            id = table.row(tr).data().UnidadeMedidaId,
            url = '/UnidadeMedida/Details',
            param = { 'id': id };
        $.post(url, add_anti_forgery_token(param), function (f) {
            abrir_form(f.data);
            linha = table.row(tr);
        })
    })
        //Excluir Linha
        .on('click', 'a.btn-excluir', function () {
            var tr = $(this).closest('tr'),
                id = table.row(tr).data().UnidadeMedidaId,
                url = '/UnidadeMedida/Delete',
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

    //Adicionar Linha
    $(document).on('click', '.btn-adicionar', function () {
        abrir_form(get_dados_inclusao());
    })
        .on('click', '#btn_confirmar', function () {
            var param = get_dados_form(),
                url = param.UnidadeMedidaId == 0 ? '/UnidadeMedida/Create' : '/UnidadeMedida/Edit';

            $.post(url, add_anti_forgery_token(param), function (f) {
                if (f.Resultado == "OK") {
                    if (param.UnidadeMedidaId == 0) {
                        param.UnidadeMedidaId = f.IdSalvo;
                        table.row.add(param).draw(false);
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
            })

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
    $('#id_cadastro').val(dados.UnidadeMedidaId);
    $('#txt_descricao').val(dados.Descricao);
    $('#txt_sigla').val(dados.Sigla);
    $('#cbx_ativo').prop('checked', dados.Ativo);
}

function set_focus_form() {
    $('#txt_descricao').focus();
}

function get_dados_inclusao() {
    return {
        UnidadeMedidaId: 0,
        Descricao: '',
        Sigla: '',
        Ativo: true
    };
}

function get_dados_form() {
    return {
        UnidadeMedidaId: $('#id_cadastro').val(),
        Descricao: $('#txt_descricao').val(),
        Sigla: $('#txt_sigla').val(),
        Ativo: $('#cbx_ativo').prop('checked')
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
        title: 'Cadastro de Unidade Medida',
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