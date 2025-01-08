using InvoiceManagement.Models;
using System;
using System.Collections.Generic;

namespace InvoiceManagement.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }

    public enum InvoiceStatus
    {
        Draft,
        Sent,
        Paid,
        Overdue
    }
}
