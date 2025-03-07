window.auth = {
    register: async function (username, email, password) {
        const response = await fetch("api/auth/register", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, email, password }),
            credentials: 'include'
        });

        return response.ok
    },
}