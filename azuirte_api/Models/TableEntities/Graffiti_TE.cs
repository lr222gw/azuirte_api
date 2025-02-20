using Azure;
using Azure.Data.Tables;

namespace azuirte_api.Models.TableEntities
{
    public class Graffiti_TE: Graffiti, ITableEntity
    {
        public Graffiti_TE() { }
        public Graffiti_TE(Graffiti graffiti) 
            :base(graffiti)
        {
            this.RowKey = Guid.NewGuid().ToString("N"); //generating a new guid each time prevents a duplicate key when re running this code
            this.PartitionKey = "General";
        }
        // From Interface
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
