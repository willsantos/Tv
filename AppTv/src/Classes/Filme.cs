using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTv.src.Classes
{
  public class Filme : EntidadeBase
  {


    private Genero Genero { get; set; }
    private string Titulo { get; set; }
    private string Diretor { get; set; }
    private string Descricao { get; set; }
    private int Ano { get; set; }

    public Filme(int id, Genero genero, string titulo, string diretor, string descricao, int ano)
    {
      this.Id = id;
      this.Genero = genero;
      this.Titulo = titulo;
      this.Diretor = diretor;
      this.Descricao = descricao;
      this.Ano = ano;
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