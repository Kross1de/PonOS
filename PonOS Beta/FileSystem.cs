using System;
using System.Collections.Generic;

namespace CosmosOS
{
    public static class FileSystem
    {
        private static Dictionary<string, string> files = new Dictionary<string, string>();
        private static Dictionary<string, List<string>> directories = new Dictionary<string, List<string>>();
        private static string currentDirectory = "/";

        public static void Initialize()
        {
            // Инициализация файловой системы в оперативной памяти
            files.Clear();
            directories.Clear();
            currentDirectory = "/";
        }

        public static void CreateFile(string name, string content)
        {
            files[GetFullPath(name)] = content;
            Console.WriteLine($"File '{name}' created.");
        }

        public static void ReadFile(string name)
        {
            string fullPath = GetFullPath(name);
            if (files.ContainsKey(fullPath))
            {
                Console.WriteLine($"Content of '{name}':");
                Console.WriteLine(files[fullPath]);
            }
            else
            {
                Console.WriteLine($"File '{name}' not found.");
            }
        }

        public static void DeleteFile(string name)
        {
            string fullPath = GetFullPath(name);
            if (files.Remove(fullPath))
            {
                Console.WriteLine($"File '{name}' deleted.");
            }
            else
            {
                Console.WriteLine($"File '{name}' not found.");
            }
        }

        public static void CreateDirectory(string name)
        {
            string fullPath = GetFullPath(name);
            if (!directories.ContainsKey(fullPath))
            {
                directories[fullPath] = new List<string>();
                Console.WriteLine($"Directory '{name}' created.");
            }
            else
            {
                Console.WriteLine($"Directory '{name}' already exists.");
            }
        }

        public static void DeleteDirectory(string name)
        {
            string fullPath = GetFullPath(name);
            if (directories.Remove(fullPath))
            {
                Console.WriteLine($"Directory '{name}' deleted.");
            }
            else
            {
                Console.WriteLine($"Directory '{name}' not found.");
            }
        }

        public static void ListContents()
        {
            Console.WriteLine($"Contents of directory '{currentDirectory}':");
            foreach (var dir in directories)
            {
                if (dir.Key.StartsWith(currentDirectory))
                {
                    Console.WriteLine($"[DIR] {dir.Key}");
                }
            }

            foreach (var file in files)
            {
                if (file.Key.StartsWith(currentDirectory))
                {
                    Console.WriteLine($"[FILE] {file.Key}");
                }
            }
        }

        public static void ChangeDirectory(string path)
        {
            if (path == "..")
            {
                if (currentDirectory != "/")
                {
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf('/'));
                }
            }
            else if (directories.ContainsKey(GetFullPath(path)))
            {
                currentDirectory = GetFullPath(path);
            }
            else
            {
                Console.WriteLine($"Directory '{path}' not found.");
            }
        }

        public static void MoveFile(string source, string destination)
        {
            string sourcePath = GetFullPath(source);
            string destPath = GetFullPath(destination);

            if (files.ContainsKey(sourcePath))
            {
                files[destPath] = files[sourcePath];
                files.Remove(sourcePath);
                Console.WriteLine($"File '{source}' moved to '{destination}'.");
            }
            else
            {
                Console.WriteLine($"File '{source}' not found.");
            }
        }

        public static void CopyFile(string source, string destination)
        {
            string sourcePath = GetFullPath(source);
            string destPath = GetFullPath(destination);

            if (files.ContainsKey(sourcePath))
            {
                files[destPath] = files[sourcePath];
                Console.WriteLine($"File '{source}' copied to '{destination}'.");
            }
            else
            {
                Console.WriteLine($"File '{source}' not found.");
            }
        }

        public static void FindFile(string name)
        {
            foreach (var file in files)
            {
                if (file.Key.Contains(name))
                {
                    Console.WriteLine($"[FILE] {file.Key}");
                }
            }
        }

        public static string ReadFileContent(string name)
        {
            string fullPath = GetFullPath(name);
            if (files.ContainsKey(fullPath))
            {
                return files[fullPath];
            }
            else
            {
                return null;
            }
        }

        public static bool FileExists(string name)
        {
            string fullPath = GetFullPath(name);
            return files.ContainsKey(fullPath);
        }

        private static string GetFullPath(string name)
        {
            return currentDirectory + "/" + name;
        }
    }
}