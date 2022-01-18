using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using kocmoc.ErrorHandle;
using kocmoc.Programs;
using Cosmos.System.Graphics;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Sys = Cosmos.System;

namespace kocmoc
{
    public class Kernel : Sys.Kernel
    {
        public static VGAScreen VScreen = new VGAScreen();
        string UserName = "Default";
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        string current_directory = "0:\\";
        string whdx = String.Empty;
        

        protected override void BeforeRun()
        {
            Console.WriteLine("Vga Driver Booting");
            VGAScreen.SetGraphicsMode(VGADriver.ScreenSize.Size720x480, ColorDepth.ColorDepth32);
            Console.WriteLine("Vga Driver Booted");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Directory.CreateDirectory("fank");
            File.Create("0:\\re.txt");
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
                Console.WriteLine("-=Files Help=-");
                Console.WriteLine("ls - list of files");
                Console.WriteLine("mkdir [foldername] - makes folder");
            }
            else if (input.StartsWith("mkdir "))
            {
                Directory.CreateDirectory(current_directory + input.Remove(0, 6));
            }
            else if (input.StartsWith("cd "))
            {
                bool isDirExist = Directory.Exists(current_directory + input.Remove(0, 3));
                try
                {
                    if (isDirExist == true)
                    {
                        current_directory = current_directory + input.Remove(0, 3);
                    }
                    else if (input.Remove(0, 3) == "0:\\")
                    {
                        current_directory = "0:\\";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else if (input.StartsWith("touch "))
            {
                string path = current_directory + input.Remove(0, 6);
                File.Create(path);
            }
            else if (input == "shutdown")
            {
                Sys.Power.Shutdown();
            }
            else if (input == "reboot")
            {
                Sys.Power.Reboot();
            }
            else if (input.StartsWith("cat "))
            {
                string file = input.Remove(0, 4);
                var content = File.ReadAllText(file);
                Console.WriteLine("File Name: {0} \nFile size: {1} \nFile Content: \n{2}", file, content.Length, content);
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
