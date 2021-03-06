﻿using P2PSocket.Core.Commands;
using P2PSocket.Core.Models;
using P2PSocket.Client.Models.Send;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P2PSocket.Client.Commands
{
    [CommandFlag(Core.P2PCommandType.P2P0x0212)]
    public class Port2PTransferCommand : P2PCommand
    {
        readonly P2PTcpClient m_tcpClient;
        BinaryReader m_data { get; }
        public Port2PTransferCommand(P2PTcpClient tcpClient, byte[] data)
        {
            m_tcpClient = tcpClient;
            m_data = new BinaryReader(new MemoryStream(data));
        }
        public override bool Excute()
        {
            if (m_data.ReadBoolean())
            {
                //Port->Client
                Debug.WriteLine("Port->Client");
                Port2PPacket sendPacket = new Port2PPacket(m_data.ReadBytes((int)(m_data.BaseStream.Length - m_data.BaseStream.Position)));
                m_tcpClient.ToClient.Client.Send(sendPacket.PackData());
            }
            else
            {
                //Server->Client
                Debug.WriteLine("Server->Client");
                P2PortPacket sendPacket = new P2PortPacket(m_data.ReadBytes((int)(m_data.BaseStream.Length - m_data.BaseStream.Position)));
                m_tcpClient.ToClient.Client.Send(sendPacket.PackData());
            }
            return true;
        }
    }
}
