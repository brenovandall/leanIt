const selectedImage = document.querySelector("#inputExternalImage");
const image = document.querySelector("#imageString");

document.querySelector('.imgPerfil').addEventListener('click', function () {
    document.getElementById('inputExternalImage').click();
});

async function uploadImage(e) {
    console.log(e.target.files[0])

    let data = new FormData();
    data.append('imagem', e.target.files[0]);

    await fetch('/api/ImagensCloud/carregar', {
        method: 'POST',
        headers: {
            'Accept': '*/*',
        },
        body: data
    }).then(response => response.json())
        .then(result => {
            console.log(result)
            image.value = result.link;

            setTimeout(() => {
                location.reload();
            }, 10);
        });
}

selectedImage.addEventListener('change', uploadImage);