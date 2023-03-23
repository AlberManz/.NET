using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49_Interfaces
{
  internal class Coche : IVehiculo
  {
    public int gasolina { get; set; }

    public Coche(int gasolina)
    {
      this.gasolina = gasolina;
    }

    public void Conducir()
    {
      if (gasolina == 0)
      {
        Console.WriteLine("Tienes que repostar");
      }
      else
      {
        Console.WriteLine("Conduciendo");
      }
    }

    public bool Repostar(int cantGas)
    {
      if (cantGas <= 0)
      {
        return false;
      }
      this.gasolina += cantGas;
      return true;
    }
  }
}

