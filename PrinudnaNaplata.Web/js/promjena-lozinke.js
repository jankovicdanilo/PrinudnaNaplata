function togglePassword(inputId, btnId) {
    const input = document.getElementById(inputId);
    const btn = document.getElementById(btnId);
    btn.addEventListener('click', () => {
        const isPassword = input.type === 'password';
        input.type = isPassword ? 'text' : 'password';
        btn.innerHTML = isPassword ? '<i class="bi bi-eye-slash"></i>' : '<i class="bi bi-eye"></i>';
    });
}

togglePassword('currentPassword', 'toggleCurrent');
togglePassword('newPassword', 'toggleNew');
togglePassword('confirmPassword', 'toggleConfirm');

document.getElementById('btnCancel').addEventListener('click', () => {
    history.back();
});

document.getElementById('btnSave').addEventListener('click', async () => {
    const errorMsg = document.getElementById('errorMsg');
    const successMsg = document.getElementById('successMsg');
    errorMsg.style.display = 'none';
    successMsg.style.display = 'none';

    const currentPassword = document.getElementById('currentPassword').value;
    const newPassword = document.getElementById('newPassword').value;
    const confirmPassword = document.getElementById('confirmPassword').value;

    if (!currentPassword || !newPassword || !confirmPassword) {
        errorMsg.textContent = 'Sva polja su obavezna.';
        errorMsg.style.display = 'block';
        return;
    }

    if (newPassword !== confirmPassword) {
        errorMsg.textContent = 'Nova lozinka i potvrda se ne poklapaju.';
        errorMsg.style.display = 'block';
        return;
    }

    if (newPassword.length < 6) {
        errorMsg.textContent = 'Nova lozinka mora imati najmanje 6 karaktera.';
        errorMsg.style.display = 'block';
        return;
    }

    try {
        const response = await fetch(`${API_URL}/auth/changePassword`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${getToken()}`
            },
            credentials: 'include',
            body: JSON.stringify({ currentPassword, newPassword })
        });

        if (response.status === 401) {
            window.location.href = 'index.html';
            return;
        }

        const data = await response.json();

        if (!response.ok) {
            errorMsg.textContent = data.message || 'Greška pri promjeni lozinke.';
            errorMsg.style.display = 'block';
            return;
        }

        successMsg.style.display = 'block';
        document.getElementById('currentPassword').value = '';
        document.getElementById('newPassword').value = '';
        document.getElementById('confirmPassword').value = '';

    } catch (err) {
        errorMsg.textContent = 'Greška pri povezivanju sa serverom.';
        errorMsg.style.display = 'block';
    }
});

initNavbar(() => {});