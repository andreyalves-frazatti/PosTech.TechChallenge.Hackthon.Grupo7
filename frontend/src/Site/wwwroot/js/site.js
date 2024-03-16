var form;
$('#foto').change(function (event) {
    form = new FormData();
    form.append('foto', event.target.files[0]);
});

function EnviaCadastro() {
    var nome = $("#nomeCliente").val();
    var email = $("#email").val();
    var telefone = $("#telefone").val();
    var endereco = $("#endereco").val();
    var complemento = $("#complemento").val();
    var bairro = $("#bairro").val();
    var municipio = $("#municipio").val();
    var UF = $("#UF").val();
    var cep = $("#cep").val();
    var imagem = $("#foto").val();

    var obj = { nome, email, telefone, endereco, complemento, bairro, municipio, UF, cep, imagem };
    var dados = JSON.stringify(obj);


        $.ajax({
            url: 'https://gabrielsalomao-sqlazure.azurewebsites.net/imagem',
            data: form,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                $.ajax({
                    url: 'https://gabrielsalomao-sqlazure.azurewebsites.net/Cadastro',
                    type: 'post',
                    contentType: 'application/json',
                    data: dados
                }).done(function (response) {
                    // Atualziar componemtes.
                });
            }
        });

}

