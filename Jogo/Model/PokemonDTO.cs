namespace Tamagotchi
{
  public class PokemonDTO
  {
    public static PokemonDomain MapPokemonApiToPokemonDomain(PokemonAPI pokemon)
    {
      
      PokemonDomain pokemonDomain = new();
      pokemonDomain.name = pokemon.name;
      pokemonDomain.height = pokemon.height;
      pokemonDomain.weight = pokemon.weight;
      pokemonDomain.abilities = MapAbilitiesApiToAbilitiesDomain(pokemon.abilities);

      pokemonDomain.alimentacao = 0;
      pokemonDomain.humor = 0;
      pokemonDomain.imc = CalcularImcPokemon(pokemon.height, pokemon.weight);

      return pokemonDomain;
    }

    public static List<AbilitiesDomain> MapAbilitiesApiToAbilitiesDomain(List<Abilities> abilities)
    {
      List<AbilitiesDomain> listaAbilitiesDomain = new List<AbilitiesDomain>();
      foreach (Abilities item in abilities)
      {
        AbilitiesDomain abDomain = new AbilitiesDomain();
        abDomain.is_hidden = item.is_hidden;
        abDomain.ability = MapAbilityApiToAbilityDomain(item.ability);
        
        listaAbilitiesDomain.Add(abDomain);
      }

      return listaAbilitiesDomain;
    }

    public static AbilityDomain MapAbilityApiToAbilityDomain(Ability ability)
    {
      AbilityDomain abilityDomain = new AbilityDomain();
      abilityDomain.name = ability.name;
      abilityDomain.url = ability.url;

      return abilityDomain;
    }
    
    public static double CalcularImcPokemon(double height, double weight)
    {
      double quadradoDaAltura = height * height;
      double imc = weight / quadradoDaAltura;

      return imc;
    }
  }
}
