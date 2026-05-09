const API_URL = 'https://localhost:7206/api';
let currentPage = 1;
const pageSize = 10;

function getToken() {
    return localStorage.getItem('token');
}

function getBool(id) {
    const val = document.getElementById(id).value;
    if (val === '') return null;
    return val === 'true';
}

function getFilters() {
    return {
        Sve: document.getElementById('f_sve').value || null,
        BrojPartije: document.getElementById('f_brojpartije').value || null,
        Ime: document.getElementById('f_ime').value || null,
        ResenjeBroj: document.getElementById('f_resenjebroj').value || null,
        ZavedenKodPov: document.getElementById('f_zavedenkodpov').value || null,
        Zaposlen: document.getElementById('f_zaposlen').value || null,
        SudID: document.getElementById('f_sudid').value || null,
        PravnoFizicko: document.getElementById('f_pravnolice').value || null,
        UkupanDug: document.getElementById('f_ukupandug').value || null,
        DugPov: document.getElementById('f_dugpov').value || null,
        DugAdv: document.getElementById('f_dugadv').value || null,
        FakturisanoProcenat: document.getElementById('f_fakturisanoprocenat').value || null,
        PlatioIznos: document.getElementById('f_platioiznos').value || null,
        PredatoDanaOd: document.getElementById('f_predatood').value || null,
        PredatoDanaDo: document.getElementById('f_predatodo').value || null,
        DonetoDanaOd: document.getElementById('f_donijetood').value || null,
        DonetoDanaDo: document.getElementById('f_donijetodo').value || null,
        IzvrsnoDanaOd: document.getElementById('f_izvrsnodanaod').value || null,
        IzvrsnoDanaDo: document.getElementById('f_izvrsnodanado').value || null,
        OdlaganjeDo: document.getElementById('f_odlaganjedo').value || null,
        JavnaObjava: getBool('f_javnaobjava'),
        Odlaganje: getBool('f_odlaganje'),
        Odbacen: getBool('f_odbacen'),
        Prekinut: getBool('f_prekinut'),
        Odbijen: getBool('f_odbijen'),
        Obustavljen: getBool('f_obustavljen'),
        Mrtav: getBool('f_mrtav'),
        Poravnanje: getBool('f_poravnanje'),
        Zakljucena: getBool('f_zakljucena'),
        Prigovor: getBool('f_prigovor'),
        PrigovorUsvojen: getBool('f_prigovorusvojen'),
        PrigovorOdbijen: getBool('f_prigovorodbijen'),
        PrigovorOdbacen: getBool('f_prigovorodbacen'),
        IzvrsnoResenjeSuda: getBool('f_izvrsnoResenjeSuda'),
        PrvostepenaPresuda: getBool('f_prvostepenaPresuda'),
        Zalba: getBool('f_zalba'),
        DrugostepenaPresuda: getBool('f_drugostepenaPresuda'),
        IzvrsenjePoPresudi: getBool('f_izvrsenjePoPresudi'),
        ZakljucakNalog: getBool('f_zakljucaknalog'),
        ZakljucakNalogNisuPostupili: getBool('f_zakljucaknalognisupostupili'),
        Fakturisano: getBool('f_fakturisano'),
        Fakturisati: getBool('f_fakturisati'),
        NeFakturisati: getBool('f_nefakturisati'),
        PredlPokrImovina: getBool('f_predlpokrimovina'),
        PredlNepokImovina: getBool('f_predlnepokimovina'),
        Hipoteka: getBool('f_hipoteka'),
        Nekretnina: getBool('f_nekretnina'),
        Vozila: getBool('f_vozila'),
        Penzioner: getBool('f_penzioner'),
        PageNumber: currentPage,
        PageSize: pageSize
    };
}

async function loadPartije() {
    const filters = getFilters();
    const params = new URLSearchParams();
    for (const [key, value] of Object.entries(filters)) {
        if (value !== null && value !== '') {
            params.append(key, value);
        }
    }

    try {
        const response = await fetch(`${API_URL}/case?${params.toString()}`, {
            headers: {
                'Authorization': `Bearer ${getToken()}`
            }
        });

        if (response.status === 401) {
            window.location.href = 'index.html';
            return;
        }

        const data = await response.json();
        renderTable(data.data);
    } catch (error) {
        console.error('Greška:', error);
    }
}

function formatDate(dateStr) {
    if (!dateStr) return '';
    return new Date(dateStr).toLocaleDateString('sr-RS');
}

function renderTable(partije) {
    const tbody = document.getElementById('tableBody');

    if (!partije || partije.length === 0) {
        tbody.innerHTML = '<tr><td colspan="8" class="text-center text-muted py-4">Nema rezultata</td></tr>';
        return;
    }

    document.getElementById('resultCount').textContent = `${partije.length} rezultata`;

    tbody.innerHTML = partije.map(p => `
        <tr>
            <td>${p.brojPartije ?? ''}</td>
            <td>${p.duznikIme ?? ''}</td>
            <td>${p.resenjeBroj ?? ''}</td>
            <td>${p.iVb ?? ''}</td>
            <td>${formatDate(p.predatoDana)}</td>
            <td>${formatDate(p.donetoDana)}</td>
            <td>${p.sudskeTakse ? p.sudskeTakse.toFixed(2) : ''}</td>
            <td><a href="partija.html?id=${p.partijaID}" class="btn-otvori">Otvori</a></td>
        </tr>
    `).join('');
}

document.getElementById('btnAdvanced').addEventListener('click', function () {
    const panel = document.getElementById('advancedPanel');
    const isVisible = panel.style.display !== 'none';
    panel.style.display = isVisible ? 'none' : 'block';
    this.innerHTML = isVisible
        ? '<i class="bi bi-sliders"></i> Napredna'
        : '<i class="bi bi-sliders"></i> Zatvori';
});

document.getElementById('btnPrikazi').addEventListener('click', () => {
    currentPage = 1;
    loadPartije();
});

document.getElementById('btnReset').addEventListener('click', () => {
    document.querySelectorAll('.dark-input').forEach(el => el.value = '');
    currentPage = 1;
    document.getElementById('tableBody').innerHTML = '<tr><td colspan="8" class="text-center text-muted py-4">Unesite kriterije i kliknite Prikaži</td></tr>';
    document.getElementById('resultCount').textContent = '';
    document.getElementById('pagination').innerHTML = '';
});

document.getElementById('btnLogout').addEventListener('click', () => {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    window.location.href = 'index.html';
});

document.getElementById('navUsername').textContent = localStorage.getItem('username') ?? '';
loadPartije();