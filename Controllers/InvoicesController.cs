using InvoiceManagement.Data;
using InvoiceManagement.Helpers;
using InvoiceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<InvoicesController> _logger;

        public InvoicesController(ApplicationDbContext context, ILogger<InvoicesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            _logger.LogInformation("Fetching all invoices.");
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems).ToListAsync();
            return Ok(invoices);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            _logger.LogInformation("Fetching invoice with ID: {Id}", id);
            var invoice = await _context.Invoices.Include(i => i.InvoiceItems).FirstOrDefaultAsync(i => i.Id == id);
            if (invoice == null)
            {
                _logger.LogWarning("Invoice with ID {Id} not found.", id);
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (ValidationHelper.ContainsSpecialCharacters(invoice.CustomerName))
            {
                return BadRequest("Customer name contains invalid characters.");
            }

            if (!ValidationHelper.IsPositiveNumber(invoice.TotalAmount))
            {
                return BadRequest("Total amount must be a positive number.");
            }

            invoice.Id = Guid.NewGuid();
            invoice.CreatedAt = DateTime.UtcNow;
            invoice.UpdatedAt = DateTime.UtcNow;

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateInvoice(Guid id, [FromBody] Invoice invoice)
        {
            if (ValidationHelper.ContainsSpecialCharacters(invoice.CustomerName))
            {
                return BadRequest("Customer name contains invalid characters.");
            }

            if (!ValidationHelper.IsPositiveNumber(invoice.TotalAmount))
            {
                return BadRequest("Total amount must be a positive number.");
            }

            var existingInvoice = await _context.Invoices.FindAsync(id);
            if (existingInvoice == null)
            {
                return NotFound();
            }

            existingInvoice.CustomerName = invoice.CustomerName;
            existingInvoice.TotalAmount = invoice.TotalAmount;
            existingInvoice.Status = invoice.Status;
            existingInvoice.UpdatedAt = DateTime.UtcNow;

            _context.Invoices.Update(existingInvoice);
            await _context.SaveChangesAsync();
            return Ok(existingInvoice);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
