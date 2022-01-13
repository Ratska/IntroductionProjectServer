using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionProjectServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
            if(_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            //send player into game
        }

        public static void MessageReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _message = _packet.ReadString();
            Console.WriteLine($"Player {_clientIdCheck}: {_message}");
            ServerSend.SendTCPDataToAll(_packet);
        }

    }
}
