using InvoiceManagement.Models;
using InvoiceManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(Guid id)
        {
            return await _context.Invoices
                .Include(i => i.InvoiceItems)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task CreateAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
