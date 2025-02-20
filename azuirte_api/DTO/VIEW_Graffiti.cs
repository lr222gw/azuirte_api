using azuirte_api.DTO;
using azuirte_api.Models.TableEntities;

namespace azuirte_api.Models
{
    public class VIEW_Graffiti : DTO<Graffiti>
    {
        public VIEW_Graffiti(Graffiti_TE g)
        {
            this.id = [g.PartitionKey, g.RowKey];
            this.Author  = g.Author;
            this.Message = g.Message;
        }
        public string[] id { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }

        public Graffiti toModel()
        {
            return new Graffiti { Author = this.Author, Message = this.Message };
        }
    }
}
