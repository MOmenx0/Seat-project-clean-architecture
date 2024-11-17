using AGI.Morn.Application.UseCases.ProductPrandCases.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProductPrandCases.Validators
{
    public class ProductPrandValidaitors: AbstractValidator<productPrandCommand>
    {
        public ProductPrandValidaitors() 
        {
            RuleFor(a => a.Name).NotEmpty();  
        }

    }
}
