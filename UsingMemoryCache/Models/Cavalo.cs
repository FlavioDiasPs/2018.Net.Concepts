using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UsingMemoryCache.Models
{
   
    public class Cavalo
    {
        [JsonProperty("Nome")]
        public string Name { get; set; }

        [JsonProperty("Idade")]
        public int Age { get; set; }

        [JsonProperty("Peso")]
        public double Weight { get; set; }
    }
}
