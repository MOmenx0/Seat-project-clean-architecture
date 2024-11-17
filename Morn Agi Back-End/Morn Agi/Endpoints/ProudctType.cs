using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.proudctTypeCases.Queries;
using AGI.Morn.Domain.Entities;
using MediatR;
using Morn_Agi.Extensions;

namespace Morn_Agi.Endpoints
{
    public class ProudctType : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
           app.MapGroup(nameof( ProudctType))
              .MapGet(TypeProudct,nameof(TypeProudct));
        }


        public async Task<DataResponse<IEnumerable<productTypes>>> TypeProudct (ISender sender )
        {
            return await sender.Send(new getAllTypesQueires());
        }
    }
}
