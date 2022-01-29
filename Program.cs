using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdverseWebhookGenerator
{
    internal class Program
    {
        private static Random random = new Random();
        private static short getRandNum()
        {
            return (short)random.Next(10);
        }
        private static string getRandChar()
        {
            string randChar = Encoding.ASCII.GetString(new byte[] { (byte)random.Next(97, 123) });
            if ((random.Next(2) % 2) == 0)
            {
                return randChar.ToUpper();
            }
            return randChar;
        }

        private static string generateWebhook()
        {
            StringBuilder webHook = new StringBuilder("https://discord.com/api/webhooks/");
            for (int i = 0; i < 18; i++)
            {
                webHook.Append(getRandNum());
            }
            webHook.Append("/");

            for (int i = 0; i < 68; i++)
            {
                if ((random.Next(2) % 2) == 0)
                {
                    webHook.Append(getRandChar());
                }
                else
                {
                    webHook.Append(getRandNum());
                }
            }
            return webHook.ToString();
        }
        static void Main(string[] args)
        {

            Console.Title = "Discord Webhook Generator.  I  https://github.com/drippinn ";
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string text = @"   ___     __                    ";
            string text2 = @"  / _ |___/ /  _____ _______ ___ ";
            string text3 = @" / __ / _  / |/ / -_) __(_-</ -_)";
            string text4 = @"/_/ |_\_,_/|___/\__/_/ /___/\__/ ";
            string text5 = "Free Discord Webhook Generator";



            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text.Length / 2).ToString() + "}", text));
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text2.Length / 2).ToString() + "}", text2));
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text3.Length / 2).ToString() + "}", text3));
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text4.Length / 2).ToString() + "}", text4));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + text5.Length / 2).ToString() + "}", text5));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("");
            Console.WriteLine("Amount: ");
            uint numOfHooks;
            while (!uint.TryParse(Console.ReadLine(), out numOfHooks))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Not a valid number.");
            }
            List<string> listOfHooks = new List<string>();
            for (int i = 0; i < numOfHooks; i++)
            {
                string generatedHook = generateWebhook();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Generated: {0}", generatedHook);
                listOfHooks.Add(generatedHook);
            }
            Console.WriteLine("Save webhooks on txt? (y/n)");
            string shouldSave = Console.ReadLine();
            while (shouldSave == null || (!shouldSave.Equals("y") && !shouldSave.Equals("n")))
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Not Valid Option.");
                shouldSave = Console.ReadLine();
            }
            if (shouldSave.Equals("y"))
            {
                File.WriteAllLines("generatedwebhook.txt", listOfHooks);

            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Ended.");
            Console.Read();
        }
    }
}
