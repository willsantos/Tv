using AppTv.src.Classes;

namespace AppTv.src
{


  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {

      InicializadorFake(3);

      obterOpcaoMainMenu(mainMenu());

      Console.WriteLine("Obrigado por utilizar nossos serviços. Aperte [Enter] para encerrar");
      Console.ReadLine();
    }

    private static string obterOpcaoMainMenu(string opcaoMenu)
    {

      while (opcaoMenu.ToUpper() != "X")
      {
        switch (opcaoMenu)
        {
          case "1":
            obterOpcaoMenuFilmes(filmesMenu());
            break;
          case "2":
            obterOpcaoMenuSeries(seriesMenu());
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

    private static string obterOpcaoMenuFilmes(string opcaoUsuario)
    {

      {
        switch (opcaoUsuario)
        {
          case "1":
            // ListarFilmes();
            break;
          case "2":
            // InserirFilme();
            break;
          case "3":
            // AtualizarFilme();
            break;
          case "4":
            // ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;
          case "X":
            return opcaoUsuario = obterOpcaoMainMenu(mainMenu());

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = obterOpcaoMenuFilmes(filmesMenu());


      }

      return opcaoUsuario;
    }

    private static string obterOpcaoMenuSeries(string opcaoUsuario)
    {

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
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;
          case "X":
            return opcaoUsuario = obterOpcaoMainMenu(mainMenu());

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = obterOpcaoMenuSeries(seriesMenu());


      }

      return opcaoUsuario;
    }


    // Acoes de series

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      System.Console.WriteLine(serie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      
      int entradaGenero = obterGenero();

      Console.Write("Digite o Título da Série: ");
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início da Série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie()
    {
      System.Console.WriteLine("Digite o id da Serie");
      int entradaSerie = int.Parse(Console.ReadLine());

      repositorio.Exclui(entradaSerie);


    }

    private static void InserirSerie()
    {
      System.Console.WriteLine("Inserir nova serie");

      int entradaGenero = obterGenero();

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
        var excluido = serie.retornaExcluido();

        if (!excluido)
        {
          System.Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());

        }
      }
    }

    // FIM Acoes de series


    private static string mainMenu()
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
    private static string seriesMenu()
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



    private static string filmesMenu()
    {
      Console.WriteLine();

      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar Filmes");
      Console.WriteLine("2- Inserir novo filme");
      Console.WriteLine("3- Atualizar filme");
      Console.WriteLine("4- Excluir filme");
      Console.WriteLine("5- Visualizar filme");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    private static int obterGenero()
    {
      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      System.Console.WriteLine("Digite o genero entre as opções acima");
      int entradaGenero = int.Parse(Console.ReadLine());
      return entradaGenero;
    }


    private static void InicializadorFake(int seconds)
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
  }

}