$(function () {

    $(".card").hide();

    $("#botao-chat").click(function () {
        $(".card").toggle();
    });


    $(".send-button").click(function () {
        var mensagem = $(".message-input").val();
        var stringUrl = "api/chat";
        
        $.ajax({
            type: "POST",
            url: stringUrl,
            async: false,
            data: { mensagem: mensagem },

            success: function (data) {

                var eu1 = $("<span></span>").text(mensagem)
                var eu2 = $("<div></div>").append(eu1);
                eu2.addClass("eu")
                $(".message-list").append(eu2);

                var bot1 = $("<span></span>").text(data.resposta)
                var bot2 = $("<div></div>").append(bot1);
                bot2.addClass("bot")
                $(".message-list").append(bot2);

                $(".message-input").val("");
            }
        });
    });
});