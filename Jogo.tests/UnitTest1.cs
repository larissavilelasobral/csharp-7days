using RestSharp;
using Newtonsoft.Json;
using System;
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
    string especie = "bulbasaur";

    var data = JsonConvert.DeserializeObject<RestResponse>(json);
    var response =  new Mock<IRestResponse>();
    response.Setup(_ => _.StatusCode).Returns(System.Net.HttpStatusCode.OK);
    response.Setup(_ => _.Content).Returns(json);

    var request = new RestRequest($"{especie}",Method.GET);
    var mock = new Mock<RestClient>();

    mock.Setup(x => x.Execute<RestRequest>It.IsAny<IRestResponse>()).Returns(response.Object);
    PokemonService service = new PokemonService(mock.Object);

    // act
    PokemonDomain result = service.BuscarCaracteristicasPorEspecie(especie);

    // assert
    Assert.That(result.name, Is.EqualTo(this.pokemon.name));
  }

  //https://gist.github.com/mrstebo/3636d3f86a4fe8e27205f2c4a0065f27
  //https://github.com/search?q=new+Mock%3CIRestClient%3E%28%29&type=code
  //https://github.com/pkonkle213/phillipkonkle-c-sharp-material/blob/99282389b50088ba617960281e84f8a1bef76d36/module-2/12_HTTP_Web_Services_POST/student-exercise/dotnet/AuctionApp.Tests/APIServiceTests.cs
  //https://github.com/Ababington/Tech-Elevator-Module-1-3/blob/4bfca851cf42efef89122c140ffaa8ca856e8053/module-2/13_HTTP_Post/student-exercise/AuctionApp.Tests/APIServiceTests.cs
  //
}