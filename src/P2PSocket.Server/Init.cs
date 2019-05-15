using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using P2PSocket.Server;

namespace P2PSocket.Server.Ini
{
    public class Init
    {
        public static bool  InitClient()
        {
            try
            {
                if (!File.Exists(Global.ConfigFile))
                {
                    System.IO.File.WriteAllText(Global.ConfigFile, $@"
#服务端设置
[Common]
Port=3488

[PortMapItem]
6020->[home]:6020
6021->[home]:21
", Encoding.UTF8);
                }

                return true;
            }
            catch (Exception )
            {
                return false;
            }
         
        }

    }
}
