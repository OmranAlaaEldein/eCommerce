using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private ecommerceContext _ecommerceContext;

        public LanguageController(ecommerceContext ecommerce)
        {
            _ecommerceContext = ecommerce;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var res = _ecommerceContext.Languages;
            return new JsonResult(res);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var res = _ecommerceContext.Languages.FirstOrDefault(s => s.languageId == id);
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult Post([FromBody] language value)
        {
            try
            {
                _ecommerceContext.Languages.Add(value);
                _ecommerceContext.SaveChanges();
                return new JsonResult("success");

            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] language value)
        {
            try
            {
                var myLanguages = _ecommerceContext.Languages.FirstOrDefault(s => s.languageId == id);
                if (myLanguages != null)
                {
                    _ecommerceContext.Entry<language>(myLanguages).CurrentValues.SetValues(value);
                    _ecommerceContext.SaveChanges();
                    return new JsonResult("success");
                }
                return new JsonResult("Not found");
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                var myLanguages = _ecommerceContext.Languages.FirstOrDefault(s => s.languageId == id);
                if (myLanguages != null)
                {
                    _ecommerceContext.Languages.Remove(myLanguages);
                    _ecommerceContext.SaveChanges();
                    return new JsonResult("success");
                }
                return new JsonResult("not found");
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

    }
}
