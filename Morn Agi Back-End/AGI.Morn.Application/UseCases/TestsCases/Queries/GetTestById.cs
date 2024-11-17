using AGI.Morn.Application.Common.Interfaces;
using AGI.Morn.Application.Common.Models;
using AGI.Morn.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.TestsCases.Queries
{
    public record GetTestByIdQuery : IRequest<DataResponse<Tests>>
    {
        public int Id { get; init; }
    }
    public class GetTestById : IRequestHandler<GetTestByIdQuery, DataResponse<Tests>>
    {
        private readonly IunitOfWork _unitOfWork;
        public GetTestById(IunitOfWork iunitOfWork) {
            _unitOfWork = iunitOfWork;
        }

        public async Task<DataResponse<Tests>> Handle([FromRoute] GetTestByIdQuery query, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.TestRepository.GetByIdAsync(query.Id);

            return  new DataResponse<Tests>
            {
                StatusCode= HttpStatusCode.OK ,
                ResponseData = data
            } ;
        }
    }
}
