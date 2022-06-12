using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTv.src
{
  public class EntidadeBase
  {
    public int Id { get; protected set; }
    public bool Excluido { get; protected set; }


    public int retornaId()
    {
      return this.Id;
    }
    public void Excluir()
    {
      this.Excluido = true;
    }

    public bool retornaExcluido()
    {
      return this.Excluido;
    }
  }
}