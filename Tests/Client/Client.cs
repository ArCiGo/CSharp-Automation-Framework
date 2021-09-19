using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Client
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
