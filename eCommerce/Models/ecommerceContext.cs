using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class ecommerceContext : DbContext
    {
        public ecommerceContext(DbContextOptions<ecommerceContext> options) : base(options)
        {

        }

        public DbSet<product> Products { set; get; }
        public DbSet<Variant> Variants { set; get; }
        public DbSet<variantValue> VariantValues { set; get; }
        public DbSet<language> Languages { set; get; }
        public DbSet<languageWord> LanguageWords { set; get; }

    }
}
