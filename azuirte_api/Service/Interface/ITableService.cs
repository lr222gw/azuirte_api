using System.Collections.Concurrent;
using azuirte_api.Models.Interface;
using azuirte_api.Models.TableEntities;
using Azure.Data.Tables;

namespace azuirte_api.Service.Interface
{
    public interface ITableService<TableEntity, DomainEntity>
        where TableEntity : class,ITableEntity
        where DomainEntity : class, I_Model<DomainEntity>
    {
        Task<List<TableEntity>> GetAll();
        Task<TableEntity> Create(DomainEntity entry);
        Task<TableEntity> Edit(string PartitionKey, string RowKey, DomainEntity entry);
        Task<Graffiti_TE> Delete(string PartitionKey, string RowKey);
    }
}
