﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsingMemoryCache.Controllers
{
    [Produces("application/json")]
    [Route("api/SqlServerCache")]
    public class SqlServerCacheController : Controller
    {
    }
}