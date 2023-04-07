using Financial.Control.Domain.Interfaces.Config;
using Microsoft.Extensions.Configuration;

namespace Financial.Control.Infra.Services.Config
{
    public class DatabaseConfig : IDatabaseConfig
    {
        private readonly IConfigurationSection configurationSection;
        public DatabaseConfig(IConfiguration configuration)
        {
            configurationSection = configuration.GetSection("Database");
        }
        public string ConnectionString => configurationSection.GetSection("DefaultConnection").Value ?? string.Empty;
    }
}
