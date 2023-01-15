namespace JK.WSB.TaskReminder.Shared.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
