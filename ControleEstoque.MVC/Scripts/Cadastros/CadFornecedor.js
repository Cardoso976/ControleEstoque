$(document)
    .ready(function () {
        getTabela();
        $('#txt_telefone').mask('(00) 0000-0000');
        $('#txt_cep').mask('00000-000');
    })
    .on('click', '#cbx_pessoa_juridica', function () {
        $('label[for="txt_num_documento"]').text('CNPJ');
        $('#txt_num_documento').mask('00.000.000/0000-00', { reverse: true });
        $('#container_razao_social').removeClass('invisible');
    })
    .on('click', '#cbx_pessoa_fisica', function () {
        $('label[for="txt_num_documento"]').text('CPF');
        $('#txt_num_documento').mask('000.000.000-00', { reverse: true });
        $('#container_razao_social').addClass('invisible');
    })
    .on('change', '#ddl_pais', function () {
        mudar_pais();
    })
    .on('change', '#ddl_estado', function () {
        mudar_estado();
    });

var linha;

var simple_checkbox = function (data, type, full, meta) {
    var is_checked = data == true ? "checked disabled" : "disabled";
    return '<input type="checkbox" class="checkbox" ' +
        is_checked + ' />';
}

function getTabela() {
    var table = $('#TabelaFornecedores').DataTable(
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
                        columns: [0, 1, 2],
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
                        columns: [0, 1, 2]
                    }
                }
            ],
            ajax: '/Fornecedor/GetFornecedores',
            columns: [
                { "data": "FornecedorId" },
                { "data": "Nome" },
                { "data": "NumDocumento" },
                { "data": "Contato" },
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

    $("#TabelaFornecedores").on('click', 'a.btn-alterar', function () {
        var tr = $(this).closest('tr'),
            id = table.row(tr).data().FornecedorId,
            url = '/Fornecedor/Details',
            param = { 'id': id };
        $.post(url, add_anti_forgery_token(param), function (f) {
            abrir_form(f.data);
            linha = table.row(tr);
        })
    })
        //Excluir Linha
        .on('click', 'a.btn-excluir', function () {
            var tr = $(this).closest('tr'),
                id = table.row(tr).data().FornecedorId,
                url = '/Fornecedor/Delete',
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
                url = param.FornecedorId == 0 ? '/Fornecedor/Create' : '/Fornecedor/Edit';

            $.post(url, add_anti_forgery_token(param), function (f) {
                if (f.Resultado == "OK") {
                    if (param.FornecedorId == 0) {
                        param.FornecedorId = f.IdSalvo;
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

function get_dados_inclusao() {
    return {
        Id: 0,
        Nome: '',
        NumDocumento: '',
        RazaoSocial: '',
        Tipo: 2,
        Telefone: '',
        Contato: '',
        Logradouro: '',
        Complemento: '',
        Cep: '',
        IdPais: 0,
        IdEstado: 0,
        IdCidade: 0,
        Ativo: true
    };
}

function get_dados_form() {
    return {
        Id: $('#id_cadastro').val(),
        Nome: $('#txt_nome').val(),
        NumDocumento: $('#txt_num_documento').val(),
        RazaoSocial: $('#txt_razao_social').val(),
        Tipo: $('#cbx_pessoa_juridica').is(':checked') ? 2 : 1,
        Telefone: $('#txt_telefone').val(),
        Contato: $('#txt_contato').val(),
        Logradouro: $('#txt_logradouro').val(),
        Complemento: $('#txt_complemento').val(),
        Cep: $('#txt_cep').val(),
        IdPais: $('#ddl_pais').val(),
        IdEstado: $('#ddl_estado').val(),
        IdCidade: $('#ddl_cidade').val(),
        Ativo: $('#cbx_ativo').prop('checked')
    };
}

function set_dados_form(dados) {
    $('#id_cadastro').val(dados.Id);
    $('#txt_nome').val(dados.Nome);
    $('#txt_num_documento').val(dados.NumDocumento);
    $('#txt_razao_social').val(dados.RazaoSocial);
    $('#txt_telefone').val(dados.Telefone);
    $('#txt_contato').val(dados.Contato);
    $('#txt_logradouro').val(dados.Logradouro);
    $('#txt_complemento').val(dados.Complemento);
    $('#txt_cep').val(dados.Cep);
    $('#cbx_ativo').prop('checked', dados.Ativo);
    $('#cbx_pessoa_juridica').prop('checked', false);
    $('#cbx_pessoa_fisica').prop('checked', false);

    if (dados.Tipo == 2) {
        $('#cbx_pessoa_juridica').prop('checked', true).trigger('click');
    }
    else {
        $('#cbx_pessoa_fisica').prop('checked', true).trigger('click');
    }

    var inclusao = (dados.Id == 0);
    if (inclusao) {
        $('#ddl_estado').empty();
        $('#ddl_estado').prop('disabled', true);

        $('#ddl_cidade').empty();
        $('#ddl_cidade').prop('disabled', true);
    }
    else {
        $('#ddl_pais').val(dados.IdPais);
        mudar_pais(dados.IdEstado, dados.IdCidade);
    }
}

function mudar_pais(id_estado, id_cidade) {
    var ddl_pais = $('#ddl_pais'),
        id_pais = parseInt(ddl_pais.val()),
        ddl_estado = $('#ddl_estado'),
        ddl_cidade = $('#ddl_cidade');

    if (id_pais > 0) {
        var url = '/Estado/GetEstadosByPais',
            param = { paisId: id_pais };

        ddl_estado.empty();
        ddl_estado.prop('disabled', true);

        ddl_cidade.empty();
        ddl_cidade.prop('disabled', true);

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response && response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    ddl_estado.append('<option value=' + response[i].EstadoId + '>' + response[i].Descricao + '</option>');
                }
                ddl_estado.prop('disabled', false);
            }
            sel_estado(id_estado);
            mudar_estado(id_cidade);
        });
    }
}

function mudar_estado(id_cidade) {
    var ddl_estado = $('#ddl_estado'),
        id_estado = parseInt(ddl_estado.val()),
        ddl_cidade = $('#ddl_cidade');

    if (id_estado > 0) {
        var url = '/Cidade/GetCidadesByEstado',
            param = { estadoId: id_estado };

        ddl_cidade.empty();
        ddl_cidade.prop('disabled', true);

        $.post(url, add_anti_forgery_token(param), function (response) {
            if (response && response.length > 0) {
                for (var i = 0; i < response.length; i++) {
                    ddl_cidade.append('<option value=' + response[i].CidadeId + '>' + response[i].Descricao + '</option>');
                }
                ddl_cidade.prop('disabled', false);
            }
            sel_cidade(id_cidade);
        });
    }
}

function sel_estado(id_estado) {
    $('#ddl_estado').val(id_estado);
    $('#ddl_estado').prop('disabled', $('#ddl_estado option').length == 0);
}

function sel_cidade(id_cidade) {
    $('#ddl_cidade').val(id_cidade);
    $('#ddl_cidade').prop('disabled', $('#ddl_cidade option').length == 0);
}

function set_focus_form() {
    $('#txt_descricao').focus();
}

function abrir_form(dados) {
    set_dados_form(dados);

    var modal_cadastro = $('#modal_cadastro');

    $('#msg_mensagem_aviso').empty();
    $('#msg_aviso').hide();
    $('#msg_mensagem_aviso').hide();
    $('#msg_erro').hide();

    bootbox.dialog({
        title: 'Cadastro de País',
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