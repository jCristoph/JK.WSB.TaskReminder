namespace JK.WSB.TaskReminder.Shared.Models
{
    public class User : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Salt { get; set; }
    }
}
