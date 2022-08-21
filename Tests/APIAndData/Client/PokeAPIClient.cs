using RestSharp;

namespace Tests.APIAndData
{
    public class PokeAPIClient
    {
        private readonly RestClient pokeAPIClient = new RestClient("https://pokeapi.co/api/v2");

        public IRestResponse GetPokemon(int pokemonId)
        {
            IRestRequest getPokemonRequest = new RestRequest("/pokemon/" + pokemonId);

            getPokemonRequest.Method = Method.GET;

            IRestResponse createResponse = pokeAPIClient.Execute(getPokemonRequest);

            return createResponse;
        }
    }
}
