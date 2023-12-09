﻿function validaCPF() {
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

    else if (input.type == "text") {
        input.type = "password";
    }
}



            // PAGINA DE SERVIÇOS //




document.addEventListener("DOMContentLoaded", function () {
    const carousel = document.querySelector('.carousel');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    let counter = 0;

    nextBtn.addEventListener('click', function () {
        counter++;
        updateCarousel();
    });

    prevBtn.addEventListener('click', function () {
        counter--;
        updateCarousel();
    });

    function updateCarousel() {
        const totalItems = document.querySelectorAll('.carousel-item').length;
        if (counter > totalItems - 1) {
            counter = 0; // Reset to the first item
        } else if (counter < 0) {
            counter = totalItems - 1; // Go to the last item
        }
        carousel.style.transform = `translateX(${-counter * 100}%)`;
    }
});


var input = document.getElementById('pac-input');
var searchBox = new google.maps.places.SearchBox(input);


searchBox.addListener('places_changed', function () {
    var places = searchBox.getPlaces();

    if (places.length === 0) {
        return;
    }

    // Get information about the selected location if needed
    var selectedPlace = places[0];
    console.log(selectedPlace);

    // Update the map with the new location
    map.setCenter(selectedPlace.geometry.location);
});
