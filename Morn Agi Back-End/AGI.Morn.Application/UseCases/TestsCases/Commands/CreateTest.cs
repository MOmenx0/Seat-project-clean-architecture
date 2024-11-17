using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.TestsCases.Commands
{
    public record CreateTestQuery: IRequest<DataResponse<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
    }
    public class CreateTest : IRequestHandler<CreateTestQuery, DataResponse<int>>
    {
        private readonly IunitOfWork _iunitOfWork;
        public CreateTest(IunitOfWork iunitOfWork) 
        {
            _iunitOfWork = iunitOfWork;
        }
        public async Task<DataResponse<int>> Handle(CreateTestQuery query, CancellationToken cancellationToken)
        {
            var test = new Tests
            {
                Name = query.Name,
                AuthorName = query.AuthorName,
                Description = query.Description,
                AuthorDescription = query.AuthorDescription,
            };
            var data = _iunitOfWork.TestRepository.Add(test);
            _iunitOfWork.SaveChanges();
            return new DataResponse<int>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data.Id
            };
        }
    }
}
