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

    window.connection.on("ReceiveMessage", (senderId, receiverId, messageText) => {
        const currentReceiverId = parseInt(document.getElementById("receiverId")?.value); // ya da ViewBag

        // Sadece aktif sohbet penceresine mesaj yaz
        if (receiverId !== currentReceiverId && senderId !== currentReceiverId) {
            console.warn("❌ Bu mesaj açık olan kullanıcıya ait değil. Atlanıyor.");
            return;
        }

        const messageArea = document.getElementById("messageArea");
        if (!messageArea) return;

        const isMine = senderId === userId;
        const alignment = isMine ? "justify-content-end" : "justify-content-start";
        const bubbleClass = isMine ? "bubble-out" : "bubble-in";

        const wrapperDiv = document.createElement("div");
        wrapperDiv.className = `d-flex ${alignment} mb-2`;

        const bubbleDiv = document.createElement("div");
        bubbleDiv.className = `${bubbleClass} p-2 rounded`;
        bubbleDiv.innerHTML = `
        <div>${messageText}</div>
        <div class="text-end small text-muted mt-1">${new Date().toLocaleDateString('tr-TR')}</div>
    `;

        wrapperDiv.appendChild(bubbleDiv);
        messageArea.appendChild(wrapperDiv);
        messageArea.scrollTop = messageArea.scrollHeight;
    });



    // 📤 Mesaj gönderme fonksiyonu
    window.sendMessageToUser = function (receiverId, messageText) {
        if (!receiverId || messageText.trim() === "") return;

        window.connection.invoke("SendMessage", userId, receiverId, messageText)
            .catch(err => console.error("🚫 Mesaj gönderilemedi:", err));
    }

    // 🔄 Sol paneli güncelleyen SignalR yayını
    window.connection.off("RefreshConversationList");
    window.connection.on("RefreshConversationList", () => {
        if (typeof loadConversations === "function") {
            loadConversations();
        }
    });
}
