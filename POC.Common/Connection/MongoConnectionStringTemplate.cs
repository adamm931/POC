namespace POC.Common.Connection
{
    public class MongoConnectionStringTemplate : ConnectionStringTemplate
    {
        public MongoConnectionStringTemplate() : base(GetTemplate())
        {
        }

        private static string GetTemplate() => $"mongodb://{ConnectionStringVariables.Host}" +
            $":{ConnectionStringVariables.Port}" +
            $"/{ConnectionStringVariables.DbName}";
    }
}
