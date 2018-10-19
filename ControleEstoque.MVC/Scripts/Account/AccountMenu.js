$(document).ready(function () {
    $(".btn-sair").click( function () {
        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: '/Account/LogOff',
            type: 'POST',
            data: {
                __RequestVerificationToken: token
            },
            success: function () {
                location.reload();
            }
        });
    });
});