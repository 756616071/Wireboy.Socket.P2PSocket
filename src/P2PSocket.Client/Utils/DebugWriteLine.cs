﻿using P2PSocket.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace P2PSocket.Client
{
    public static class Debug
    {
        public static void WriteLine(string str,bool  IsShow=false)
        {
            if (IsShow)
            {
                ConsoleUtils.WriteLine(str);
            }
        }
    }
}
