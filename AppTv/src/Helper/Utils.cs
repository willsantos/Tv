namespace AppTv.src.Helper
{
  public class Utils
  {
    public static int obterGenero()
    {
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      System.Console.WriteLine("Digite o genero entre as opções acima");
      int entradaGenero = int.Parse(Console.ReadLine());
      return entradaGenero;
    }

    public static void InicializadorFake(int seconds)
    {
      Console.WriteLine();
      Console.Write("Iniciando AppTV");


      for (int i = 0; i < seconds; i++)
      {
        Thread.Sleep(1000);
        System.Console.Write(".");
      }


      System.Console.WriteLine("");
      System.Console.WriteLine("");
    }

    public static bool Excluir()
    {
      System.Console.WriteLine("Deseja realmente excluir? (S/N)");
      string entradaExcluir = Console.ReadLine();

      bool opcaoExcluir = false;

      switch (entradaExcluir.ToUpper())
      {
        case "S" or "Y":
          opcaoExcluir = true;
          break;
        case "N":
          opcaoExcluir = false;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      return opcaoExcluir;
    }
  }
}