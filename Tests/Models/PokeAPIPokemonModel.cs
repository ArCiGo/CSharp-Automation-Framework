using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Models
{
    public class PokeAPIPokemonModel
    {
        [JsonProperty("abilities")]
        public dynamic? Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("forms")]
        public dynamic? Forms { get; set; }
    }
}
