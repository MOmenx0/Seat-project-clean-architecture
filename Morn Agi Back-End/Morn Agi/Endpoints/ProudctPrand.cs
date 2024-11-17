using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.ProductPrandCases.Commands;
using AGI.Morn.Application.UseCases.ProductPrandCases.Queries;
using AGI.Morn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Morn_Agi.Extensions;

namespace Morn_Agi.Endpoints
{
    public class ProudctPrand : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(nameof(ProudctPrand))
               .MapGet(GetAllPrands, nameof(GetAllPrands))
               .MapPost(createPrands, nameof(createPrands));
        }

        public async Task<DataResponse<IEnumerable<productPrand>>> GetAllPrands(ISender sender)
        {
            return await sender.Send(new GetAllPrandsQueriey());
        }

        public async Task<DataResponse<int>> createPrands(ISender sender , productPrandCommand Request)
        {
          return await sender.Send(Request);
        }
    }
}
