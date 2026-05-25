
let debounceTimer;

function debounce(fn, delay = 400){
    clearTimeout(debounceTimer);
    debounceTimer = setTimeout(fn, delay);
}

let currentPage = 1;

function getFilters() {
    return {
        Ime: document.getElementById('f_ime').value || null,
        Mjesto: document.getElementById('f_mjesto').value || null,
        Reon: document.getElementById('f_reon').value || null,
        Adresa: document.getElementById('f_adresa').value || null,
        JMBG: document.getElementById('f_jmbg').value || null,
        LicniBroj: document.getElementById('f_licnibroj').value || null,
        ZavedenKodPov: document.getElementById('f_zavedenkodpov').value || null,
        ZaposlenKod: document.getElementById('f_zaposlen').value || null,
        Nepoznat: document.getElementById('f_nepoznat').value === '' ? null : document.getElementById('f_nepoznat').value === 'true',
        Umro: document.getElementById('f_umro').value === '' ? null : document.getElementById('f_umro').value === 'true',
        Penzioner: document.getElementById('f_penzioner').value === '' ? null : document.getElementById('f_penzioner').value === 'true',
        PravnoLice: document.getElementById('f_pravnolice').value === '' ? null : document.getElementById('f_pravnolice').value === 'true',
        UkupanDug: document.getElementById('f_ukupandug').value || null,
        DugOd: document.getElementById('f_dugod').value || null,
        DugDo: document.getElementById('f_dugdo').value || null,
        KlijentID: parseInt(localStorage.getItem('selectedKlijent')) || 0,
        PageNumber: currentPage,
        PageSize: pageSize,
    };
}

async function loadDuznici() {
    const filters = getFilters();
    const params = new URLSearchParams();
    for (const [key, value] of Object.entries(filters)) {
        if (value !== null && value !== '') {
            params.append(key, value);
        }
    }

    try {
        const data = await apiFetch(`${API_URL}/debtor?${params.toString()}`);
        if (data) {
    renderTable(data.items);  // ✅
    document.getElementById('resultCount').textContent = `${data.totalCount} rezultata`;
    renderPagination(data.totalCount);
}
    } catch (error) {
        console.error('Greška:', error);
    }
}

function renderTable(duznici) {
    const tbody = document.getElementById('tableBody');

    if (!duznici || duznici.length === 0) {
        tbody.innerHTML = '<tr><td colspan="5" class="text-center text-muted py-4">Nema rezultata</td></tr>';
        return;
    }

    tbody.innerHTML = duznici.map(d => `
        <tr>
            <td>${d.zavedenKodPov ?? ''}</td>
            <td>${d.ime ?? ''}</td>
            <td>${d.mjesto ?? ''}</td>
            <td>${d.ukupnoDugovanje ? d.ukupnoDugovanje.toFixed(2) : '0,00'}</td>
            <td><a href="duznik.html?id=${d.duznikID}" class="btn-otvori">Otvori</a></td>
        </tr>
    `).join('');
}

function renderPagination(totalCount) {
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    const totalPages = Math.ceil(totalCount / pageSize);
    if (totalPages <= 1) return;

    const createBtn = (label, page, disabled = false, active = false) => {
        const btn = document.createElement('button');
        btn.className = `page-btn ${active ? 'active' : ''} ${disabled ? 'disabled' : ''}`;
        btn.textContent = label;
        btn.disabled = disabled;
        btn.addEventListener('click', () => {
            currentPage = page;
            loadDuznici();
        });
        return btn;
    };

    const addEllipsis = () => {
        const span = document.createElement('span');
        span.textContent = '...';
        span.className = 'page-ellipsis';
        pagination.appendChild(span);
    };

    pagination.appendChild(createBtn('«', 1, currentPage === 1));
    pagination.appendChild(createBtn('‹', currentPage - 1, currentPage === 1));

    const delta = 2;
    const left = Math.max(2, currentPage - delta);
    const right = Math.min(totalPages - 1, currentPage + delta);

    pagination.appendChild(createBtn(1, 1, false, currentPage === 1));

    if (left > 2) addEllipsis();

    for (let i = left; i <= right; i++) {
        pagination.appendChild(createBtn(i, i, false, i === currentPage));
    }

    if (right < totalPages - 1) addEllipsis();

    pagination.appendChild(createBtn(totalPages, totalPages, false, currentPage === totalPages));

    pagination.appendChild(createBtn('›', currentPage + 1, currentPage === totalPages));
    pagination.appendChild(createBtn('»', totalPages, currentPage === totalPages));
}

document.getElementById('btnPrikazi').addEventListener('click', () => {
    currentPage = 1;
    loadDuznici();
});

document.getElementById('btnReset').addEventListener('click', () => {
    document.querySelectorAll('.dark-input').forEach(el => {
        el.value = '';
    });
    currentPage = 1;
    loadDuznici();
});

initNavbar(() => { currentPage = 1; loadDuznici(); });
loadDuznici();

document.querySelectorAll('.dark-input').forEach(el => {
    el.addEventListener('input', () => {
        debounce(() =>{
            currentPage = 1;
            loadDuznici();
        });
    });
});