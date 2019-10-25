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
            
            Console.WriteLine("\n ...");
            
            Console.WriteLine("\n  Opps, Wrong Program..");
            
            Console.WriteLine("\n Welcome to Battle Bots");
            
            Console.WriteLine("\n This is a Battle to the Dea... err of the Pokemon ");
            
            Console.WriteLine("\n My name is Professor Oak, Welcome to the World of Pokemon");
            Console.WriteLine("\n Professor Oak: what is your Name?");
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
                    Number = 1;

                }
            }
            while (Number == 0);
            
            Console.WriteLine("\n Please type your Choice of Pokemon:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Pikachu: ## HP");
            Console.WriteLine("\n               ## Damage");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Squirtle: ## HP");
            Console.WriteLine("\n               ## Damage");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Pidgey: ## HP");
            Console.WriteLine("\n               ## Damage");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Geodude: ## HP");
            Console.WriteLine("\n               ## Damage");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Swadloon: ## HP");
            Console.WriteLine("\n               ## Damage");

            string strUserBotChoice = Console.ReadLine();
            //User then Will Choice the "Bot"

            // For Fightinging
            Console.WriteLine("\n Pokemon Name: ## HP");
            Console.WriteLine("\n               ## Damage");

            Console.WriteLine("\n     ----- VS -----   ");
            

            Console.WriteLine("\n Pokemon Name: ## HP");
            Console.WriteLine("\n               ## Damage");

            // for Move Input

            Console.WriteLine("\n Health Left: ##");
            Console.WriteLine("\n Energy Left: ##%");
            Console.WriteLine("\n Next Move: ");



            Console.ReadLine();
        }
    }
}
