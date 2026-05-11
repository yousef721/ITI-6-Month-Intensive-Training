(() => {
  // =========================
  // CONFIG
  // =========================

  const CHAT_API = "https://api.fireworks.ai/inference/v1/chat/completions";
  const IMAGE_API =
    "https://api.fireworks.ai/inference/v1/workflows/accounts/fireworks/models/flux-1-schnell-fp8/text_to_image";
  const IMAGE_EDIT_API =
    "https://api.fireworks.ai/inference/v1/workflows/accounts/fireworks/models/flux-kontext-pro";

  let apiKey = localStorage.getItem("fireworks_api_key") || "";
  let mode = "chat"; // chat | image
  let isLoading = false;

  const chatModel = "accounts/fireworks/models/llama-v3p3-70b-instruct";
  const imageModel = "flux-1-schnell-fp8";
  const imageEditModel = "flux-kontext-pro";
  const STORAGE_KEY = "nexus_ai_chat_sessions";

  let chats = [];
  let currentChatId = null;

  // =========================
  // DOM ELEMENTS
  // =========================

  const messagesContainer = document.getElementById("messagesContainer");
  const chatInput = document.getElementById("chatInput");
  const btnSend = document.getElementById("btnSend");
  const welcomeScreen = document.getElementById("welcomeScreen");
  const welcomeSuggestions = document.getElementById("welcomeSuggestions");
  const chatModeBtn = document.getElementById("chatModeBtn");
  const imageModeBtn = document.getElementById("imageModeBtn");
  const modeLabel = document.getElementById("modeLabel");
  const apiStatusSpan = document.getElementById("apiStatus");
  const btnToggleSidebar = document.getElementById("btnToggleSidebar");
  const sidebar = document.getElementById("sidebar");
  const sidebarOverlay = document.getElementById("sidebarOverlay");
  const btnNewChat = document.getElementById("btnNewChat");
  const btnNewChatTop = document.getElementById("btnNewChatTop");
  const sessionHeader = document.getElementById("sessionHeader");
  const sessionTitle = document.querySelector(".session-title");
  const apiKeyModal = document.getElementById("apiKeyModal");
  const apiKeyInput = document.getElementById("apiKeyInput");
  const btnSaveApiKey = document.getElementById("btnSaveApiKey");
  const btnSkipApiKey = document.getElementById("btnSkipApiKey");

  // =========================
  // INIT
  // =========================

  function init() {
    loadChatsFromStorage();

    if (!chats.length) {
      const session = createChatSession();
      chats.push(session);
      currentChatId = session.id;
      saveChatsToStorage();
    } else if (!currentChatId) {
      currentChatId = chats[0].id;
    }

    renderChatHistory();
    selectChat(currentChatId);
    updateSuggestions();
    setupEventListeners();

    // Check if API key needed
    if (!apiKey) {
      showApiKeyModal();
    } else {
      updateApiStatus("Ready");
    }
  }

  function setupEventListeners() {
    btnSend.addEventListener("click", sendMessage);
    chatInput.addEventListener("keydown", (e) => {
      if (e.key === "Enter" && !e.shiftKey) {
        e.preventDefault();
        sendMessage();
      }
    });

    chatModeBtn.addEventListener("click", () => switchMode("chat"));
    imageModeBtn.addEventListener("click", () => switchMode("image"));

    btnToggleSidebar.addEventListener("click", toggleSidebar);
    sidebarOverlay.addEventListener("click", closeSidebar);
    btnNewChat.addEventListener("click", newChat);
    if (btnNewChatTop) btnNewChatTop.addEventListener("click", newChat);
    chatHistory.addEventListener("click", handleHistoryClick);

    welcomeSuggestions.addEventListener("click", (e) => {
      if (e.target.classList.contains("suggestion-chip")) {
        chatInput.value = e.target.textContent.trim();
        chatInput.focus();
      }
    });

    btnSaveApiKey.addEventListener("click", saveApiKey);
    btnSkipApiKey.addEventListener("click", skipApiKey);
    apiKeyInput.addEventListener("keydown", (e) => {
      if (e.key === "Enter") saveApiKey();
    });
  }

  // =========================
  // API KEY MODAL
  // =========================

  function showApiKeyModal() {
    apiKeyModal.classList.add("active");
    apiKeyInput.focus();
  }

  function hideApiKeyModal() {
    apiKeyModal.classList.remove("active");
  }

  function saveApiKey() {
    const key = apiKeyInput.value.trim();
    if (!key) {
      alert("Please enter an API key");
      return;
    }
    apiKey = key;
    localStorage.setItem("fireworks_api_key", apiKey);
    hideApiKeyModal();
    updateApiStatus("Ready");
  }

  function skipApiKey() {
    hideApiKeyModal();
    updateApiStatus("Demo Mode (limited)");
  }

  function loadChatsFromStorage() {
    try {
      const raw = localStorage.getItem(STORAGE_KEY);
      chats = raw ? JSON.parse(raw) : [];
      if (chats.length && !currentChatId) {
        currentChatId = chats[0].id;
      }
    } catch (err) {
      console.warn("Unable to load chat history", err);
      chats = [];
    }
  }

  function saveChatsToStorage() {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(chats));
  }

  function createChatSession(title = "New chat") {
    const id =
      typeof crypto !== "undefined" && crypto.randomUUID
        ? crypto.randomUUID()
        : `chat-${Date.now()}`;
    return {
      id,
      title,
      messages: [],
      createdAt: Date.now(),
      updatedAt: Date.now(),
    };
  }

  function getCurrentChat() {
    return chats.find((chat) => chat.id === currentChatId);
  }

  function renderChatHistory() {
    const items = chats
      .slice()
      .sort((a, b) => b.updatedAt - a.updatedAt)
      .map((chat) => {
        const snippet = getChatSnippet(chat);
        return `
          <div class="history-item ${chat.id === currentChatId ? "active" : ""}" data-chat-id="${chat.id}">
            <div class="history-info">
              <span class="history-title">${escapeHtml(chat.title)}</span>
              <span class="history-snippet">${escapeHtml(snippet)}</span>
            </div>
            <button class="history-delete" data-delete-id="${chat.id}" title="Delete conversation">
              <i class="fa-solid fa-trash-can"></i>
            </button>
          </div>
        `;
      })
      .join("");

    chatHistory.innerHTML = `
      <div class="chat-history-label">Recent Conversations</div>
      ${items}
    `;
  }

  function getChatSnippet(chat) {
    if (!chat.messages.length) return "Start a new conversation";
    const lastMessage = chat.messages[chat.messages.length - 1];
    if (lastMessage.type === "image") {
      return `🖼️ ${lastMessage.content.prompt}`;
    }
    return String(lastMessage.content).slice(0, 40);
  }

  function selectChat(chatId) {
    const chat = chats.find((session) => session.id === chatId);
    if (!chat) return;
    currentChatId = chatId;
    renderChatHistory();
    renderChatMessages(chat);
    if (sessionTitle) {
      sessionTitle.textContent = chat.title || "New conversation";
    }
    chatInput.value = "";
    updateApiStatus("Ready");
  }

  function renderChatMessages(chat) {
    messagesContainer.innerHTML = "";
    if (!chat.messages.length) {
      messagesContainer.appendChild(welcomeScreen);
      welcomeScreen.style.display = "flex";
      return;
    }
    welcomeScreen.style.display = "none";
    chat.messages.forEach((message) => {
      addMessage(message.role, message.content, message.type, false);
    });
  }

  function handleHistoryClick(event) {
    const deleteButton = event.target.closest("[data-delete-id]");
    if (deleteButton) {
      const id = deleteButton.dataset.deleteId;
      deleteChat(id);
      return;
    }

    const item = event.target.closest(".history-item");
    if (!item) return;
    const id = item.dataset.chatId;
    if (id) selectChat(id);
  }

  function deleteChat(chatId) {
    const index = chats.findIndex((chat) => chat.id === chatId);
    if (index === -1) return;
    chats.splice(index, 1);

    if (currentChatId === chatId) {
      if (chats.length) {
        selectChat(chats[0].id);
      } else {
        const session = createChatSession();
        chats.push(session);
        currentChatId = session.id;
        renderChatHistory();
        selectChat(session.id);
      }
    } else {
      renderChatHistory();
    }

    saveChatsToStorage();
  }

  function addMessageToCurrentChat(role, content, type = "text") {
    const currentChat = getCurrentChat();
    if (!currentChat) return;

    const message = {
      id:
        typeof crypto !== "undefined" && crypto.randomUUID
          ? crypto.randomUUID()
          : `msg-${Date.now()}`,
      role,
      type,
      content,
      timestamp: Date.now(),
    };

    currentChat.messages.push(message);
    currentChat.updatedAt = Date.now();

    if (role === "user") {
      const titleText =
        type === "image" ? content.prompt : String(content).slice(0, 40);
      currentChat.title = titleText || currentChat.title || "New chat";
    }

    saveChatsToStorage();
    renderChatHistory();
  }

  // =========================
  // UTIL
  // =========================

  function time() {
    return new Date().toLocaleTimeString([], {
      hour: "2-digit",
      minute: "2-digit",
    });
  }

  function updateApiStatus(status) {
    apiStatusSpan.textContent = status;
    apiStatusSpan.style.color =
      status === "Ready"
        ? "#22c55e"
        : status.includes("Error")
          ? "#ef4444"
          : status.includes("loading")
            ? "#f59e0b"
            : "#64748b";
  }

  function switchMode(newMode) {
    if (mode === newMode) return;

    mode = newMode;

    // Update UI
    chatModeBtn.classList.toggle("active", mode === "chat");
    imageModeBtn.classList.toggle("active", mode === "image");
    modeLabel.textContent = mode === "chat" ? "Chat" : "Image";
    chatInput.placeholder =
      mode === "chat" ? "Ask me anything..." : "Describe an image...";

    updateSuggestions();
    closeSidebar();
  }

  function updateSuggestions() {
    const suggestions =
      mode === "chat"
        ? ["Explain quantum computing", "Write a poem", "Tell me a joke"]
        : [
            "A futuristic cyberpunk city",
            "A serene mountain landscape",
            "Abstract digital art",
          ];

    welcomeSuggestions.innerHTML = suggestions
      .map((s) => `<button class="suggestion-chip">${s}</button>`)
      .join("");
  }

  function toggleSidebar() {
    sidebar.classList.toggle("open");
    sidebarOverlay.classList.toggle("active");
  }

  function closeSidebar() {
    sidebar.classList.remove("open");
    sidebarOverlay.classList.remove("active");
  }

  function newChat() {
    const session = createChatSession();
    chats.unshift(session);
    currentChatId = session.id;
    saveChatsToStorage();
    renderChatHistory();
    selectChat(currentChatId);
    closeSidebar();
  }

  function addMessage(role, content, type = "text", save = true) {
    welcomeScreen.style.display = "none";

    const wrapper = document.createElement("div");
    wrapper.className = "message-wrapper " + role;

    const bubble = document.createElement("div");
    bubble.className = "message-bubble";

    if (type === "image") {
      const container = document.createElement("div");
      container.className = "image-message-container";

      const caption = document.createElement("p");
      caption.className = "image-caption";
      caption.textContent = "🎨 " + escapeHtml(content.prompt);

      const img = document.createElement("img");
      img.src = content.url;
      img.alt = escapeHtml(content.prompt);
      img.loading = "lazy";
      img.className = "generated-image";
      img.onerror = () => {
        img.style.display = "none";
        const errorDiv = document.createElement("div");
        errorDiv.className = "image-error";
        errorDiv.textContent = "⚠️ Image failed to load";
        container.appendChild(errorDiv);
      };

      const downloadBtn = document.createElement("a");
      downloadBtn.href = content.url;
      downloadBtn.download = content.prompt.replace(/\s+/g, "_") + ".png";
      downloadBtn.className = "btn-download-image";
      downloadBtn.innerHTML = '<i class="fa-solid fa-download"></i> Download';
      downloadBtn.target = "_blank";

      container.appendChild(caption);
      container.appendChild(img);
      container.appendChild(downloadBtn);
      bubble.appendChild(container);
    } else {
      bubble.textContent = content;
    }

    const ts = document.createElement("div");
    ts.className = "message-timestamp";
    ts.innerText = time();

    wrapper.appendChild(bubble);
    messagesContainer.appendChild(wrapper);
    messagesContainer.appendChild(ts);

    messagesContainer.scrollTop = messagesContainer.scrollHeight;

    if (save) {
      addMessageToCurrentChat(role, content, type);
    }
  }

  function escapeHtml(text) {
    const map = {
      "&": "&amp;",
      "<": "&lt;",
      ">": "&gt;",
      '"': "&quot;",
      "'": "&#039;",
    };
    return text.replace(/[&<>"']/g, (m) => map[m]);
  }

  function addTypingIndicator() {
    const wrapper = document.createElement("div");
    wrapper.className = "message-wrapper ai";
    wrapper.id = "typing-indicator";

    const bubble = document.createElement("div");
    bubble.className = "typing-indicator";
    bubble.innerHTML = `
            <div class="typing-dot"></div>
            <div class="typing-dot"></div>
            <div class="typing-dot"></div>
        `;

    wrapper.appendChild(bubble);
    messagesContainer.appendChild(wrapper);
    messagesContainer.scrollTop = messagesContainer.scrollHeight;
  }

  function removeTypingIndicator() {
    const indicator = document.getElementById("typing-indicator");
    if (indicator) indicator.remove();
  }

  // =========================
  // API CALLS
  // =========================

  async function chatRequest(message) {
    if (!apiKey) {
      throw new Error("API key not set. Please configure your API key.");
    }

    const response = await fetch(CHAT_API, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${apiKey}`,
      },
      body: JSON.stringify({
        model: chatModel,
        messages: [
          {
            role: "system",
            content:
              "You are Nexus AI, a helpful and friendly AI assistant. Provide clear, concise, and accurate responses. Use markdown formatting when appropriate.",
          },
          {
            role: "user",
            content: message,
          },
        ],
        temperature: 0.7,
        max_tokens: 1024,
        top_p: 0.9,
      }),
    });

    if (!response.ok) {
      const error = await response.json();
      throw new Error(error.error?.message || `API Error: ${response.status}`);
    }

    const data = await response.json();
    return data?.choices?.[0]?.message?.content || "No response received";
  }

  async function imageRequest(prompt) {
    if (!apiKey) {
      throw new Error(
        "API key not set. Please configure your Fireworks API key.",
      );
    }

    try {
      const response = await fetch(IMAGE_API, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${apiKey}`,
        },
        body: JSON.stringify({
          prompt: prompt.trim() + ", professional, detailed, high quality",
          height: 512,
          width: 512,
          num_inference_steps: 4,
        }),
      });

      if (!response.ok) {
        try {
          const error = await response.json();
          throw new Error(
            error.error?.message || `API Error: ${response.status}`,
          );
        } catch {
          throw new Error(`API Error: ${response.status}`);
        }
      }

      // Check content type - Fireworks returns binary image data
      const contentType = response.headers.get("content-type");

      if (contentType && contentType.includes("image")) {
        // Response is binary image data - convert to data URL so it persists in localStorage
        const blob = await response.blob();
        const imageUrl = await blobToDataURL(blob);
        return imageUrl;
      } else {
        // Try to parse as JSON
        const data = await response.json();

        // Fireworks API returns result with image data
        let imageUrl =
          data?.result?.image_url ||
          data?.image_url ||
          data?.images?.[0]?.url ||
          data?.output?.image_url ||
          null;

        if (!imageUrl) {
          throw new Error(
            "No image URL in response. Please check your API key and try again.",
          );
        }

        return imageUrl;
      }
    } catch (error) {
      throw new Error(`Image generation failed: ${error.message}`);
    }
  }

  function blobToDataURL(blob) {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onloadend = () => resolve(reader.result);
      reader.onerror = reject;
      reader.readAsDataURL(blob);
    });
  }

  // =========================
  // SEND MESSAGE
  // =========================

  async function sendMessage() {
    const text = chatInput.value.trim();
    if (!text || isLoading) return;

    chatInput.value = "";
    isLoading = true;

    addMessage("user", text);
    addTypingIndicator();
    updateApiStatus("Processing...");
    btnSend.disabled = true;

    try {
      if (mode === "image") {
        const url = await imageRequest(text);
        removeTypingIndicator();
        addMessage(
          "ai",
          {
            prompt: text,
            url: url,
          },
          "image",
        );
      } else {
        const reply = await chatRequest(text);
        removeTypingIndicator();
        addMessage("ai", reply);
      }
      updateApiStatus("Ready");
    } catch (err) {
      removeTypingIndicator();
      const errorMsg = `❌ Error: ${err.message}`;
      addMessage("ai", errorMsg);
      updateApiStatus("Error: " + err.message);
      console.error("API Error:", err);
    } finally {
      isLoading = false;
      btnSend.disabled = false;
      chatInput.focus();
    }
  }

  // =========================
  // START
  // =========================

  init();
})();
