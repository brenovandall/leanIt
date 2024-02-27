document.getElementById("check").addEventListener("click", () => {
    var a = document.getElementsByName("marcado")

    for (let i = 0; i < a.length; i++) {

        if (a[i].checked) {
            document.querySelector(".botaoCadastro").removeAttribute("disabled")
            document.querySelector(".botaoCadastro").style.cursor = "pointer"
        }
        else {
            document.querySelector(".botaoCadastro").setAttribute("disabled", true)
            document.querySelector(".botaoCadastro").style.cursor = "not-allowed"
        }
    }
}) 






function validaCPF() {
    let cpfInput = document.querySelector('#cpfCadastro');
    let cpf = cpfInput.value.replace(/\D/g, '');

    if (cpf.length === 14) {
        cpf = cpf.substring(0, 3) + '.' + cpf.substring(3, 6) + '.' + cpf.substring(6, 9) + '-' + cpf.substring(9);
        cpfInput.value = cpf;
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