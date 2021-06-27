using System;
using System.Threading.Tasks;
using Refit;

namespace XFRefitSample
{
    public interface ITodoServer
    {
        [Get("/todos")]
        Task<TodoItem[]> GetTodoItems();

        [Get("/todos/{id}")]
        Task<TodoItem> GetTodoItem(int id);

        [Post("/todos")]
        Task<TodoItem> SaveTodoItem([Body]TodoItem item);
    }
}
