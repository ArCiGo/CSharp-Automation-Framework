using Newtonsoft.Json;

namespace Tests.APIAndData.Models
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
