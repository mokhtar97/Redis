using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("/Redis")]
    public class RedisController : ControllerBase
    {
        private IEasyCachingProvider cachingProvider;
        private IEasyCachingProviderFactory cachingProviderFactory;

        public RedisController(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this.cachingProviderFactory = cachingProviderFactory;
            this.cachingProvider = this.cachingProviderFactory.GetCachingProvider("redis1");
        }

        [HttpGet("Set")]
        public IActionResult SetItemInQueue()
        {
            this.cachingProvider.Set("TestMokhtar2from2to1", "Here is my value22from2to1", TimeSpan.FromDays(100));
           

            return Ok();
        }

        [HttpGet("Get")]
        public IActionResult GetItemInQueue()
        {
            var item = this.cachingProvider.Get<string>("TestKey123");

            return Ok(item);
        }
    }
}