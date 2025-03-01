using CosmosOS;
using System.Collections.Generic;
using System;

public static class CommandHandler
{
    private static List<string> commandHistory = new List<string>();

    public static void HandleCommand(string command)
    {
        commandHistory.Add(command);
        string[] parts = command.Split(' ');
        string cmd = parts[0].ToLower();

        switch (cmd)
        {
            case "echo":
                if (parts.Length > 1)
                {
                    Console.WriteLine(string.Join(" ", parts, 1, parts.Length - 1));
                }
                else
                {
                    Console.WriteLine("Usage: echo <text>");
                }
                break;

            case "help":
                Console.WriteLine("Available commands:");
                Console.WriteLine("echo <text> - Echoes the text back");
                Console.WriteLine("reboot - Restarting PC");
                Console.WriteLine("shutdown - Turn off PC");
                Console.WriteLine("commander - Enter the commander");
                Console.WriteLine("clear - Clears the screen");
                Console.WriteLine("help - Displays this help message");
                Console.WriteLine("create <filename> <content> - Creates a new file");
                Console.WriteLine("read <filename> - Reads the content of a file");
                Console.WriteLine("delete <filename> - Deletes a file");
                Console.WriteLine("mkdir <dirname> - Creates a new directory");
                Console.WriteLine("rmdir <dirname> - Deletes a directory");
                Console.WriteLine("ls - Lists contents of the current directory");
                Console.WriteLine("cd <dirname> - Changes the current directory");
                Console.WriteLine("psfetch - Displays system information");
                Console.WriteLine("date - Writing current date");
                Console.WriteLine("time - Writing current time");
                Console.WriteLine("whoami - Writing who are you in this OS");
                Console.WriteLine("cat <filename> - Display the contents of a file");
                Console.WriteLine("mv <source> <destination> - Move or rename a file");
                Console.WriteLine("cp <source> <destination> - Copy a file");
                Console.WriteLine("find <filename> - Search for a file");
                Console.WriteLine("history - Show command history");
                Console.WriteLine("sysinfo - Detailed system information");
                Console.WriteLine("theme <color> - Change console theme (e.g., theme blue)");
                break;

            case "clear":
                Console.Clear();
                break;

            case "create":
                if (parts.Length > 2)
                {
                    string filename = parts[1];
                    string content = string.Join(" ", parts, 2, parts.Length - 2);
                    FileSystem.CreateFile(filename, content);
                }
                else
                {
                    Console.WriteLine("Usage: create <filename> <content>");
                }
                break;

            case "read":
                if (parts.Length > 1)
                {
                    FileSystem.ReadFile(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: read <filename>");
                }
                break;

            case "delete":
                if (parts.Length > 1)
                {
                    FileSystem.DeleteFile(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: delete <filename>");
                }
                break;

            case "mkdir":
                if (parts.Length > 1)
                {
                    FileSystem.CreateDirectory(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: mkdir <dirname>");
                }
                break;

            case "rmdir":
                if (parts.Length > 1)
                {
                    FileSystem.DeleteDirectory(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: rmdir <dirname>");
                }
                break;

            case "ls":
                FileSystem.ListContents();
                break;

            case "cd":
                if (parts.Length > 1)
                {
                    FileSystem.ChangeDirectory(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: cd <dirname>");
                }
                break;

            case "psfetch":
                Console.WriteLine("PonOS v1.2");
                Console.WriteLine("OS Created on C#");
                Console.WriteLine("Author: Syncas");
                break;

            case "reboot":
                Console.WriteLine("Shutting down...");
                Cosmos.System.Power.Reboot();
                break;

            case "shutdown":
                Console.WriteLine("Shutting down...");
                Cosmos.System.Power.Shutdown();
                break;

            case "commander":
                Commander.Start();
                break;

            case "date":
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                break;

            case "time":
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                break;

            case "whoami":
                Console.WriteLine("user");
                break;

            case "cat":
                if (parts.Length > 1)
                {
                    FileSystem.ReadFile(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: cat <filename>");
                }
                break;

            case "mv":
                if (parts.Length > 2)
                {
                    FileSystem.MoveFile(parts[1], parts[2]);
                }
                else
                {
                    Console.WriteLine("Usage: mv <source> <destination>");
                }
                break;

            case "cp":
                if (parts.Length > 2)
                {
                    FileSystem.CopyFile(parts[1], parts[2]);
                }
                else
                {
                    Console.WriteLine("Usage: cp <source> <destination>");
                }
                break;

            case "find":
                if (parts.Length > 1)
                {
                    FileSystem.FindFile(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: find <filename>");
                }
                break;

            case "history":
                ShowHistory();
                break;

            case "sysinfo":
                Console.WriteLine($"OS: PonOS v1.2");
                Console.WriteLine($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}");
                Console.WriteLine($"RAM: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
                Console.WriteLine($"Uptime: {Cosmos.Core.CPU.GetCPUUptime()} seconds");
                break;

            case "theme":
                if (parts.Length > 1)
                {
                    ChangeTheme(parts[1]);
                }
                else
                {
                    Console.WriteLine("Usage: theme <color>");
                }
                break;

            default:
                Console.WriteLine($"Unknown command: {cmd}");
                break;
        }
    }

    public static void ShowHistory()
    {
        Console.WriteLine("Command history:");
        foreach (var command in commandHistory)
        {
            Console.WriteLine(command);
        }
    }

    public static void ChangeTheme(string color)
    {
        switch (color.ToLower())
        {
            case "blue":
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                break;
            case "green":
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                break;
            case "red":
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid theme color. Available colors: blue, green, red");
                break;
        }
    }
}