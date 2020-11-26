using _2048_Ext.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Ext.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            string inp = "";


            Console.WriteLine("Insert the name of the player: ");
            string nameOfPlayer = Console.ReadLine();

            Console.WriteLine("Rows and Columns: ");
            string [] tableDimentionsString = Console.ReadLine().Split(' ');

            int rows = int.Parse(tableDimentionsString[0]);
            int columns = int.Parse(tableDimentionsString[1]);


            game.NewGame(nameOfPlayer, rows, columns);
            game.PrintTable();

            while (!game.DidILose())
            {
                Console.WriteLine("Move 0-1-2-3");
                inp = Console.ReadLine();

                if (inp == " ")
                    break;

                if (inp == "0")
                    game.DownMove();
                else if (inp == "1")
                    game.LeftMove();
                else if (inp == "2")
                    game.UpMove();
                else if (inp == "3")
                    game.RightMove();
                else if (inp == "4")
                    game.Save();

                Console.WriteLine(game.PlayerName);
                Console.WriteLine(game.Score);
                game.PrintTable();
            }
        }
    }
}
