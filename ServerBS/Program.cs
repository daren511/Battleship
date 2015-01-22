using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerBS
{
    class Program
    {

        static byte[] Buffer { get; set; }
        static Socket sckserver;
        static Socket sck1;
        static Socket sck2;

        /// <summary
        /// Retourne une réponse si le socket retoune un état actif
        ///  Intrants : 
        ///         Socket s - Socket du joueur
        ///         
        ///  Extrants : Retourne létat le bool 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool SocketConnected(Socket s)
        {
            return !(s.Poll(1000, SelectMode.SelectRead) && s.Available == 0);
        }

        static void Main(string[] args)
        {
            sckserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sckserver.Bind(new IPEndPoint(0, 0021));
            sckserver.Listen(100);
            Console.WriteLine("Serveur en attente de connexion");
            int i = 1;
            while (true)
            {
                // Accepte la connexion de joueur1
                if (sck1 == null)
                {
                    sck1 = sckserver.Accept();
                }
                // Accepte la connexion de joueur2
                if (sck2 == null)
                {
                    sck2 = sckserver.Accept();
                }
                // Si les 2 sockets sont connecté
                if (SocketConnected(sck1) && SocketConnected(sck2))
                {
                    new Partie(sck1, sck2).T.Start();

                    Console.WriteLine("Partie Debuté entre : " + (sck1.RemoteEndPoint as IPEndPoint).Address + " et " + (sck2.RemoteEndPoint as IPEndPoint).Address + " Partie: " + i.ToString());
                    ++i;
                    sck1 = null;
                    sck2 = null;
                }

                else if (!SocketConnected(sck1))
                {
                    sck1 = null;
                }
                else
                {
                    sck2 = null;
                }

            }
        }
    }
}
