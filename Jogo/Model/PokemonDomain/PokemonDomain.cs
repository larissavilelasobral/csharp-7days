namespace Tamagotchi
{
  public class PokemonDomain
  {
    public List<AbilitiesDomain> abilities { get; set; }
    public double height { get; set; }
    public double weight { get; set; }
    public string name { get; set; }

    public int alimentacao { get; set; }
    public int humor { get; set; }
    public double imc { get; set; }


    public void BrincarMascote()
    {
      this.humor++;
      this.alimentacao--;
    }

    public void AlimentarMascote()
    {
      this.alimentacao++;
    }

    public bool VerificarFome()
    {
      return this.alimentacao < 1;
    }
  }
}