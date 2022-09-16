namespace Tamagotchi
{
  public class TamagotchiView
  {
    private string NomeJogador { get; set; }

    public void BoasVindas()
    {
      Console.WriteLine("Bem Vindo(a)!");
      Console.WriteLine("Qual é seu nome?");
      NomeJogador = Console.ReadLine();
    }

    public void MenuInicial()
    {
      Console.WriteLine("\n--------------------------- MENU ---------------------------");
      Console.WriteLine($"{NomeJogador} você deseja:");
      Console.WriteLine("1 - Adotar um mascote virtual");
      Console.WriteLine("2 - Ver seus mascotes");
      Console.WriteLine("3 - Sair");
    }

    public string MenuAdocao()
    {
      Console.WriteLine("\n--------------------- ADOTAR UM MASCOTE ---------------------");
      Console.WriteLine($"{NomeJogador} escolha uma espécie:");
      Console.WriteLine("\n 1 - BULBASAUR \n 2 - CHARMANDER \n 3 - CHARIZARD");

      switch (Console.ReadLine())
      {
        case "1":
          return "bulbasaur";
        case "2":
          return "charmander";
        case "3":
          return "charizard";
        default:
          Console.WriteLine("Opção Invalida!");
          return "error";
      }
    }

    public string DesejaSaberMais(string especie)
    {
      Console.WriteLine("\n-------------------------------------------------------------");
      Console.WriteLine($"{NomeJogador} você deseja:");
      Console.WriteLine($"1 - Saber mais sobre o {especie}");
      Console.WriteLine($"2 - ADOTAR {especie}");
      Console.WriteLine($"3 - VOLTAR");

      return Console.ReadLine();
    }

    public int MenuMascotes(List<PokemonDomain> mascotesAdotados)
    {
      Console.WriteLine("\n-------------------------------------------------------------");
      Console.WriteLine($"Você possui {mascotesAdotados.Count} mascote adotados.");
      if (mascotesAdotados.Count > 0)
      {
        Console.WriteLine("Os mascotes adotados são: ");
        int index = 0;
        foreach (PokemonDomain mascote in mascotesAdotados)
        {
          Console.WriteLine($"{index} - {mascote.name}");
          index++;
        }
      }

      Console.WriteLine("Qual mascote você deseja interagir?");
      return Convert.ToInt32(Console.ReadLine());
    }

    public void MenuInteracaoMascote(List<PokemonDomain> mascotesAdotados, int indiceMascote)
    {
      Console.WriteLine("\n-------------------------------------------------------------");
      Console.WriteLine($"{NomeJogador} você deseja:");
      Console.WriteLine($"1 - SABER COMO {mascotesAdotados[indiceMascote].name} ESTÁ");
      Console.WriteLine($"2 - ALIMENTAR O {mascotesAdotados[indiceMascote].name}");
      Console.WriteLine($"3 - BRINCAR COM {mascotesAdotados[indiceMascote].name} ");
      Console.WriteLine($"4 - VOLTAR");
    }
  }
}