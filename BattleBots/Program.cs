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


            Player p;

            System.Media.SoundPlayer Open = new System.Media.SoundPlayer(GameR.Pokemon_Open);
            Open.Play();
            Console.WriteLine("Welcome to Rock Paper Scissors Lizard Spock");
            Console.WriteLine("n/ ...");
            Console.WriteLine("n/Opps, Wrong Program..");
            Console.WriteLine("Welcome to Battle Bots");
            Console.WriteLine("n/ This is a Battle to the Dea... err of the Pokemon ");
            Console.WriteLine("n/ My name is Professor Oak");
            Console.WriteLine("n/ Professor Oak: what is your Name?");
            int Number = 0;
            do
            {

                //...............................STILL IN WORK, DONT USE...................
                string strName = Console.ReadLine();

                if (strName.Trim() == "")
                {
                    p = new Player();
                }
                else
                {
                    p = new Player(strName);


                }
                int NumberAgain = 0;
                do
                {
                    Console.WriteLine("n/ Are you Sure??");
                    string strYesNo = Console.ReadLine();
                    if (strYesNo == "Yes" || strYesNo == "yes")
                    {
                        Number = 1;
                        NumberAgain = 1;
                    }
                    else if (strYesNo == "No" || strYesNo == "no")
                    {
                        Number = 0;
                        NumberAgain = 1;
                    }
                    else
                    {
                        NumberAgain = 0;
                    }
                } while (NumberAgain == 0);
            }
            while (Number == 0);


























            Console.ReadLine();
        }
    }
}
