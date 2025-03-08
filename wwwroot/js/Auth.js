window.auth = {
    register: async function (username, email, password) {
        const response = await fetch("auth/register", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, email, password }),
            credentials: 'include'
        });

        return response.ok
    },
    
    login: async function (email, password) {
        const response = await fetch("auth/login", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({email, password }),
            credentials: 'include'
        });
    }
}