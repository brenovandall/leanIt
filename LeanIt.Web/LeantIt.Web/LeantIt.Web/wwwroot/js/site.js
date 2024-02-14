



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

function fecharAlerta() {
    document.getElementById("alerta").style.display = "none";
    localStorage.setItem("alertaFechado", "true");
}

window.onload = function () {
    if (localStorage.getItem("alertaFechado")) {
        document.getElementById("alerta").style.display = "none";
    }
};