using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P2PSocket.Client.Ini
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
#客户端设置
[Common]
#服务器地址
ServerAddress=127.0.0.1:3488
#客户端名称
ClientName=home
#允许被映射的本地端口
AllowPort=6020

[PortMapItem]
6021->127.0.0.1:3389
6020->192.168.0.150:33089
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
