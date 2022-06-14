using AppTv.src.Classes;

namespace AppTv.src.Helper
{
  public static class SeriesMenu
  {
    static SerieRepositorio seriesRepositorio = new SerieRepositorio();

    public static string mostrarMenu()
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

    public static string obterOpcao(string opcaoUsuario)
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
            return opcaoUsuario = MainMenu.obterOpcao(MainMenu.mostrarMenu());

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = obterOpcao(mostrarMenu());


      }

      return opcaoUsuario;
    }

    private static void ListarSeries()
    {
      System.Console.WriteLine("Lista de series");
      var lista = seriesRepositorio.Lista();

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

    private static void InserirSerie()
    {
      System.Console.WriteLine("Inserir nova serie");

      int entradaGenero = Utils.obterGenero();

      System.Console.WriteLine("Digite o Titulo da Serie");
      string entradaTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o ano da serie");
      int entradaAno = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite a descricao da Serie");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(id: seriesRepositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

      seriesRepositorio.Insere(novaSerie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());


      int entradaGenero = Utils.obterGenero();

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

      seriesRepositorio.Atualiza(indiceSerie, atualizaSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = seriesRepositorio.RetornaPorId(indiceSerie);

      System.Console.WriteLine(serie);
    }

    private static void ExcluirSerie()
    {
      System.Console.WriteLine("Digite o id da Serie");
      int entradaSerie = int.Parse(Console.ReadLine());

      bool opcaoExcluir = Utils.Excluir();

      if (opcaoExcluir != false)
      {
        seriesRepositorio.Exclui(entradaSerie);
        System.Console.WriteLine("Serie Excluida com sucesso");
      }


    }


  }
}