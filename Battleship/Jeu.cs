using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using BattleShipDLL;


namespace Battleship
{
    public partial class Jeu : Form
    {
        // ---------- CONSTANTES ---------- //
        const int NB_COLONNES = 10;
        const string LETTRES = "ABCDEFGHIJ";    // Pour la grille

        // Bateaux
        const string SHIP_1 = "Porte-Avions";
        const string SHIP_2 = "Croiseur";
        const string SHIP_3 = "Contre-Torpilleur";
        const string SHIP_4 = "Sous-Marin";
        const string SHIP_5 = "Torpilleur";

        // ---------- VARIABLES ---------- //
        private string ordre = "";
        private bool over = false;
        private static Socket sck;

        // IP
        private string ip = "172.17.104.126";   // Laptop Daren
        //private string ip = "172.17.104.104";   // PC Charles

        // Port
        private int port = 0021;
        private IPEndPoint localEndPoint;

        // Sélections
        private int _maxSelection = 5;
        private int _selectedRow = -1;
        private int _selectedColumn = -1;

        // Navires & coordonnées
        private List<Navire> _navires = new List<Navire>();
        private List<int> _shipsCoords = new List<int>();
        private Flotte flotte = null;

        public Jeu()
        {
            InitializeComponent();

            Initialize_DGV(DGV_Placements);     // Pour initialiser le DGV du joueur
            Initialize_DGV(DGV_Attaques);       // Pour initialiser le DGV du joueur ennemi
        }

        //
        // Fermer l'application à partir du menu
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        // Fermer l'application à partir du Windows Form
        private void Jeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Confirmation;
            Confirmation = MessageBox.Show("Voulez-vous vraiment quittez ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Confirmation != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        //
        // Initialise le DGV du joueur
        private void Initialize_DGV(DataGridView dgv)
        {
            dgv.RowCount = NB_COLONNES;     // [NB_COLONNES] == 10
            dgv.ColumnCount = NB_COLONNES;

            for (int i = 0; i < NB_COLONNES; ++i)   // Créer les lignes du DGV
            {
                dgv.Rows[i].Height = 20;
                dgv.RowHeadersWidth = 50;
                dgv.Rows[i].HeaderCell.Value = LETTRES[i].ToString();   // Afficher les lettres

                for (int j = 0; j < NB_COLONNES; ++j)   // Créer les colonnes du DGV
                {
                    dgv.Columns[i].Width = 20;
                    dgv.Columns[i].HeaderCell.Value = i.ToString();
                }
            }
        }

        //
        // Affecte la sélection maximale selon la variable en paramètre
        private void SetMaxSelection(int value)
        {
            _maxSelection = value;
        }

        //
        // Envoie la position d'attaque au serveur
        private void Attaque()
        {
            int row = DGV_Attaques.SelectedCells[0].RowIndex;               // Ligne sélectionnée
            int column = DGV_Attaques.SelectedCells[0].ColumnIndex;         // Colonne sélectionnée
            string dataString = row.ToString() + " " + column.ToString();   // Convertissement des coordonnées en string
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(dataString);
                sck.Send(data);     // Envoie les coordonnées (string) au serveur
            }
            catch (SocketException e)
            {
                MessageBox.Show("Connexion Perdue!");
            }
        }

        //
        // Traite les informations après une attaque (joueur courant ou ennemi)
        private void TraiterResultatsAttaque(DataGridView dgv, string position, bool ok)
        {
            string[] table = position.Split(' ');
            bool hit = table[0] == "True" ? true : false;   // Si table[0] == True, c'est au tour du joueur courant
            int row = Int32.Parse(table[1]);    // Obtient la ligne
            int col = Int32.Parse(table[2]);    // Obtient la colonne

            if (hit)    // Si un bateau a été touché
            {
                dgv.Rows[row].Cells[col].Style.BackColor = Color.Red;   // Change la couleur de la case

                if (table.Length > 3)   // Si un bateau a été coulé
                {
                    if (dgv == DGV_Placements)  // Pour vérifier si c'est le joueur courant qui a attaqué
                        MessageBox.Show("Votre " + table[3] + " a coulé!");
                    else      // Sinon c'est l'ennemi qui a attaqué
                        MessageBox.Show("Vous avez coulé le " + table[3] + " ennemi!");
                    if (table.Length == 5)  // La partie est terminée
                    {
                        DGV_Attaques.Enabled = false;
                        over = true;
                        if (table[4] == "1")    // Le joueur courant a gagné la partie
                            MessageBox.Show("Félicitations! Vous avez gagné!");
                        else          // L'ennemi a gagné la partie
                            MessageBox.Show("Désolé! Vous avez perdu!");
                        if (sck.Connected)
                            sck.Close();    // Ferme le socket s'il est activé

                        Jeu.ActiveForm.Text = "Partie Terminée";
                        LBL_TurnTag.Text = "";
                    }
                }
            }
            else     // Sinon, on met la case blanche (coup manqué)
            {
                dgv.Rows[row].Cells[col].Style.BackColor = Color.White;
            }
            if (!over)  // Si la partie n'est pas finie
            {
                DGV_Attaques.Enabled = ok;  // Le boutton d'attaque change d'état
                if (ok)     // Si c'est au tour du joueur, change le texte
                    LBL_TurnTag.Text = "C'est à vous!";
            }
            this.Refresh();     // Rafraîchit la fenêtre
        }

