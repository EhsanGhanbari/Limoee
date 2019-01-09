function ShowWebMessage(message) {
    if (message.Success) {
        $("#webMessage").html(message.Message).addClass("alert-success").show();
    } else {
        $("#webMessage").html(message.Message).addClass("alert-danger").show();
    }
}