(function () {
    var server = $.connection.chatHub.server;
    var client = $.connection.chatHub.client;

    $.connection.hub.start()
        .done(function () {
            console.log("connected!");
        })
        .fail(function () {
            alert("Failed to connect.")
        });

    client.send = function (message) {
        var text = "<label class='pull-right' style='background-color: #99c199; color: white'>" + message +"</label><br/>";
        $("#messages").append(text + "<br/>");
    };

    $("#sendNow").click(function () {
        var message = $("#chatMessage").val();
        var text = "<label class='pull-left' style='background-color: #757fa9; color: white'>" + message + "</label><br/>";
        $("#messages").append(text);
        server.send(message);
    })
})()