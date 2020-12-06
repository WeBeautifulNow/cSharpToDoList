using ToDoList.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ToDoList.Storage.Repositories.WorkItems
{
    public interface IWorkItemRepository
    {
        Task<List<WorkItem>> GetAllItems();
        Task<WorkItem> GetWorkItem(Guid workItemId);
    }
}
