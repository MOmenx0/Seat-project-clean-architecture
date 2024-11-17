using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Domain.Entities
{
    public class Product : BaseEntitys
    {
        public string Name { set; get; }
        public string Description  { set; get; }

        public decimal Price { set; get; }

        public string PictureUrl { set; get; }

        public productTypes productType {set ;get;}
        public int ProductTypeId { set; get; }
        public productPrand ProductPrand { set; get; }
        public int ProudctPrandId { set; get; }
       
    }
}
