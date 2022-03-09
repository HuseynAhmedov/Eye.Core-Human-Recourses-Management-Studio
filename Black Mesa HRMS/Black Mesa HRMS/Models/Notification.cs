using Black_Mesa_HRMS.Enums;

namespace Black_Mesa_HRMS.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public NotificationType Type { get; set; }
        public bool Read { get; set; }
    }
}
