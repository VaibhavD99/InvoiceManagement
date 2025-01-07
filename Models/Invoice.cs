using InvoiceManagement.Models;
using System;
using System.Collections.Generic;

namespace InvoiceManagement.Models
{
    public class Invoice
    {
        public Guid Id { get; set; } // Unique identifier
        public string CustomerName { get; set; } // Name of the customer
        public DateTime CreatedAt { get; set; } // Creation timestamp
        public DateTime UpdatedAt { get; set; } // Last update timestamp
        public decimal TotalAmount { get; set; } // Total invoice amount
        public InvoiceStatus Status { get; set; } // Status of the invoice
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>(); // Associated invoice items
    }

    public enum InvoiceStatus
    {
        Draft,  // Initial state
        Sent,   // Invoice sent to the customer
        Paid,   // Invoice fully paid
        Overdue // Payment overdue
    }
}
