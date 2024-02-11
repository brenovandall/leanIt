document.addEventListener("DOMContentLoaded", function () {
    localStorage.removeItem("tempo");
});

var totalDeEstrelas;

document.querySelector(".star-1c").addEventListener("click", () => {
    let input = document.querySelector(".valorEstrelas");
    totalDeEstrelas = 1;
    input.value = 1;
    console.log(input.value);
});

document.querySelector(".star-2c").addEventListener("click", () => {
    let input = document.querySelector(".valorEstrelas");
    totalDeEstrelas = 2;
    input.value = 2;
    console.log(input.value);
})

document.querySelector(".star-3c").addEventListener("click", () => {
    let input = document.querySelector(".valorEstrelas");
    totalDeEstrelas = 3;
    input.value = 3;
    console.log(input.value);
})

document.querySelector(".star-4c").addEventListener("click", () => {
    let input = document.querySelector(".valorEstrelas");
    totalDeEstrelas = 4;
    input.value = 4;
    console.log(input.value);
})

document.querySelector(".star-5c").addEventListener("click", () => {
    let input = document.querySelector(".valorEstrelas");
    totalDeEstrelas = 5;
    input.value = 5;
    console.log(input.value);
})