using InvoiceManagement.Data;
using InvoiceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Services
{
    public class InvoiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(ApplicationDbContext context, ILogger<InvoiceService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync()
        {
            _logger.LogInformation("Fetching all invoices.");
            try
            {
                return await _context.Invoices.Include(i => i.InvoiceItems).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching invoices.");
                throw;
            }
        }

        public async Task<Invoice> GetInvoiceByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching invoice with ID: {Id}", id);
            try
            {
                return await _context.Invoices.Include(i => i.InvoiceItems).FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching invoice with ID: {Id}", id);
                throw;
            }
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _logger.LogInformation("Creating new invoice.");
            try
            {
                invoice.Id = Guid.NewGuid();
                invoice.CreatedAt = DateTime.UtcNow;
                invoice.UpdatedAt = DateTime.UtcNow;

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Invoice created successfully with ID: {Id}", invoice.Id);
                return invoice;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating invoice.");
                throw;
            }
        }

        public async Task<Invoice> UpdateInvoiceAsync(Guid id, Invoice invoice)
        {
            _logger.LogInformation("Updating invoice with ID: {Id}", id);
            try
            {
                var existingInvoice = await _context.Invoices.Include(i => i.InvoiceItems).FirstOrDefaultAsync(i => i.Id == id);
                if (existingInvoice == null)
                {
                    _logger.LogWarning("Invoice with ID {Id} not found.", id);
                    return null;
                }

                existingInvoice.CustomerName = invoice.CustomerName;
                existingInvoice.TotalAmount = invoice.TotalAmount;
                existingInvoice.Status = invoice.Status;
                existingInvoice.UpdatedAt = DateTime.UtcNow;

                _context.Invoices.Update(existingInvoice);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Invoice updated successfully with ID: {Id}", id);
                return existingInvoice;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating invoice with ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> DeleteInvoiceAsync(Guid id)
        {
            _logger.LogInformation("Deleting invoice with ID: {Id}", id);
            try
            {
                var invoice = await _context.Invoices.FindAsync(id);
                if (invoice == null)
                {
                    _logger.LogWarning("Invoice with ID {Id} not found.", id);
                    return false;
                }

                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Invoice deleted successfully with ID: {Id}", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting invoice with ID: {Id}", id);
                throw;
            }
        }
    }
}