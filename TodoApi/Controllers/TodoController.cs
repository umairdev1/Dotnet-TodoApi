using TodoApi.Services;

namespace TodoApi.Controllers;

public static class TodoController
{
    public static async Task<IResult> GetAll(TodoService service)
    {
        var todos = await service.GetAllAsync();
        return TypedResults.Ok(todos);
    }

    public static async Task<IResult> GetCompleted(TodoService service)
    {
        var todos = await service.GetCompletedAsync();
        return TypedResults.Ok(todos);
    }

    public static async Task<IResult> GetById(int id, TodoService service)
    {
        var todo = await service.GetByIdAsync(id);
        return todo is not null
            ? TypedResults.Ok(todo)
            : TypedResults.NotFound();
    }

    public static async Task<IResult> Create(Todo todo, TodoService service)
    {
        var created = await service.CreateAsync(todo);
        return TypedResults.Created($"/todo/{created.Id}", created);
    }

    public static async Task<IResult> Update(int id, Todo input, TodoService service)
    {
        var success = await service.UpdateAsync(id, input);
        return success
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }

    public static async Task<IResult> Delete(int id, TodoService service)
    {
        var success = await service.DeleteAsync(id);
        return success
            ? TypedResults.NoContent()
            : TypedResults.NotFound();
    }
}