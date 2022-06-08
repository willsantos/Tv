namespace AppTv.src
{


  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {

      string opcaoUsuario = ObterOpcaoUsuario();



      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSeries();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            // AtualizarSerie();
            break;
          case "4":
            // ExcluirSerie();
            break;
          case "5":
            // VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario();
      }

      Console.WriteLine("Obrigado por utilizar nossos serviços. Aperte [Enter] para encerrar");
      Console.ReadLine();
    }

    private static void InserirSerie()
    {
      System.Console.WriteLine("Inserir nova serie");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      System.Console.WriteLine("Digite o genero entre as opções acima");
      int entradaGenero = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite o Titulo da Serie");
      string entradaTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o ano da serie");
      int entradaAno = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite a descricao da Serie");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

      repositorio.Insere(novaSerie);
    }

    private static void ListarSeries()
    {
      System.Console.WriteLine("Lista de series");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        System.Console.WriteLine("Nenhuma Serie cadastrada");
        return;
      }

      foreach (var serie in lista)
      {
        System.Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
      }
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();

      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
    }
  }

}