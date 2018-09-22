$(document).ready(
    getPaises()
);

function getPaises() {
    $('#TabelaPais').DataTable({
        ajax: '/Paises/GetPaises',
        columns: [
            { "data": "PaisId"},
            { "data": "Descricao" },
            { "data": "Codigo"},
            { "data": "Ativo" }
        ]
    });
}