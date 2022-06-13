using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTv.src.Helper
{
  public static class MainMenu
  {
    public static string mostrarMenu()
    {
      Console.WriteLine();

      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Acessar coleção de Filmes");
      Console.WriteLine("2- Acessar coleção de Series");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    public static string obterOpcao(string opcaoMenu)
    {

      while (opcaoMenu.ToUpper() != "X")
      {
        switch (opcaoMenu)
        {
          case "1":
            FilmeMenu.obterOpcao(FilmeMenu.mostrarMenu());
            break;
          case "2":
            SeriesMenu.obterOpcao(SeriesMenu.mostrarMenu());
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();

        }

        return opcaoMenu;
      }
      return opcaoMenu;
    }


  }
}