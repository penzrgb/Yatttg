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
            // Init the Yatttg facade
            IYatttgFacade yatttg = new YatttgModel.YatttgModel();
            Console.WriteLine("Welcome to Yatttg! (Yet another tic-tac-toe game).");
            Console.WriteLine("The current characters for the norts and crosses are {0} and {1} respectively.",
                yatttg.Nort.Character, yatttg.Cross.Character);

            HandleChangeChars(yatttg);

            Console.Read();
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
            string lineRead = Console.ReadLine().Trim();
            if (lineRead.Length == 0)
                return '\0';
            else
                return Char.Parse(lineRead);
        }
    }
}
