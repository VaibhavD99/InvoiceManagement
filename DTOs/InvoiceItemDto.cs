using System;

namespace InvoiceManagement.DTOs
{
    public class InvoiceItemDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
    }
}
