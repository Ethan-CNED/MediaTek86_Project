using System;
using System.Windows.Forms;
using Kanban.controller;
using Kanban.dal;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Kanban.model;

namespace Kanban.view
{
    /// <summary>
    /// Formulaire principal pour afficher les personnels et absences à l'aide d'un TabControl.
    /// </summary>
    public partial class FrmListe : Form
    {
        /// <summary>
        /// Champs privés pour les contrôles de l'interface.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_Personnel;
        private System.Windows.Forms.DataGridView dataGridView_Absence; 
        private System.Windows.Forms.Button btn_Perso_Ajoutez;
        private System.Windows.Forms.Button btn_Perso_Modifier;
        private System.Windows.Forms.Button button_Abs_Ajoutez;
        private System.Windows.Forms.Button button_Abs_Modifier;

        /// <summary>
        /// Chargement des données à l'ouverture du formulaire.
        /// </summary>
        private void FrmListe_Load(object sender, EventArgs e)
        {
            ConfigureDataGridViews();
            LoadPersonnels();
            LoadAbsences();
        }

        private void InitializeComponent()
        {
            this.dataGridView_Personnel = new System.Windows.Forms.DataGridView();
            this.dataGridView_Absence = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Perso_Ajoutez = new System.Windows.Forms.Button();
            this.btn_Perso_Modifier = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_Abs_Ajoutez = new System.Windows.Forms.Button();
            this.button_Abs_Modifier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Personnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Absence)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Personnel
            //
            dataGridView_Personnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Personnel.AllowUserToAddRows = false;
            this.dataGridView_Personnel.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Personnel.Name = "dataGridView_Personnel";
            this.dataGridView_Personnel.Size = new System.Drawing.Size(840, 408);
            this.dataGridView_Personnel.TabIndex = 0;
            dataGridView_Personnel.AutoGenerateColumns = false; 


