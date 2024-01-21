document.addEventListener("DOMContentLoaded", function () {


    var minutos = parseInt(localStorage.getItem("tempo")) || 0;
    function comecar() {
        setInterval(function () {
            minutos++;
            localStorage.setItem("tempo", minutos);
            console.log('Minutos:', minutos);
        }, 1000);
    }

    if (minutos >= 1) {
        comecar();
    }

});