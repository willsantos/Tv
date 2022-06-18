using AppTv.src.Interfaces;

namespace AppTv.src.Classes
{
  public class FilmeRepositorio : IRepositorio<Filme>
  {
    string caminhoArquivo = "filmes.txt";

    public void criaArquivo()
    {

      var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create);
    }
    public void leArquivo()
    {
      using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Open))
      using (var leitor = new StreamReader(fluxoDeArquivo))
      {
        while (!leitor.EndOfStream)
        {
          var linha = leitor.ReadLine();
          var registro = linha.Split(";");

          Filme filme = new Filme(
            id: int.Parse(registro[0].ToString()),
            genero: (Genero)int.Parse(registro[1].ToString()),
            titulo: registro[2].ToString(),
            diretor: registro[3].ToString(),
            descricao: registro[4].ToString(),
            ano: int.Parse(registro[5].ToString())
          );

          listaFilme.Add(filme);

        }
      }
    }

    private List<Filme> listaFilme = new List<Filme>();
    public void Atualiza(int id, Filme entidade)
    {
      listaFilme[id] = entidade;
    }

    public void Exclui(int id)
    {
      listaFilme[id].Excluir();
    }

    public void Insere(Filme entidade)
    {
      listaFilme.Add(entidade);
    }

    public List<Filme> Lista()
    {
      return listaFilme;
    }

    public int ProximoId()
    {
      return listaFilme.Count;
    }

    public Filme RetornaPorId(int id)
    {
      return listaFilme[id];
    }
  }
}