        //
        // Connecte le joueur au serveur
        private void Connect()
        {
            try
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // Initialise un nouveau socket
                localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);      // Initialise un nouveau network endpoint avec l'IP et le port

                Cursor = Cursors.WaitCursor;
                sck.Connect(localEndPoint);     // Connecte le joueur au socket

                BTN_Place.Enabled = false;
                BTN_Valider.Enabled = false;
                DGV_Placements.Enabled = false;
                BTN_Reset.Enabled = false;

                DGV_Attaques.Enabled = true;

                SendShips();    // Envoie la flotte du joueur au serveur
            }
            catch (SocketException ex)      // Erreur de connexion
            {
                MessageBox.Show("Erreur de connexion: " + ex.Message.ToString(), "Erreur", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                Reset();    // Réinitialise l'application
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }

        //
        // Envoie la flotte du joueur au serveur
        private void SendShips()
        {
            BinaryFormatter b = new BinaryFormatter();  // Création d'un tableau de byte
            using (var stream = new MemoryStream())     // Encrypter ou désencrypter la flotte de navires
            {
                b.Serialize(stream, flotte);    // Sérialise la flotte du joueur
                sck.Send(stream.ToArray());     // Envoie les données au serveur
            }
            BTN_Send.Enabled = false;
        }

        //
        // Reçoit les informations du serveur
        private string Recevoir()
        {
            string msg;
            byte[] buffer = new byte[sck.SendBufferSize];
            int bytesRead = sck.Receive(buffer);
            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; ++i)
            {
                formatted[i] = buffer[i];
            }
            msg = Encoding.ASCII.GetString(formatted);

            return msg;
        }

        //
        // Retourne le nom du bateau
        private string GetShip()
        {
            string ship = GB_Navires.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            return ship.Split(' ')[0];
        }

        //
        // Place les bateaux du joueur
        private void PlaceShip()
        {
            List<Point> coords = new List<Point>();     // Liste de coordonnées
            string shipName = GetShip();    // Obtenir le nom du bateau
            Color shipTrace = ColorShipTrace(shipName);     // Met la couleur appropriée selon le bateau

            if (_navires.Count < 5)     // Tant que le joueur peut placer des bateaux
            {
                for (int i = 0; i < DGV_Placements.SelectedCells.Count; ++i)
                {
                    coords.Add(new Point(DGV_Placements.SelectedCells[i].RowIndex, DGV_Placements.SelectedCells[i].ColumnIndex));   // Ajoute les coordonnées à la liste
                    DGV_Placements.SelectedCells[i].Style.BackColor = shipTrace;    // Change la couleur des cases où le bateau est situé
                }
                _navires.Add(new Navire(shipName, coords));     // Ajoute le navire à la liste de navires
            }
            flotte = new Flotte(_navires);      // Création d'une nouvelle flotte

            // Retourne le RadioButton qui est coché dans le GroupBox
            var checkedShip = GB_Navires.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            checkedShip.Enabled = false;

            for (int i = 0; i < GB_Navires.Controls.Count; ++i)
            {
                if (GB_Navires.Controls[i].Enabled == true)
                    GB_Navires.Controls[i].Focus();
            }
            DGV_Placements.ClearSelection();
            CheckReady();   // Vérifie si le joueur peut commencer la partie
        }

