using azuirte_api.Models.Interface;
using azuirte_api.Models.TableEntities;
using Azure;
using Azure.Data.Tables;

namespace azuirte_api.Models
{
    public class Graffiti : I_Model<Graffiti>
    {
        public Graffiti() { }
        public Graffiti(Graffiti e)
        {
            Update(e);
        }
        public string Author { get; set; }
        public string Message { get; set; }

        public void Update(Graffiti updated)
        {
            this.Author  = updated.Author  ?? this.Author ;
            this.Message = updated.Message ?? this.Message;
        }
    }
}
