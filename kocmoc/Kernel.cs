using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using Figgle;
using Sys = Cosmos.System;

namespace kocmoc
{
    public class Kernel : Sys.Kernel
    {
        string UserName = "Default";
        Sys.FileSystem.CosmosVFS fs;
        string current_directory = "0:\\";

        protected override void BeforeRun()
        {
            Sys.FileSystem.CosmosVFS fs;
            string current_directory = "0:\\";
            Console.WriteLine("      ::::::::: :::    :::  :::   :::  :::::::::     :::     ::::::::  ::::::::  ::::::::  ::::::::");
            Console.WriteLine("     :+:    :+::+:    :+: :+:+: :+:+: :+:    :+:  :+: :+:  :+:    :+::+:    :+::+:    :+::+:    :+:");
            Console.WriteLine("    +:+    +:++:+    +:++:+ +:+:+ +:++:+ +:+    +:+  +:+  +:+     :+        +:+       +:++:+");
            Console.WriteLine("   +#+    +:++#+    +:++#+  +:+  +#++#++:++#+ +#++:++#++:+#++:++#+++#++:++#+++#+    +:++#++:++#++");
            Console.WriteLine("  +#+    +#++#+    +#++#+       +#++#+    +#++#+     +#+       +#+       +#++#+    +#+       +#+");
            Console.WriteLine(" #+#    #+##+#    #+##+#       #+##+#    #+##+#     #+##+#    #+##+#    #+##+#    #+##+#    #+#");
            Console.WriteLine("#########  ######## ###       ############ ###     ### ########  ########  ########  ########");


        }

        protected override void Run()
        {
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
        }
    }
}
