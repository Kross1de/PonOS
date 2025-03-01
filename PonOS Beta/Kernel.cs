using System;
using Sys = Cosmos.System;

namespace CosmosOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================");
            Console.WriteLine("PonOS booted successfully. Type 'help' for a list of commands.");
            Console.WriteLine("============================================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("user#ponos~$ ");
            var input = Console.ReadLine();
            CommandHandler.HandleCommand(input);
        }
    }
}