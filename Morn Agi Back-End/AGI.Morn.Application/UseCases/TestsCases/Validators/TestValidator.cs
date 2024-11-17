using AGI.Morn.Application.UseCases.TestsCases.Queries;
using AGI.Morn.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.TestsCases.Validators
{
    public class TestValidator : AbstractValidator<GetTestByIdQuery>
    {
        public TestValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("id is required");
        }

    }
}