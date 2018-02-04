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
            double COST = 0;
            bool continuePick = true; //playerCheck;
            int playerRow, playerCol;
            //string playerSelection;
            List<String> playersList = new List<String>();
            List<String> collegeList = new List<String>();
            List<String> positionList = new List<String>();
            List<Double> costList = new List<Double>();
            List<DraftPick> draftPick = new List<DraftPick>();
            string message = "Cost Effective!";
            double COST_EFFECTIVE = 65000000;
            double EFFECTIVE_BUDGET = 0;
            int count = 0;                  

            // Program start
            housekeeping(out startkey);

            while (startkey.Key == ConsoleKey.Enter)
            {
                
                do
                {

                    outputPlayers(ref playerNames, ref college, ref playerCost, ref position);
                    getPlayer(out playerRow, out playerCol, ref playerNames);
                    if (playerRow < 3)
                    {
                        count = count + 1;
                        
                    }

                    // add to list
                    playersList.Add(playerNames[playerRow, playerCol]);
                    //collegeList.Add(college[playerRow, playerCol]);
                    //positionList.Add(position[playerRow, playerCol]);
                    //costList.Add(playerCost[playerRow, playerCol]);

                    COST = playerCost[playerRow, playerCol];
                    BUDGET = BUDGET - COST;
                    EFFECTIVE_BUDGET = EFFECTIVE_BUDGET + COST; // counter for cost effective
                    

                    showPlayer(ref playerRow, ref playerCol, ref playerNames, ref college, ref playerCost, ref position, ref BUDGET);
                    //BUDGET = getBudget(ref COST, ref playerCost, ref playerRow, ref playerCol);
                    //preventPick(playerRow, playerCol, ref playerNames);
                    //playerCheck = checkPlayers(ref playerRow, ref playerCol);
                    continuePick = continueProgram();

                } while (continuePick);
                

                draftPick.Add(new DraftPick(playerNames[playerRow, playerCol], college[playerRow, playerCol], position[playerRow, playerCol], playerCost[playerRow, playerCol]));

                if (BUDGET <= 0) // the message "cost effective" won't display for this condition becaause it can't display if user runs out of money
                {
                    Console.Clear();
                    Console.WriteLine("\nYou have went passed your budget!");
                    foreach (var i in playersList)
                    {
                        Console.WriteLine($"You have selected the following players: {i}");
                    }
                    endProgram(out startkey);
                    BUDGET = 95000000;
                }
                else
                {
                    foreach (var i in playersList)
                    {
                        Console.WriteLine($"You have selected the following players: {i}");
                    }
                    Console.WriteLine("\nBudget used: " + EFFECTIVE_BUDGET);
                    
                    if (EFFECTIVE_BUDGET < COST_EFFECTIVE && count == 3)
                    {
                        Console.WriteLine(message);
                    }
                    
                    endProgram(out startkey);
                    BUDGET = 95000000;
                }
                
                playersList.Clear();
            }
        }

        // Housekeeping
        public static void housekeeping(out ConsoleKeyInfo start)
        {
            Console.WriteLine("Welcome coach! This is a draft program designed to help you choose from a list " +
                "of the top 40 players, based on your $95 million budget.\n");
            Console.WriteLine("Please fullscreen this program for the best experience.\n");
            Console.WriteLine("A list of players will appear if you choose to use this program.");
            Console.WriteLine("Press <Enter> to continue, or another key to exit");
            start = Console.ReadKey();
            Console.Clear();
        }
        // End Program, ask for primer again to continue
        /*public static void endProgram(out ConsoleKeyInfo end, ref List<String> name, ref List<String> school, ref List<String> position)
        {
            for (var x = 0; x < name.Count; x++)
            {
                Console.WriteLine("Your picks are below: \n\n");
                Console.WriteLine(name[x] + " | " + school[x] + " | " + position[x]);
            }

            //Console.WriteLine("\n\nThank you for using this program.");
            //Console.WriteLine("\n\n\nIf you want to make another draft, press the <Enter> key, or any other key to exit.");
            end = Console.ReadKey();
            Console.Clear();
        }*/
        public static void endProgram(out ConsoleKeyInfo end)
        {
            Console.WriteLine("\n\nThank you for using this program.");
            Console.WriteLine("\n\n\nIf you want to make another draft, press the <Enter> key, or any other key to exit.");
            end = Console.ReadKey();
            Console.Clear();
        }
        // output players table
        public static void outputPlayers(ref string[,] players, ref string[,] school, ref double[,] cost, ref string[,] position )
        {
            /* Making this table took me forever...It might not be the most efficient way, but it's the only way I found it to work for me. =) */
            for (var x = 0; x < players.GetLength(1); x++)
            {
                Console.Write("{0, -25} {1, -25} {2, -25} {3, -25} {4, -25} {5, -25} {6, -25} {7, -25}\n",
                         "0" + x,
                         "|" + "1" + x,
                         "|" + "2" + x,
                         "|" + "3" + x,
                         "|" + "4" + x,
                         "|" + "5" + x,
                         "|" + "6" + x,
                         "|" + "7" + x
                        );
                Console.Write("{0, -25} {1, -25} {2, -25} {3, -25} {4, -25} {5, -25} {6, -25} {7, -25}\n",
                         players[0, x],
                         "|" + players[1, x],
                         "|" + players[2, x],
                         "|" + players[3, x],
                         "|" + players[4, x],
                         "|" + players[5, x],
                         "|" + players[6, x],
                         "|" + players[7, x]
                        );
                Console.Write("{0, -25} {1, -25} {2, -25} {3, -25} {4, -25} {5, -25} {6, -25} {7, -25}\n",
                         school[0, x],
                         "|" + position[1, x],
                         "|" + position[2, x],
                         "|" + position[3, x],
                         "|" + position[4, x],
                         "|" + position[5, x],
                         "|" + position[6, x],
                         "|" + position[7, x]
                        );
                Console.Write("{0, -25} {1, -25} {2, -25} {3, -25} {4, -25} {5, -25} {6, -25} {7, -25}\n",
                         position[0, x],
                         "|" + school[1, x],
                         "|" + school[2, x],
                         "|" + school[3, x],
                         "|" + school[4, x],
                         "|" + school[5, x],
                         "|" + school[6, x],
                         "|" + school[7, x]
                        );
                Console.Write("{0, -25} {1, -25} {2, -25} {3, -25} {4, -25} {5, -25} {6, -25} {7, -25}\n",
                         cost[0, x],
                         "|" + cost[1, x],
                         "|" + cost[2, x],
                         "|" + cost[3, x],
                         "|" + cost[4, x],
                         "|" + cost[5, x],
                         "|" + cost[6, x],
                         "|" + cost[7, x]
                        );
                Console.WriteLine("\n");
            }
        }
        /*public static double getBudget(ref double cost, ref double[,] playerCost, ref int playerRow, ref int playerCol)
        {
            double budget = 95000000;

            cost = playerCost[playerRow, playerCol];

            budget = budget - cost;

            return budget;

        }*/
        public static void getPlayer(out int playerRow, out int playerCol, ref string[,] players)
        {
            string playerSelection;

            Console.WriteLine("Select any player from the table above to add to your draft list.\n");
            Console.WriteLine("Please select by entering the corresponding number to each player: ");

            playerSelection = Console.ReadLine();
            playerRow = Int32.Parse(playerSelection.Substring(0, 1));
            playerCol = Convert.ToInt32(playerSelection.Substring(1, 1));

        }
        public static void showPlayer(ref int playerRow, ref int playerCol, ref string[,] players, ref string[,] school, ref double[,] cost, ref string[,] position, ref double BUDGET)
        {
            Console.WriteLine("\nYou have selected: \n\n" + 
                players[playerRow, playerCol ] + "\n" +
                school[playerRow, playerCol] + "\n" + 
                position[playerRow, playerCol] + "\n" +
                cost[playerRow, playerCol]);

            Console.WriteLine("\nBudget: " + BUDGET);
        }
        // end table
        public static bool continueProgram()
        {
            string proceed;
            bool continuePick;

            
            Console.WriteLine("\nIf you want to add another player, please enter Y or another key to stop adding players.");
            proceed = Console.ReadLine();
            proceed = proceed.ToUpper();

            if (proceed == "Y")
            {
                continuePick = true;
            }
            else
            {
                continuePick = false;
            }
            Console.Clear();
            return continuePick;
        }
        /* NOT USED
        public static void effectiveCounter(out int count, ref int playerCol)
        {
            count = 0;

            if (playerCol < 3) // playerRow doesn't matter here, only playerCol because it specifies rank starting from 0 - 2 which is rank 1 - 3
            {
                count++; // add to the counter, if any three combination of the top three ranks are selected
            }

        }
        /* I had a good thought, but could not execute it
        public static bool checkPlayers(ref int playerRow, ref int playerCol)
        {
            string playerSelect;
            bool playerCheck = true;

            string checkRow = playerRow.ToString();
            string checkCol = playerCol.ToString();

            playerSelect = checkRow + checkCol;

            Console.WriteLine(playerSelect);

            if (checkRow + checkCol == playerSelect)
            {
                playerCheck = true;
            }
            else
            {
                playerCheck = false;
            };
            return playerCheck;
        }
        */
    }
    // Didn't even make use of this class
    class DraftPick
    {
        private string PlayerName;
        private string College;
        private string Position;
        private double PlayerCost;
        
        //Constructor
        public DraftPick(string name, string school, string position, double cost)
        {
            PlayerName = name;
            College = school;
            Position = position;
            PlayerCost = cost;

        }
        public string getPlayerName()
        {
            return PlayerName;
        }
        public string getCollege()
        {
            return College;
        }
        public string getPosition()
        {
            return Position;
        }
        public double getPlayerCost()
        {
            return PlayerCost;
        }
    }
}



