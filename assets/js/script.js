

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