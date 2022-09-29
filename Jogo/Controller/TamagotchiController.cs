using RestSharp;

namespace Tamagotchi
{
  public class TamagotchiController
  {
    private TamagotchiView message;
    private List<PokemonDomain> mascotesAdotados;

    public void Jogar()
    {
      this.mascotesAdotados = new List<PokemonDomain>();
      this.message = new TamagotchiView();
      this.message.BoasVindas();

      int sempre = 1;
      while (sempre == 1)
      {
        this.message.MenuInicial();
        switch (Console.ReadLine())
        {
          case "1":
            MenuDeAdocao();
            break;
          case "2":
            MenuInteracao();
            break;
          case "3":
            System.Environment.Exit(-1);
            break;
          default:
            Console.WriteLine("Opção Inválida!");
            break;
        }
      }
    }

    private void MenuDeAdocao()
    {
      string especieMascote = this.message.MenuAdocao();
      string opcao = this.message.DesejaSaberMais(especieMascote);
      
      RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
      PokemonService service = new PokemonService(client);
      PokemonDomain pokemon = service.BuscarCaracteristicasPorEspecie(especieMascote);

      switch (opcao)
      {
        case "1":
          Console.WriteLine($"----------------------------");
          Console.WriteLine($"Nome: {pokemon.name}");
          Console.WriteLine($"Altura: {pokemon.height}");
          Console.WriteLine($"Largura: {pokemon.weight}");
          break;
        case "2":
          mascotesAdotados.Add(pokemon);
          Console.WriteLine("Mascote Adotado com Sucesso!");
          break;
        case "3":
          this.message.MenuInicial();
          break;
        default:
          Console.WriteLine("Opção Invalida");
          break;
      }
    }

    private void MenuInteracao()
    {
      int indiceMascote = this.message.MenuMascotes(mascotesAdotados);
      this.message.MenuInteracaoMascote(mascotesAdotados, indiceMascote);
      switch (Console.ReadLine())
      {
        case "1":
          bool fome = mascotesAdotados[indiceMascote].VerificarFome();
          if (fome == true)
          {
            Console.WriteLine($"Seu mascote {mascotesAdotados[indiceMascote].name} está com fome");
            Console.WriteLine($"Alimentação: {mascotesAdotados[indiceMascote].alimentacao}");
            Console.WriteLine($"Humor: {mascotesAdotados[indiceMascote].humor}");
            Console.WriteLine($"IMC do Mascote: {mascotesAdotados[indiceMascote].imc}");
          }
          else
          {
            Console.WriteLine($"Seu mascote {mascotesAdotados[indiceMascote].name} está sem fome.");
            Console.WriteLine($"Alimentação: {mascotesAdotados[indiceMascote].alimentacao}");
            Console.WriteLine($"Humor: {mascotesAdotados[indiceMascote].humor}");
            Console.WriteLine($"IMC do Mascote: {mascotesAdotados[indiceMascote].imc}");
          }
          break;
        case "2":
          mascotesAdotados[indiceMascote].AlimentarMascote();
          break;
        case "3":
          mascotesAdotados[indiceMascote].BrincarMascote();
          break;
        default:
          Console.WriteLine("Opção Invalida");
          break;
      }
    }
  }
}