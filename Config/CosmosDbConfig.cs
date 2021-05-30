namespace AuditTool.Config
{
    public class CosmosDbConfig
    {
        public string Database { get; set; }
        public string EngagementContainerName { get; set; }
        public string UserContainerName { get; set; }
        public string PartitionKey { get; set; }
    }
}