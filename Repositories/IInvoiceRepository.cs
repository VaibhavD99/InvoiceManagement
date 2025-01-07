using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManagement.Models;
using InvoiceManagement.Models;

namespace InvoiceManagement.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(Guid id);
        Task CreateAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(Guid id);
    }
}
