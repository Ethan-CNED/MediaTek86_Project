using Kanban.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kanban.controller;
using Kanban.model;
using Kanban.bddmanager;

namespace Kanban.view
{
    public partial class FrmAjoutAbsence : Form
    {
        public FrmAjoutAbsence()
        {
            InitializeComponent();
            LoadMotifs();
            this.Load += new System.EventHandler(this.FrmAjoutAbsence_Load);
        }

        private void btn_Perso_Valider_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer les dates depuis les DateTimePicker
                DateTime dateDebut = dateTimePicker_Ajout_Début.Value;
                DateTime dateFin = dateTimePicker_Ajout_Fin.Value;

                // Vérification des dates
                if (dateDebut > dateFin)
                {
                    MessageBox.Show("La date de début ne peut pas être postérieure à la date de fin.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérification de la sélection du personnel
                if (comboBox_Nom.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un personnel.",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Récupération de l'identifiant du personnel depuis comboBox_Nom
                int idPersonnel;
                try
                {
                    idPersonnel = Convert.ToInt32(comboBox_Nom.SelectedValue);

                    // Affichage pour vérifier l'ID sélectionné (facultatif pour le débogage)
                    Console.WriteLine($"ID Personnel sélectionné : {idPersonnel}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la récupération de l'identifiant du personnel : {ex.Message}",
                                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idMotif = Convert.ToInt32(comboBox_Motif.SelectedValue);
                // Formatage des dates selon le format attendu par MySQL
                string formattedDebut = dateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                string formattedFin = dateFin.ToString("yyyy-MM-dd HH:mm:ss");

                // Appel de la méthode d'ajout d'absence
                AbsenceAccess.AddAbsence(idPersonnel, formattedDebut, formattedFin, idMotif);
                MessageBox.Show("Absence ajoutée avec succès !",
                                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Rafraîchir la liste des absences si le formulaire principal possède la méthode LoadAbsences
                if (this.Owner != null && this.Owner is FrmListe frmListe)
                {
                    frmListe.LoadAbsences();
                }
                else
                {
                    MessageBox.Show("Impossible de rafraîchir la liste des absences. Vérifiez l'intégration avec FrmListe.",
                                    "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Fermer le formulaire après ajout
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMotifs()
        {
            try
            {
                var motifs = MotifAccess.GetAllMotifs();

                // Remplit la ComboBox avec la liste d'objets Motif
                comboBox_Motif.DataSource = motifs;
                comboBox_Motif.DisplayMember = "Libelle"; // Propriété de l'objet
                comboBox_Motif.ValueMember = "IdMotif";  // Propriété de l'objet
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des motifs : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Personnel> GetListePersonnels()
        {
            List<Personnel> liste = new List<Personnel>();

            // Exemple de requête SQL pour récupérer les personnels.
            string query = "SELECT idpersonnel, nom FROM personnel";
            var results = BddManager.GetInstance().ReqSelect(query);
            foreach (var row in results)
            {
                // Supposons que row[0] est l'id et row[1] est le nom
                Personnel p = new Personnel()
                {
                    idpersonnel = Convert.ToInt32(row[0]),
                    Nom = row[1].ToString()
                };
                liste.Add(p);
            }

            return liste;
        }

        private void FrmAjoutAbsence_Load(object sender, EventArgs e)
        {
            // On récupère la liste des personnels depuis la base
            List<Personnel> personnels = PersonnelAccess.GetAllPersonnels();
            List<Personnel> listepersonnels = GetListePersonnels();

            // Vérifier que la liste n'est pas nulle et l'affecter au ComboBox
            if (personnels != null && personnels.Count > 0)
            {
                comboBox_Nom.DataSource = personnels;
                comboBox_Nom.DisplayMember = "Nom";    // Affiche la propriété Nom sur le ComboBox
                comboBox_Nom.ValueMember = "idpersonnel";         // Valorise le SelectedValue avec la propriété Id
            }
            else
            {
                comboBox_Nom.DataSource = null;
            }
        }

        private void btn_Abs_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


