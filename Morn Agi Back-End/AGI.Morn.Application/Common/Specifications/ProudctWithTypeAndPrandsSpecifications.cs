using AGI.Morn.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.Common.Specifications
{
    public class ProudctWithTypeAndPrandsSpecifications : Specifications<Product>
    {
        public ProudctWithTypeAndPrandsSpecifications(ProductSpecPrams prams)
            :base(x=>(!prams.TypeId.HasValue || x.ProductTypeId== prams.TypeId) && (prams.BrandId.HasValue || x.ProudctPrandId== prams.BrandId))
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.ProductPrand);
            ApplyPagination(prams.pageSize * (prams.PageIndex - 1), prams.pageSize);
            if (!string.IsNullOrEmpty(prams.Sort))
            {
                switch (prams.Sort)
                { 
                    case "priceAsc":
                        AddOrderby(o => o.Price);
                        break;

                    case "priceDesc":
                        AddOrderbyDesc(o => o.Price);
                        break;

                    default:
                        AddOrderby(o => o.Name);
                        break;
                }
            }

        }
    }
}
