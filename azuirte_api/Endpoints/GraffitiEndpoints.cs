using azuirte_api.Models;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;

namespace azuirte_api.Endpoints
{
    static public class GraffitiEndpoints
    {
        static public void Configure_GraffitiEndpoints(this WebApplication app)
        {
            var graffiti = app.MapGroup("/");
            graffiti.MapGet("/", (Delegate)GetAll);     // Casting to Delegate makes the Endpoints show up in Swagger! 
            graffiti.MapPost("/", (Delegate)AddPost);   // Otherwise we need to add arguments to the endpoint functions...
            graffiti.MapPut("/{id}&{id2}", (Delegate)EditPost);   // Otherwise we need to add arguments to the endpoint functions...
        }

        private static async Task<IResult> EditPost(HttpContext context, string id, string id2)
        {
            TableServiceClient tableClient = new TableServiceClient("UseDevelopmentStorage=true");

            var tbc = tableClient.GetTableClient("Graffitis");
            var all = tbc.Query<Graffiti>();
            var alllist = all.ToList(); // Tables to list 


            return TypedResults.Ok(alllist.Select(x => new VIEW_Graffiti(x)).ToList());
        }

        private static async Task<IResult> AddPost(HttpContext context, POST_Graffiti dto )
        {
            TableClient client = new TableClient("UseDevelopmentStorage=true", "Graffitis");
            TableItem table = client.CreateIfNotExists();

            Console.WriteLine($"The table's name is {table.Name}.");

            Graffiti graf = new Graffiti() { Author = dto.Author, Message = dto.Message };

            //create a TableEntity passing in the PartitionKey and RowIndex
            string rowKey = Guid.NewGuid().ToString("N"); //generating a new guid each time prevents a duplicate key when re running this code
            string partitionKey = "General";

            
            var grafEntity = new TableEntity(partitionKey, rowKey)
            {
                { nameof(graf.Author) ,graf.Author },
                { nameof(graf.Message) ,graf.Message},                

            };


            Console.WriteLine($"{grafEntity.RowKey}: {grafEntity["Author"]} {grafEntity["Message"]}");

            //add to our Azure table so now we have four columns in our table, the PartitionKey, RowIndex, Make, Model
            client.AddEntity(grafEntity);

            return TypedResults.Ok("");
        }

        private static async Task<IResult> GetAll(HttpContext context)
        {

            TableServiceClient tableClient = new TableServiceClient("UseDevelopmentStorage=true");

            var tbc = tableClient.GetTableClient("Graffitis");
            var all = tbc.Query<Graffiti>();
            var alllist = all.ToList(); // Tables to list 

            
            return TypedResults.Ok(alllist.Select(x => new VIEW_Graffiti(x)).ToList());
        }
    }
}
