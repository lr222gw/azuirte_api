namespace azuirte_api.Models
{
    public class VIEW_Graffiti
    {
        public VIEW_Graffiti(Graffiti g)
        {
            this.id = [g.PartitionKey, g.RowKey];
            this.Author  = g.Author;
            this.Message = g.Message;
        }
        public string[] id { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
    }
}
