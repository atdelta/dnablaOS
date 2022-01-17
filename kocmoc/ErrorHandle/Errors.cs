using System;
using System.Collections.Generic;
using System.Text;

namespace kocmoc.ErrorHandle
{
    class Errors
    {
        public static string SystemError
        {
            get
            {
                return "Error! SystemException: Command not found. Error Code: 100";
            }
        }
        public static string IOException
        {
            get
            {
                return "Error! IOException: Directory not found";
            }
        }
        public static string IOFilestreamException
        {
            get
            {
                return "Error! IOException: File not found";
            }
        }
    }
}
