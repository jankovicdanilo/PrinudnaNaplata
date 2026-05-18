const API_URL = 'https://localhost:7206/api';
const pageSize = 10;

function getToken(){
    return localStorage.getItem('token');
}

function getBool(id){
    const val = document.getElementById(id).value;
    if(val === '')
        return null;
    return val === 'true';
}

async function apiFetch(url) {
    const response = await fetch(url, {
        headers:{'Authorization': `Bearer ${getToken()}`},
        credentials: 'include'
    });
    if(response.status === 401){
        window.location.href = 'index.html';
        return null;
    }
    const json = await response.json()
    return json.data;
}

function formatDate(dateStr){
    if(!dateStr)
        return '';
    return new Date(dateStr).toLocaleDateString('sr-RS');
}