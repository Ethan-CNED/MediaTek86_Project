using Kanban.dal;
using System;
using System.Windows.Forms;

namespace Kanban.view
{
    /// <summary>
    /// Formulaire pour ajouter un nouveau personnel.
    /// </summary>
    public partial class FrmAjoutPersonnel : Form
    {
        /// <summary>
        /// Initialise une nouvelle instance du formulaire d'ajout de personnel.
        /// </summary>
        public FrmAjoutPersonnel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Valider" est cliqué.
        /// Ajoute un nouveau personnel dans la base de données.
        /// </summary>
        private void btn_Perso_Valider_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer les informations des champs
                string nom = textBox_Nom.Text;
                string prenom = textBox_Prenom.Text;
                string tel = textBox_Tel.Text;
                string mail = textBox_Mail.Text;

                // Vérifie que tous les champs nécessaires sont remplis
                if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) ||
                    string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(mail))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Information manquante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Appelle la méthode pour ajouter le personnel dans la base
                PersonnelAccess.AddPersonnel(nom, prenom, tel, mail);

                // Confirmation
                MessageBox.Show("Personnel ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Ferme le formulaire après succès
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show($"Erreur lors de l'ajout du personnel : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Annuler" est cliqué.
        /// Ferme le formulaire sans rien faire.
        /// </summary>
        private void btn_Perso_Annuler_Click(object sender, EventArgs e)
        {
            // Confirme avant de fermer le formulaire
            DialogResult result = MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Ferme le formulaire
            }
        }

        private void btn_Perso_Annuler_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
