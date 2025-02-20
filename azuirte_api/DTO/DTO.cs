namespace azuirte_api.DTO
{
    public interface DTO<DomainModel> where DomainModel : class
    {
        DomainModel toModel();
    }
}
