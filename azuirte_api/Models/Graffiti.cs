using Azure;
using Azure.Data.Tables;

namespace azuirte_api.Models
{
    public class Graffiti : ITableEntity
    {
        public string Author { get; set; }
        public string Message { get; set; }

        // From Interface
        public string PartitionKey { get ; set ; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
