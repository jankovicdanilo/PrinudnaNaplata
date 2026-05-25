document.getElementById('togglePwd').addEventListener('click', function () {
    const pwd = document.getElementById('password');
    const isPassword = pwd.type === 'password';
    pwd.type = isPassword ? 'text' : 'password';
    this.className = isPassword ? 'bi bi-eye-slash input-icon' : 'bi bi-eye input-icon';
});

document.getElementById('btnLogin').addEventListener('click', async function () {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const rememberMe = document.getElementById('rememberMe').checked;

    try{
        const response = await fetch('https://localhost:7206/api/auth/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({Username: username,Password: password, rememberMe: rememberMe  })
        });

        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token);
            localStorage.setItem('username',data.username);
            window.location.href = 'duznici.html';
        } else {
            alert('Pogrešno korisničko ime ili lozinka');
        }
    } catch(error){
        alert('Greska pri povezivanju sa servereom');
    }
});