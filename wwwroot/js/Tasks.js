window.tasks = {
    getTasks: async function(userId){
        const response = await fetch("api/todo", {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ userId}),
            credentials: 'include'
        });
        
        return response.json;
    },
    
    createTask: async function(userId, task){
        const response = await fetch("api/todo", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ userId, task}),
            credentials: 'include'
        });
        
        return response.ok
    }
}