        //
        // Colorie les cases selon le bateau
        private Color ColorShipTrace(string shipName)
        {
            Color color = Color.Black;

            switch (shipName)
            {
                case SHIP_1:
                    color = Color.DarkGray;
                    break;
                case SHIP_2:
                    color = Color.LightGray;
                    break;
                case SHIP_3:
                    color = Color.LightSlateGray;
                    break;
                case SHIP_4:
                    color = Color.Gray;
                    break;
                case SHIP_5:
                    color = Color.DarkSlateGray;
                    break;
            }
            return color;
        }

        //
        // Vérifie si le joueur peut comencer la partie
        private void CheckReady()
        {
            bool ready = _navires.Count == 5;

            BTN_Valider.Enabled = ready;
            DGV_Placements.Enabled = !ready;
        }

        //
        // Réinitialise le Form (nouvelle partie)
        private void Reset()
        {
            for (int i = 0; i < GB_Navires.Controls.Count; ++i)
                GB_Navires.Controls[i].Enabled = true;

            for (int i = 0; i < DGV_Placements.Rows.Count; ++i)
            {
                for (int j = 0; j < DGV_Placements.Rows[i].Cells.Count; ++j)
                {
                    DGV_Placements.Rows[i].Cells[j].Style.BackColor = DGV_Placements.DefaultCellStyle.BackColor;
                    DGV_Attaques.Rows[i].Cells[j].Style.BackColor = DGV_Attaques.DefaultCellStyle.BackColor;
                }
            }

            BTN_Valider.Enabled = false;
            DGV_Placements.Enabled = true;
            BTN_Send.Enabled = false;
            BTN_Reset.Enabled = true;
            over = false;

            Jeu.ActiveForm.Text = "Nouvelle partie";
            _shipsCoords.Clear();
            _navires.Clear();
        }

        //
        // Vérifie si le joueur essaie de placer un bateau sur un autre bateau
        private Point CheckSelection()
        {
            List<Point> selection = new List<Point>();

            for (int i = 0; i < DGV_Placements.SelectedCells.Count; ++i)
                selection.Add(new Point(DGV_Placements.SelectedCells[i].RowIndex, DGV_Placements.SelectedCells[i].ColumnIndex));

            for (int i = 0; i < _navires.Count; ++i)
            {
                for (int j = 0; j < selection.Count; ++j)
                    if (_navires[i]._coords.Contains(selection[j])) return selection[j];
            }
            return new Point(-1, -1);
        }

