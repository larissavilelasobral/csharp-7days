namespace Tamagotchi.tests;

public class Tests
{
    private PokemonService _service;

    [SetUp]
    public void Setup()
    {
        _service = new PokemonService();
    }

    [Test]
    public void TestRetornoAPI()
    {
        string especie = "bulbasaur";
        //lib?
        _service.BuscarCaracteristicasPorEspecie(especie);
        // https://www.newtonsoft.com/json/help/html/deserializeobject.htm

        //var result = response.Content;
        //PokemonAPI pokemon = JsonSerializer.Deserialize<PokemonAPI>(result);
        Assert.Pass();
    }

    [Test]
    public void TestRetornoAPI()
    {
        
    }
}