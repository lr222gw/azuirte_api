using azuirte_api.DTO;
using azuirte_api.Models;
using azuirte_api.Models.TableEntities;
using azuirte_api.Service.Interface;
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
            graffiti.MapGet("/", (Delegate)GetAll);     // Casting to Delegate makes the Endpoints show up in Swagger! (If they don't have any arguments)
            graffiti.MapPost("/", (Delegate)AddPost);   // Otherwise we need to add arguments to the endpoint functions...
            graffiti.MapPut("/{PartitionKey}&{RowKey}", (Delegate)EditPost);   // Otherwise we need to add arguments to the endpoint functions...
            graffiti.MapDelete("/{PartitionKey}&{RowKey}", (Delegate)DeletePost);   // Otherwise we need to add arguments to the endpoint functions...
        }

        private static async Task<IResult> DeletePost(HttpContext context, ITableService<Graffiti_TE, Graffiti> service, string PartitionKey, string RowKey)
        {
            var ret = await service.Delete(PartitionKey, RowKey); 
            return TypedResults.Ok(new VIEW_Graffiti(ret));
        }

        private static async Task<IResult> EditPost(HttpContext context, ITableService<Graffiti_TE, Graffiti> service, string PartitionKey, string RowKey, PUT_Graffiti dto)
        {

            var ret = await service.Edit(PartitionKey, RowKey, dto.toModel());
            return TypedResults.Ok(new VIEW_Graffiti(ret));
        }

        private static async Task<IResult> AddPost(HttpContext context, ITableService<Graffiti_TE, Graffiti> service, POST_Graffiti dto )
        {
            var te = await service.Create(dto.toModel());
            var ret = new VIEW_Graffiti(te);

            return TypedResults.Ok(ret);
        }

        private static async Task<IResult> GetAll(HttpContext context, ITableService<Graffiti_TE, Graffiti> service)
        {
            return TypedResults.Ok((await service.GetAll()).Select(x => new VIEW_Graffiti(x)).ToList());
        }
    }
}
