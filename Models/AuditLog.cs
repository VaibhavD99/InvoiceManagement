using System;

namespace InvoiceManagement.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; } // Unique identifier
        public string UserId { get; set; } // User making the change
        public string Action { get; set; } // Type of action (Create, Update, Delete)
        public string Entity { get; set; } // Name of the entity (e.g., "Invoice")
        public string Changes { get; set; } // Details of the changes
        public DateTime Timestamp { get; set; } // When the action occurred
    }
}
