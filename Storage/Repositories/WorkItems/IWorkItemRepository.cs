using ToDoList.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ToDoList.Storage.Repositories.WorkItems
{
    public interface IWorkItemRepository
    {
        Task<List<WorkItem>> GetAllItems();
    }
}
