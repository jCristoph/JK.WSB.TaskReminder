namespace JK.WSB.TaskReminder.Shared.Models
{
    public class Quest : BaseModel
    {
        public DateTimeOffset? RemindDate { get; set; }
        public DateTimeOffset? DeadLine { get; set; }
        public string? Note { get; set; }
        public bool IsFavoruite { get; set; }
        public bool IsDone { get; set; }
        public IEnumerable<Step>? Steps { get; set; }
        public User User { get; set; } = null!;

    }
}
