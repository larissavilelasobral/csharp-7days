using RestSharp;
using System.Text.Json;

namespace Tamagotchi
{
  public static class PokemonService
  {
    public static PokemonDomain BuscarCaracteristicasPorEspecie(string especie)
    {
      var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie}");
      var request = new RestRequest("",Method.Get);
      RestResponse response = client.Execute(request);
      
      if (response.StatusCode != System.Net.HttpStatusCode.OK)
      {
        Console.WriteLine("Error: " + response.ErrorMessage);
      }

      // usar lib para response

      var result = response.Content;
      PokemonAPI pokemon = JsonSerializer.Deserialize<PokemonAPI>(result);
      
      return PokemonDTO.MapPokemonApiToPokemonDomain(pokemon);
    }
  }
}