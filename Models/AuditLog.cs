
namespace InvoiceManagement.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Entity { get; set; }
        public string Changes { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
