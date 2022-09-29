using RestSharp;
using System.Text.Json;

namespace Tamagotchi
{
  public class PokemonService
  {
    public RestClient client;

    public PokemonService(IRestClient client)
    {
      this.client = client;
    }
    
    public PokemonDomain BuscarCaracteristicasPorEspecie(string especie)
    {
      var request = new RestRequest($"{especie}",Method.Get);

      RestResponse response = this.client.Execute(request);
      
      if (response.StatusCode != System.Net.HttpStatusCode.OK)
      {
        Console.WriteLine("Error: " + response.ErrorMessage);
      }

      var result = response.Content;
      PokemonAPI pokemon = JsonSerializer.Deserialize<PokemonAPI>(result);
      
      return PokemonDTO.MapPokemonApiToPokemonDomain(pokemon);
    }
  }
}