$(document).ready(function () {
    //hide login and register
    $('.navbar-nav').css('display', 'none');

    //click of logout
    $('#btnLogout').click(function () {
        localStorage.removeItem("playerId");
        location.href = "/Login";
    });

    //click of submit
    $('#btnSubmit').off().on('click', function (e) {
        var radio_inputs = document.getElementsByTagName('input');
        var correct_count = 0;
        var option_checked = 0;
        for (var i = 0; i < radio_inputs.length; i++) {
            if (radio_inputs[i].type == 'radio') {
                if (radio_inputs[i].checked) {
                    option_checked += 1;
                    if (radio_inputs[i].value.toLowerCase().localeCompare(radio_inputs[i].getAttribute('correct_val').toLowerCase())==0) {
                        correct_count += 1;
                    }
                }
            }
        }
        if (option_checked == 10) {
            //save score
            var formdata = {
                "PlayerId": localStorage.getItem("playerId"),
                "Score": correct_count
            };
            $.ajax({
                url: "http://localhost:62689/api/player/SaveScore",
                type: 'POST',
                dataType: 'json',
                data: formdata,
                success: function (data) {
                    if (data.status == 200) {
                        $('#alertText').html('Your Score: ' + correct_count + '/10');
                        document.getElementById("divAlertReponse").classList.remove("alert-danger");
                        document.getElementById("divAlertReponse").classList.add("alert-success");
                        $('.badge').css('display', 'block');
                        $('#btnSubmit').css('display', 'none');
                        $('#divLogout').css('display', 'block');
                    }
                    else {
                        $('#alertText').html(data.message)
                        document.getElementById("divAlertReponse").classList.remove("alert-success");
                        document.getElementById("divAlertReponse").classList.add("alert-danger");
                    }
                },
                error: function (xhr) {
                    console.log(xhr)
                    $('#alertText').html('Error occured!')
                    document.getElementById("divAlertReponse").classList.remove("alert-success");
                    document.getElementById("divAlertReponse").classList.add("alert-danger")
                }
            });
        }
        else {
            $('#alertText').html('Please answer all questions to know the score!');
            document.getElementById("divAlertReponse").classList.remove("alert-success");
            document.getElementById("divAlertReponse").classList.add("alert-danger");
        }
        $("html, body").animate({ scrollTop: 0 }, "slow");
        $('#divAlertReponse').css('display', 'block');
    });
});