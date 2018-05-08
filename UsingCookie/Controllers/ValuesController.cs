using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UsingCookie.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {                    
            var cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["key"];
            var cookieValueFromReq = GetCookieByKey("key");
            
            return String.Join(", ", Request.Cookies.Keys) + "\n\ncookieValueFromContext: " + cookieValueFromContext + "  |  cookieValueFromReq: " + cookieValueFromReq 
                + "\n\n" + 
                "cookieValueFromContext2: " + cookieValueFromContext + "  |  cookieValueFromReq2: " + cookieValueFromReq;
        }

        [HttpGet("/api/[controller]/set/{key}")]
        public IActionResult Set(string key)
        {
            SetCookieInfo(key, "Hello from cookie", 1);
            //SetCookieInfo("key2", "How will it appear?", 2);
            return RedirectToAction("Get", "Values");
        }



        [HttpGet("/api/[controller]/delete/{key}")]
        public IActionResult Delete(string key)
        {
            RemoveCookieByKey(key);

            return RedirectToAction("Get", "Values");
        }





        public string GetCookieByKey(string key)
        {
            return Request.Cookies[key];
        }
        public void RemoveCookieByKey(string key)
        {
            //foreach (var cookie in Request.Cookies.Keys)
            //{
            //    Response.Cookies.Delete(cookie);
            //}

            Response.Cookies.Delete(key);
        }

        public void SetCookieInfo(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            //option.Path = @"\";
            //option.Domain = @"http://localhost:53256";

            if (expireTime.HasValue) option.Expires = DateTime.Now.AddMinutes(expireTime.Value);                            
            else option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
 
       
    }
}
