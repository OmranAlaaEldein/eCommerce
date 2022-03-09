using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ecommerceContext _ecommerceContext;

        public ProductsController(ecommerceContext ecommerce)
        {
            _ecommerceContext = ecommerce;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var res= _ecommerceContext.Products.Include(x=>x.productVariant).ThenInclude(x=>x.Values).ToList();
            return new JsonResult(res);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var res= _ecommerceContext.Products.Include(x => x.productVariant).ThenInclude(x => x.Values).FirstOrDefault(s => s.productId == id);
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult Post([FromBody] product value)
        {
            try
            {
                _ecommerceContext.Products.Add(value);
                _ecommerceContext.SaveChanges();
                return new JsonResult(Ok("Success"));
            }
            catch (Exception) {
                return new JsonResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] product value)
        {
            try
            {
                var myProduct = _ecommerceContext.Products.FirstOrDefault(s => s.productId == id);
                if (myProduct != null)
                {
                    _ecommerceContext.Entry<product>(myProduct).CurrentValues.SetValues(value);
                    foreach (var Variant in value.productVariant)
                    {
                        _ecommerceContext.Entry(Variant).State = Variant.VariantId == 0 ? EntityState.Added : EntityState.Modified;
                        foreach (var VariantValue in Variant.Values)
                        {
                            _ecommerceContext.Entry(VariantValue).State = VariantValue.variantValueId == 0 ? EntityState.Added : EntityState.Modified;
                        }
                    }
                    _ecommerceContext.SaveChanges();
                    return new JsonResult(Ok("Success"));
                }
                return new JsonResult(NotFound());
            }
            catch (Exception)
            {
                return new JsonResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var myProduct = _ecommerceContext.Products.FirstOrDefault(s => s.productId == id);
                if (myProduct != null)
                {
                    
                    _ecommerceContext.Products.Remove(myProduct);
                    _ecommerceContext.SaveChanges();

                    var VariantValues = _ecommerceContext.VariantValues.Include(x=>x.variant).ToList();
                    foreach (var VariantValue in VariantValues)
                        if (VariantValue.variant==null)
                            _ecommerceContext.VariantValues.Remove(VariantValue);
                    _ecommerceContext.SaveChanges();
                    
                    return new JsonResult(Ok("Success"));
                }
                return new JsonResult(NotFound());
            }
            catch (Exception)
            {
                return new JsonResult(System.Net.HttpStatusCode.InternalServerError);
            }
        }

    }
}
