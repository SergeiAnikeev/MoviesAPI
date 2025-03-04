using Microsoft.Extensions.Diagnostics.HealthChecks;
using Movies.Application.Database;

namespace Movies.API.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public const string Name = "Database";
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly ILogger<DatabaseHealthCheck> _logger;

        public DatabaseHealthCheck(IDbConnectionFactory dbConnectionFactory, ILogger<DatabaseHealthCheck> logger)
        {
            _connectionFactory = dbConnectionFactory;
            _logger = logger;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try 
            {
                _ = await _connectionFactory.CreateConnectionAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                const string errmsg = "DB is unhealthy";
                _logger.LogError(errmsg, ex);
                return HealthCheckResult.Unhealthy(errmsg);
            }
        } 
    }
}
