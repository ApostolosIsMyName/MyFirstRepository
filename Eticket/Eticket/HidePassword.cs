using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticket
{
    public class HidePassword
    {
        public static void Logo()
        {
            Console.WriteLine(" ______   _______ _____ _____ _  ________ _______ ");
            Console.WriteLine("|  ____| |__   __|_   _/ ____| |/ /  ____|__   __|");
            Console.WriteLine("| |__ ______| |    | || |    | ' /| |__     | |   ");
            Console.WriteLine("|  __|______| |    | || |    |  < |  __|    | |   ");
            Console.WriteLine("| |____     | |   _| || |____| . \\| |____   | |   ");
            Console.WriteLine("|______|    |_|  |_____\\_____|_|\\_\\______|  |_|   ");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<   WELCOME   >>>>>>>>>>>>>>>>>>>>>>");
        }
        public static string HideString()
        {
            Console.CursorVisible = false;
            string input = "";
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey(true);
                if (pressedKey.Key != ConsoleKey.Backspace && pressedKey.Key != ConsoleKey.Enter && pressedKey.Key != ConsoleKey.Spacebar && pressedKey.Key != ConsoleKey.Escape)
                {
                    input += pressedKey.KeyChar;
                    Console.Write("*");
                }
                else if (pressedKey.Key == ConsoleKey.Spacebar || pressedKey.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = true;
                    Console.CursorVisible = false;
                }
                else
                {
                    if (pressedKey.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (pressedKey.Key == ConsoleKey.Backspace && input.Length == 0)
                    {
                        Console.CursorVisible = true;
                        Console.CursorVisible = false;
                    }
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            return input;
        }
        
    }

}
