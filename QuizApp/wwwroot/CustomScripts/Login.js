$(document).ready(function () {
    //click of login
    $('#btnLogin').off().on('click', function (e) {
        if (!$('form#formLogin').data('unobtrusiveValidation').validate()) {
            e.preventDefault();
            return false;
        }
        else {
            var formdata = {
                "Email": $("#Email").val(),
                "Password": $("#Password").val()
            };
            $.ajax({
                url: "http://localhost:62689/api/player/login",
                type: 'POST',
                dataType: 'json',
                data: formdata,
                success: function (data) {
                    if (data.status == 200) {
                        localStorage.setItem("playerId", data.playerid);
                        $('#alertText').html(data.message)
                        document.getElementById("divAlertReponse").classList.remove("alert-danger");
                        document.getElementById("divAlertReponse").classList.add("alert-success");
                        $('#divAlertReponse').css('display', 'block');
                        $('form#formLogin')[0].reset();
                        setTimeout(function () {
                            location.href = "/Choose";
                        }, 3000);
                    }
                    else {
                        $('#alertText').html(data.message)
                        document.getElementById("divAlertReponse").classList.remove("alert-success");
                        document.getElementById("divAlertReponse").classList.add("alert-danger");
                        $('#divAlertReponse').css('display', 'block');
                    }
                },
                error: function (xhr) {
                    console.log(xhr)
                    $('#alertText').html('Error occured!')
                    document.getElementById("divAlertReponse").classList.remove("alert-success");
                    document.getElementById("divAlertReponse").classList.add("alert-danger")
                    $('#divAlertReponse').css('display', 'block')
                }
            });
        }
    });
});