            // 
            // dataGridView_Absence
            // 
            dataGridView_Absence.DataSource = null;
            dataGridView_Absence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Absence.AllowUserToAddRows = false;
            this.dataGridView_Absence.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Absence.Name = "dataGridView_Absence";
            this.dataGridView_Absence.Size = new System.Drawing.Size(840, 408);
            this.dataGridView_Absence.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 580);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_Personnel);
            this.tabPage1.Controls.Add(this.btn_Perso_Ajoutez);
            this.tabPage1.Controls.Add(this.btn_Perso_Modifier);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(904, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personnel";
            // 
            // btn_Perso_Ajoutez
            // 
            this.btn_Perso_Ajoutez.Location = new System.Drawing.Point(5, 431);
            this.btn_Perso_Ajoutez.Name = "btn_Perso_Ajoutez";
            this.btn_Perso_Ajoutez.Size = new System.Drawing.Size(97, 31);
            this.btn_Perso_Ajoutez.TabIndex = 1;
            this.btn_Perso_Ajoutez.Text = "Ajoutez";
            this.btn_Perso_Ajoutez.Click += new System.EventHandler(this.btn_Perso_Ajoutez_Click_1);
            // 
            // btn_Perso_Modifier
            // 
            this.btn_Perso_Modifier.Location = new System.Drawing.Point(117, 431);
            this.btn_Perso_Modifier.Name = "btn_Perso_Modifier";
            this.btn_Perso_Modifier.Size = new System.Drawing.Size(97, 31);
            this.btn_Perso_Modifier.TabIndex = 2;
            this.btn_Perso_Modifier.Text = "Modifier";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_Absence);
            this.tabPage2.Controls.Add(this.button_Abs_Ajoutez);
            this.tabPage2.Controls.Add(this.button_Abs_Modifier);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(904, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Absence";
            // 
            // button_Abs_Ajoutez
            // 
            this.button_Abs_Ajoutez.Location = new System.Drawing.Point(5, 431);
            this.button_Abs_Ajoutez.Name = "button_Abs_Ajoutez";
            this.button_Abs_Ajoutez.Size = new System.Drawing.Size(97, 31);
            this.button_Abs_Ajoutez.TabIndex = 1;
            this.button_Abs_Ajoutez.Text = "Ajoutez";
            this.button_Abs_Ajoutez.Click += new System.EventHandler(this.button_Abs_Ajoutez_Click);
            // 
            // button_Abs_Modifier
            // 
            this.button_Abs_Modifier.Location = new System.Drawing.Point(117, 431);
            this.button_Abs_Modifier.Name = "button_Abs_Modifier";
            this.button_Abs_Modifier.Size = new System.Drawing.Size(97, 31);
            this.button_Abs_Modifier.TabIndex = 2;
            this.button_Abs_Modifier.Text = "Modifier";
            // 
            // FrmListe
            // 
            this.ClientSize = new System.Drawing.Size(936, 604);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmListe";
            this.Text = "Liste des Personnels et Absences";
            this.Load += new System.EventHandler(this.FrmListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Personnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Absence)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        /// <summary>
        /// Configure les colonnes des DataGridView.
        /// </summary>
        private void ConfigureDataGridViews()
        {
            dataGridView_Personnel.Columns.Clear();

            dataGridView_Personnel.Columns.Add("id", "ID");
            dataGridView_Personnel.Columns["id"].DataPropertyName = "idpersonnel";

            dataGridView_Personnel.Columns.Add("nom", "Nom");
            dataGridView_Personnel.Columns["nom"].DataPropertyName = "nom";

            dataGridView_Personnel.Columns.Add("prenom", "Prénom");
            dataGridView_Personnel.Columns["prenom"].DataPropertyName = "prenom";

            dataGridView_Personnel.Columns.Add("tel", "Téléphone");
            dataGridView_Personnel.Columns["tel"].DataPropertyName = "tel";

            dataGridView_Personnel.Columns.Add("email", "Email");
            dataGridView_Personnel.Columns["email"].DataPropertyName = "mail";

            dataGridView_Personnel.Columns.Add("idService", "Service");
            dataGridView_Personnel.Columns["idService"].DataPropertyName = "idservice";

            dataGridView_Absence.Columns.Add("idPersonnel", "Personnel");
            dataGridView_Absence.Columns["idPersonnel"].DataPropertyName = "idPersonnel";

            dataGridView_Absence.Columns.Add("dateDebut", "Date Début");
            dataGridView_Absence.Columns["dateDebut"].DataPropertyName = "dateDebut";

            dataGridView_Absence.Columns.Add("dateFin", "Date Fin");
            dataGridView_Absence.Columns["dateFin"].DataPropertyName = "dateFin";

            dataGridView_Absence.Columns.Add("idMotif", "Motif");
            dataGridView_Absence.Columns["idMotif"].DataPropertyName = "idMotif";
        }


        /// <summary>
        /// Charge les données des personnels dans le DataGridView_Personnel.
        /// </summary>
        /// <summary>
        /// Charge et affiche la liste des personnels dans le DataGridView correspondant.
        /// </summary>
        private void LoadPersonnels()
        {
            try
            {
                // Récupérer les personnels depuis la base de données
                var personnels = PersonnelAccess.GetAllPersonnels();

                // Vérifier que des personnels ont été retournés
                if (personnels != null && personnels.Count > 0)
                {
                    // Au lieu de vider et ajouter manuellement les lignes,
                    // affectez directement la source de données
                    dataGridView_Personnel.DataSource = personnels;
                }
                else
                {
                    MessageBox.Show("Aucun personnel trouvé.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des personnels : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Charge et affiche la liste des absences dans le DataGridView correspondant.
        /// </summary>

        public void LoadAbsences()
        {
            try
            {
                var absences = AbsenceAccess.GetAllAbsences();

                // Dictionnaire de correspondance pour les motifs connus
                Dictionary<int, string> motifNames = new Dictionary<int, string>
        {
            { 1, "Congé" },
            { 2, "Maladie" },
            { 3, "Retard" },
            { 4, "Autre" }
        };

                // Nettoyer le DataGridView pour éviter l'accumulation de lignes
                dataGridView_Absence.AutoGenerateColumns = true;
                dataGridView_Absence.DataSource = null;
                dataGridView_Absence.Rows.Clear();
                dataGridView_Absence.Columns.Clear();

                if (absences != null && absences.Count > 0)
                {
                    var data = absences.Select(a =>
                    {
                        // a[0] : maintenant le nom du personnel,
                        // a[1] : Date de début (DateTime),
                        // a[2] : Date de fin (DateTime),
                        // a[3] : ID du motif

                        DateTime dtDebut = (DateTime)a[1];
                        DateTime dtFin = (DateTime)a[2];

                        // Formatage pour afficher en "jour/mois/année HH:mm:ss"
                        string displayDateDebut = dtDebut == DateTime.MinValue ? "Non renseignée" : dtDebut.ToString("dd/MM/yyyy HH:mm:ss");
                        string displayDateFin = dtFin == DateTime.MinValue ? "Non renseignée" : dtFin.ToString("dd/MM/yyyy HH:mm:ss");

                        // Remplacement du motif numérique par son libellé
                        int motifId = Convert.ToInt32(a[3]);
                        string motifString = motifId == 0
                                                ? "Aucun motif"
                                                : motifNames.ContainsKey(motifId) ? motifNames[motifId] : "Inconnu";

                        return new
                        {
                            Personnel = a[0],         // Affichera le nom du personnel
                            DateDebut = displayDateDebut,
                            DateFin = displayDateFin,
                            Motif = motifString       // Affichera le libellé du motif
                        };
                    }).ToList();

                    dataGridView_Absence.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Aucune absence trouvée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des absences : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
