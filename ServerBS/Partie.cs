using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using BattleShipDLL;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace ServerBS
{
    class Partie
    {
        public Thread T;
        Socket Joueur1;
        Socket Joueur2;
        Flotte Flotte1 = null;
        Flotte Flotte2 = null;
        public Partie(Socket sck1, Socket sck2)
        {
            T = new Thread(new ThreadStart(Run));
            Joueur1 = sck1;
            Joueur2 = sck2;
        }
        /// <summary>
        ///     Run() est la fonction principale pour jouer . 
        /// </summary>
        public void Run()
        {
            try
            {
                // Lecture des bateaux
                Flotte1 = readBateau(Joueur1);
                Flotte2 = readBateau(Joueur2);

                // Envoie de la position des joueurs
                envoyerReponse("1 " + (Joueur2.RemoteEndPoint as IPEndPoint).Address, Joueur1);
                envoyerReponse("2 " + (Joueur1.RemoteEndPoint as IPEndPoint).Address, Joueur2);

                //Boucle de jeu
                while (!Flotte1.FlotteEstMorte() && !Flotte2.FlotteEstMorte() && ServerBS.Program.SocketConnected(Joueur1) && ServerBS.Program.SocketConnected(Joueur2))
                {
                    envoyerReponse(traiterAttaque(recevoirAttaque(Joueur1), Flotte2.flotte));
                    if (!Flotte2.FlotteEstMorte()) envoyerReponse(traiterAttaque(recevoirAttaque(Joueur2), Flotte1.flotte));
                }
                // Fermeture des sockets joueurs
                Joueur1.Close();
                Joueur2.Close();
            }
            catch(Exception e)
            {
                
            }
        }
        /// <summary>
        ///  Envoie d'une information spécifique de touché à un joueur associé a son socket
        ///  Intrants : 
        ///         string texte - Represente la chaine de caracteres à envoyer
        ///         Socket sck   - Le socket de joueur mis en paramètre
        ///  Extrants : -
        /// </summary>
        /// <param name="toucher"></param>
        /// <param name="sck"></param>
        private void envoyerReponse(string texte, Socket sck)
        {
            byte[] data = Encoding.ASCII.GetBytes(texte);

            sck.Send(data);
        }
        /// <summary>
        /// Envoie d'information aux 2 joueurs
        ///  Intrants : 
        ///         string toucher - Represente la chaine de caracteres à envoyer
        ///  Extrants : -
        /// </summary>
        /// <param name="toucher"></param>
        private void envoyerReponse(string texte)
        {
            byte[] data1;
            byte[] data2;
            // Si telle flotte est morte , le joueur x a gagné
            if (Flotte1.FlotteEstMorte())
            {
                data1 = Encoding.ASCII.GetBytes(texte + " 0");
                data2 = Encoding.ASCII.GetBytes(texte + " 1");
            }
            // Si telle flotte est morte , le joueur x a gagné
            else if (Flotte2.FlotteEstMorte())
            {
                data1 = Encoding.ASCII.GetBytes(texte + " 1");
                data2 = Encoding.ASCII.GetBytes(texte + " 0");
            }
            // Envoie normale d'information d'attaque
            else
            {
                data1 = Encoding.ASCII.GetBytes(texte);
                data2 = Encoding.ASCII.GetBytes(texte);
            }
            // Envoie des informations finales
            Joueur1.Send(data1);
            Joueur2.Send(data2);

        }

        /// <summary>
        /// Fonction appellée dans la boucle principale de jeu qui traite la reception de l'atttaque de la flotte oppposée
        ///  Intrants : 
        ///         string atck - Represente la chaine de caracteres à envoyer
        ///         List<Navire> f   - Le socket de joueur mis en paramètre
        ///
        ///  Extrants : String le bool si touché + position || string bool si touché et coulé avec le nom du beteau
        /// </summary>
        /// <param name="atck"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private string traiterAttaque(string atck, List<Navire> f)
        {
            string[] tab = atck.Split(' ');
            Point pt = new Point(Int32.Parse(tab[0]), Int32.Parse(tab[1]));
            bool toucher = false;
            for (int i = 0; i < f.Count && !toucher; ++i)
            {
                // Si f position i contient le point
                if (f[i]._coords.Contains(pt))
                {
                    bool fin = false;
                    for (int j = 0; j < f[i]._isAlive.Length && !fin; ++j)
                    {
                        // Si vivant
                        if (f[i]._isAlive[j])
                        {
                            f[i]._isAlive[j] = false;
                            fin = true;
                            // Si mort
                            if (!f[i].NavireVivant())
                            {
                                toucher = !toucher;
                                return toucher.ToString() + " " + atck + " " + f[i]._nom;
                            }
                        }
                    }
                    toucher = !toucher;
                }
            }
            return toucher.ToString() + " " + atck;
        }
        /// <summary>
        /// Le joueur est en mode reception en attente de l'attaque de l'ennemi
        ///  Intrants : Recois le socket associé au joueur lors de l'utilisation  
        ///
        ///  Extrants : Retourne le string de la position
        /// </summary>
        /// <param name="Joueur"></param>
        /// <returns></returns>
        private string recevoirAttaque(Socket Joueur)
        {
            string atck;
            byte[] buffer = new byte[Joueur.SendBufferSize];
            int bytesRead = Joueur.Receive(buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }

            atck = Encoding.ASCII.GetString(formatted);

            return atck;
        }
        /// <summary>
        /// Fonction qui lit les bateaux des 2 opposants
        ///  Intrants : Recoit le socket associé au joueur lors de l'utilisation  
        ///
        ///  Extrants : Retourne la flotte de bateau
        /// </summary>
        /// <param name="Joueur"></param>
        /// <returns></returns>
        private Flotte readBateau(Socket Joueur)
        {
            Flotte flotte = null;
            byte[] buffer = new byte[Joueur.SendBufferSize];
            int bytesRead = Joueur.Receive(buffer);
            byte[] formatted = new byte[bytesRead];
            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }
            BinaryFormatter receive = new BinaryFormatter();
            using (var recstream = new MemoryStream(formatted))
            {
                flotte = receive.Deserialize(recstream) as Flotte;
            }

            return flotte;
        }
    }
}
