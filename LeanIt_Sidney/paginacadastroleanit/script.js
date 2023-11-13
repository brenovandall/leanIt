function validaCPF() {
    let cpfInput = document.querySelector('.inputCpfCadastro');
    let cpf = cpfInput.value.replace(/\D/g, '');

    if (cpf.length === 11) {
        cpf = cpf.substring(0, 3) + '.' + cpf.substring(3, 6) + '.' + cpf.substring(6, 9) + '-' + cpf.substring(9);
        cpfInput.value = cpf;
    } else {
        alert('CPF inválido');
    }
}

function dadosEndereco() {
    let cep = document.querySelector('.inputCepCadastro').value;
    fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then((dados) => dados.json())
        .then((response) => {
            console.log(response)
            document.querySelector('.inputEnderecoCadastro').value = response.logradouro
            document.querySelector('.inputBairroCadastro').value = response.bairro
            document.querySelector('.inputCidadeCadastro').value = response.localidade
            document.querySelector('#estado').value = response.uf
        }
        )
        .catch((erro) => console.log(erro))
}

function mostrarSenha() {
    const input = document.querySelector('.inputSenhaCadastro');

    const button = document.querySelector('.tooglePass');

    if (input.type == "password") {
        input.type = "text"
    }

    else {
        input.type = "password";
    }
}






