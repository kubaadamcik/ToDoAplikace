window.tasks = {
    getTasks: async function (userId) {
        const response = await fetch(`api/todo/${userId}`, {
            method: 'GET',
            credentials: 'include'
        });

        if (!response.ok) {
            throw new Error(`Failed to fetch tasks: ${response.status}`);
        }

        const data = await response.json();
        return data;
    },

    createTask: async function (task) {
        const response = await fetch('api/todo', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(task),
            credentials: 'include'
        });

        if (!response.ok) {
            throw new Error(`Failed to create task: ${response.status}`);
        }

        return response.ok;
    },

    finishTask: async function (id, userId) {
        const response = await fetch('api/todo', {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(id, userId),
            credentials: 'include'
        });

        if (!response.ok) {
            throw new Error(`Failed to finish task: ${response.status}`);
        }
        
        return true;
    }
};