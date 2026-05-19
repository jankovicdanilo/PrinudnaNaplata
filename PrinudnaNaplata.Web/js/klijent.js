async function loadKlijentDropdown() {
  const data = await apiFetch(`${API_URL}/klijent`);
  if(!data)
    return;

  const select = document.getElementById('klijentDropdown');

  //add svi klijenti option
  const defaultOption = document.createElement('option');
  defaultOption.value = '0';
  defaultOption.textContent = 'Svi klijenti';
  select.appendChild(defaultOption);

  data.forEach(k => {
    const option = document.createElement('option');
    option.value = k.klijentID;
    option.textContent = k.naziv;
    select.appendChild(option);
  });

  // Restore from localStorage
    const current = localStorage.getItem('selectedKlijent');
    if (current) select.value = current;

    select.addEventListener('change', () => {
        localStorage.setItem('selectedKlijent', select.value);
        loadDuznici();
    });


}