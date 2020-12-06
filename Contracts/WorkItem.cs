using System;

namespace ToDoList.Contracts
{
    public enum WorkItemStatus
    {
        Proposed,
        Sterted,
        Completed,
        Future,
        Cut,
    }
    public class WorkItem
    {
        public static string GetPartitionKey(Guid uniqueId) => uniqueId.ToString().Substring(0, 2);

        public WorkItem()
        {
            this.UniqueIdentifier = new Guid();
            this.Name = "test";
            this.Description = "all for test";
            this.Status = WorkItemStatus.Proposed;
        }
        public Guid UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WorkItemStatus Status { get; set; }
    }
}
