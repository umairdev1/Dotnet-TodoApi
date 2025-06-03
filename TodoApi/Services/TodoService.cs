using Microsoft.EntityFrameworkCore;

namespace TodoApi.Services;

public class TodoService
{
    private readonly TodoDb _db;

    public TodoService(TodoDb db)
    {
        _db = db;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _db.Todos.ToListAsync();
    }

    public async Task<List<Todo>> GetCompletedAsync()
    {
        return await _db.Todos.Where(t => t.IsComplete).ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _db.Todos.FindAsync(id);
    }

    public async Task<Todo> CreateAsync(Todo todo)
    {
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> UpdateAsync(int id, Todo input)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return false;

        todo.Name = input.Name;
        todo.IsComplete = input.IsComplete;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) return false;

        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
        return true;
    }
}