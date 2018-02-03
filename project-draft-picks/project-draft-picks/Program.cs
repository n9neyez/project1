using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_draft_picks
{
    class Program
    {
        static void Main()
        {
            //DECLARATATIONS
            string[,] playerNames =
            {
                {"Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield" },
                {"Saquon Barkley", "Derrius Guice", "Bryce Love", "Ronald Jones II", "Damien Harris" },
                {"Courtland Sutton", "James Washington", "Marcell Ateman", "Anthony Miller", "Calvin Ridley" },
                {"Maurice Hurst", "Vita Vea", "Taven Bryan", "Da'Ron Payne", "Harrison Phillips" },
                {"Joshua Jackson", "Derwin James", "Denzel Ward", "Minkah Fitzpatrick", "Isaiah Oliver" },
                {"Mark Andrews", "Dallas Goedert", "Jaylen Samuels", "Mike Gesicki", "Troy Fumagalli" },
                {"Roquan Smith", "Tremaine Edmunds", "Kendall Joseph", "Dorian O'Daniel", "Mailk Jefferson" },
                {"Orlando Brown", "Kolton Miller", "Chukwuma Okorafor", "Connor Williams", "Mike McGlinchey" }
            };
            string[,] college =
            {
                {"Oklahoma State", "Louisville", "UCLA", "Southern California", "Oklahoma" },
                {"Penn State", "LSU", "Stanford", "Southern California", "Alabama" },
                {"Southern Methodist", "Oklahoma State", "Oklahoma State", "Memphis", "Alabama" },
                {"Michigan", "Washington", "Florida", "Alabama", "Stanford" },
                {"Iowa", "Florida state", "Ohio State", "Alabama", "Colorado" },
                {"Oklahoma", "So. Dakota State", "NC State", "Penn State", "Wisconsin" },
                {"Georgia", "Virginia Tech", "Clemson", "Clemson", "Texas" },
                {"Oklahoma", "UCLA", "Western Michigan", "Texas", "Notre Dame" }
            };
            double[,] playerCost =
            {
                {26400100, 20300100, 17420300, 13100145, 10300000 },
                {24500100, 19890800, 18700800, 15000000, 11600400 },
                {23400000, 21900300, 19300230, 13400230, 10000000 },
                {26200300, 22000000, 16000000, 18000000, 13000000 },
                {24000000, 22500249, 20000100, 16000200, 11899999 },
                {27800900, 21000800, 17499233, 27900200, 14900333 },
                {22900300, 19000590, 18000222, 12999999, 10000100 },
                {23000000, 20000000, 19400000, 16200700, 15900000 }
            };
            string[,] position =
            {
                {"Quarterback", "Quarterback", "Quarterback", "Quarterback", "Quarterback" },
                {"Running Back", "Running Back", "Running Back", "Running Back", "Running Back" },
                {"Wide-Reciever", "Wide-Reciever", "Wide-Reciever", "Wide-Reciever", "Wide-Reciever" },
                {"Defensive Tackle", "Defensive Tackle", "Defensive Tackle", "Defensive Tackle", "Defensive Tackle" },
                {"Defensive-Back", "Defensive-Back", "Defensive-Back", "Defensive-Back", "Defensive-Back" },
                {"Tight End", "Tight End", "Tight End", "Tight End", "Tight End" },
                {"Line-Backer", "Line-Backer", "Line-Backer", "Line-Backer", "Line-Backer"},
                {"Offensive Tackle", "Offensive Tackle", "Offensive Tackle", "Offensive Tackle", "Offensive Tackle" }
            };

            ConsoleKeyInfo startkey;
            double BUDGET = 95000000;
            bool continueProgram = true;

            // Program start

            housekeeping(out startkey);

            while (startkey.Key == ConsoleKey.Enter)
            {
                outputPlayers(ref playerNames, ref college, ref playerCost, ref position);

                /*
                do
                {

                } while (continueProgram);
                */

                endProgram(out startkey);

            }

        }
        // Housekeeping
        public static void housekeeping(out ConsoleKeyInfo start)
        {
            Console.WriteLine("Welcome coach! This is a draft program designed to help you choose from a list " +
                "of the top 40 players, based on your $95 million budget.\n");
            Console.WriteLine("A list of players will appear if you choose to use this program.");
            Console.WriteLine("Press <Enter> to continue, or another key to exit");
            start = Console.ReadKey();
            Console.Clear();
        }
        // End Program, ask for primer again to continue
        public static void endProgram(out ConsoleKeyInfo end)
        {
            Console.WriteLine("\nThank you for using this progmram.");
            Console.WriteLine("\nIf you want to make another draft, press the <Enter> key, or any other key to exit.");
            end = Console.ReadKey();
        }
        // output players
        public static void outputPlayers(ref string[,] players, ref string[,] school, ref double[,] cost, ref string[,] position )
        {
            for (var x = 0; x < 1; x++)
            {
                
                for (var y = 0; y < 5; y++)
                {
                    Console.Write($"\n|{players[0, y]}|\t|{players[1, y]}|\t|{players[2, y]}|\t|{players[3, y]}|\t|{players[4, y]}|\t|{players[5, y]}|\t|{players[6, y]}|\t|{players[7, y]}" +
                        $"\n{school[0, 0]}\n{cost[x, 0]}\n{position[0, 0]}   ");
                    Console.WriteLine("\n");
                }
            }
            
        }
    }
}
    // end main class


