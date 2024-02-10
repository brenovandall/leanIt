document.addEventListener("DOMContentLoaded", function () {
    localStorage.removeItem("tempo");
});

var totalDeEstrelas;

document.querySelector(".star-1c").addEventListener("click", () => {
    totalDeEstrelas = 1;
    console.log(totalDeEstrelas);
});

document.querySelector(".star-2c").addEventListener("click", () => {
    totalDeEstrelas = 2;
    console.log(totalDeEstrelas);
})

document.querySelector(".star-3c").addEventListener("click", () => {
    totalDeEstrelas = 3;
    console.log(totalDeEstrelas);
})

document.querySelector(".star-4c").addEventListener("click", () => {
    totalDeEstrelas = 4;
    console.log(totalDeEstrelas);
})

document.querySelector(".star-5c").addEventListener("click", () => {
    totalDeEstrelas = 5;
    console.log(totalDeEstrelas);
})