        //
        // Affiche le Form pour changer de connexion
        private void ChangeConnectionSettings()
        {
            Form_Settings form = new Form_Settings();
            form.ip = this.ip;
            form.port = this.port;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ip = form.ip;
                port = form.port;
            }
        }

        //
        // Corrige la sélection de placement d'un bateau
        private bool CheckSelectionLength()
        {
            bool ok = true;

            if (DGV_Placements.SelectedCells.Count == _maxSelection)
            {
                if (DGV_Placements.SelectedCells[1].RowIndex > DGV_Placements.SelectedCells[0].RowIndex)
                    if (DGV_Placements.SelectedCells[0].RowIndex + _maxSelection - 1 < DGV_Placements.SelectedCells[DGV_Placements.SelectedCells.Count - 1].RowIndex)
                        ok = false;
                if (DGV_Placements.SelectedCells[1].RowIndex < DGV_Placements.SelectedCells[0].RowIndex)
                    if (DGV_Placements.SelectedCells[0].RowIndex - _maxSelection + 1 > DGV_Placements.SelectedCells[DGV_Placements.SelectedCells.Count - 1].RowIndex)
                        ok = false;
                if (DGV_Placements.SelectedCells[1].ColumnIndex > DGV_Placements.SelectedCells[0].ColumnIndex)
                    if (DGV_Placements.SelectedCells[0].ColumnIndex + _maxSelection - 1 < DGV_Placements.SelectedCells[DGV_Placements.SelectedCells.Count - 1].ColumnIndex)
                        ok = false;
                if (DGV_Placements.SelectedCells[1].ColumnIndex < DGV_Placements.SelectedCells[0].ColumnIndex)
                    if (DGV_Placements.SelectedCells[0].ColumnIndex - _maxSelection + 1 > DGV_Placements.SelectedCells[DGV_Placements.SelectedCells.Count - 1].ColumnIndex)
                        ok = false;
            }
            return ok;
        }

        //
        // Oriente la sélection (choisir juste une colonne ou une rangée)
        private void DGV_Placements_SelectionChanged(object sender, EventArgs e)
        {
            Point coords = CheckSelection();

            if (DGV_Placements.SelectedCells.Count == 0)
            {
                _selectedRow = -1;
                _selectedColumn = -1;
            }
            if (DGV_Placements.SelectedCells.Count > _maxSelection)
                DGV_Placements.SelectedCells[0].Selected = false;
            if (coords.X != -1)
                DGV_Placements.ClearSelection();
            if (DGV_Placements.SelectedCells.Count <= _maxSelection && DGV_Placements.SelectedCells.Count > 0)
            {
                _selectedRow = DGV_Placements.SelectedCells[0].RowIndex;
                _selectedColumn = DGV_Placements.SelectedCells[0].ColumnIndex;
            }
            if (DGV_Placements.SelectedCells.Count == _maxSelection)
                BTN_Place.Enabled = true;
            else
                BTN_Place.Enabled = false;

            // Pour toutes les sélections dans les cases du DGV, on vérifie l'axe des bateaux
            foreach (DataGridViewCell cell in DGV_Placements.SelectedCells)
            {
                if (cell.RowIndex == _selectedRow)
                {
                    if (cell.ColumnIndex != _selectedColumn)
                        _selectedColumn = -1;
                }
                else if (cell.ColumnIndex == _selectedColumn)
                {
                    if (cell.RowIndex != _selectedRow)
                        _selectedRow = -1;
                }
                // Sinon, on désélectionne
                else
                    cell.Selected = false;
            }
        }

        //
        // Limite la sélection à un certain nombre de cases
        private void RB_PorteAvions_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxSelection(5);
        }

        //
        // Limite la sélection à un certain nombre de cases
        private void RB_Croiseur_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxSelection(4);
        }

        //
        // Limite la sélection à un certain nombre de cases
        private void RB_ContreTorpilleur_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxSelection(3);
        }

        //
        // Limite la sélection à un certain nombre de cases
        private void RB_SousMarin_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxSelection(3);
        }

        //
        // Limite la sélection à un certain nombre de cases
        private void RB_Torpilleur_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxSelection(2);
        }

        //
        // Réinitialise le Form
        private void BTN_Reset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //
        // Place le bateau sélectionné
        private void BTN_Place_Click(object sender, EventArgs e)
        {
            PlaceShip();
        }

        //
        // Connecte le joueur au serveur et démarre la partie
        private void BTN_Valider_Click(object sender, EventArgs e)
        {
            Connect();

            if (sck.Connected)
            {
                string[] table = Recevoir().Split(' ');
                ordre = table[0];

                Jeu.ActiveForm.Text = "Partie en cours avec : " + table[1];

                if (ordre == "1")
                    BTN_Send.Enabled = true;
                else
                {
                    TraiterResultatsAttaque(DGV_Placements, Recevoir(), true);
                    DGV_Attaques.ClearSelection();
                }
            }
        }

        //
        // Ouvre le Form pour changer de connexion
        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeConnectionSettings();
        }

        // Réinitialise le Form
        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //
        // Attaque l'ennemi à la position désirée
        private void BTN_Send_Click(object sender, EventArgs e)
        {
            if (!over)
            {
                LBL_TurnTag.Text = "En attente de l'ennemi";
                BTN_Send.Enabled = false;
                Attaque();
                DGV_Attaques.ClearSelection();

                TraiterResultatsAttaque(DGV_Attaques, Recevoir(), false);
                if (!over)
                    TraiterResultatsAttaque(DGV_Placements, Recevoir(), true);
            }
        }

        //
        // Appel la vérification de la sélection
        private void DGV_Placements_MouseUp(object sender, MouseEventArgs e)
        {
            if (!CheckSelectionLength())
                DGV_Placements.ClearSelection();
        }

        //
        // Sélectionne la case désirée pour attaquer
        private void DGV_Attaques_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV_Attaques.SelectedCells.Count == 0 || DGV_Attaques.SelectedCells[0].Style.BackColor == Color.Red
                || DGV_Attaques.SelectedCells[0].Style.BackColor == Color.White)
                BTN_Send.Enabled = false;
            else
                BTN_Send.Enabled = true;
        }

        //
        // Initialise certaines composantes de l'interface
        private void Jeu_Shown(object sender, EventArgs e)
        {
            Jeu.ActiveForm.Text = "Nouvelle partie";
            DGV_Attaques.Enabled = false;
            BTN_Send.Enabled = false;
        }
    }
}