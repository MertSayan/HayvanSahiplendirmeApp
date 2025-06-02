if (window.connection) {
    window.connection.stop(); // eski bağlantı varsa kapat
}
const userId = parseInt(localStorage.getItem("userId"));

if (!userId || userId === 0) {
    console.warn("❌ userId yok. SignalR bağlantısı yapılmadı.");
} else {
    console.log("🔌 SignalR bağlantısı başlatılıyor. Giriş yapan kullanıcı ID:", userId);

    // 🔧 Global bağlantı nesnesi
    window.connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7160/hubs/message") // 🔁 API portuna göre ayarla
        .withAutomaticReconnect()
        .build();

    // 🔌 Bağlantıyı başlat
    window.connection.start()
        .then(() => {
            console.log("✅ SignalR bağlantısı kuruldu.");
            window.connection.invoke("RegisterUser", userId);
        })
        .catch(err => console.error("🚫 SignalR bağlantı hatası:", err));


    // 📥 Gelen mesajları dinle
    // 👇 Önce varsa eski event listener'ı kaldır
    window.connection.off("ReceiveMessage");

    window.connection.on("ReceiveMessage", (senderId, messageText) => {
        const messageArea = document.getElementById("messageArea");
        if (!messageArea) return;

        const prefix = senderId === userId ? "Sen" : "O";
        messageArea.innerHTML += `<div><b>${prefix}:</b> ${messageText}</div>`;
        messageArea.scrollTop = messageArea.scrollHeight;
    });


    // 📤 Mesaj gönderme fonksiyonu
    window.sendMessageToUser = function (receiverId, messageText) {
        if (!receiverId || messageText.trim() === "") return;

        window.connection.invoke("SendMessage", userId, receiverId, messageText)
            .catch(err => console.error("🚫 Mesaj gönderilemedi:", err));
    }
}
