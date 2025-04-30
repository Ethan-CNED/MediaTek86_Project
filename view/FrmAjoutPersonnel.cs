using Kanban.dal;
using Kanban.model;
using System;
using System.Windows.Forms;

namespace Kanban.view
{
    /// <summary>
    /// Mode du formulaire : Ajout ou Modification.
    /// </summary>
    public enum FormMode { Ajout, Modification }

    /// <summary>
    /// Formulaire pour ajouter ou modifier un personnel.
    /// </summary>
    public partial class FrmAjoutPersonnel : Form
    {
        private FormMode currentMode;          // Mode du formulaire (Ajout ou Modification)
        private Personnel personnel;          // Instance du personnel pour modification

        /// <summary>
        /// Constructeur pour le mode Ajout.
        /// </summary>
        public FrmAjoutPersonnel()
        {
            InitializeComponent();
            currentMode = FormMode.Ajout;      // Par défaut, en mode Ajout
        }

        /// <summary>
        /// Constructeur pour le mode Modification.
        /// </summary>
        /// <param name="personnel">Instance du personnel à modifier.</param>
        public FrmAjoutPersonnel(Personnel personnel) : this()
        {
            currentMode = FormMode.Modification;
            this.personnel = personnel;

            // Pré-remplir les champs avec les informations du personnel existant
            if (personnel != null)
            {
                textBox_Nom.Text = personnel.nom;
                textBox_Prenom.Text = personnel.prenom;
                textBox_Tel.Text = personnel.tel;
                textBox_Mail.Text = personnel.mail;
                btn_Perso_Valider.Text = "Modifier"; // Adapter le texte du bouton
            }
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Valider" est cliqué.
        /// Ajoute ou modifie un personnel dans la base de données.
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

                if (currentMode == FormMode.Ajout)
                {
                    // Mode Ajout : Ajouter un nouveau personnel
                    PersonnelAccess.AddPersonnel(nom, prenom, tel, mail);
                    MessageBox.Show("Personnel ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Modification && personnel != null)
                {
                    // Mode Modification : Mettre à jour le personnel existant
                    PersonnelAccess.UpdatePersonnel(personnel.idpersonnel, nom, prenom, tel, mail);
                    MessageBox.Show("Personnel modifié avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Fermer le formulaire après succès
                this.Close();
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show($"Erreur lors de l'opération : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
