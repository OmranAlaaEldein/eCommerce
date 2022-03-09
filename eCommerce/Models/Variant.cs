using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Variant
    {
        [Key]
        public int VariantId { set; get; }

        [StringLength(20, MinimumLength = 2)]
        public string name { set; get; }

        public virtual ICollection<product> productVariant { set; get; }
        public ICollection<variantValue> Values { set; get; }


    }
}
