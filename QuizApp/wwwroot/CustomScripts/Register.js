$(document).ready(function () {
    //remove local storage player id if exists
    localStorage.clear();

    //click of register
    $('#btnRegister').off().on('click', function (e) {
        if (!$('form#formRegister').data('unobtrusiveValidation').validate()) {
            e.preventDefault();
            return false;
        }
        else {
            var formdata = {
                "Username": $("#Username").val(),
                "Email": $("#Email").val(),
                "Password": $("#Password").val()
            };
            $.ajax({
                url: "http://localhost:62689/api/player/register",
                type: 'POST',
                dataType: 'json',
                data: formdata,
                success: function (data) {
                    if (data.status == 200) {
                        $('#alertText').html(data.message + '! Login to play!')
                        document.getElementById("divAlertReponse").classList.remove("alert-danger");
                        document.getElementById("divAlertReponse").classList.add("alert-success");
                        $('#divAlertReponse').css('display', 'block');
                        $('form#formRegister')[0].reset();
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