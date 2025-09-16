namespace OrderService.Config
{
    public static class AppSettingsHelper
    {
        private static readonly IConfigurationRoot _configuration;

        static AppSettingsHelper()
        {
            // Lê o appsettings.json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetConnectionString(string name = "DbConnection")
        {
            return _configuration.GetConnectionString(name);
        }
    }
}
