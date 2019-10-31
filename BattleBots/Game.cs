
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.Timers;

namespace BattleBots
{


    public class Game
    {
        public const string WEAPON_CIRCULAR_SAW = "Pikachu";
        public const string WEAPON_CLAW_CUTTER = "Squirtle";
        public const string WEAPON_FLAME_THROWER = "Charmander";
        public const string WEAPON_SLEDGE_HAMMER = "Geodude";
        public const string WEAPON_SPINNNING_BLADE = "Bulbasaur";





        public static string[] WEAPONS = new string[] { WEAPON_CIRCULAR_SAW, WEAPON_CLAW_CUTTER, WEAPON_FLAME_THROWER, WEAPON_SLEDGE_HAMMER, WEAPON_SPINNNING_BLADE };
        public static ConsoleColor[] WEAPON_COLORS = new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.DarkRed, ConsoleColor.Gray, ConsoleColor.Green };
        public static string[] WEAPON_TYPES = new string[] { "Electric", "Water", "Flying", "Rock/Ground", "Grass" };


        private static ConsoleKey[] KONAMI_CODE = new ConsoleKey[] { ConsoleKey.UpArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.DownArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.B, ConsoleKey.A };
        private System.Timers.Timer timer;
        private Random rGen = new Random();
        private int intTimeSinceGameStart;
        private int intBattleStartTime;
        private int intTimeElapsed;

        System.Media.SoundPlayer OpenSFX = new System.Media.SoundPlayer(GameR.Pokemon_Open);
        System.Media.SoundPlayer BattleSFX = new System.Media.SoundPlayer(GameR.Pokemon_Battle);
        System.Media.SoundPlayer MeetOakSFX = new System.Media.SoundPlayer(GameR.Pokemon_MeetingOak);
        System.Media.SoundPlayer PokeBallOpenSFX = new System.Media.SoundPlayer(GameR.PokeBall);

        static System.Media.SoundPlayer pikachuSound = new System.Media.SoundPlayer(GameR.Thunderbolt_Pikachu);
        static System.Media.SoundPlayer bulbasaurSound = new System.Media.SoundPlayer(GameR.VineWhip_Bluba);
        static System.Media.SoundPlayer geodudeSound = new System.Media.SoundPlayer(GameR.RockTomb_GeoDude);
        static System.Media.SoundPlayer charamanderSound = new System.Media.SoundPlayer(GameR.Flamethrower_Charmader);
        static System.Media.SoundPlayer squirtleSound = new System.Media.SoundPlayer(GameR.BubbleBeam_Squart);


        
        


        private bool blnIsBattleSoundPlaying = false;

        public Game()
        {
            timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            intTimeSinceGameStart++;
            intTimeElapsed = intTimeSinceGameStart - intBattleStartTime;
        }

