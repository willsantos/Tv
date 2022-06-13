using AppTv.src.Classes;


namespace AppTv.src.Helper
{
  public static class FilmeMenu
  {
    static FilmeRepositorio filmesRepositorio = new FilmeRepositorio();
    public static string mostrarMenu()
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

    public static string obterOpcao(string opcaoUsuario)
    {

      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;
          case "X":
            return opcaoUsuario = MainMenu.obterOpcao(MainMenu.mostrarMenu());

          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = FilmeMenu.obterOpcao(FilmeMenu.mostrarMenu());


      }

      return opcaoUsuario;
    }

    private static void ListarFilmes()
    {
      System.Console.WriteLine("Lista de filmes");
      var lista = filmesRepositorio.Lista();

      if (lista.Count == 0)
      {
        System.Console.WriteLine("Nenhum Filme cadastrado");
        return;
      }

      foreach (var filme in lista)
      {
        var excluido = filme.retornaExcluido();

        if (!excluido)
        {
          System.Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());

        }
      }
    }

    private static void InserirFilme()
    {
      System.Console.WriteLine("Inserir novo filme");

      int entradaGenero = Utils.obterGenero();

      System.Console.WriteLine("Digite o Titulo do filme");
      string entradaTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o Diretor do filme");
      string entradaDiretor = Console.ReadLine();

      System.Console.WriteLine("Digite o ano de lançamento do filme");
      int entradaAno = int.Parse(Console.ReadLine());

      System.Console.WriteLine("Digite a descricao do filme");
      string entradaDescricao = Console.ReadLine();

      Filme novoFilme = new Filme(id: filmesRepositorio.ProximoId(),
                                  genero: (Genero)entradaGenero,
                                  titulo: entradaTitulo,
                                  diretor: entradaDiretor,
                                  ano: entradaAno,
                                  descricao: entradaDescricao);

      filmesRepositorio.Insere(novoFilme);
    }

    private static void AtualizarFilme()
    {
      Console.Write("Digite o id do Filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      int entradaGenero = Utils.obterGenero();

      Console.Write("Digite o Título do Filme: ");
      string entradaTitulo = Console.ReadLine();

      System.Console.WriteLine("Digite o Diretor do filme");
      string entradaDiretor = Console.ReadLine();

      Console.Write("Digite o Ano de Início do Filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição do Filme: ");
      string entradaDescricao = Console.ReadLine();

      Filme atualizaFilme = new Filme(id: indiceFilme,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    diretor: entradaDiretor,
                    ano: entradaAno,
                    descricao: entradaDescricao);

      filmesRepositorio.Atualiza(indiceFilme, atualizaFilme);
    }

    private static void VisualizarFilme()
    {
      Console.Write("Digite o id do Filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      var Filme = filmesRepositorio.RetornaPorId(indiceFilme);

      System.Console.WriteLine(Filme);
    }

    private static void ExcluirFilme()
    {
      System.Console.WriteLine("Digite o id do Filme");
      int entradaFilme = int.Parse(Console.ReadLine());

      filmesRepositorio.Exclui(entradaFilme);
    }


  }
}