using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp5
{ 
  public class Program
  {
        public static void Main(string[] args)
        {
            Console.WriteLine("#Your Total Score of  game#");
            //hear "X"= strike  "/"= Spare 
            var game = new TenPinGame("X|7/|9-|X|-8|8/|-6|X|9-|X||89");
            Console.WriteLine("Total Score: " + game.Score());
            Console.WriteLine("#ThankYou");
            Console.Read();
        }

    
    
  }
}