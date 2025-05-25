/**
 * register.js
 * Hesap oluşturma sayfası için gerekli işlemler
 */

// Sayfa yüklendiğinde
$(function () {
    // Şehir seçimine göre ilçeleri değiştirir
    $('#city').on('change', function () {
        var cityId = $(this).val();
        if (cityId) {
            // Şehir ID'sine göre ilçeleri getir
            loadDistricts(cityId);
        }
    });
});

/**
 * Şehir ID'sine göre ilçeleri yükler
 * @param {number} cityId Şehir ID'si
 */
function loadDistricts(cityId) {
    // İlçe selectbox'ını temizle
    var $district = $('#district');
    $district.empty();
    $district.append('<option value="" disabled selected>Seçiniz</option>');

    // Şehir ID'sine göre ilçeleri ekle (normalde API'den gelecek)
    if (cityId == 1) { // İstanbul
        $district.append('<option value="1">Kadıköy</option>');
        $district.append('<option value="2">Beşiktaş</option>');
        $district.append('<option value="3">Üsküdar</option>');
        $district.append('<option value="4">Bakırköy</option>');
    } else if (cityId == 2) { // Ankara
        $district.append('<option value="5">Çankaya</option>');
        $district.append('<option value="6">Keçiören</option>');
        $district.append('<option value="7">Etimesgut</option>');
    } else if (cityId == 3) { // İzmir
        $district.append('<option value="8">Konak</option>');
        $district.append('<option value="9">Karşıyaka</option>');
        $district.append('<option value="10">Bornova</option>');
    } else if (cityId == 4) { // Bursa
        $district.append('<option value="11">Nilüfer</option>');
        $district.append('<option value="12">Osmangazi</option>');
    } else if (cityId == 5) { // Adana
        $district.append('<option value="13">Seyhan</option>');
        $district.append('<option value="14">Çukurova</option>');
    }

    // İlçe selectbox'ını etkinleştir
    $district.prop('disabled', false);
}