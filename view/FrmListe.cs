using Kanban.dal;
using Kanban.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban.view
{
    public partial class FrmListe : Form
    {
        public FrmListe()
        {
            InitializeComponent();
            dataGridView_Absence.DataSource = AbsenceAccess.GetAllAbsences();
        }

        private void FrmListePersonnel_Load(object sender, EventArgs e)
        {

        }

        private void btn_Perso_Ajoutez_Click(object sender, EventArgs e)
        {

        }

        private void FrmListe_Load_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gère l'ajout d'un nouvel élément en fonction de l'onglet actif.
        /// Si l'onglet actif est "Personnel", ouvre le formulaire d'ajout de personnel.
        /// Si l'onglet actif est "Absence", ouvre le formulaire d'ajout d'absence.
        /// Recharge les données après l'ajout.
        /// </summary>
        /// <param name="ongletActif">L'onglet actuellement sélectionné dans le TabControl.</param>
        private void GererAjout(TabPage ongletActif)
        {
            if (ongletActif == tabPage1) // Onglet Personnel
            {
                // Créer une instance du formulaire d'ajout de personnel
                FrmAjoutPersonnel ajoutPersonnel = new FrmAjoutPersonnel
                {
                    Owner = this // Définir FrmListe comme Owner
                };

                // Ouvrir le formulaire en mode boîte de dialogue
                ajoutPersonnel.ShowDialog();

                // Recharge la liste des personnels après l'ajout
                LoadPersonnels();
            }
            else if (ongletActif == tabPage2) // Onglet Absence
            {
                // Créer une instance du formulaire d'ajout d'absence
                FrmAjoutAbsence ajoutAbsence = new FrmAjoutAbsence
                {
                    Owner = this // Définir FrmListe comme Owner
                };

                // Ouvrir le formulaire en mode boîte de dialogue
                ajoutAbsence.ShowDialog();

                // Recharge la liste des absences après l'ajout
                LoadAbsences();
            }
        }


        private void btn_Perso_Ajoutez_Click_1(object sender, EventArgs e)
        {
            GererAjout(tabControl1.SelectedTab);
        }

        private void button_Abs_Ajoutez_Click(object sender, EventArgs e)
        {
            GererAjout(tabControl1.SelectedTab);
        }



        private void btn_Perso_Modifier_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer le personnel sélectionné dans la DataGridView
                if (dataGridView_Personnel.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner un personnel à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Personnel personnel = (Personnel)dataGridView_Personnel.SelectedRows[0].DataBoundItem;

                // Ouvrir le formulaire de modification
                FrmAjoutPersonnel frm = new FrmAjoutPersonnel(personnel);
                frm.ShowDialog();

                // Rafraîchir la liste après modification
                LoadPersonnels();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Abs_Modifier_Click(object sender, EventArgs e)
        {
            if (dataGridView_Absence.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une absence à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Déclaration et initialisation de la variable 'absence'
            Absence absence = dataGridView_Absence.SelectedRows[0].DataBoundItem as Absence;

            if (absence == null)
            {
                MessageBox.Show("Impossible de récupérer l'absence sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmAjoutAbsence frm = new FrmAjoutAbsence(absence);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAbsences(); 
            }
        }
    }
}
