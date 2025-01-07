using InvoiceManagement.DTOs;
using System;
using System.Collections.Generic;

namespace InvoiceManagement.DTOs
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Draft, Sent, Paid, Overdue
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<InvoiceItemDto> InvoiceItems { get; set; }
    }
}
