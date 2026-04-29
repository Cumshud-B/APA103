const styles = {
      body: {
        margin: 0,
        minHeight: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        backgroundColor: "#f4f4f0",
        fontFamily: "'Segoe UI', system-ui, sans-serif",
      },
      card: {
        width: "340px",
        backgroundColor: "#ffffff",
        borderRadius: "20px",
        border: "0.5px solid rgba(0,0,0,0.1)",
        overflow: "hidden",
        cursor: "pointer",
        transition: "transform 0.25s ease",
      },
      imgWrap: {
        position: "relative",
        height: "200px",
        overflow: "hidden",
        backgroundColor: "#ccc",
      },
      img: {
        width: "100%",
        height: "100%",
        objectFit: "cover",
        display: "block",
        transition: "transform 0.4s ease",
      },
      heartBtn: {
        position: "absolute",
        top: "12px",
        right: "12px",
        width: "36px",
        height: "36px",
        borderRadius: "50%",
        border: "none",
        backgroundColor: "rgba(255,255,255,0.88)",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        cursor: "pointer",
        transition: "transform 0.15s, background 0.2s",
      },
      tag: {
        position: "absolute",
        bottom: "12px",
        left: "12px",
        backgroundColor: "rgba(0,0,0,0.55)",
        color: "#fff",
        fontSize: "11px",
        fontWeight: "500",
        padding: "4px 10px",
        borderRadius: "20px",
        letterSpacing: "0.04em",
      },
      body: {
        padding: "18px 20px 0",
      },
      label: {
        fontSize: "11px",
        fontWeight: "600",
        letterSpacing: "0.08em",
        color: "#888",
        textTransform: "uppercase",
        marginBottom: "6px",
      },
      price: {
        fontSize: "30px",
        fontWeight: "600",
        color: "#111",
        letterSpacing: "-0.5px",
        lineHeight: "1.1",
      },
      address: {
        fontSize: "14px",
        color: "#888",
        marginTop: "4px",
      },
      divider: {
        height: "0.5px",
        backgroundColor: "rgba(0,0,0,0.08)",
        margin: "16px 20px",
      },
      features: {
        display: "flex",
        gap: "24px",
        padding: "0 20px 16px",
      },
      feat: {
        display: "flex",
        alignItems: "center",
        gap: "8px",
        fontSize: "14px",
        color: "#111",
        fontWeight: "500",
      },
      agentSection: {
        borderTop: "0.5px solid rgba(0,0,0,0.08)",
        padding: "14px 20px 16px",
        display: "flex",
        alignItems: "center",
        gap: "12px",
      },
      agentLabel: {
        fontSize: "10px",
        letterSpacing: "0.09em",
        textTransform: "uppercase",
        color: "#888",
        marginBottom: "2px",
        fontWeight: "600",
      },
      agentName: {
        fontSize: "14px",
        fontWeight: "600",
        color: "#111",
      },
      agentPhone: {
        fontSize: "12px",
        color: "#888",
      },
      avatar: {
        width: "42px",
        height: "42px",
        borderRadius: "50%",
        backgroundColor: "#B5D4F4",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        fontSize: "15px",
        fontWeight: "600",
        color: "#0C447C",
        flexShrink: 0,
      },
      callBtn: {
        border: "0.5px solid rgba(0,0,0,0.2)",
        background: "transparent",
        borderRadius: "8px",
        padding: "7px 12px",
        fontSize: "12px",
        cursor: "pointer",
        color: "#111",
        transition: "background 0.15s",
        fontFamily: "inherit",
      },
      ctaBtn: {
        display: "block",
        width: "calc(100% - 40px)",
        margin: "0 20px 18px",
        padding: "11px",
        backgroundColor: "#111",
        color: "#fff",
        border: "none",
        borderRadius: "10px",
        fontSize: "14px",
        fontWeight: "500",
        cursor: "pointer",
        letterSpacing: "0.02em",
        transition: "opacity 0.2s, transform 0.15s",
        fontFamily: "inherit",
      },
      ctaBtnRequested: {
        backgroundColor: "#d1fae5",
        color: "#065f46",
        cursor: "default",
      },
    };

    const state = {
      liked: false,
      hoveringCard: false,
      hoveringImg: false,
      tourRequested: false,
    };

    function heartSVG(liked) {
      const svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
      Object.assign(svg, { setAttribute: svg.setAttribute.bind(svg) });
      svg.setAttribute("width", "18");
      svg.setAttribute("height", "18");
      svg.setAttribute("viewBox", "0 0 24 24");
      svg.setAttribute("fill", liked ? "#e24b4a" : "none");
      svg.setAttribute("stroke", liked ? "#e24b4a" : "#555");
      svg.setAttribute("stroke-width", "2");
      svg.setAttribute("stroke-linecap", "round");
      svg.setAttribute("stroke-linejoin", "round");
      const path = document.createElementNS("http://www.w3.org/2000/svg", "path");
      path.setAttribute("d", "M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z");
      svg.appendChild(path);
      return svg;
    }

    function bedSVG() {
      const ns = "http://www.w3.org/2000/svg";
      const svg = document.createElementNS(ns, "svg");
      svg.setAttribute("width", "20"); svg.setAttribute("height", "20");
      svg.setAttribute("viewBox", "0 0 24 24");
      svg.setAttribute("fill", "none"); svg.setAttribute("stroke", "#888");
      svg.setAttribute("stroke-width", "1.5");
      svg.setAttribute("stroke-linecap", "round");
      svg.setAttribute("stroke-linejoin", "round");
      const p1 = document.createElementNS(ns, "path");
      p1.setAttribute("d", "M3 20v-8a2 2 0 0 1 .586-1.414l8-8a2 2 0 0 1 2.828 0l8 8A2 2 0 0 1 21 12v8");
      const p2 = document.createElementNS(ns, "path");
      p2.setAttribute("d", "M9 20v-6h6v6");
      const r = document.createElementNS(ns, "rect");
      r.setAttribute("x", "3"); r.setAttribute("y", "20");
      r.setAttribute("width", "18"); r.setAttribute("height", "1"); r.setAttribute("rx", ".5");
      svg.append(p1, p2, r);
      return svg;
    }

    function bathSVG() {
      const ns = "http://www.w3.org/2000/svg";
      const svg = document.createElementNS(ns, "svg");
      svg.setAttribute("width", "20"); svg.setAttribute("height", "20");
      svg.setAttribute("viewBox", "0 0 24 24");
      svg.setAttribute("fill", "none"); svg.setAttribute("stroke", "#888");
      svg.setAttribute("stroke-width", "1.5");
      svg.setAttribute("stroke-linecap", "round");
      svg.setAttribute("stroke-linejoin", "round");
      const p1 = document.createElementNS(ns, "path");
      p1.setAttribute("d", "M4 12h16v4a4 4 0 0 1-4 4H8a4 4 0 0 1-4-4v-4z");
      const p2 = document.createElementNS(ns, "path");
      p2.setAttribute("d", "M4 12V6a2 2 0 0 1 2-2h1a2 2 0 0 1 2 2v2");
      const line = document.createElementNS(ns, "line");
      line.setAttribute("x1", "4"); line.setAttribute("y1", "12");
      line.setAttribute("x2", "20"); line.setAttribute("y2", "12");
      svg.append(p1, p2, line);
      return svg;
    }

    function applyStyles(el, styleObj) {
      Object.assign(el.style, styleObj);
    }

    function buildCard() {

      applyStyles(document.body, styles.body);

      const card = document.createElement("div");
      applyStyles(card, styles.card);

      const imgWrap = document.createElement("div");
      applyStyles(imgWrap, styles.imgWrap);

      const img = document.createElement("img");
      img.src = "https://images.unsplash.com/photo-1570129477492-45c003edd2be?w=700&q=80";
      img.alt = "742 Evergreen Terrace";
      applyStyles(img, styles.img);
      imgWrap.appendChild(img);

      const heartBtn = document.createElement("button");
      applyStyles(heartBtn, styles.heartBtn);
      heartBtn.setAttribute("aria-label", "Sevimli");
      heartBtn.appendChild(heartSVG(state.liked));

      heartBtn.addEventListener("click", (e) => {
        e.stopPropagation();
        state.liked = !state.liked;
        heartBtn.innerHTML = "";
        heartBtn.appendChild(heartSVG(state.liked));
        applyStyles(heartBtn, {
          transform: "scale(1.15)",
          backgroundColor: "rgba(255,255,255,1)",
        });
        setTimeout(() => applyStyles(heartBtn, { transform: "scale(1)" }), 150);
      });

      const tag = document.createElement("span");
      tag.textContent = "Detached House • 5y old";
      applyStyles(tag, styles.tag);

      imgWrap.append(heartBtn, tag);

      card.addEventListener("mouseenter", () => {
        applyStyles(card, { transform: "translateY(-4px)" });
        applyStyles(img, { transform: "scale(1.04)" });
      });
      card.addEventListener("mouseleave", () => {
        applyStyles(card, { transform: "translateY(0)" });
        applyStyles(img, { transform: "scale(1)" });
      });

      const bodyDiv = document.createElement("div");
      applyStyles(bodyDiv, styles.body);

      const label = document.createElement("div");
      label.textContent = "Detached House • 5Y Old";
      applyStyles(label, styles.label);

      const price = document.createElement("div");
      price.textContent = "$750,000";
      applyStyles(price, styles.price);

      const address = document.createElement("div");
      address.textContent = "742 Evergreen Terrace";
      applyStyles(address, styles.address);

      bodyDiv.append(label, price, address);

      const divider = document.createElement("div");
      applyStyles(divider, styles.divider);

      const features = document.createElement("div");
      applyStyles(features, styles.features);

      const bedFeat = document.createElement("div");
      applyStyles(bedFeat, styles.feat);
      const bedText = document.createElement("span");
      bedText.textContent = "3 Bedrooms";
      bedFeat.append(bedSVG(), bedText);

      const bathFeat = document.createElement("div");
      applyStyles(bathFeat, styles.feat);
      const bathText = document.createElement("span");
      bathText.textContent = "2 Bathrooms";
      bathFeat.append(bathSVG(), bathText);

      features.append(bedFeat, bathFeat);

      const agentSection = document.createElement("div");
      applyStyles(agentSection, styles.agentSection);

      const avatar = document.createElement("div");
      avatar.textContent = "TH";
      applyStyles(avatar, styles.avatar);

      const agentInfo = document.createElement("div");
      agentInfo.style.flex = "1";

      const agentLabel = document.createElement("div");
      agentLabel.textContent = "Realtor";
      applyStyles(agentLabel, styles.agentLabel);

      const agentName = document.createElement("div");
      agentName.textContent = "Tiffany Heffner";
      applyStyles(agentName, styles.agentName);

      const agentPhone = document.createElement("div");
      agentPhone.textContent = "(555) 555-4321";
      applyStyles(agentPhone, styles.agentPhone);

      agentInfo.append(agentLabel, agentName, agentPhone);

      const callBtn = document.createElement("button");
      callBtn.textContent = "Call";
      applyStyles(callBtn, styles.callBtn);
      callBtn.addEventListener("mouseenter", () => applyStyles(callBtn, { backgroundColor: "#f4f4f0" }));
      callBtn.addEventListener("mouseleave", () => applyStyles(callBtn, { backgroundColor: "transparent" }));
      callBtn.addEventListener("click", (e) => {
        e.stopPropagation();
        window.location.href = "tel:5555554321";
      });

      agentSection.append(avatar, agentInfo, callBtn);

      const ctaBtn = document.createElement("button");
      ctaBtn.textContent = "Request a Tour";
      applyStyles(ctaBtn, styles.ctaBtn);

      ctaBtn.addEventListener("mouseenter", () => {
        if (!state.tourRequested) applyStyles(ctaBtn, { opacity: "0.82" });
      });
      ctaBtn.addEventListener("mouseleave", () => {
        applyStyles(ctaBtn, { opacity: "1" });
      });
      ctaBtn.addEventListener("click", () => {
        if (state.tourRequested) return;
        state.tourRequested = true;
        ctaBtn.textContent = "Tour Requested!";
        applyStyles(ctaBtn, { ...styles.ctaBtnRequested, transform: "scale(0.98)" });
        setTimeout(() => applyStyles(ctaBtn, { transform: "scale(1)" }), 150);
      });

      card.append(imgWrap, bodyDiv, divider, features, agentSection, ctaBtn);
      document.getElementById("root").appendChild(card);
    }

    buildCard();