$(document).ready(function () {
    //hide login and register
    $('.navbar-nav').css('display', 'none');

    //click of logout
    $('#btnLogout').click(function () {
        localStorage.clear();
        location.href = "/Login";
    });

    //click of play
    $('#btnPlay').click(function () {
        location.href = "/Game";
    });
});