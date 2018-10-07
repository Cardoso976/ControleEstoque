$(document).ready(function () {
    getTabela();
});

var linha;

function getTabela() {
    var table = $('#TabelaPais').DataTable(
        {
            ajax: '/Paises/GetPaises',
            //buttons: ['csv', 'excel', 'pdf', 'print'],
            columns: [
                { "data": "PaisId" },
                { "data": "Descricao" },
                { "data": "Codigo" },
                { "data": "Ativo" },
                {
                    data: null,
                    className: "center",
                    width: "20%",
                    defaultContent:
                        '<a class="btn btn-primary btn-alterar" role="button"><i class="glyphicon glyphicon-pencil"></i> Alterar</a>' +
                        '&nbsp <a class="btn btn-danger btn-excluir" role="button"><i class="glyphicon glyphicon-trash"></i> Excluir</a>'
                }
            ]
        });

    $("#TabelaPais").on('click', 'a.btn-alterar', function () {
        var tr = $(this).closest('tr'),
            id = table.row(tr).data().PaisId,
            url = '/Paises/Details',
            param = { 'id': id };
        $.post(url, add_anti_forgery_token(param), function (f) {
            abrir_form(f.data);
            linha = table.row(tr);
        })
    })
        //Excluir Linha
        .on('click', 'a.btn-excluir', function () {
            var tr = $(this).closest('tr'),
                id = table.row(tr).data().PaisId,
                url = '/Paises/Delete',
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
                            tr.remove();
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
                url = param.PaisId == 0 ? '/Paises/Create' : '/Paises/Edit';

            $.post(url, add_anti_forgery_token(param), function (f) {
                if (f.Resultado == "OK") {
                    if (param.PaisId == 0) {
                        param.PaisId = f.IdSalvo;
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
        PaisId: 0,
        Descricao: '',
        Codigo: '',
        Ativo: true
    };
}

function get_dados_form() {
    return {
        PaisId: $('#id_cadastro').val(),
        Descricao: $('#txt_descricao').val(),
        Codigo: $('#txt_codigo').val(),
        Ativo: $('#cbx_ativo').prop('checked')
    };
}

function set_dados_form(dados) {
    $('#id_cadastro').val(dados.PaisId);
    $('#txt_descricao').val(dados.Descricao);
    $('#txt_codigo').val(dados.Codigo);
    $('#cbx_ativo').prop('checked', dados.Ativo).iCheck('update');
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