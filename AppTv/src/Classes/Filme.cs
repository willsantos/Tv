namespace AppTv.src.Classes
{
  public class Filme : EntidadeBase
  {


    public Genero Genero { get; protected set; }
    public string Titulo { get; protected set; }
    public string Diretor { get; protected set; }
    public string Descricao { get; protected set; }
    public int Ano { get; protected set; }

    public Filme(int id, Genero genero, string titulo, string diretor, string descricao, int ano, bool excluido = false)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Diretor = diretor;
      this.Descricao = descricao;
      this.Ano = ano;
      this.Excluido = excluido;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Gênero: " + this.Genero + Environment.NewLine;
      retorno += "Titulo: " + this.Titulo + Environment.NewLine;
      retorno += "Diretor: " + this.Titulo + Environment.NewLine;
      retorno += "Descrição: " + this.Descricao + Environment.NewLine;
      retorno += "Data de Lançamento: " + this.Ano + Environment.NewLine;
      retorno += "Excluido: " + this.Excluido + Environment.NewLine;
      return retorno;
    }

    public string retornaTitulo()
    {
      return this.Titulo;
    }


  }
}