using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHCPSzimulacio
{
  class Program
  {
    static List<string> excluded = new List<string>();

    static void BeolvasExclude()
    {
      try
      {
        StreamReader file = new StreamReader("excluded.csv");

        try
        {
          while (!file.EndOfStream)
          {
            excluded.Add(file.ReadLine());
          }
        }
        catch (Exception exception)
        {
          Console.WriteLine(exception.Message);
        }
        finally
        {
          file.Close();
        }

        file.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    static string CimEggyelNo(string cim)
    {
      string[] adatok = cim.Split('.');
      int okt4 = Convert.ToInt32(adatok[3]);
      if (okt4 < 255)
      {
        okt4++;
      }

      return adatok[0] + "." + 
             adatok[1] + "." + 
             adatok[2] + "." + 
             okt4.ToString();
    }

    static void Main(string[] args)
    {
      BeolvasExclude();

      //foreach (var e in excluded)
      //{
      //  Console.WriteLine(e);
      //}

      Console.WriteLine("\nVége...");
      Console.ReadLine();
    }
  }
}
