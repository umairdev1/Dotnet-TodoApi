using TodoApi.Controllers;

namespace TodoApi.Routes;

public static class TodoRoutes
{
    public static void Register(WebApplication app)
    {
        app.MapGet("/todo", TodoController.GetAll);
        app.MapGet("/todo/completed", TodoController.GetCompleted);
        app.MapGet("/todo/{id}", TodoController.GetById);
        app.MapPost("/todo", TodoController.Create);
        app.MapPut("/todo/{id}", TodoController.Update);
        app.MapDelete("/todo/{id}", TodoController.Delete);
    }
}