using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YatttgModel;

namespace Yatttg
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1, p2;
            bool playing = true;

            // Init the Yatttg facade
            IYatttgFacade yatttg = new YatttgModel.YatttgModel();
            Console.WriteLine("Welcome to Yatttg! (Yet another tic-tac-toe game).");
            Console.WriteLine("The current characters for the norts and crosses are {0} and {1} respectively.",
                yatttg.Nort.Character, yatttg.Cross.Character);

            // Users can change the characters for the norts and crosses, if they wish.
            HandleChangeChars(yatttg);

            // Set up each player
            Console.Write("Enter player name for norts: ");
            string name = Console.ReadLine();
            p1 = new Player(name, yatttg.Nort);
            Console.Write("Enter player name for crosses: ");
            name = Console.ReadLine();
            p2 = new Player(name, yatttg.Cross);

            // Start the game
            while (playing)
            {
                Tuple<Player, Constant.GameState> game = PlayGame(yatttg, p1, p2);
                bool reprompt = true;

                if (game.Item2 == Constant.GameState.Win)
                    Console.WriteLine("{0} Wins!", game.Item1.Name);
                else if (game.Item2 == Constant.GameState.Tie)
                    Console.WriteLine("{0} tied the game!", game.Item1.Name);

                while (reprompt)
                {
                    Console.Write("Play again (y/N)? ");

                    char choice = GetChar();

                    if (choice == 'y')
                        break;

                    // Reprompt if the choice wasn't n or empty
                    reprompt = ((choice != 'n') && (choice != '\0'));
                }

                if (!reprompt)
                    playing = false;
            }
        }

        static Tuple<Player, Constant.GameState> PlayGame(IYatttgFacade yatttg,
            Player p1, Player p2)
        {
            Constant.GameState currentGameState_;
            currentGameState_ = yatttg.InitGame(p1, p2);

            Player turn = null;
            bool error = false;

            while (currentGameState_ == Constant.GameState.InProgress)
            {
                Console.Clear();

                if (!error)
                    turn = yatttg.StartNextTurn();

                Console.WriteLine("{0}'s Turn ({1}):", turn.Name, turn.Marker.Character);
                Console.WriteLine();

                DisplayGrid(yatttg);

                Console.WriteLine("Press the number of the cell you would like to select.");

                try
                {
                    int option = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
                    currentGameState_ = yatttg.MakeMove(turn, option);
                    error = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    error = true;
                }
            }

            return new Tuple<Player, Constant.GameState>(turn, currentGameState_);
        }

        static void DisplayGrid(IYatttgFacade yatttg)
        {
            Cell[,] currentGrid = yatttg.GetGrid();
            int counter = 1;

            Console.WriteLine("-------");
            for (int row = 0; row < Constant.GridSize; row++)
            {
                Console.Write("|");
                for (int column = 0; column < Constant.GridSize; column++)
                {
                    char value = Char.Parse(counter.ToString());
                    if (currentGrid[row, column].Marker != null)
                        value = currentGrid[row, column].Marker.Character;

                    Console.Write("{0}|", value);
                    counter++;
                }

                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        static void HandleChangeChars(IYatttgFacade yatttg)
        {
            bool reprompt = true;

            while (reprompt)
            {
                Console.Write("{0}Would you like to change these (y/N)? ", Environment.NewLine);
                char choice = GetChar();

                if (choice == 'y')
                {
                    Console.Write("Enter the new Nort character (Default: {0}): ", yatttg.Nort.Character);
                    char newNort = GetChar();

                    if (newNort != '\0')
                        yatttg.Nort.Character = newNort;

                    Console.Write("Enter the new Cross character (Default: {0}): ", yatttg.Cross.Character);
                    char newCross = GetChar();

                    if (newCross != '\0')
                        yatttg.Cross.Character = newCross;

                    Console.WriteLine("Norts = {0}, Crosses = {1}", yatttg.Nort.Character, yatttg.Cross.Character);

                    break;
                }

                // Reprompt if the choice wasn't n or empty
                reprompt = ((choice != 'n') && (choice != '\0'));
            }
        }

        private static char GetChar()
        {
            string lineRead = Console.ReadLine().Trim().ToLower();
            if (lineRead.Length == 0)
                return '\0';
            else
                return Char.Parse(lineRead);
        }
    }
}
