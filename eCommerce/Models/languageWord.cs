using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class languageWord
    {
        [Key]
        public int languageWordId { set; get; }
        //word and their translate , unattached with other table
        public string Defaultword { set; get; }
        public string word { set; get; }
        public language Language { set; get; }

    }
}
