using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGI.Morn.Application.UseCases.ProudctCase.DTO
{
    public class ProudctDto 
    {
        public int Id { get; set; } 
        public string Name { set; get; }
        public string Description { set; get; }

        public decimal Price { set; get; }

        public string PictureUrl { set; get; }

        public string productType { set; get; }
        public string ProductPrand { set; get; }
    }
}
