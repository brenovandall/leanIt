

let carouselContainer = document.querySelector('.carousel-container');
let slides = document.querySelectorAll('.carousel-slide');

let currentIndex = 0;

function updateCarousel() {
    let newTransformValue = -currentIndex * 100 + '%';
    carouselContainer.style.transform = 'translateX(' + newTransformValue + ')';
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % slides.length;
    updateCarousel();
}

function prevSlide() {
    currentIndex = (currentIndex - 1 + slides.length) % slides.length;
    updateCarousel();
}
