﻿using Microsoft.AspNetCore.Mvc;
using ToDoAplikace.Data;
using ToDoAplikace.Services;

namespace ToDoAplikace.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly ToDoTaskService _toDoTaskService;

        public ToDoTaskController(ToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTasks(int userId)
        {
            var tasks = await _toDoTaskService.GetTasksByUserIdAsync(userId);

            return tasks is not null ? Ok(tasks) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(int userId, ToDoTask task)
        {
            var request = await _toDoTaskService.CreateTaskWithUserIdAsync(userId, task);

            if (request) return Ok();

            return BadRequest();
        }
    }
}
