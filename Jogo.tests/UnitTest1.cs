using RestSharp;
using Newtonsoft.Json;
using Moq;

namespace Tamagotchi.tests;

public class Tests
{
  public string json;

  [SetUp]
  public void Setup()
  {
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
    var mock = new Mock<RestClient>();

    var request = new RestRequest($"{especie}",Method.Get);

    mock.Setup(x => x.Execute(request)).Returns(responseJson);

    PokemonService service = new PokemonService(mock);

    // act
    service.BuscarCaracteristicasPorEspecie(especie);

    // assert
    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
  }

}