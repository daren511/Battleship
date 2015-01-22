namespace Battleship
{
    partial class Jeu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouvellePartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DGV_Placements = new System.Windows.Forms.DataGridView();
            this.DGV_Attaques = new System.Windows.Forms.DataGridView();
            this.BTN_Send = new System.Windows.Forms.Button();
            this.BTN_Valider = new System.Windows.Forms.Button();
            this.BTN_Reset = new System.Windows.Forms.Button();
            this.LBL_PlayerTag = new System.Windows.Forms.Label();
            this.LBL_EnemyTag = new System.Windows.Forms.Label();
            this.GB_Navires = new System.Windows.Forms.GroupBox();
            this.RB_Torpilleur = new System.Windows.Forms.RadioButton();
            this.RB_SousMarin = new System.Windows.Forms.RadioButton();
            this.RB_ContreTorpilleur = new System.Windows.Forms.RadioButton();
            this.RB_Croiseur = new System.Windows.Forms.RadioButton();
            this.RB_PorteAvions = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_Place = new System.Windows.Forms.Button();
            this.LBL_TurnTag = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Placements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Attaques)).BeginInit();
            this.GB_Navires.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvellePartieToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouvellePartieToolStripMenuItem
            // 
            this.nouvellePartieToolStripMenuItem.Name = "nouvellePartieToolStripMenuItem";
            this.nouvellePartieToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nouvellePartieToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.nouvellePartieToolStripMenuItem.Text = "Nouvelle Partie";
            this.nouvellePartieToolStripMenuItem.Click += new System.EventHandler(this.nouvellePartieToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.connectionToolStripMenuItem.Text = "Connexion";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // DGV_Placements
            // 
            this.DGV_Placements.AllowUserToAddRows = false;
            this.DGV_Placements.AllowUserToDeleteRows = false;
            this.DGV_Placements.AllowUserToResizeColumns = false;
            this.DGV_Placements.AllowUserToResizeRows = false;
            this.DGV_Placements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Placements.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Placements.Location = new System.Drawing.Point(175, 63);
            this.DGV_Placements.Name = "DGV_Placements";
            this.DGV_Placements.ReadOnly = true;
            this.DGV_Placements.RowHeadersWidth = 40;
            this.DGV_Placements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_Placements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Placements.Size = new System.Drawing.Size(255, 225);
            this.DGV_Placements.TabIndex = 1;
            this.DGV_Placements.SelectionChanged += new System.EventHandler(this.DGV_Placements_SelectionChanged);
            this.DGV_Placements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DGV_Placements_MouseUp);
            // 
            // DGV_Attaques
            // 
            this.DGV_Attaques.AllowUserToAddRows = false;
            this.DGV_Attaques.AllowUserToDeleteRows = false;
            this.DGV_Attaques.AllowUserToResizeColumns = false;
            this.DGV_Attaques.AllowUserToResizeRows = false;
            this.DGV_Attaques.CausesValidation = false;
            this.DGV_Attaques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Attaques.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Attaques.Location = new System.Drawing.Point(457, 63);
            this.DGV_Attaques.MultiSelect = false;
            this.DGV_Attaques.Name = "DGV_Attaques";
            this.DGV_Attaques.ReadOnly = true;
            this.DGV_Attaques.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_Attaques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV_Attaques.Size = new System.Drawing.Size(255, 225);
            this.DGV_Attaques.TabIndex = 2;
            this.DGV_Attaques.SelectionChanged += new System.EventHandler(this.DGV_Attaques_SelectionChanged);
            // 
            // BTN_Send
            // 
            this.BTN_Send.Enabled = false;
            this.BTN_Send.Location = new System.Drawing.Point(457, 299);
            this.BTN_Send.Name = "BTN_Send";
            this.BTN_Send.Size = new System.Drawing.Size(260, 30);
            this.BTN_Send.TabIndex = 3;
            this.BTN_Send.Text = "Attaquer";
            this.BTN_Send.UseVisualStyleBackColor = true;
            this.BTN_Send.Click += new System.EventHandler(this.BTN_Send_Click);
            // 
            // BTN_Valider
            // 
            this.BTN_Valider.Enabled = false;
            this.BTN_Valider.Location = new System.Drawing.Point(175, 299);
            this.BTN_Valider.Name = "BTN_Valider";
            this.BTN_Valider.Size = new System.Drawing.Size(130, 30);
            this.BTN_Valider.TabIndex = 4;
            this.BTN_Valider.Text = "Commencer Partie";
            this.BTN_Valider.UseVisualStyleBackColor = true;
            this.BTN_Valider.Click += new System.EventHandler(this.BTN_Valider_Click);
            // 
            // BTN_Reset
            // 
            this.BTN_Reset.Location = new System.Drawing.Point(305, 299);
            this.BTN_Reset.Name = "BTN_Reset";
            this.BTN_Reset.Size = new System.Drawing.Size(130, 30);
            this.BTN_Reset.TabIndex = 5;
            this.BTN_Reset.Text = "Recommencer";
            this.BTN_Reset.UseVisualStyleBackColor = true;
            this.BTN_Reset.Click += new System.EventHandler(this.BTN_Reset_Click);
            // 
            // LBL_PlayerTag
            // 
            this.LBL_PlayerTag.AutoSize = true;
            this.LBL_PlayerTag.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PlayerTag.Location = new System.Drawing.Point(255, 35);
            this.LBL_PlayerTag.Name = "LBL_PlayerTag";
            this.LBL_PlayerTag.Size = new System.Drawing.Size(105, 23);
            this.LBL_PlayerTag.TabIndex = 6;
            this.LBL_PlayerTag.Text = "Vos navires";
            // 
            // LBL_EnemyTag
            // 
            this.LBL_EnemyTag.AutoSize = true;
            this.LBL_EnemyTag.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_EnemyTag.Location = new System.Drawing.Point(543, 35);
            this.LBL_EnemyTag.Name = "LBL_EnemyTag";
            this.LBL_EnemyTag.Size = new System.Drawing.Size(86, 23);
            this.LBL_EnemyTag.TabIndex = 7;
            this.LBL_EnemyTag.Text = "L\'ennemi";
            // 
            // GB_Navires
            // 
            this.GB_Navires.Controls.Add(this.RB_Torpilleur);
            this.GB_Navires.Controls.Add(this.RB_SousMarin);
            this.GB_Navires.Controls.Add(this.RB_ContreTorpilleur);
            this.GB_Navires.Controls.Add(this.RB_Croiseur);
            this.GB_Navires.Controls.Add(this.RB_PorteAvions);
            this.GB_Navires.Location = new System.Drawing.Point(12, 63);
            this.GB_Navires.Name = "GB_Navires";
            this.GB_Navires.Size = new System.Drawing.Size(160, 148);
            this.GB_Navires.TabIndex = 8;
            this.GB_Navires.TabStop = false;
            // 
            // RB_Torpilleur
            // 
            this.RB_Torpilleur.AutoSize = true;
            this.RB_Torpilleur.Location = new System.Drawing.Point(7, 112);
            this.RB_Torpilleur.Name = "RB_Torpilleur";
            this.RB_Torpilleur.Size = new System.Drawing.Size(117, 17);
            this.RB_Torpilleur.TabIndex = 4;
            this.RB_Torpilleur.Text = "Torpilleur (2  cases)";
            this.RB_Torpilleur.UseVisualStyleBackColor = true;
            this.RB_Torpilleur.CheckedChanged += new System.EventHandler(this.RB_Torpilleur_CheckedChanged);
            // 
            // RB_SousMarin
            // 
            this.RB_SousMarin.AutoSize = true;
            this.RB_SousMarin.Location = new System.Drawing.Point(7, 89);
            this.RB_SousMarin.Name = "RB_SousMarin";
            this.RB_SousMarin.Size = new System.Drawing.Size(124, 17);
            this.RB_SousMarin.TabIndex = 3;
            this.RB_SousMarin.Text = "Sous-Marin (3 cases)";
            this.RB_SousMarin.UseVisualStyleBackColor = true;
            this.RB_SousMarin.CheckedChanged += new System.EventHandler(this.RB_SousMarin_CheckedChanged);
            // 
            // RB_ContreTorpilleur
            // 
            this.RB_ContreTorpilleur.AutoSize = true;
            this.RB_ContreTorpilleur.Location = new System.Drawing.Point(7, 66);
            this.RB_ContreTorpilleur.Name = "RB_ContreTorpilleur";
            this.RB_ContreTorpilleur.Size = new System.Drawing.Size(148, 17);
            this.RB_ContreTorpilleur.TabIndex = 2;
            this.RB_ContreTorpilleur.Text = "Contre-Torpilleur (3 cases)";
            this.RB_ContreTorpilleur.UseVisualStyleBackColor = true;
            this.RB_ContreTorpilleur.CheckedChanged += new System.EventHandler(this.RB_ContreTorpilleur_CheckedChanged);
            // 
            // RB_Croiseur
            // 
            this.RB_Croiseur.AutoSize = true;
            this.RB_Croiseur.Location = new System.Drawing.Point(7, 43);
            this.RB_Croiseur.Name = "RB_Croiseur";
            this.RB_Croiseur.Size = new System.Drawing.Size(109, 17);
            this.RB_Croiseur.TabIndex = 1;
            this.RB_Croiseur.Text = "Croiseur (4 cases)";
            this.RB_Croiseur.UseVisualStyleBackColor = true;
            this.RB_Croiseur.CheckedChanged += new System.EventHandler(this.RB_Croiseur_CheckedChanged);
            // 
            // RB_PorteAvions
            // 
            this.RB_PorteAvions.AutoSize = true;
            this.RB_PorteAvions.Checked = true;
            this.RB_PorteAvions.Location = new System.Drawing.Point(7, 20);
            this.RB_PorteAvions.Name = "RB_PorteAvions";
            this.RB_PorteAvions.Size = new System.Drawing.Size(131, 17);
            this.RB_PorteAvions.TabIndex = 0;
            this.RB_PorteAvions.TabStop = true;
            this.RB_PorteAvions.Text = "Porte-Avions (5 cases)";
            this.RB_PorteAvions.UseVisualStyleBackColor = true;
            this.RB_PorteAvions.CheckedChanged += new System.EventHandler(this.RB_PorteAvions_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Navires";
            // 
            // BTN_Place
            // 
            this.BTN_Place.Location = new System.Drawing.Point(19, 217);
            this.BTN_Place.Name = "BTN_Place";
            this.BTN_Place.Size = new System.Drawing.Size(130, 30);
            this.BTN_Place.TabIndex = 10;
            this.BTN_Place.Text = "Placer navire";
            this.BTN_Place.UseVisualStyleBackColor = true;
            this.BTN_Place.Click += new System.EventHandler(this.BTN_Place_Click);
            // 
            // LBL_TurnTag
            // 
            this.LBL_TurnTag.AutoSize = true;
            this.LBL_TurnTag.Location = new System.Drawing.Point(394, 42);
            this.LBL_TurnTag.Name = "LBL_TurnTag";
            this.LBL_TurnTag.Size = new System.Drawing.Size(0, 13);
            this.LBL_TurnTag.TabIndex = 11;
            // 
            // Jeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 344);
            this.Controls.Add(this.LBL_TurnTag);
            this.Controls.Add(this.BTN_Place);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GB_Navires);
            this.Controls.Add(this.LBL_EnemyTag);
            this.Controls.Add(this.LBL_PlayerTag);
            this.Controls.Add(this.BTN_Reset);
            this.Controls.Add(this.BTN_Valider);
            this.Controls.Add(this.BTN_Send);
            this.Controls.Add(this.DGV_Attaques);
            this.Controls.Add(this.DGV_Placements);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Jeu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Nouvelle partie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Jeu_FormClosing);
            this.Shown += new System.EventHandler(this.Jeu_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Placements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Attaques)).EndInit();
            this.GB_Navires.ResumeLayout(false);
            this.GB_Navires.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouvellePartieToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.DataGridView DGV_Placements;
        private System.Windows.Forms.DataGridView DGV_Attaques;
        private System.Windows.Forms.Button BTN_Send;
        private System.Windows.Forms.Button BTN_Valider;
        private System.Windows.Forms.Button BTN_Reset;
        private System.Windows.Forms.Label LBL_PlayerTag;
        private System.Windows.Forms.Label LBL_EnemyTag;
        private System.Windows.Forms.GroupBox GB_Navires;
        private System.Windows.Forms.RadioButton RB_Torpilleur;
        private System.Windows.Forms.RadioButton RB_SousMarin;
        private System.Windows.Forms.RadioButton RB_ContreTorpilleur;
        private System.Windows.Forms.RadioButton RB_Croiseur;
        private System.Windows.Forms.RadioButton RB_PorteAvions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Place;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.Label LBL_TurnTag;
    }
}

