namespace OrderService.Config
{
    public static class AppSettingsHelper
    {
        private static readonly IConfigurationRoot _configuration;


        /// <summary>
        /// Initializes the <see cref="AppSettingsHelper"/> class by loading configuration settings from the
        /// "appsettings.json" file.
        /// </summary>
        /// <remarks>This static constructor reads the "appsettings.json" file located in the
        /// application's current directory and builds a configuration object. The file is required and changes to it
        /// will be reloaded automatically.</remarks>
        static AppSettingsHelper()
        {
            // Reads appsettings.json
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
