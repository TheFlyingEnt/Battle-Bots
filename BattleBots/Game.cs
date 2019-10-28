
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BattleBots
{
    public class Game
    {

        public const string WEAPON_CIRCULAR_SAW = "Pikachu";
        public const string WEAPON_CLAW_CUTTER = "Squirtle";
        public const string WEAPON_FLAME_THROWER = "Pidgey";
        public const string WEAPON_SLEDGE_HAMMER = "Geodude";
        public const string WEAPON_SPINNNING_BLADE = "Swadloon";
        // In this Code, We have Assign Each weapon to a Pokemon Name

        public static string[] WEAPONS = new string[] { WEAPON_CIRCULAR_SAW, WEAPON_CLAW_CUTTER, WEAPON_FLAME_THROWER, WEAPON_SLEDGE_HAMMER, WEAPON_SPINNNING_BLADE };
        private System.Timers.Timer timer;
        private Random rGen = new Random();
        private int intTimeSinceGameStart;
        private int intBattleStartTime;
        private int intTimeElapsed;

        // Sound Locations
        System.Media.SoundPlayer OpeningSFX = new System.Media.SoundPlayer(GameR.Pokemon_Open);
        System.Media.SoundPlayer BattleSFX = new System.Media.SoundPlayer(GameR.Pokemon_Battle);

        // For Sound Later On
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


        // User Interface
        public BattleBot PromptUserForBot()
        {
            OpeningSFX.Play();
            Console.WriteLine("Do you want to enable the reading out of all the text? (y/n)");
            if (Console.ReadLine().Trim().ToLower()[0] != 'y')
            {
                SpeakingConsole.EnableSpeaking = false;
            }
            SpeakingConsole.WriteLine("Welcome to Battle Bots! This is a game where there is no winning (just like life). Your goal is to get the most possible points.\n\nTo start, please enter the name for your bot:");
            string strName = SpeakingConsole.ReadLine();
            SpeakingConsole.WriteLine("\nPlease choose a weapon from the following:");

            foreach (string weapon in WEAPONS)
            {
                string[] beatableWeapons = Array.FindAll(WEAPONS, w => CanBeat(weapon, w));
                SpeakingConsole.WriteLine("\n" + weapon + " Beats " + String.Join(" And ", beatableWeapons));
            }

            string strWeapon;
            while (((strWeapon = SpeakingConsole.ReadLine()) == "" || !IsValidWeapon(strWeapon)) && strName != "")
            {
                SpeakingConsole.WriteLine("Please enter a valid weapon from above");
            }
            OpeningSFX.Stop();
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














    }
}
