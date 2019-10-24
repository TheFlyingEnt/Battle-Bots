using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Media;

namespace BattleBots
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starting Sound (Welcome to BATTLE BOTS) 




            System.Media.SoundPlayer player4 = new System.Media.SoundPlayer(GameR.Pokemon_Open);
            player4.Play();
            Console.WriteLine("Welcome to Battle Bots");
            
            



























            Console.ReadLine();
        }
    }
}
