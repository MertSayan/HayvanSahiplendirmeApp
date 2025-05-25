/**
 * register.js
 * Hesap oluşturma sayfası için gerekli işlemler
 */

// Sayfa yüklendiğinde
$(function () {
    // Şehir seçimine göre ilçeleri değiştirir
    $('#city').on('change', function () {
        var cityId = $(this).val(); // string isim
        if (cityId) {
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
    if (cityId == "Adana") { // Adana
        $district.append('<option value="1">Aladağ</option>');
        $district.append('<option value="2">Ceyhan</option>');
        $district.append('<option value="3">Çukurova</option>');
        $district.append('<option value="4">Feke</option>');
        $district.append('<option value="5">İmamoğlu</option>');
        $district.append('<option value="6">Karaisalı</option>');
        $district.append('<option value="7">Karataş</option>');
        $district.append('<option value="8">Kozan</option>');
        $district.append('<option value="9">Pozantı</option>');
        $district.append('<option value="10">Saimbeyli</option>');
        $district.append('<option value="11">Sarıçam</option>');
        $district.append('<option value="12">Seyhan</option>');
        $district.append('<option value="13">Tufanbeyli</option>');
        $district.append('<option value="14">Yumurtalık</option>');
        $district.append('<option value="15">Yüreğir</option>');
    } else if (cityId == "Adıyaman") { // Adıyaman
        $district.append('<option value="16">Besni</option>');
        $district.append('<option value="17">Çelikhan</option>');
        $district.append('<option value="18">Gerger</option>');
        $district.append('<option value="19">Gölbaşı</option>');
        $district.append('<option value="20">Kahta</option>');
        $district.append('<option value="21">Merkez</option>');
        $district.append('<option value="22">Samsat</option>');
        $district.append('<option value="23">Sincik</option>');
        $district.append('<option value="24">Tut</option>');
    }
    else if (cityId == "Afyonkarahisar") { // Afyonkarahisar
        $district.append('<option>Başmakçı</option>');
        $district.append('<option>Bayat</option>');
        $district.append('<option>Bolvadin</option>');
        $district.append('<option>Çay</option>');
        $district.append('<option>Çobanlar</option>');
        $district.append('<option>Dazkırı</option>');
        $district.append('<option>Dinar</option>');
        $district.append('<option>Emirdağ</option>');
        $district.append('<option>Evciler</option>');
        $district.append('<option>Hocalar</option>');
        $district.append('<option>İhsaniye</option>');
        $district.append('<option>İscehisar</option>');
        $district.append('<option>Kızılören</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sandıklı</option>');
        $district.append('<option>Sinanpaşa</option>');
        $district.append('<option>Sultandağı</option>');
        $district.append('<option>Şuhut</option>');
    } else if (cityId == "Amasya") { // Ağrı
        $district.append('<option>Diyadin</option>');
        $district.append('<option>Doğubayazıt</option>');
        $district.append('<option>Eleşkirt</option>');
        $district.append('<option>Hamur</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Patnos</option>');
        $district.append('<option>Taşlıçay</option>');
        $district.append('<option>Tutak</option>');
    } else if (cityId == 5) { // Amasya
        $district.append('<option>Göynücek</option>');
        $district.append('<option>Gümüşhacıköy</option>');
        $district.append('<option>Hamamözü</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Merzifon</option>');
        $district.append('<option>Suluova</option>');
        $district.append('<option>Taşova</option>');
    } else if (cityId == "Antalya") { // Ankara
        $district.append('<option>Akyurt</option>');
        $district.append('<option>Altındağ</option>');
        $district.append('<option>Ayaş</option>');
        $district.append('<option>Bala</option>');
        $district.append('<option>Beypazarı</option>');
        $district.append('<option>Çamlıdere</option>');
        $district.append('<option>Çankaya</option>');
        $district.append('<option>Çubuk</option>');
        $district.append('<option>Elmadağ</option>');
        $district.append('<option>Etimesgut</option>');
        $district.append('<option>Evren</option>');
        $district.append('<option>Gölbaşı</option>');
        $district.append('<option>Güdül</option>');
        $district.append('<option>Haymana</option>');
        $district.append('<option>Kahramankazan</option>');
        $district.append('<option>Kalecik</option>');
        $district.append('<option>Keçiören</option>');
        $district.append('<option>Kızılcahamam</option>');
        $district.append('<option>Mamak</option>');
        $district.append('<option>Nallıhan</option>');
        $district.append('<option>Polatlı</option>');
        $district.append('<option>Pursaklar</option>');
        $district.append('<option>Sincan</option>');
        $district.append('<option>Şereflikoçhisar</option>');
        $district.append('<option>Yenimahalle</option>');
    } else if (cityId == 7) { // Antalya
        $district.append('<option>Aksu</option>');
        $district.append('<option>Alanya</option>');
        $district.append('<option>Demre</option>');
        $district.append('<option>Döşemealtı</option>');
        $district.append('<option>Elmalı</option>');
        $district.append('<option>Finike</option>');
        $district.append('<option>Gazipaşa</option>');
        $district.append('<option>Gündoğmuş</option>');
        $district.append('<option>İbradı</option>');
        $district.append('<option>Kaş</option>');
        $district.append('<option>Kemer</option>');
        $district.append('<option>Kepez</option>');
        $district.append('<option>Konyaaltı</option>');
        $district.append('<option>Korkuteli</option>');
        $district.append('<option>Kumluca</option>');
        $district.append('<option>Manavgat</option>');
        $district.append('<option>Muratpaşa</option>');
        $district.append('<option>Serik</option>');
    }
    else if (cityId == "Aydın") { // Artvin
        $district.append('<option>Ardanuç</option>');
        $district.append('<option>Arhavi</option>');
        $district.append('<option>Borçka</option>');
        $district.append('<option>Hopa</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Murgul</option>');
        $district.append('<option>Şavşat</option>');
        $district.append('<option>Yusufeli</option>');
    } else if (cityId == 9) { // Aydın
        $district.append('<option>Bozdoğan</option>');
        $district.append('<option>Buharkent</option>');
        $district.append('<option>Çine</option>');
        $district.append('<option>Didim</option>');
        $district.append('<option>Efeler</option>');
        $district.append('<option>Germencik</option>');
        $district.append('<option>İncirliova</option>');
        $district.append('<option>Karacasu</option>');
        $district.append('<option>Karpuzlu</option>');
        $district.append('<option>Koçarlı</option>');
        $district.append('<option>Köşk</option>');
        $district.append('<option>Kuşadası</option>');
        $district.append('<option>Kuyucak</option>');
        $district.append('<option>Nazilli</option>');
        $district.append('<option>Söke</option>');
        $district.append('<option>Sultanhisar</option>');
        $district.append('<option>Yenipazar</option>');
    } else if (cityId == "Balıkesir") { // Balıkesir
        $district.append('<option>Altıeylül</option>');
        $district.append('<option>Ayvalık</option>');
        $district.append('<option>Balya</option>');
        $district.append('<option>Bandırma</option>');
        $district.append('<option>Bigadiç</option>');
        $district.append('<option>Burhaniye</option>');
        $district.append('<option>Dursunbey</option>');
        $district.append('<option>Edremit</option>');
        $district.append('<option>Erdek</option>');
        $district.append('<option>Gömeç</option>');
        $district.append('<option>Gönen</option>');
        $district.append('<option>Havran</option>');
        $district.append('<option>İvrindi</option>');
        $district.append('<option>Karesi</option>');
        $district.append('<option>Kepsut</option>');
        $district.append('<option>Manyas</option>');
        $district.append('<option>Marmara</option>');
        $district.append('<option>Savaştepe</option>');
        $district.append('<option>Sındırgı</option>');
        $district.append('<option>Susurluk</option>');
    } else if (cityId == "Bilecik") { // Bilecik
        $district.append('<option>Bozüyük</option>');
        $district.append('<option>Gölpazarı</option>');
        $district.append('<option>İnhisar</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Osmaneli</option>');
        $district.append('<option>Pazaryeri</option>');
        $district.append('<option>Söğüt</option>');
        $district.append('<option>Yenipazar</option>');
    } else if (cityId == "Bingöl") { // Bingöl
        $district.append('<option>Adaklı</option>');
        $district.append('<option>Genç</option>');
        $district.append('<option>Karlıova</option>');
        $district.append('<option>Kiğı</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Solhan</option>');
        $district.append('<option>Yayladere</option>');
        $district.append('<option>Yedisu</option>');
    } else if (cityId == "Bitlis") { // Bitlis
        $district.append('<option>Adilcevaz</option>');
        $district.append('<option>Ahlat</option>');
        $district.append('<option>Güroymak</option>');
        $district.append('<option>Hizan</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Mutki</option>');
        $district.append('<option>Tatvan</option>');
    } else if (cityId == "Bolu") { // "Bolu"
        $district.append('<option>Dörtdivan</option>');
        $district.append('<option>Gerede</option>');
        $district.append('<option>Göynük</option>');
        $district.append('<option>Kıbrıscık</option>');
        $district.append('<option>Mengen</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Mudurnu</option>');
        $district.append('<option>Seben</option>');
        $district.append('<option>Yeniçağa</option>');
    }
    else if (cityId == "Burdur") { // Burdur
        $district.append('<option>Ağlasun</option>');
        $district.append('<option>Altınyayla</option>');
        $district.append('<option>Bucak</option>');
        $district.append('<option>Çavdır</option>');
        $district.append('<option>Çeltikçi</option>');
        $district.append('<option>Gölhisar</option>');
        $district.append('<option>Kemer</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Tefenni</option>');
        $district.append('<option>Yeşilova</option>');
    } else if (cityId == "Bursa") { // Bursa
        $district.append('<option>Gemlik</option>');
        $district.append('<option>Gürsu</option>');
        $district.append('<option>Harmancık</option>');
        $district.append('<option>İnegöl</option>');
        $district.append('<option>İznik</option>');
        $district.append('<option>Karacabey</option>');
        $district.append('<option>Keles</option>');
        $district.append('<option>Kestel</option>');
        $district.append('<option>Mudanya</option>');
        $district.append('<option>Mustafakemalpaşa</option>');
        $district.append('<option>Nilüfer</option>');
        $district.append('<option>Orhaneli</option>');
        $district.append('<option>Orhangazi</option>');
        $district.append('<option>Osmangazi</option>');
        $district.append('<option>Yenişehir</option>');
        $district.append('<option>Yıldırım</option>');
    } else if (cityId == "Çanakkale") { // Çanakkale
        $district.append('<option>Ayvacık</option>');
        $district.append('<option>Bayramiç</option>');
        $district.append('<option>Biga</option>');
        $district.append('<option>Bozcaada</option>');
        $district.append('<option>Çan</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Eceabat</option>');
        $district.append('<option>Ezine</option>');
        $district.append('<option>Gelibolu</option>');
        $district.append('<option>Gökçeada</option>');
        $district.append('<option>Lapseki</option>');
        $district.append('<option>Yenice</option>');
    } else if (cityId == "Çankırı") { // Çankırı
        $district.append('<option>Atkaracalar</option>');
        $district.append('<option>Bayramören</option>');
        $district.append('<option>Çerkeş</option>');
        $district.append('<option>Eldivan</option>');
        $district.append('<option>Ilgaz</option>');
        $district.append('<option>Kızılırmak</option>');
        $district.append('<option>Korgun</option>');
        $district.append('<option>Kurşunlu</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Orta</option>');
        $district.append('<option>Şabanözü</option>');
        $district.append('<option>Yapraklı</option>');
    } else if (cityId == "Çorum") { // Çorum
        $district.append('<option>Alaca</option>');
        $district.append('<option>Bayat</option>');
        $district.append('<option>Boğazkale</option>');
        $district.append('<option>Dodurga</option>');
        $district.append('<option>İskilip</option>');
        $district.append('<option>Kargı</option>');
        $district.append('<option>Laçin</option>');
        $district.append('<option>Mecitözü</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Oğuzlar</option>');
        $district.append('<option>Ortaköy</option>');
        $district.append('<option>Osmancık</option>');
        $district.append('<option>Sungurlu</option>');
        $district.append('<option>Uğurludağ</option>');
    } else if (cityId == "Denizli") { // Denizli
        $district.append('<option>Acıpayam</option>');
        $district.append('<option>Babadağ</option>');
        $district.append('<option>Baklan</option>');
        $district.append('<option>Bekilli</option>');
        $district.append('<option>Beyağaç</option>');
        $district.append('<option>Bozkurt</option>');
        $district.append('<option>Buldan</option>');
        $district.append('<option>Çal</option>');
        $district.append('<option>Çameli</option>');
        $district.append('<option>Çardak</option>');
        $district.append('<option>Çivril</option>');
        $district.append('<option>Güney</option>');
        $district.append('<option>Honaz</option>');
        $district.append('<option>Kale</option>');
        $district.append('<option>Merkezefendi</option>');
        $district.append('<option>Pamukkale</option>');
        $district.append('<option>Sarayköy</option>');
        $district.append('<option>Serinhisar</option>');
        $district.append('<option>Tavas</option>');
    } else if (cityId == "Diyarbakır") { // Diyarbakır
        $district.append('<option>Bağlar</option>');
        $district.append('<option>Bismil</option>');
        $district.append('<option>Çermik</option>');
        $district.append('<option>Çınar</option>');
        $district.append('<option>Çüngüş</option>');
        $district.append('<option>Dicle</option>');
        $district.append('<option>Eğil</option>');
        $district.append('<option>Ergani</option>');
        $district.append('<option>Hani</option>');
        $district.append('<option>Hazro</option>');
        $district.append('<option>Kocaköy</option>');
        $district.append('<option>Kulp</option>');
        $district.append('<option>Lice</option>');
        $district.append('<option>Silvan</option>');
        $district.append('<option>Sur</option>');
        $district.append('<option>Yenişehir</option>');
    }
    else if (cityId == "Edirne") { // Edirne
        $district.append('<option>Enez</option>');
        $district.append('<option>Havsa</option>');
        $district.append('<option>İpsala</option>');
        $district.append('<option>Keşan</option>');
        $district.append('<option>Lalapaşa</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Meriç</option>');
        $district.append('<option>Süloğlu</option>');
        $district.append('<option>Uzunköprü</option>');
    } else if (cityId == "Elazığ") { // Elazığ
        $district.append('<option>Ağın</option>');
        $district.append('<option>Alacakaya</option>');
        $district.append('<option>Arıcak</option>');
        $district.append('<option>Baskil</option>');
        $district.append('<option>Karakoçan</option>');
        $district.append('<option>Keban</option>');
        $district.append('<option>Kovancılar</option>');
        $district.append('<option>Maden</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Palu</option>');
        $district.append('<option>Sivrice</option>');
    } else if (cityId == "Erzincan") { // Erzincan
        $district.append('<option>Çayırlı</option>');
        $district.append('<option>İliç</option>');
        $district.append('<option>Kemah</option>');
        $district.append('<option>Kemaliye</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Otlukbeli</option>');
        $district.append('<option>Refahiye</option>');
        $district.append('<option>Tercan</option>');
        $district.append('<option>Üzümlü</option>');
    } else if (cityId == "Erzurum") { // Erzurum
        $district.append('<option>Aşkale</option>');
        $district.append('<option>Aziziye</option>');
        $district.append('<option>Çat</option>');
        $district.append('<option>Hınıs</option>');
        $district.append('<option>Horasan</option>');
        $district.append('<option>İspir</option>');
        $district.append('<option>Karayazı</option>');
        $district.append('<option>Karaçoban</option>');
        $district.append('<option>Köprüköy</option>');
        $district.append('<option>Narman</option>');
        $district.append('<option>Oltu</option>');
        $district.append('<option>Olur</option>');
        $district.append('<option>Palandöken</option>');
        $district.append('<option>Pasinler</option>');
        $district.append('<option>Pazaryolu</option>');
        $district.append('<option>Şenkaya</option>');
        $district.append('<option>Tekman</option>');
        $district.append('<option>Tortum</option>');
        $district.append('<option>Uzundere</option>');
        $district.append('<option>Yakutiye</option>');
    } else if (cityId == "Eskişehir") { // Eskişehir
        $district.append('<option>Alpu</option>');
        $district.append('<option>Beylikova</option>');
        $district.append('<option>Çifteler</option>');
        $district.append('<option>Günyüzü</option>');
        $district.append('<option>Han</option>');
        $district.append('<option>İnönü</option>');
        $district.append('<option>Mahmudiye</option>');
        $district.append('<option>Mihalgazi</option>');
        $district.append('<option>Mihalıççık</option>');
        $district.append('<option>Odunpazarı</option>');
        $district.append('<option>Sarıcakaya</option>');
        $district.append('<option>Seyitgazi</option>');
        $district.append('<option>Tepebaşı</option>');
    } else if (cityId == "Gaziantep") { // Gaziantep
        $district.append('<option>Araban</option>');
        $district.append('<option>İslahiye</option>');
        $district.append('<option>Karkamış</option>');
        $district.append('<option>Nizip</option>');
        $district.append('<option>Nurdağı</option>');
        $district.append('<option>Oğuzeli</option>');
        $district.append('<option>Şahinbey</option>');
        $district.append('<option>Şehitkamil</option>');
        $district.append('<option>Yavuzeli</option>');
    } else if (cityId == "Giresun") { // Giresun
        $district.append('<option>Alucra</option>');
        $district.append('<option>Bulancak</option>');
        $district.append('<option>Çamoluk</option>');
        $district.append('<option>Çanakçı</option>');
        $district.append('<option>Dereli</option>');
        $district.append('<option>Doğankent</option>');
        $district.append('<option>Espiye</option>');
        $district.append('<option>Eynesil</option>');
        $district.append('<option>Görele</option>');
        $district.append('<option>Güce</option>');
        $district.append('<option>Keşap</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Piraziz</option>');
        $district.append('<option>Şebinkarahisar</option>');
        $district.append('<option>Tirebolu</option>');
        $district.append('<option>Yağlıdere</option>');
    }
    else if (cityId == "Gümüşhane") { // Gümüşhane
        $district.append('<option>Kelkit</option>');
        $district.append('<option>Köse</option>');
        $district.append('<option>Kürtün</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Şiran</option>');
        $district.append('<option>Torul</option>');
    } else if (cityId == "Hakkari") { // Hakkari
        $district.append('<option>Çukurca</option>');
        $district.append('<option>Derecik</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Şemdinli</option>');
        $district.append('<option>Yüksekova</option>');
    } else if (cityId == "Hatay") { // Hatay
        $district.append('<option>Altınözü</option>');
        $district.append('<option>Antakya</option>');
        $district.append('<option>Arsuz</option>');
        $district.append('<option>Belen</option>');
        $district.append('<option>Dörtyol</option>');
        $district.append('<option>Erzin</option>');
        $district.append('<option>Hassa</option>');
        $district.append('<option>İskenderun</option>');
        $district.append('<option>Kırıkhan</option>');
        $district.append('<option>Kumlu</option>');
        $district.append('<option>Payas</option>');
        $district.append('<option>Reyhanlı</option>');
        $district.append('<option>Samandağ</option>');
        $district.append('<option>Yayladağı</option>');
    } else if (cityId == "Isparta") { // Isparta
        $district.append('<option>Aksu</option>');
        $district.append('<option>Atabey</option>');
        $district.append('<option>Eğirdir</option>');
        $district.append('<option>Gelendost</option>');
        $district.append('<option>Gönen</option>');
        $district.append('<option>Keçiborlu</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sarkikaraagaç</option>');
        $district.append('<option>Sütçüler</option>');
        $district.append('<option>Şarkikaraağaç</option>');
        $district.append('<option>Uluborlu</option>');
        $district.append('<option>Yalvaç</option>');
        $district.append('<option>Yenişarbademli</option>');
    } else if (cityId == "Mersin") { // Mersin
        $district.append('<option>Akdeniz</option>');
        $district.append('<option>Anamur</option>');
        $district.append('<option>Aydıncık</option>');
        $district.append('<option>Bozyazı</option>');
        $district.append('<option>Çamlıyayla</option>');
        $district.append('<option>Erdemli</option>');
        $district.append('<option>Gülnar</option>');
        $district.append('<option>Mezitli</option>');
        $district.append('<option>Mut</option>');
        $district.append('<option>Silifke</option>');
        $district.append('<option>Tarsus</option>');
        $district.append('<option>Toroslar</option>');
        $district.append('<option>Yenişehir</option>');
    } else if (cityId == "İstanbul") { // İstanbul
        $district.append('<option>Adalar</option>');
        $district.append('<option>Arnavutköy</option>');
        $district.append('<option>Ataşehir</option>');
        $district.append('<option>Avcılar</option>');
        $district.append('<option>Bağcılar</option>');
        $district.append('<option>Bahçelievler</option>');
        $district.append('<option>Bakırköy</option>');
        $district.append('<option>Başakşehir</option>');
        $district.append('<option>Bayrampaşa</option>');
        $district.append('<option>Beşiktaş</option>');
        $district.append('<option>Beykoz</option>');
        $district.append('<option>Beylikdüzü</option>');
        $district.append('<option>Beyoğlu</option>');
        $district.append('<option>Büyükçekmece</option>');
        $district.append('<option>Çatalca</option>');
        $district.append('<option>Çekmeköy</option>');
        $district.append('<option>Esenler</option>');
        $district.append('<option>Esenyurt</option>');
        $district.append('<option>Eyüpsultan</option>');
        $district.append('<option>Fatih</option>');
        $district.append('<option>Gaziosmanpaşa</option>');
        $district.append('<option>Güngören</option>');
        $district.append('<option>Kadıköy</option>');
        $district.append('<option>Kağıthane</option>');
        $district.append('<option>Kartal</option>');
        $district.append('<option>Küçükçekmece</option>');
        $district.append('<option>Maltepe</option>');
        $district.append('<option>Pendik</option>');
        $district.append('<option>Sancaktepe</option>');
        $district.append('<option>Sarıyer</option>');
        $district.append('<option>Şile</option>');
        $district.append('<option>Silivri</option>');
        $district.append('<option>Şişli</option>');
        $district.append('<option>Sultanbeyli</option>');
        $district.append('<option>Sultangazi</option>');
        $district.append('<option>Tuzla</option>');
        $district.append('<option>Ümraniye</option>');
        $district.append('<option>Üsküdar</option>');
        $district.append('<option>Zeytinburnu</option>');
    } else if (cityId == "İzmir") { // İzmir
        $district.append('<option>Aliağa</option>');
        $district.append('<option>Balçova</option>');
        $district.append('<option>Bayındır</option>');
        $district.append('<option>Bayraklı</option>');
        $district.append('<option>Bergama</option>');
        $district.append('<option>Beydağ</option>');
        $district.append('<option>Bornova</option>');
        $district.append('<option>Buca</option>');
        $district.append('<option>Çeşme</option>');
        $district.append('<option>Çiğli</option>');
        $district.append('<option>Dikili</option>');
        $district.append('<option>Foça</option>');
        $district.append('<option>Gaziemir</option>');
        $district.append('<option>Güzelbahçe</option>');
        $district.append('<option>Karabağlar</option>');
        $district.append('<option>Karaburun</option>');
        $district.append('<option>Karşıyaka</option>');
        $district.append('<option>Kemalpaşa</option>');
        $district.append('<option>Kınık</option>');
        $district.append('<option>Kiraz</option>');
        $district.append('<option>Konak</option>');
        $district.append('<option>Menderes</option>');
        $district.append('<option>Menemen</option>');
        $district.append('<option>Narlıdere</option>');
        $district.append('<option>Ödemiş</option>');
        $district.append('<option>Seferihisar</option>');
        $district.append('<option>Selçuk</option>');
        $district.append('<option>Tire</option>');
        $district.append('<option>Torbalı</option>');
        $district.append('<option>Urla</option>');
    }
    else if (cityId == "Kars") { // Kars
        $district.append('<option>Akyaka</option>');
        $district.append('<option>Arpaçay</option>');
        $district.append('<option>Digor</option>');
        $district.append('<option>Kağızman</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sarıkamış</option>');
        $district.append('<option>Selim</option>');
        $district.append('<option>Susuz</option>');
    } else if (cityId == "Kastamonu") { // Kastamonu
        $district.append('<option>Abana</option>');
        $district.append('<option>Araç</option>');
        $district.append('<option>Azdavay</option>');
        $district.append('<option>Bozkurt</option>');
        $district.append('<option>Cide</option>');
        $district.append('<option>Çatalzeytin</option>');
        $district.append('<option>Daday</option>');
        $district.append('<option>Devrekani</option>');
        $district.append('<option>Doğanyurt</option>');
        $district.append('<option>Hanönü</option>');
        $district.append('<option>İhsangazi</option>');
        $district.append('<option>İnebolu</option>');
        $district.append('<option>Küre</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Pınarbaşı</option>');
        $district.append('<option>Şenpazar</option>');
        $district.append('<option>Seydiler</option>');
        $district.append('<option>Taşköprü</option>');
        $district.append('<option>Tosya</option>');
    } else if (cityId == "Kayseri") { // Kayseri
        $district.append('<option>Akkışla</option>');
        $district.append('<option>Bünyan</option>');
        $district.append('<option>Develi</option>');
        $district.append('<option>Felahiye</option>');
        $district.append('<option>Hacılar</option>');
        $district.append('<option>İncesu</option>');
        $district.append('<option>Kocasinan</option>');
        $district.append('<option>Melikgazi</option>');
        $district.append('<option>Özvatan</option>');
        $district.append('<option>Pınarbaşı</option>');
        $district.append('<option>Sarıoğlan</option>');
        $district.append('<option>Sarız</option>');
        $district.append('<option>Talas</option>');
        $district.append('<option>Tomarza</option>');
        $district.append('<option>Yahyalı</option>');
        $district.append('<option>Yeşilhisar</option>');
    } else if (cityId == "Kırklareli") { // Kırklareli
        $district.append('<option>Babaeski</option>');
        $district.append('<option>Demirköy</option>');
        $district.append('<option>Kofçaz</option>');
        $district.append('<option>Lüleburgaz</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Pehlivanköy</option>');
        $district.append('<option>Pınarhisar</option>');
        $district.append('<option>Vize</option>');
    } else if (cityId == "Kırşehir") { // Kırşehir
        $district.append('<option>Akçakent</option>');
        $district.append('<option>Akpınar</option>');
        $district.append('<option>Boztepe</option>');
        $district.append('<option>Çiçekdağı</option>');
        $district.append('<option>Kaman</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Mucur</option>');
    } else if (cityId == "Kocaeli") { // Kocaeli
        $district.append('<option>Başiskele</option>');
        $district.append('<option>Çayırova</option>');
        $district.append('<option>Darıca</option>');
        $district.append('<option>Derince</option>');
        $district.append('<option>Dilovası</option>');
        $district.append('<option>Gebze</option>');
        $district.append('<option>Gölcük</option>');
        $district.append('<option>İzmit</option>');
        $district.append('<option>Kandıra</option>');
        $district.append('<option>Karamürsel</option>');
        $district.append('<option>Kartepe</option>');
        $district.append('<option>Körfez</option>');
    } else if (cityId == "Konya") { // Konya
        $district.append('<option>Ahırlı</option>');
        $district.append('<option>Akören</option>');
        $district.append('<option>Akşehir</option>');
        $district.append('<option>Altınekin</option>');
        $district.append('<option>Beyşehir</option>');
        $district.append('<option>Bozkır</option>');
        $district.append('<option>Çeltik</option>');
        $district.append('<option>Cihanbeyli</option>');
        $district.append('<option>Çumra</option>');
        $district.append('<option>Derbent</option>');
        $district.append('<option>Derebucak</option>');
        $district.append('<option>Doğanhisar</option>');
        $district.append('<option>Emirgazi</option>');
        $district.append('<option>Ereğli</option>');
        $district.append('<option>Güneysınır</option>');
        $district.append('<option>Hadim</option>');
        $district.append('<option>Halkapınar</option>');
        $district.append('<option>Hüyük</option>');
        $district.append('<option>Ilgın</option>');
        $district.append('<option>Kadınhanı</option>');
        $district.append('<option>Karapınar</option>');
        $district.append('<option>Karatay</option>');
        $district.append('<option>Meram</option>');
        $district.append('<option>Sarayönü</option>');
        $district.append('<option>Selçuklu</option>');
        $district.append('<option>Seydişehir</option>');
        $district.append('<option>Taşkent</option>');
        $district.append('<option>Tuzlukçu</option>');
        $district.append('<option>Yalıhüyük</option>');
        $district.append('<option>Yunak</option>');
    } else if (cityId == "Kütahya") { // Kütahya
        $district.append('<option>Altıntaş</option>');
        $district.append('<option>Aslanapa</option>');
        $district.append('<option>Çavdarhisar</option>');
        $district.append('<option>Domaniç</option>');
        $district.append('<option>Dumlupınar</option>');
        $district.append('<option>Emet</option>');
        $district.append('<option>Gediz</option>');
        $district.append('<option>Hisarcık</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Pazarlar</option>');
        $district.append('<option>Şaphane</option>');
        $district.append('<option>Simav</option>');
        $district.append('<option>Tavşanlı</option>');
    } else if (cityId == "Malatya") { // Malatya
        $district.append('<option>Akçadağ</option>');
        $district.append('<option>Arapgir</option>');
        $district.append('<option>Arguvan</option>');
        $district.append('<option>Battalgazi</option>');
        $district.append('<option>Darende</option>');
        $district.append('<option>Doğanşehir</option>');
        $district.append('<option>Doğanyol</option>');
        $district.append('<option>Hekimhan</option>');
        $district.append('<option>Kale</option>');
        $district.append('<option>Kuluncak</option>');
        $district.append('<option>Pütürge</option>');
        $district.append('<option>Yazıhan</option>');
        $district.append('<option>Yeşilyurt</option>');
    } else if (cityId == "Manisa") { // Manisa
        $district.append('<option>Ahmetli</option>');
        $district.append('<option>Akhisar</option>');
        $district.append('<option>Alaşehir</option>');
        $district.append('<option>Demirci</option>');
        $district.append('<option>Gölmarmara</option>');
        $district.append('<option>Gördes</option>');
        $district.append('<option>Kırkağaç</option>');
        $district.append('<option>Köprübaşı</option>');
        $district.append('<option>Kula</option>');
        $district.append('<option>Salihli</option>');
        $district.append('<option>Saruhanlı</option>');
        $district.append('<option>Sarıgöl</option>');
        $district.append('<option>Selendi</option>');
        $district.append('<option>Soma</option>');
        $district.append('<option>Şehzadeler</option>');
        $district.append('<option>Turgutlu</option>');
        $district.append('<option>Yunusemre</option>');
    } else if (cityId == "Kahramanmaraş") { // Kahramanmaraş
        $district.append('<option>Afşin</option>');
        $district.append('<option>Andırın</option>');
        $district.append('<option>Çağlayancerit</option>');
        $district.append('<option>Dulkadiroğlu</option>');
        $district.append('<option>Ekinözü</option>');
        $district.append('<option>Elbistan</option>');
        $district.append('<option>Göksun</option>');
        $district.append('<option>Nurhak</option>');
        $district.append('<option>Onikişubat</option>');
        $district.append('<option>Pazarcık</option>');
        $district.append('<option>Türkoğlu</option>');
    }
    else if (cityId == "Mardin") { // Mardin
        $district.append('<option>Artuklu</option>');
        $district.append('<option>Dargeçit</option>');
        $district.append('<option>Derik</option>');
        $district.append('<option>Kızıltepe</option>');
        $district.append('<option>Mazıdağı</option>');
        $district.append('<option>Midyat</option>');
        $district.append('<option>Nusaybin</option>');
        $district.append('<option>Ömerli</option>');
        $district.append('<option>Savur</option>');
        $district.append('<option>Yeşilli</option>');
    } else if (cityId == "Muğla") { // Muğla
        $district.append('<option>Bodrum</option>');
        $district.append('<option>Dalaman</option>');
        $district.append('<option>Datça</option>');
        $district.append('<option>Fethiye</option>');
        $district.append('<option>Kavaklıdere</option>');
        $district.append('<option>Köyceğiz</option>');
        $district.append('<option>Marmaris</option>');
        $district.append('<option>Menteşe</option>');
        $district.append('<option>Milas</option>');
        $district.append('<option>Ortaca</option>');
        $district.append('<option>Ula</option>');
        $district.append('<option>Yatağan</option>');
    } else if (cityId == "Muş") { // Muş
        $district.append('<option>Bulanık</option>');
        $district.append('<option>Hasköy</option>');
        $district.append('<option>Korkut</option>');
        $district.append('<option>Malazgirt</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Varto</option>');
    } else if (cityId == "Nevşehir") { // Nevşehir
        $district.append('<option>Acıgöl</option>');
        $district.append('<option>Avanos</option>');
        $district.append('<option>Derinkuyu</option>');
        $district.append('<option>Gülşehir</option>');
        $district.append('<option>Hacıbektaş</option>');
        $district.append('<option>Kozaklı</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Ürgüp</option>');
    } else if (cityId == "Niğde") { // Niğde
        $district.append('<option>Altunhisar</option>');
        $district.append('<option>Bor</option>');
        $district.append('<option>Çamardı</option>');
        $district.append('<option>Çiftlik</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Ulukışla</option>');
    } else if (cityId == "Ordu") { // Ordu
        $district.append('<option>Akkuş</option>');
        $district.append('<option>Altınordu</option>');
        $district.append('<option>Aybastı</option>');
        $district.append('<option>Çamaş</option>');
        $district.append('<option>Çatalpınar</option>');
        $district.append('<option>Çaybaşı</option>');
        $district.append('<option>Fatsa</option>');
        $district.append('<option>Gölköy</option>');
        $district.append('<option>Gülyalı</option>');
        $district.append('<option>Gürgentepe</option>');
        $district.append('<option>İkizce</option>');
        $district.append('<option>Kabadüz</option>');
        $district.append('<option>Kabataş</option>');
        $district.append('<option>Korgan</option>');
        $district.append('<option>Kumru</option>');
        $district.append('<option>Mesudiye</option>');
        $district.append('<option>Perşembe</option>');
        $district.append('<option>Ulubey</option>');
        $district.append('<option>Ünye</option>');
    } else if (cityId == "Rize") { // Rize
        $district.append('<option>Ardeşen</option>');
        $district.append('<option>Çamlıhemşin</option>');
        $district.append('<option>Çayeli</option>');
        $district.append('<option>Derepazarı</option>');
        $district.append('<option>Fındıklı</option>');
        $district.append('<option>Güneysu</option>');
        $district.append('<option>Hemşin</option>');
        $district.append('<option>İkizdere</option>');
        $district.append('<option>İyidere</option>');
        $district.append('<option>İyidere</option>');
        $district.append('<option>Kalkandere</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Pazar</option>');
    } else if (cityId == "Sakarya") { // Sakarya
        $district.append('<option>Adapazarı</option>');
        $district.append('<option>Akyazı</option>');
        $district.append('<option>Arifiye</option>');
        $district.append('<option>Erenler</option>');
        $district.append('<option>Ferizli</option>');
        $district.append('<option>Geyve</option>');
        $district.append('<option>Hendek</option>');
        $district.append('<option>Karapürçek</option>');
        $district.append('<option>Karasu</option>');
        $district.append('<option>Kaynarca</option>');
        $district.append('<option>Kocaali</option>');
        $district.append('<option>Pamukova</option>');
        $district.append('<option>Sapanca</option>');
        $district.append('<option>Serdivan</option>');
        $district.append('<option>Söğütlü</option>');
        $district.append('<option>Taraklı</option>');
    } else if (cityId == "Samsun") { // Samsun
        $district.append('<option>Alaçam</option>');
        $district.append('<option>Asarcık</option>');
        $district.append('<option>Atakum</option>');
        $district.append('<option>Ayvacık</option>');
        $district.append('<option>Bafra</option>');
        $district.append('<option>Canik</option>');
        $district.append('<option>Çarşamba</option>');
        $district.append('<option>Havza</option>');
        $district.append('<option>İlkadım</option>');
        $district.append('<option>Kavak</option>');
        $district.append('<option>Ladik</option>');
        $district.append('<option>Salıpazarı</option>');
        $district.append('<option>Terme</option>');
        $district.append('<option>Tekkeköy</option>');
        $district.append('<option>Vezirköprü</option>');
        $district.append('<option>Yakakent</option>');
    } else if (cityId == "Siirt") { // Siirt
        $district.append('<option>Baykan</option>');
        $district.append('<option>Eruh</option>');
        $district.append('<option>Kurtalan</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Pervari</option>');
        $district.append('<option>Şirvan</option>');
        $district.append('<option>Tillo</option>');
    } else if (cityId == "Sinop") { // Sinop
        $district.append('<option>Ayancık</option>');
        $district.append('<option>Boyabat</option>');
        $district.append('<option>Dikmen</option>');
        $district.append('<option>Durağan</option>');
        $district.append('<option>Erfelek</option>');
        $district.append('<option>Gerze</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Saraydüzü</option>');
        $district.append('<option>Türkeli</option>');
    } else if (cityId == "Sivas") { // Sivas
        $district.append('<option>Akıncılar</option>');
        $district.append('<option>Altınyayla</option>');
        $district.append('<option>Divriği</option>');
        $district.append('<option>Doğanşar</option>');
        $district.append('<option>Gemerek</option>');
        $district.append('<option>Gölova</option>');
        $district.append('<option>Gürün</option>');
        $district.append('<option>Hafik</option>');
        $district.append('<option>İmranlı</option>');
        $district.append('<option>Kangal</option>');
        $district.append('<option>Koyulhisar</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Suşehri</option>');
        $district.append('<option>Şarkışla</option>');
        $district.append('<option>Ulaş</option>');
        $district.append('<option>Yıldızeli</option>');
        $district.append('<option>Zara</option>');
    } else if (cityId == "Tekirdağ") { // Tekirdağ
        $district.append('<option>Çerkezköy</option>');
        $district.append('<option>Çorlu</option>');
        $district.append('<option>Ergene</option>');
        $district.append('<option>Hayrabolu</option>');
        $district.append('<option>Malkara</option>');
        $district.append('<option>Marmaraereğlisi</option>');
        $district.append('<option>Muratlı</option>');
        $district.append('<option>Saray</option>');
        $district.append('<option>Süleymanpaşa</option>');
        $district.append('<option>Şarköy</option>');
    } else if (cityId == "Tokat") { // Tokat
        $district.append('<option>Almus</option>');
        $district.append('<option>Artova</option>');
        $district.append('<option>Başçiftlik</option>');
        $district.append('<option>Erbaa</option>');
        $district.append('<option>Niksar</option>');
        $district.append('<option>Pazar</option>');
        $district.append('<option>Reşadiye</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sulusaray</option>');
        $district.append('<option>Turhal</option>');
    }
    else if (cityId == "Trabzon") { // Trabzon
        $district.append('<option>Akçaabat</option>');
        $district.append('<option>Araklı</option>');
        $district.append('<option>Arsin</option>');
        $district.append('<option>Beşikdüzü</option>');
        $district.append('<option>Çarşıbaşı</option>');
        $district.append('<option>Çaykara</option>');
        $district.append('<option>Dernekpazarı</option>');
        $district.append('<option>Düzköy</option>');
        $district.append('<option>Hayrat</option>');
        $district.append('<option>Köprübaşı</option>');
        $district.append('<option>Maçka</option>');
        $district.append('<option>Of</option>');
        $district.append('<option>Ortahisar</option>');
        $district.append('<option>Sürmene</option>');
        $district.append('<option>Şalpazarı</option>');
        $district.append('<option>Tonya</option>');
        $district.append('<option>Vakfıkebir</option>');
        $district.append('<option>Yomra</option>');
    } else if (cityId == "Tunceli") { // Tunceli
        $district.append('<option>Çemişgezek</option>');
        $district.append('<option>Hozat</option>');
        $district.append('<option>Mazgirt</option>');
        $district.append('<option>Nazımiye</option>');
        $district.append('<option>Ovacık</option>');
        $district.append('<option>Pertek</option>');
        $district.append('<option>Pülümür</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Şanlıurfa") { // Şanlıurfa
        $district.append('<option>Akçakale</option>');
        $district.append('<option>Birecik</option>');
        $district.append('<option>Bozova</option>');
        $district.append('<option>Ceylanpınar</option>');
        $district.append('<option>Eyyübiye</option>');
        $district.append('<option>Halfeti</option>');
        $district.append('<option>Haliliye</option>');
        $district.append('<option>Harran</option>');
        $district.append('<option>Hilvan</option>');
        $district.append('<option>Karaköprü</option>');
        $district.append('<option>Siverek</option>');
        $district.append('<option>Suruç</option>');
        $district.append('<option>Viranşehir</option>');
    } else if (cityId == "Uşak") { // Uşak
        $district.append('<option>Banaz</option>');
        $district.append('<option>Eşme</option>');
        $district.append('<option>Karahallı</option>');
        $district.append('<option>Sivaslı</option>');
        $district.append('<option>Ulubey</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Van") { // Van
        $district.append('<option>Bahçesaray</option>');
        $district.append('<option>Başkale</option>');
        $district.append('<option>Çaldıran</option>');
        $district.append('<option>Çatak</option>');
        $district.append('<option>Edremit</option>');
        $district.append('<option>Erciş</option>');
        $district.append('<option>Gevaş</option>');
        $district.append('<option>Gürpınar</option>');
        $district.append('<option>İpekyolu</option>');
        $district.append('<option>Muradiye</option>');
        $district.append('<option>Özalp</option>');
        $district.append('<option>Saray</option>');
        $district.append('<option>Tuşba</option>');
    } else if (cityId == "Yozgat") { // Yozgat
        $district.append('<option>Akdağmadeni</option>');
        $district.append('<option>Aydıncık</option>');
        $district.append('<option>Boğazlıyan</option>');
        $district.append('<option>Çandır</option>');
        $district.append('<option>Çayıralan</option>');
        $district.append('<option>Çekerek</option>');
        $district.append('<option>Kadışehri</option>');
        $district.append('<option>Saraykent</option>');
        $district.append('<option>Sarıkaya</option>');
        $district.append('<option>Sorgun</option>');
        $district.append('<option>Şefaatli</option>');
        $district.append('<option>Yenifakılı</option>');
        $district.append('<option>Yerköy</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Zonguldak") { // Zonguldak
        $district.append('<option>Alaplı</option>');
        $district.append('<option>Çaycuma</option>');
        $district.append('<option>Devrek</option>');
        $district.append('<option>Gökçebey</option>');
        $district.append('<option>Kilimli</option>');
        $district.append('<option>Kozlu</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Aksaray") { // Aksaray
        $district.append('<option>Ağaçören</option>');
        $district.append('<option>Eskil</option>');
        $district.append('<option>Gülağaç</option>');
        $district.append('<option>Güzelyurt</option>');
        $district.append('<option>Ortaköy</option>');
        $district.append('<option>Sarıyahşi</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Bayburt") { // Bayburt
        $district.append('<option>Aydıntepe</option>');
        $district.append('<option>Demirözü</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Karaman") { // Karaman
        $district.append('<option>Ayrancı</option>');
        $district.append('<option>Başyayla</option>');
        $district.append('<option>Ermenek</option>');
        $district.append('<option>Kazımkarabekir</option>');
        $district.append('<option>Sarıveliler</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Kırıkkale") { // Kırıkkale
        $district.append('<option>Bahşili</option>');
        $district.append('<option>Balışeyh</option>');
        $district.append('<option>Çelebi</option>');
        $district.append('<option>Delice</option>');
        $district.append('<option>Karakeçili</option>');
        $district.append('<option>Keskin</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sulakyurt</option>');
        $district.append('<option>Yahşihan</option>');
    } else if (cityId == "Batman") { // Batman
        $district.append('<option>Beşiri</option>');
        $district.append('<option>Gercüş</option>');
        $district.append('<option>Hasankeyf</option>');
        $district.append('<option>Kozluk</option>');
        $district.append('<option>Sason</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Şırnak") { // Şırnak
        $district.append('<option>Uludere</option>');
        $district.append('<option>Silopi</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>İdil</option>');
        $district.append('<option>Güçlükonak</option>');
        $district.append('<option>Cizre</option>');
        $district.append('<option>Beytüşşebap</option>');
    } else if (cityId == "Bartın") { // Bartın
        $district.append('<option>Amasra</option>');
        $district.append('<option>Kurucaşile</option>');
        $district.append('<option>Ulus</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Ardahan") { // Ardahan
        $district.append('<option>Çıldır</option>');
        $district.append('<option>Damal</option>');
        $district.append('<option>Göle</option>');
        $district.append('<option>Hanak</option>');
        $district.append('<option>Posof</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Iğdır") { // Iğdır
        $district.append('<option>Aralık</option>');
        $district.append('<option>Karakoyunlu</option>');
        $district.append('<option>Tuzluca</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Yalova") { // Yalova
        $district.append('<option>Altınova</option>');
        $district.append('<option>Armutlu</option>');
        $district.append('<option>Çınarcık</option>');
        $district.append('<option>Çiftlikköy</option>');
        $district.append('<option>Termal</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Karabük") { // Karabük
        $district.append('<option>Eflani</option>');
        $district.append('<option>Eskipazar</option>');
        $district.append('<option>Ovacık</option>');
        $district.append('<option>Safranbolu</option>');
        $district.append('<option>Yenice</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Kilis") { // Kilis
        $district.append('<option>Elbeyli</option>');
        $district.append('<option>Musabeyli</option>');
        $district.append('<option>Polateli</option>');
        $district.append('<option>Merkez</option>');
    } else if (cityId == "Osmaniye") { // Osmaniye
        $district.append('<option>Bahçe</option>');
        $district.append('<option>Düziçi</option>');
        $district.append('<option>Hasanbeyli</option>');
        $district.append('<option>Kadirli</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Sumbas</option>');
        $district.append('<option>Toprakkale</option>');
    } else if (cityId == "Düzce") { // Düzce
        $district.append('<option>Akçakoca</option>');
        $district.append('<option>Çilimli</option>');
        $district.append('<option>Cumayeri</option>');
        $district.append('<option>Gölyaka</option>');
        $district.append('<option>Gümüşova</option>');
        $district.append('<option>Kaynaşlı</option>');
        $district.append('<option>Merkez</option>');
        $district.append('<option>Yığılca</option>');
    }

    // İlçe selectbox'ını etkinleştir
    $district.prop('disabled', false);
}