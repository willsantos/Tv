
using AppTv.src.Helper;

namespace AppTv.src
{


  class Program
  {
    
    static void Main(string[] args)
    {

      Utils.InicializadorFake(3);

      MainMenu.obterOpcao(MainMenu.mostrarMenu());

      Console.WriteLine("Obrigado por utilizar nossos serviços. Aperte [Enter] para encerrar");
      Console.ReadLine();
    }

    
  }

}