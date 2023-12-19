namespace Todo_items__MVC_.Models
{
    using System;

    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public TodoStatus Status { get; set; }
    }

    public enum TodoStatus
    {
        Pending = 0,
        Done = 1,
        Rejected = 2
    }


}
