using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Application.UseCases.TestsCases.DTO;
using AGI.Morn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.TestsCases.Queries
{
    public record GetAllTestsQuery : IRequest<DataResponse<IEnumerable<Tests>>>;
    public class GetAllTestsHandler : IRequestHandler<GetAllTestsQuery, DataResponse<IEnumerable<Tests>>>
    {
        private readonly IunitOfWork _unitOfWork;

        public GetAllTestsHandler(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataResponse<IEnumerable<Tests>>> Handle(GetAllTestsQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.TestRepository.GetAllAsync();

            return new DataResponse<IEnumerable<Tests>>
            {
                StatusCode = HttpStatusCode.OK,
                ResponseData = data
            };
        }
    }
}
