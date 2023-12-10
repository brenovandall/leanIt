function validaCPF() {
    let cpfInput = document.querySelector('#cpfCadastro');
    let cpf = cpfInput.value.replace(/\D/g, '');

    if (cpf.length === 11) {
        cpf = cpf.substring(0, 3) + '.' + cpf.substring(3, 6) + '.' + cpf.substring(6, 9) + '-' + cpf.substring(9);
        cpfInput.value = cpf;
    } else {
        alert('CPF inválido');
    }
}
function dadosEndereco() {
    let cep = document.querySelector('#inputCep').value;
    fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then((dados) => dados.json())
        .then((response) => {
            console.log(response)
            document.querySelector('#inputEndereco').value = response.logradouro
            document.querySelector('#inputBairro').value = response.bairro
            document.querySelector('#inputCidade').value = response.localidade
            document.querySelector('#inputEstado').value = response.uf
            document.querySelector('#inputPais').value = response.uf
        }
        )
        .catch((erro) => console.log(erro))
        console.log(cep)
}