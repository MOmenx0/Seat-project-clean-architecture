using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.TestsCases.Commands;
using AGI.Morn.Application.UseCases.TestsCases.Queries;
using AGI.Morn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Morn_Agi.Extensions;

namespace Morn_Agi.Endpoints
{
    public class TestsEndPoint : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(nameof(TestsEndPoint))
               .MapGet(GetAllTests, nameof(GetAllTests))
               .MapGet(GetTestById, nameof(GetTestById))
               .MapGet(GetOne,nameof(GetOne))
               .MapPost(CreateTest, nameof(CreateTest));
        }


        public async Task<DataResponse<IEnumerable<Tests>>> GetAllTests(ISender sender , [AsParameters] GetAllTestsQuery request)
        {
           return await sender.Send(request);
        }

        public async Task<DataResponse<Tests>> GetTestById(ISender sender ,[AsParameters] GetTestByIdQuery request)
        {
            return await sender.Send(request);
        }

        public async Task<DataResponse<Tests>> GetOne(ISender sender, [AsParameters] GetOneQuery request)
        {
            return await sender.Send(request);
        }

        public async Task<DataResponse<int>> CreateTest(ISender sender,CreateTestQuery Request )
        {
            return await sender.Send(Request);
        }
    }
}
