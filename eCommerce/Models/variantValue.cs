using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class variantValue
    {
        [Key]
        public int variantValueId { set; get; }
        [StringLength(20, MinimumLength = 2)]
        public string value { set; get; }
        public virtual Variant variant { set; get; }

    }
}
