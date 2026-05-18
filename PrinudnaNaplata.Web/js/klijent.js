async function loadKlijentDropdown() {
  const data = await apiFetch(`{API_URL}/klijent`);
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

  });

  // Restore previously selected value from cookie
  const current = getCookie('selectedKlijent');
  if(current)
    select.value = current;

  select.addEventListener('change', () => {
    document.cookie = `selectedKlijent=${select.value}; path=/`;
    loadDuznici(); //or whatever the current page's load function is
  })

  function getCookie(name){
    return document.getCookie
        .split('; ')
        .find(r => r.startsWith(name + '='))
        ?.split('=')[1];  
  }


}