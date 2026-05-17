
let currentPage = 1;

function getFilters() {
    return {
        BrzaPretraga: document.getElementById('f_sve').value || null,
        BrojPartije: document.getElementById('f_brojpartije').value || null,
        ImeDuznika: document.getElementById('f_ime').value || null,
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
        const result = await apiFetch(`${API_URL}/case?${params.toString()}`);
        if(result) {
            renderTable(result.items);
            renderPagination(result.totalCount);
        }
    } catch (error) {
        console.error('Greška:', error);
    }
}

async function loadSudovi() {
    const response = await fetch(`${API_URL}/court`,{
        headers: {'Authorization': `Bearer ${getToken()}`}
    });
    const data = await response.json();
    const select = document.getElementById('f_sudid');
    data.data.forEach(sud => {
        const option = document.createElement('option');
        option.value = sud.naziv;
        option.textContent = sud.naziv;
        select.appendChild(option);
    })
}

function renderPagination(totalCount){
    const totalPages = Math.ceil(totalCount/ pageSize);
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    if(totalPages <= 1)
        return;

    //Previous button
    const prev = document.createElement('button');
    prev.className = `page-btn ${currentPage === 1 ? 'disabled' : ''}`;
    prev.textContent = '←';
    prev.disabled = currentPage === 1;
    prev.addEventListener('click', () => {currentPage--; loadPartije();});
    pagination.appendChild(prev);

    //Page numbers
    for(let i = 1; i < totalPages; i++){
        // Show first, last, and pages around current
        if(i === 1 || i === totalPages || (i >= currentPage - 2 && i <= currentPage + 2)){
            const btn = document.createElement('button');
            btn.className = `page-btn ${i === currentPage ? 'active' : ''}`;
            btn.textContent = i;
            btn.addEventListener('click', () => {currentPage = i; loadPartije(); });
            pagination.appendChild(btn);
        } else if(i === currentPage - 3 || i === currentPage + 3){
            const dots = document.createElement('span');
            dots.textContent = '...';
            dots.style.cssText = 'padding: 4px 6px; color: #64748b; font-size: 13px;';
            pagination.appendChild(dots);
        }
    }

    //Next button
    const next = document.createElement('button');
    next.className = `page-btn ${currentPage === totalPages ? 'disabled' : ''}`;
    next.textContent = '→';
    next.disabled = currentPage === totalPages;
    next.addEventListener('click', () => {currentPage++, loadPartije(); })
    pagination.appendChild(next);

    //Result count
    document.getElementById('resultCount').textContent = `${totalCount} rezultata — stranica ${currentPage} od ${totalPages}`;
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
loadSudovi();