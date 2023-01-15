using JK.WSB.TaskReminder.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JK.WSB.TaskReminder.Shared.Dtos
{
    public class QuestDto
    {
        public string? Name { get; set; }
        public DateTimeOffset? RemindDate { get; set; }
        public DateTimeOffset? DeadLine { get; set; }
        public string? Note { get; set; }
        public bool IsFavoruite { get; set; }
        public bool IsDone { get; set; }
        public Guid UserId { get; set; }
    }
}
