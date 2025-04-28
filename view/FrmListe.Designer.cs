using System;
using System.Windows.Forms;
using Kanban.controller;
using Kanban.dal;

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
            this.dataGridView_Personnel.AllowUserToAddRows = false;
            this.dataGridView_Personnel.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Personnel.Name = "dataGridView_Personnel";
            this.dataGridView_Personnel.Size = new System.Drawing.Size(840, 408);
            this.dataGridView_Personnel.TabIndex = 0;
            // 
            // dataGridView_Absence
            // 
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
            // Configuration des colonnes pour dataGridView_Personnel
            dataGridView_Personnel.Columns.Clear();
            dataGridView_Personnel.Columns.Add("id", "ID");
            dataGridView_Personnel.Columns.Add("nom", "Nom");
            dataGridView_Personnel.Columns.Add("prenom", "Prénom");
            dataGridView_Personnel.Columns.Add("tel", "Téléphone");
            dataGridView_Personnel.Columns.Add("email", "Email");
            dataGridView_Personnel.Columns.Add("idService", "Service");

            // Configuration des colonnes pour dataGridView_Absence
            dataGridView_Absence.Columns.Clear();
            dataGridView_Absence.Columns.Add("idPersonnel", "Personnel");
            dataGridView_Absence.Columns.Add("dateDebut", "Date Début");
            dataGridView_Absence.Columns.Add("dateFin", "Date Fin");
            dataGridView_Absence.Columns.Add("idMotif", "Motif");
        }

        /// <summary>
        /// Charge les données des personnels dans le DataGridView_Personnel.
        /// </summary>
        private void LoadPersonnels()
        {
            try
            {
                var personnels = FrmPersonnelController.GetAllPersonnels();
                foreach (var personnel in personnels)
                {
                    dataGridView_Personnel.Rows.Add(personnel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des personnels : {ex.Message}");
            }
        }

        /// <summary>
        /// Charge les données des absences dans le DataGridView_Absence.
        /// </summary>
        private void LoadAbsences()
        {
            try
            {
                var absences = FrmAbsenceController.GetAllAbsences();
                foreach (var absence in absences)
                {
                    dataGridView_Absence.Rows.Add(absence);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des absences : {ex.Message}");
            }
        }
    }
}
