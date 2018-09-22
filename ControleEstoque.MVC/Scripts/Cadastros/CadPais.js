$(document).ready(
    getPaises()
);

function getPaises() {
    $('#TabelaPais').DataTable({
        ajax: '/Paises/GetPaises',
        columns: [
            { "data": "PaisId" },
            { "data": "Descricao" },
            { "data": "Codigo" },
            { "data": "Ativo" },
            {
                data: null,
                className: "center",
                width: "15%",
                defaultContent: '<a class="btn btn-primary btn-alterar" role="button"><i class="glyphicon glyphicon-pencil"></i> Alterar</a>' +
                                '&nbsp <a class="btn btn-danger btn-excluir" role="button"><i class="glyphicon glyphicon-trash"></i> Excluir</a>'
            }
        ]
    });
}

//function add_anti_forgery_token(data) {
//    data.__RequestVerificationToken = $('[name=__RequestVerificationToken]').val();
//    return data;
//}