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
                    System.IO.File.WriteAllText(Global.ConfigFile, 
$@"#客户端设置
[Common]
#服务器地址
ServerAddress=118.24.71.235:3488
#客户端名称
ClientName=xc
#允许被映射的本地端口
AllowPort=6020

[PortMapItem]
6020->192.168.0.150:33089
6021->127.0.0.1:33089
6022->127.0.0.1:1435
6023->127.0.0.1:1433
6024->127.0.0.1:21
4022->127.0.0.1:4022
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
