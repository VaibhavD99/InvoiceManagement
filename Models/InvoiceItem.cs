using System;

namespace InvoiceManagement.Models
{
    public class InvoiceItem
    {
        public Guid Id { get; set; } // Unique identifier
        public Guid InvoiceId { get; set; } // Foreign key to the parent invoice
        public string Description { get; set; } // Item description
        public int Quantity { get; set; } // Number of units
        public decimal Price { get; set; } // Price per unit
        public decimal Total => Quantity * Price; // Computed total for the item
    }
}
