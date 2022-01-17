using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using kocmoc.ErrorHandle;
using kocmoc.Programs;
using Sys = Cosmos.System;

namespace kocmoc
{
    public class Kernel : Sys.Kernel
    {
        string UserName = "Default";
        Sys.FileSystem.CosmosVFS fs;
        string current_directory = "0:\\";
        string whdx = String.Empty;

        protected override void BeforeRun()
        {
            Sys.FileSystem.CosmosVFS fs;
            string current_directory = "0:\\";
            Console.WriteLine("DUMBASSOS");


        }

        protected override void Run()
        {
            string[] dirs = GetDirFadr(current_directory);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(UserName);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;
            var input = Console.ReadLine();
            if (input == "clear")
            {
                Console.Clear();
            }
            else if (input.StartsWith("cun "))
            {
                UserName = input.Remove(0, 4);
            }
            else if (input.StartsWith("echo "))
            {
                Console.WriteLine(input.Remove(0, 5));
            }
            else if (input == "sysver")
            {
                Console.WriteLine("System Name: dumbassOS");
                Console.WriteLine("System Version: v0.1.0");
                Console.WriteLine("Codename: CTEPBA (idkwhylol)");
                Console.WriteLine("User: {0}", UserName);
            }
            else if (input == "ls")
            {
                foreach (var item in dirs)
                {
                    Console.WriteLine(item);
                }
            }
            else if (input == "help")
            {
                Console.WriteLine("-=Help=-");
                Console.WriteLine("help - outputs this message");
                Console.WriteLine("echo [text] - shows your text after command");
                Console.WriteLine("cun - Change UserName");
                Console.WriteLine("sysver - about system");
                Console.WriteLine("utils - small dev utils");
            }
        }

        public static void VariableAdd(string comusa, string whatdoes)
        {
            Console.WriteLine(comusa + " - " + whatdoes);
        } 

        private string[] GetDirFadr(string adr) // Get Directories From Address
        {
            var dirs = Directory.GetDirectories(adr);
            return dirs;
        }
    }
}
