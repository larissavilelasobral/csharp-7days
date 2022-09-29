using RestSharp;
using Newtonsoft.Json;
using Moq;

namespace Tamagotchi.tests;

public class Tests
{
  public string json;
  public PokemonDomain pokemon;

  [SetUp]
  public void Setup()
  {

    this.pokemon = new PokemonDomain();
    this.pokemon.name = "bulbasaur";
    this.pokemon.height = 7;


    this.json = @"{
    ""abilities"": [
        {
            ""ability"": {
                ""name"": ""overgrow"",
                ""url"": ""https://pokeapi.co/api/v2/ability/65/""
            },
            ""is_hidden"": false,
            ""slot"": 1
        },
        {
            ""ability"": {
                ""name"": ""chlorophyll"",
                ""url"": ""https://pokeapi.co/api/v2/ability/34/""
            },
            ""is_hidden"": true,
            ""slot"": 3
        }
    ],
    ""height"": 7,
    ""is_default"": true,
    ""weight"": 69,
    ""name"": ""bulbasaur""
    }";
  }

  [Test]
  public void StatusCodeTest()
  {
    // arrange
    var responseJson = JsonConvert.DeserializeObject<RestResponse>(json);
    string especie = "bulbasaur";

    var request = new RestRequest($"{especie}",Method.GET);
    var mock = new Mock<RestClient>();

    mock.Setup(x => x.Execute(request)).Returns(new RestResponse(){Content = this.json});
    PokemonService service = new PokemonService(mock.Object);

    // act
    PokemonDomain result = service.BuscarCaracteristicasPorEspecie(especie);

    // assert
    Assert.That(result.name, Is.EqualTo(this.pokemon.name));
  }

}