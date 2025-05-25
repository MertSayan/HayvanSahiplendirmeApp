/**
 * login.js
 * Kullanıcı girişi sayfası için gerekli işlemler
 */

// Sayfa yüklendiğinde
$(function () {
    // Örnek kullanıcı bilgilerinden birine tıklayınca otomatik doldurmayı sağlar
    $('.sample-user-row').on('click', function () {
        var email = $(this).data('email');
        var password = $(this).data('password');

        $('#email').val(email);
        $('#password').val(password);
    });

    // Form gönderilmeden önce kontrolleri yapar
    $('form').on('submit', function (e) {
        var email = $('#email').val().trim();
        var password = $('#password').val();

        if (!email) {
            alert('Lütfen e-posta adresinizi girin.');
            e.preventDefault();
            return false;
        }

        if (!password) {
            alert('Lütfen şifrenizi girin.');
            e.preventDefault();
            return false;
        }

        return true;
    });
});