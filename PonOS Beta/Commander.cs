using System;

namespace CosmosOS
{
    public static class Commander
    {
        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("PonOS Commander v2.0 (Graphical Mode)");
            Console.WriteLine("Use arrow keys to navigate, Enter to select, Esc to exit.");

            string[] mainMenuItems = { "File Manager", "System Info", "Network Tools", "Settings", "Shutdown" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("PonOS Commander v2.0");
                Console.WriteLine("====================");

                for (int i = 0; i < mainMenuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(mainMenuItems[i]);
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : mainMenuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < mainMenuItems.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    HandleMainMenuSelection(mainMenuItems[selectedIndex]);
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Leaving commander");
                    break;
                }
            }
        }

        private static void HandleMainMenuSelection(string selectedItem)
        {
            switch (selectedItem)
            {
                case "File Manager":
                    FileManagerMenu();
                    break;
                case "System Info":
                    SystemInfoMenu();
                    break;
                case "Network Tools":
                    NetworkToolsMenu();
                    break;
                case "Settings":
                    SettingsMenu();
                    break;
                case "Shutdown":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Shutting down...");
                    Environment.Exit(0);
                    break;
            }
        }

        private static void FileManagerMenu()
        {
            string[] fileManagerMenuItems = { "List Files", "Create File", "Delete File", "Create Directory", "Delete Directory", "Back" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("File Manager");
                Console.WriteLine("============");

                for (int i = 0; i < fileManagerMenuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(fileManagerMenuItems[i]);
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : fileManagerMenuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < fileManagerMenuItems.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    HandleFileManagerMenuSelection(fileManagerMenuItems[selectedIndex]);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void HandleFileManagerMenuSelection(string selectedItem)
        {
            switch (selectedItem)
            {
                case "List Files":
                    FileSystem.ListContents();
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Create File":
                    Console.Write("Enter file name: ");
                    string fileName = Console.ReadLine();
                    Console.Write("Enter file content: ");
                    string fileContent = Console.ReadLine();
                    FileSystem.CreateFile(fileName, fileContent);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Delete File":
                    Console.Write("Enter file name: ");
                    string fileToDelete = Console.ReadLine();
                    FileSystem.DeleteFile(fileToDelete);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Create Directory":
                    Console.Write("Enter directory name: ");
                    string dirName = Console.ReadLine();
                    FileSystem.CreateDirectory(dirName);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Delete Directory":
                    Console.Write("Enter directory name: ");
                    string dirToDelete = Console.ReadLine();
                    FileSystem.DeleteDirectory(dirToDelete);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Back":
                    break;
            }
        }

        private static void SystemInfoMenu()
        {
            string[] systemInfoMenuItems = { "General Info", "CPU Info", "RAM Info", "Back" };  
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("System Info");
                Console.WriteLine("===========");

                for (int i = 0; i < systemInfoMenuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(systemInfoMenuItems[i]);
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : systemInfoMenuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < systemInfoMenuItems.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    HandleSystemInfoMenuSelection(systemInfoMenuItems[selectedIndex]);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void HandleSystemInfoMenuSelection(string selectedItem)
        {
            switch (selectedItem)
            {
                case "General Info":
                    Console.WriteLine($"OS: PonOS v1.2");
                    Console.WriteLine($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}");
                    Console.WriteLine($"RAM: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
                    Console.WriteLine($"Uptime: {Cosmos.Core.CPU.GetCPUUptime()} seconds");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "CPU Info":
                    Console.WriteLine($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "RAM Info":
                    Console.WriteLine($"RAM: {Cosmos.Core.CPU.GetAmountOfRAM()} MB");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Back":
                    break;
            }
        }

        private static void NetworkToolsMenu()
        {
            string[] networkToolsMenuItems = { "Ping", "IP Config", "Network Scan", "Back" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Network Tools");
                Console.WriteLine("=============");

                for (int i = 0; i < networkToolsMenuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(networkToolsMenuItems[i]);
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : networkToolsMenuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < networkToolsMenuItems.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    HandleNetworkToolsMenuSelection(networkToolsMenuItems[selectedIndex]);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void HandleNetworkToolsMenuSelection(string selectedItem)
        {
            switch (selectedItem)
            {
                case "Ping":
                    Console.WriteLine("Ping functionality not implemented yet.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "IP Config":
                    Console.WriteLine("IP Config functionality not implemented yet.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Network Scan":
                    Console.WriteLine("Network Scan functionality not implemented yet.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Back":
                    break;
            }
        }

        private static void SettingsMenu()
        {
            string[] settingsMenuItems = { "Change Theme", "Change Password", "System Update", "Back" };
            int selectedIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Settings");
                Console.WriteLine("========");

                for (int i = 0; i < settingsMenuItems.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(settingsMenuItems[i]);
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : settingsMenuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < settingsMenuItems.Length - 1) ? selectedIndex + 1 : 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    HandleSettingsMenuSelection(settingsMenuItems[selectedIndex]);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void HandleSettingsMenuSelection(string selectedItem)
        {
            switch (selectedItem)
            {
                case "Change Theme":
                    Console.Write("Enter theme color (blue, green, red): ");
                    string color = Console.ReadLine();
                    CommandHandler.ChangeTheme(color);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Change Password":
                    Console.WriteLine("Change Password functionality not implemented yet.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "System Update":
                    Console.WriteLine("System Update functionality not implemented yet.");
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                case "Back":
                    break;
            }
        }
    }
}