        public BattleBot PromptUserForBot()
        {
            OpenSFX.Play();
            // Plays Sound
            Console.WriteLine("\n Version 42.069");
            Console.WriteLine("\n Copyright (©) The Pokemon Company 2019");
            Console.WriteLine("\n Copyright (©) Nintendo 2019");
            Console.WriteLine("\n Copyright (©) MrLettsGiveUseAnA.Inc 2019\n");

            Console.WriteLine("Do you want to enable the reading out of all the text?");
            if (Console.ReadLine().Trim().ToLower()[0] != 'y')
            {
                SpeakingConsole.EnableSpeaking = false;
            }
            OpenSFX.Stop();
            MeetOakSFX.PlayLooping();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            SpeakingConsole.WriteLine("Welcome to Rock Paper Scissors Lizard Spock");
            Console.WriteLine("\n Press Enter...");
            Console.ReadLine();

            Console.WriteLine("\n ...");
            Console.ReadLine();
            SpeakingConsole.WriteLine("\n  Opps, Wrong Program..");
            Console.ReadLine();
            SpeakingConsole.WriteLine("\n Welcome to Battle Bots");
            Console.ReadLine();
            SpeakingConsole.WriteLine("\n This is a Battle to the Dea... err of the Pokemon ");
            Console.ReadLine();
            SpeakingConsole.WriteLine("\n My name is Professor Oak, Welcome to the World of Pokemon");
            Console.ReadLine();
            Console.WriteLine("\n This world is inhabited by creatures called pokémon!");
            Console.WriteLine("\n For some people, pokémon are pets. Others use them for fights.");
            Console.WriteLine("\n Myself...I study pokémon as a profession.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            SpeakingConsole.WriteLine("\n Professor Oak: what is your Name?");

            string strName = SpeakingConsole.ReadLine();
            SpeakingConsole.WriteLine("\n Please choose a Pokemon:");

            //foreach (string weapon in WEAPONS)
            //{
            //string[] beatableWeapons = Array.FindAll(WEAPONS, w => CanBeat(weapon, w));
            //SpeakingConsole.WriteLine("\n" + weapon + " Beats " + String.Join(" And ", beatableWeapons));
            //}

            ///////////////////////////////////////////////////////////////////////
            //Console.WriteLine("\n Please type your Choice of Pokemon:");
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("\n Pikachu: Electric");
            //Console.WriteLine("\n     Strengths: Squirtle and Pidgey");
            //Console.WriteLine("\n     Weekness: Geodude and Swadloon");

            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("\n Squirtle: Water");
            //Console.WriteLine("\n     Strengths: Swadloon and Geodude");
            //Console.WriteLine("\n     Weekness: Pickachu and Pidgey");

            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("\n Charmander: Fire");
            //Console.WriteLine("\n     Strengths: Squirtle and Swadloon");
            //Console.WriteLine("\n     Weekness: Pickachu and Geodude");

            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine("\n Geodude: Rock/Ground");
            //Console.WriteLine("\n     Strengths: Pikachu and Pidgey");
            //Console.WriteLine("\n     Weekness: Swadloon and Squirtle");

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("\n Bulbasaur: Grass");
            //Console.WriteLine("\n     Strengths: Geodude and Pikachu");
            //Console.WriteLine("\n     Weekness: Squirtle and Pidgey");

            SpeakingConsole.WriteLine("\nPlease choose a Pokemon from the following:");

            foreach (string weapon in WEAPONS)
            {
                string[] beatableWeapons = Array.FindAll(WEAPONS, w => CanBeat(weapon, w));
                string[] unbeatableWeapons = Array.FindAll(WEAPONS, w => (!CanBeat(weapon, w)) && w != weapon);

                Console.ForegroundColor = GetColorForWeapon(weapon);
                SpeakingConsole.WriteLine("\n " + weapon + ": " + GetTypeForWeapon(weapon));
                SpeakingConsole.WriteLine("\n     Strengths: " + string.Join(" And ", beatableWeapons));
                SpeakingConsole.WriteLine("\n     Weekness: " + string.Join(" And ", unbeatableWeapons));
            }
            Console.ForegroundColor = ConsoleColor.White;

            //////////////////////////////////////////////////////////////////

            string strWeapon;

            while (((strWeapon = SpeakingConsole.ReadLine()) == "" || !IsValidWeapon(strWeapon)) && strName != "")
            {
                SpeakingConsole.WriteLine("Please enter a valid weapon from above");
            }
            MeetOakSFX.Stop();
            
            timer.Start();
            intTimeSinceGameStart = 0;
            if (IsValidWeapon(strWeapon))
            {
                if (strName != "")
                {
                    return new BattleBot(strName, GetValidWeaponName(strWeapon));
                }
                else
                {
                    return new BattleBot(GetValidWeaponName(strWeapon));
                }
            }
            else
            {
                return new BattleBot();
            }

        }

        public void Battle(ref BattleBot battleBot)
        {
            if (!blnIsBattleSoundPlaying)
            {
                BattleSFX.PlayLooping();
                blnIsBattleSoundPlaying = true;
            }
            
            if (battleBot.FuelLevel > 0 && battleBot.ConditionLevel > 0)
            {
                intBattleStartTime = intTimeSinceGameStart;
                string computerWeapon = WEAPONS[rGen.Next(WEAPONS.Length)];
                //////////////////////////////////
                Console.ForegroundColor = GetColorForWeapon(battleBot.Weapon);
                Console.WriteLine("███████████████████████████");
                SpeakingConsole.WriteLine("\n\t\t" + battleBot.Weapon + "           ");

                Console.ForegroundColor = ConsoleColor.White;
                SpeakingConsole.WriteLine("\n\t\t----- VS -----   ");

                Console.ForegroundColor = GetColorForWeapon(computerWeapon);
                SpeakingConsole.WriteLine("\n\t\t" + computerWeapon);    // Pokemon
                Console.WriteLine("███████████████████████████");

                Console.ForegroundColor = ConsoleColor.White;
                //////////////////////////////////
                //SpeakingConsole.WriteLine("\nYou are being attacked by a " + computerWeapon + ". What do you do?");
                bool blnValidAction = false;
                char charReadKey = '\0';
                while (!blnValidAction)
                {
                    bool blnCheatCodeWorked = false;
                    SpeakingConsole.WriteLine("\nAttack, Defend, or Retreat");
                    for (int i = 0; i < KONAMI_CODE.Length; i++)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        charReadKey = key.KeyChar;
                        if (key.Key != KONAMI_CODE[i])
                        {
                            break;
                        }
                        if (i == KONAMI_CODE.Length - 1)
                        {
                            battleBot.GainPoints(20);
                            SpeakingConsole.WriteLine("\nYou have cheated, trainer!! But you will get 20 extra points because that's just how the world is (unfair)");
                            PokeBallOpenSFX.PlaySync();
                            
                            blnCheatCodeWorked = true;
                            BattleSFX.PlayLooping();
                        }
                    }
                    if (blnCheatCodeWorked)
                        continue;

                    string strAction = SpeakingConsole.SpeakAndReturn(charReadKey + Console.ReadLine());
                    switch (strAction.Trim().ToLower())
                    {
                        case "attack":
                            blnValidAction = true;
                            if (CanBeat(battleBot.Weapon, computerWeapon))
                            {
                                if (IsCriticalTo(battleBot.Weapon, computerWeapon))
                                {
                                    battleBot.GainPoints(rGen.Next(6, 11));
                                    SpeakingConsole.WriteLine("You have critically destroyed your opponent!!");
                                   
                                    //////////////////////////////////
                                    ///////////////////////////////////
                                    /////////////////////////////////
                                }
                                else
                                {
                                    battleBot.GainPoints(5);
                                    SpeakingConsole.WriteLine("You have destroyed your opponent!!");
                                }
                            }
                            else
                            {
                                if (IsCriticalTo(battleBot.Weapon, computerWeapon))
                                {
                                    battleBot.HandleDamage(rGen.Next(6, 11));
                                    SpeakingConsole.WriteLine("You have tragically lost!!");
                                }
                                else
                                {
                                    battleBot.HandleDamage(5);
                                    SpeakingConsole.WriteLine("You have lost!!");
                                }
                            }
                            battleBot.ConsumeFuel(2 * intTimeElapsed);
                            break;
                        case "defend":
                            blnValidAction = true;
                            if (CanBeat(battleBot.Weapon, computerWeapon))
                            {
                                battleBot.GainPoints(2);
                                SpeakingConsole.WriteLine("You have defended yourself like a noble man!!");
                            }
                            else
                            {
                                if (IsCriticalTo(battleBot.Weapon, computerWeapon))
                                {
                                    battleBot.HandleDamage(rGen.Next(3, 5));
                                    SpeakingConsole.WriteLine("Whoops, your shield has completely failed!!");
                                }
                                else
                                {
                                    battleBot.HandleDamage(2);
                                    SpeakingConsole.WriteLine("Whoops, your shield has failed!!");
                                }
                            }
                            battleBot.ConsumeFuel(intTimeElapsed);
                            break;
                        case "retreat":
                            blnValidAction = true;
                            if (rGen.Next(0, 4) == 0)
                            {
                                SpeakingConsole.WriteLine("Unfortunately, you couldn't escape in time!!");
                                battleBot.HandleDamage(7);
                            }
                            else
                            {
                                SpeakingConsole.WriteLine("You have succesfully escaped from the battle like a coward!! No points for you!!");
                            }
                            battleBot.ConsumeFuel(3 * intTimeElapsed);
                            break;
                        case "absorb":
                            if (battleBot.Weapon == computerWeapon)
                            {
                                blnValidAction = true;
                                SpeakingConsole.WriteLine("You have succesfully absorbed the opponent's power!! This tastes yummy OwO");
                                battleBot.Refuel(10);
                                battleBot.Heal(10);
                            }
                            break;
                    }

                    if (blnValidAction)
                    {
                        GetSoundForWeapon(battleBot.Weapon).PlaySync();
                        BattleSFX.Play();
                    }







                }
                Thread.Sleep(1000);
                SpeakingConsole.WriteLine("\nBot stats:");

                SpeakingConsole.WriteLine("Trainers Name: " + battleBot.Name + ",");

                // Color Desider
                if (battleBot.Weapon == "Pickachu")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (battleBot.Weapon == "Geodude")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (battleBot.Weapon == "Squirtle")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (battleBot.Weapon == "Swadloon")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (battleBot.Weapon == "Charmander")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }




                SpeakingConsole.WriteLine("Pokemon: " + battleBot.Weapon + ",");
                Console.ForegroundColor = ConsoleColor.White;
                SpeakingConsole.WriteLine("Condition Level: " + battleBot.ConditionLevel + ",");
                SpeakingConsole.WriteLine("Power Points:" + battleBot.FuelLevel + ",\nTurn Time: " + intTimeElapsed + ",\nTotal Battle Time: " + intTimeSinceGameStart + ",\nPoints: " + battleBot.Score + ",\nHighest Score: " + battleBot.HighScore);

                SpeakingConsole.WriteLine("\n Health Left: ##");
                SpeakingConsole.WriteLine("\n Power Left: ");
                //Console.WriteLine("\n Next Move: ");

                Thread.Sleep(1000);
                Battle(ref battleBot);
            }
            else
            {
                battleBot.UpdateHighScore(battleBot.Score);
                SpeakingConsole.WriteLine("Your pokemon has lost. Do you want to play again?");
                if (SpeakingConsole.ReadLine().Trim().ToLower()[0] == 'y')
                {
                    battleBot = PromptUserForBot();
                    Battle(ref battleBot);
                }
            }
        }

        private static bool CanBeat(string weapon, string otherWeapon)
        {
            switch (weapon)
            {
                case WEAPON_CIRCULAR_SAW:
                    if (otherWeapon == WEAPON_CLAW_CUTTER || otherWeapon == WEAPON_FLAME_THROWER)
                        return true;
                    break;
                case WEAPON_SLEDGE_HAMMER:
                    if (otherWeapon == WEAPON_SPINNNING_BLADE || otherWeapon == WEAPON_CIRCULAR_SAW)
                        return true;
                    break;
                case WEAPON_SPINNNING_BLADE:
                    if (otherWeapon == WEAPON_CIRCULAR_SAW || otherWeapon == WEAPON_FLAME_THROWER)
                        return true;
                    break;
                case WEAPON_CLAW_CUTTER:
                    if (otherWeapon == WEAPON_SLEDGE_HAMMER || otherWeapon == WEAPON_SPINNNING_BLADE)
                        return true;
                    break;
                case WEAPON_FLAME_THROWER:
                    if (otherWeapon == WEAPON_SLEDGE_HAMMER || otherWeapon == WEAPON_CLAW_CUTTER)
                        return true;
                    break;
            }
            return false;
        }

        private static bool IsValidWeapon(string weapon)
        {
            return Array.FindIndex(WEAPONS, s => weapon.Trim().ToLower() == s.Trim().ToLower()) != -1;
        }

        private static string GetValidWeaponName(string weapon)
        {
            return Array.Find(WEAPONS, s => weapon.Trim().ToLower() == s.Trim().ToLower());
        }
        private static ConsoleColor GetColorForWeapon(string weapon)
        {
            return WEAPON_COLORS[Array.FindIndex(WEAPONS, s => weapon.Trim().ToLower() == s.Trim().ToLower())];
        }

        private static string GetTypeForWeapon(string weapon)
        {
            return WEAPON_TYPES[Array.FindIndex(WEAPONS, s => weapon.Trim().ToLower() == s.Trim().ToLower())];
        }

        private static bool IsCriticalTo(string weapon, string otherWeapon)
        {
            switch (weapon)
            {
                case WEAPON_CIRCULAR_SAW:
                    if (otherWeapon == WEAPON_FLAME_THROWER)
                        return true;
                    break;
                case WEAPON_CLAW_CUTTER:
                    if (otherWeapon == WEAPON_SPINNNING_BLADE)
                        return true;
                    break;
                case WEAPON_FLAME_THROWER:
                    if (otherWeapon == WEAPON_CLAW_CUTTER)
                        return true;
                    break;
                case WEAPON_SLEDGE_HAMMER:
                    if (otherWeapon == WEAPON_SPINNNING_BLADE)
                        return true;
                    break;
                case WEAPON_SPINNNING_BLADE:
                    if (otherWeapon == WEAPON_CIRCULAR_SAW)
                        return true;
                    break;
            }
            return false;
        }

        private static SoundPlayer GetSoundForWeapon(string weapon)
        {
            switch (weapon)
            {
                case WEAPON_CIRCULAR_SAW:
                    return pikachuSound;
                case WEAPON_CLAW_CUTTER:
                    return squirtleSound;
                case WEAPON_FLAME_THROWER:
                    return charamanderSound;
                case WEAPON_SLEDGE_HAMMER:
                    return bulbasaurSound;
                case WEAPON_SPINNNING_BLADE:
                    return geodudeSound;
            }
            return null;
        }








    }















}
