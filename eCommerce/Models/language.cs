using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class language
    {
        [Key]
        public int languageId { set; get; }
        public string nameLanguage { set; get; }
        public ICollection<languageWord> words { set; get; }

    }
}
