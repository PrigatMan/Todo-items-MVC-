using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo_items__MVC_.Models;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private static List<TodoItem> tasks = new List<TodoItem>();

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TodoItem task)
    {
        if (ModelState.IsValid)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
            return Ok(task);
        }
        return BadRequest("Invalid task data");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] TodoItem updatedTask)
    {
        if (ModelState.IsValid)
        {
            var existingTask = tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Name = updatedTask.Name;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;
                return Ok(existingTask);
            }
            return NotFound(); // Task not found
        }
        return BadRequest("Invalid task data");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            return Ok(); // Return success
        }
        return NotFound(); // Task not found
    }
}