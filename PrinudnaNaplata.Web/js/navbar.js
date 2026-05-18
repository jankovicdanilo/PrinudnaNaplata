function renderNavbar() {
    const navbarHTML = `
        <nav class="navbar navbar-custom">
            <div class="container-fluid px-4 d-flex align-items-center">
                <div style="flex: 1;"></div>
                <span class="navbar-brand fw-500 mb-0">Prinudna Naplata</span>
                <div style="flex: 1; display: flex; justify-content: flex-end; align-items: center; gap: 12px;">
                    <select id="klijentDropdown" class="form-select form-select-sm dark-input" style="width: auto;">
                    </select>
                    <div class="dropdown">
                        <a href="#" class="dropdown-toggle" id="navUsername" data-bs-toggle="dropdown"
                        style="color:#fff; font-size:14px; text-decoration:none; padding: 0;">
                        </a>
                        <ul class="dropdown-menu dropdown-menu-end" style="min-width: 160px; font-size: 10px;">
                            <li><a class="dropdown-item py-1" href="promjena-lozinke.html">
                                <i class="bi bi-key"></i> Promjena lozinke
                            </a></li>
                        </ul>
                    </div>
                    <button class="btn btn-sm btn-outline-light" id="btnLogout">
                        <i class="bi bi-box-arrow-right"></i> Odjava
                    </button>
                </div>
            </div>
        </nav>
    `;

    document.getElementById('navbar').innerHTML = navbarHTML;

    document.getElementById('navUsername').textContent = localStorage.getItem('username') ?? '';

    document.getElementById('btnLogout').addEventListener('click', () => {
        localStorage.removeItem('token');
        localStorage.removeItem('username');
        document.cookie = 'selectedKlijent=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/';
        window.location.href = 'index.html';
    });
}

async function initNavbar(onKlijentChange) {
    renderNavbar();

    const data = await apiFetch(`${API_URL}/client`);
    if (!data) return;

    const select = document.getElementById('klijentDropdown');

    const defaultOption = document.createElement('option');
    defaultOption.value = '0';
    defaultOption.textContent = 'Svi klijenti';
    select.appendChild(defaultOption);

    data.forEach(k => {
      if (k.klijentID === 0 || k.naziv?.toLowerCase() === 'svi klijenti') return;
        const option = document.createElement('option');
        option.value = k.klijentID;
        option.textContent = k.naziv;
        select.appendChild(option);
    });

    const current = document.cookie.split('; ').find(r => r.startsWith('selectedKlijent='))?.split('=')[1];
    if (current) select.value = current;

    select.addEventListener('change', () => {
        document.cookie = `selectedKlijent=${select.value}; path=/`;
        if (onKlijentChange) onKlijentChange();
    });
}