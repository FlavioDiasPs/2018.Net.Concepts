using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace UsingMemoryCache.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InMemoryCacheController : Controller
    {
        private IMemoryCache _Cache;
        public InMemoryCacheController(IMemoryCache cache)
        {
            _Cache = cache;                
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("go to id");
        }

        [HttpGet("{cavaloID}")]
        public IActionResult Get(string cavaloID)
        {

            var c1 = _Cache.Get(cavaloID);
            Models.Cavalo c2 = null;
           _Cache.TryGetValue(cavaloID, out c2);


            if (_Cache.TryGetValue<Models.Cavalo>(cavaloID, out Models.Cavalo cavalo))            
                return new JsonResult(cavalo);
            else
                return new NotFoundObjectResult($"The Key: {cavaloID} does not exists."); 
        }
        

        [HttpPost]
        public IActionResult Post([FromBody] Models.Cavalo cavalo)
        {
            if (ModelState.IsValid && cavalo != null)
            {
                if (_Cache.TryGetValue("Cavaliiinho", out Models.Cavalo tryCavalo))                
                    return StatusCode(409, cavalo);
                
                var cacheExpirationOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = System.TimeSpan.FromSeconds(5),
                    //AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                    Priority = CacheItemPriority.Normal
                };

                _Cache.Set<Models.Cavalo>("Cavaliiinho", cavalo, cacheExpirationOptions);


                
                _Cache.CreateEntry("Cavaliiinho").SetValue(cavalo);
                var c1 = _Cache.Get("Cavaliiinho");

                return Created("Cavaliiinho", "Sua cavala!");
            }
            else
                return BadRequest("Deu não");
        }

    }
}
