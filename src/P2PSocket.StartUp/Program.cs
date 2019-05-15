using System;
using System.Reflection;
using System.IO;
using System.Threading;

namespace P2PSocket.StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            string m_PathClient = $@"{AppDomain.CurrentDomain.BaseDirectory}P2PSocket\netstandard2.0\P2PSocket.Client.dll";
            string m_PathServer = $@"{AppDomain.CurrentDomain.BaseDirectory}P2PSocket\netstandard2.0\P2PSocket.Server.dll";
            if (File.Exists(m_PathServer))
            {
                //Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "/P2PSocket/P2PSocket.Server.dll");
                Assembly assembly = Assembly.LoadFrom(m_PathServer);
                assembly = AppDomain.CurrentDomain.Load(assembly.FullName);
                object obj = assembly.CreateInstance("P2PSocket.Server.CoreModule");
                MethodInfo method = obj.GetType().GetMethod("Start");
                method.Invoke(obj, null);
                flag = true;
            }
            if (File.Exists(m_PathClient))
            {
                Assembly assembly = Assembly.LoadFrom(m_PathClient);
                assembly = AppDomain.CurrentDomain.Load(assembly.FullName);

                object obj = assembly.CreateInstance("P2PSocket.Client.CoreModule");
                MethodInfo method = obj.GetType().GetMethod("Start");
                method.Invoke(obj, null);
                flag = true;
            }
            if (flag)
            {
                while (true)
                {
                    Thread.Sleep(10000);
                }
            }
            else
            {
                Console.WriteLine("未找到P2PSocket客户端或服务端dll文件.");
                Thread.Sleep(10000);
            }
        }
    }
}
