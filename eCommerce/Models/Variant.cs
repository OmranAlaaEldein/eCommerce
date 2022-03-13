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
        public string size { set; get; }
        public string color { set; get; }
        public string model { set; get; }
        public string matrial { set; get; }
        public  virtual product myProduct { set; get; }


    }
}
