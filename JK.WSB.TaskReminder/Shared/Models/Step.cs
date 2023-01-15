namespace JK.WSB.TaskReminder.Shared.Models
{
    public class Step : BaseModel
    {
        public Quest Parent { get; set; } = null!;
        public bool IsDone { get; set; }

    }
}
