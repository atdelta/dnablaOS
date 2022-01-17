using System;
using System.Collections.Generic;
using System.Text;

namespace kocmoc.Programs
{
    class Utils
    {
        public static void Launch()
        {
            MainLoop();
        }
        static void MainLoop()
        {
            Kernel.VariableAdd("1", "Char. counter");
            Kernel.VariableAdd("2", "+");
            Kernel.VariableAdd("3", "-");
            Kernel.VariableAdd("4", "x");
            Kernel.VariableAdd("5", ":");
        }
    }
}
