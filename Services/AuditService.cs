using InvoiceManagement.Data;
using InvoiceManagement.Models;

namespace InvoiceManagement.Services
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuditService> _logger;

        public AuditService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<AuditService> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task LogAsync(string action, string entity, string changes)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";

                var auditLog = new AuditLog
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Action = action,
                    Entity = entity,
                    Changes = changes,
                    Timestamp = DateTime.UtcNow
                };

                _context.AuditLogs.Add(auditLog);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Audit Log Created: {Action} on {Entity} by {UserId}", action, entity, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating audit log for {Entity}", entity);
            }
        }
    }
}
