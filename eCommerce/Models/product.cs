using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class product
    {
        [Key]
        public int productId { set; get; }
        [StringLength(20, MinimumLength = 2)]
        public string name { set; get; }

        public string description { set; get; }
        public string Sku { set; get; }

        public ICollection<Variant> productVariant { set; get; }


    }
}
