using azuirte_api.DTO;

namespace azuirte_api.Models
{
    public class POST_Graffiti : DTO<Graffiti>
    {
        
        public string Author { get; set; }
        public string Message { get; set; }

        public Graffiti toModel()
        {
            return new Graffiti { Author = this.Author, Message = this.Message };
        }
    }
}
