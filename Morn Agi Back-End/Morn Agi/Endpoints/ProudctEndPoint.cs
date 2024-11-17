using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.ProudctCase.Command;
using AGI.Morn.Application.UseCases.ProudctCase.DTO;
using AGI.Morn.Application.UseCases.ProudctCase.Queries;
using AGI.Morn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Morn_Agi.Extensions;

namespace Morn_Agi.Endpoints
{
    public class ProudctEndPoint : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(nameof(ProudctEndPoint))
               .MapGet(GetAll, nameof(GetAll))
               .MapGet(GetProudctById, nameof(GetProudctById))
               .MapPost(GetWithFilter, nameof(GetWithFilter))
               .MapPost(CreateProudct, nameof(CreateProudct))
               .MapPut(Update, nameof(Update));

        }

        public async Task<DataResponse<IEnumerable<ProudctDto>>> GetAll(ISender sender )
        {
            return await sender.Send(new GetAllProudctsQuery());
        }

        public async Task<DataResponse<PaginatedList<ProudctDto>>> GetWithFilter(ISender sender,[FromBody] getAllProudctFilteredQuery request)
        {
            return await sender.Send(request);
        }

        public async Task<DataResponse<int>> CreateProudct(ISender sender, CreateProudctQueriy Request)
        {
            return await sender.Send(Request);
        }

        public async Task<DataResponse<ProudctDto>> GetProudctById(ISender sender ,[AsParameters] GetProudctByIdQuery Request)
        {
            return await sender.Send(Request);
        }

        public async Task<DataResponse<int>> Update (ISender sender , updateProudctQuery request)
        {
            return await sender.Send(request);
        }
    }
}
