using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.Common.Specifications
{
    public class ProductSpecPrams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _PageSize { get; set;} = 6;

        public int pageSize
        {
            get => _PageSize; 
            set => _PageSize = (value>MaxPageSize) ? MaxPageSize : value ;
        }
        public int ? BrandId { get; set; }
        public int ? TypeId { get;set; }

        public string Sort {  get; set; } 
    }
}
