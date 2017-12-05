namespace Bold.WebAPI.Commons.Constants
{
    public class Constants
    {
        public class Configuration
        {
            public const string ConfigName = "ServiceEndpoint";
            public const string Username = "BoldUsername";
            public const string Password = "BoldPassword";
        }

        public class MediaTypes
        {
            public const string ApplicationOctet = "application/octet-stream";
        }

        public class RoutePrefixes
        {
            public const string StoreConfiguration = "storeconfiguration";
            public const string ProductsPrefix = "{locale}/products";
            public const string FilesPrefix = "files";
        }
    }
}
