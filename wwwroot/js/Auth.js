window.auth = {
    register: async function (userName, email, password, confirmPassword) {
        const response = await fetch("api/auth/register", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ userName, email, password, confirmPassword }),
            credentials: 'include'
        });

        return response.ok
    },
    
    login: async function (email, password) {
        const response = await fetch("api/auth/login", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({email, password }),
            credentials: 'include'
        });

        return response.ok
    },

    logout: async function () {
        const response = await fetch("api/auth/logout", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include'
        })

        return response.ok
    }
}