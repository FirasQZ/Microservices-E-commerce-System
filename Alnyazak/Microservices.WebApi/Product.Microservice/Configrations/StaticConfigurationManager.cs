namespace Product.Microservice.Configrations
{
    public class StaticConfigurationManager
    {
        public static IConfiguration AppSetting
        {
            get;
        }
        static StaticConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
