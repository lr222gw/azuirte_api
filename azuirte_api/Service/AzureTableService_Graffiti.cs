using Azure.Data.Tables.Models;
using Azure.Data.Tables;
using azuirte_api.Service.Interface;
using azuirte_api.Models;
using azuirte_api.Models.TableEntities;

namespace azuirte_api.Service
{
    public class AzureTableService_Graffiti : ITableService<Graffiti_TE, Graffiti>
    {
        private TableServiceClient _tableClientService= new TableServiceClient("UseDevelopmentStorage=true");
        private TableClient _Graffitis_client= null;
        public AzureTableService_Graffiti()
        {
            var t = _tableClientService.CreateTableIfNotExists("Graffitis");
            _Graffitis_client = _tableClientService.GetTableClient("Graffitis");
            Console.WriteLine($"The table's name is {t.Value.Name}.");
        }

        public async Task<Graffiti_TE> Create(Graffiti entry)
        {
            var gte = new Graffiti_TE(entry);
            _Graffitis_client.AddEntity(gte);
            return gte;
        }

        public async Task<Graffiti_TE> Delete(string PartitionKey, string RowKey)
        {
            var entry = await _GetEntry(PartitionKey, RowKey);
            _Graffitis_client.DeleteEntity(entry);
            return entry;
        }

        public  async Task<Graffiti_TE> Edit(string PartitionKey, string RowKey, Graffiti updatedEntry)
        {
            Graffiti_TE entity = await _GetEntry(PartitionKey, RowKey);
            entity.Update(updatedEntry);
            _Graffitis_client.UpdateEntity(entity, entity.ETag);

            return entity;
        }

        private async Task<Graffiti_TE> _GetEntry(string PartitionKey, string RowKey)
        {
            var results = _Graffitis_client.Query<Graffiti_TE>(x => x.PartitionKey == PartitionKey && x.RowKey == RowKey).ToList();
            if (results.Count == 0 || results.Count > 1)
                throw new Exception("Oh no");
            var entity = results[0];
            return entity;
        }

        public async Task<List<Graffiti_TE>> GetAll()
        {
            var all = _Graffitis_client.Query<Graffiti_TE>();
            var allst = all.ToList(); // Tables to list 

            return allst;

        }
    }
}
