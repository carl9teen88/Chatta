
var server = $.connection.chatHub.server;
var client = $.connection.chatHub.client;

$.connection.hub.start()
    .done(function () {
        console.log("connected!"); 
    })
    .fail(function () {
        alert("Failed to connect.")
    });

client.send = function (message, type) {
    console.log(type);
    var msg;
    if (type === 'string') {
        msg = "<label class='pull-right' style='background-color: #99c199; color: white'>" + message + "</label><br/>";
    }
    else if (type === "image") {
        msg = `<img class='blah' src = ${message} alt='image' />`;
    }

    $("#messages").append(msg + "<br/>");
};

$("#sendNow").click(function () {
    var message = $("#chatMessage").val();
    var text = "<label class='pull-left' style='background-color: #757fa9; color: white'>" + message + "</label><br/>";
    $("#messages").append(text);
    server.send(message, "string");
})

$("#uploadImage").on('change', function (e) {
    if (e.files && e.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var image = `<img class='blah' src = ${this.result} alt='image' />`
            $("#messages").append(image);
            server.send(this.result, "image");
        };

        reader.readAsDataURL(e.files[0]);
    }
})