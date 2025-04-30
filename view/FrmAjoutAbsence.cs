using Kanban.dal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Kanban.model;
using Kanban.bddmanager;

namespace Kanban.view
{
    public partial class FrmAjoutAbsence : Form
    {
        private FormMode currentMode;
        private Absence currentAbsence; // Utilisé uniquement en mode Modification
        private bool isModification = false;

        /// <summary>
        /// Constructeur pour le mode Ajout.
        /// </summary>
        public FrmAjoutAbsence()
        {
            InitializeComponent();
            currentMode = FormMode.Ajout;       // Par défaut, mode Ajout
            LoadMotifs();
            this.Load += FrmAjoutAbsence_Load;
            isModification = false;
            dateTimePicker_Ajout_Début.Value = DateTime.Now;
            dateTimePicker_Ajout_Fin.Value = DateTime.Now;
            if (comboBox_Motif.Items.Count > 0)
            {
                comboBox_Motif.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Constructeur pour le mode Modification.
        /// </summary>
        /// <param name="absence">Instance de l'absence à modifier.</param>
        public FrmAjoutAbsence(Absence absence) : this()  // Appel du constructeur de base
        {
            if (absence == null)
                throw new ArgumentNullException(nameof(absence));

            currentAbsence = absence;
            isModification = true;
            currentMode = FormMode.Modification;

            // Remplir les contrôles avec les valeurs existantes
            dateTimePicker_Ajout_Début.Value = absence.dateDebut;
            dateTimePicker_Ajout_Fin.Value = absence.dateFin;
            comboBox_Motif.SelectedValue = absence.idMotif;
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Valider" est cliqué.
        /// Gère l'ajout ou la modification d'une absence.
        /// </summary>
        private void btn_Abs_Valider_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer les valeurs saisies
                DateTime newDateDebut = dateTimePicker_Ajout_Début.Value;
                DateTime newDateFin = dateTimePicker_Ajout_Fin.Value;
                int newIdMotif = Convert.ToInt32(comboBox_Motif.SelectedValue);

                if (!isModification)
                {
                    // Mode Ajout
                    int idPersonnel = Convert.ToInt32(comboBox_Nom.SelectedValue);  
                    string newDateDebutStr = newDateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                    string newDateFinStr = newDateFin.ToString("yyyy-MM-dd HH:mm:ss");

                    int rows = AbsenceAccess.AddAbsence(idPersonnel, newDateDebutStr, newDateFinStr, newIdMotif);

                    if (rows > 0)
                    {
                        MessageBox.Show("Absence ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("L'ajout de l'absence a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Mode Modification
                    string newDateDebutStr = newDateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                    string newDateFinStr = newDateFin.ToString("yyyy-MM-dd HH:mm:ss");
                    string oldDateDebutStr = currentAbsence.OriginalDateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                    string oldDateFinStr = currentAbsence.OriginalDateFin.ToString("yyyy-MM-dd HH:mm:ss");

                    // Récupérer l'ancien id et le nouveau id du personnel depuis le ComboBox
                    int oldIdPersonnel = currentAbsence.idPersonnel;
                    int newIdPersonnel = Convert.ToInt32(comboBox_Nom.SelectedValue);
                    int rowsAffected = AbsenceAccess.UpdateAbsence(
                        oldIdPersonnel,     // Ancien id en WHERE
                        newIdPersonnel,     // Nouveau id dans SET
                        newDateDebutStr,    // Nouvelle date de début
                        newDateFinStr,      // Nouvelle date de fin
                        newIdMotif,         // Nouvel id du motif
                        oldDateDebutStr,    // Ancienne date de début
                        oldDateFinStr);     // Ancienne date de fin

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Absence modifiée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Mettre à jour currentAbsence pour refléter les nouvelles valeurs
                        currentAbsence.idPersonnel = newIdPersonnel;
                        currentAbsence.dateDebut = newDateDebut;
                        currentAbsence.dateFin = newDateFin;
                        currentAbsence.idMotif = newIdMotif;
                        currentAbsence.OriginalDateDebut = newDateDebut;
                        currentAbsence.OriginalDateFin = newDateFin;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("La modification n'a pas été effectuée. Vérifiez vos paramètres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la validation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Charge les motifs dans le ComboBox.
        /// </summary>
        private void LoadMotifs()
        {
            try
            {
                var motifs = MotifAccess.GetAllMotifs();

                // Remplit le ComboBox avec les motifs
                comboBox_Motif.DataSource = motifs;
                comboBox_Motif.DisplayMember = "Libelle"; // Propriété de l'objet à afficher
                comboBox_Motif.ValueMember = "IdMotif";   // Propriété de l'objet utilisée comme valeur
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des motifs : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Charge la liste des personnels dans le ComboBox, lors du chargement du formulaire.
        /// </summary>
        private void FrmAjoutAbsence_Load(object sender, EventArgs e)
        {
            try
            {
                List<Personnel> personnels = PersonnelAccess.GetAllPersonnels();
                if (personnels != null && personnels.Count > 0)
                {
                    comboBox_Nom.DataSource = personnels;
                    comboBox_Nom.DisplayMember = "NomComplet";  
                    comboBox_Nom.ValueMember = "idpersonnel";     
                }
                else
                {
                    comboBox_Nom.DataSource = null;
                    MessageBox.Show("Aucun personnel trouvé.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des personnels : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Méthode statique d'update de l'absence qui inclut la mise à jour du personnel.
        /// </summary>
        public static int UpdateAbsence(int oldIdPersonnel, int newIdPersonnel, string newDateDebut, string newDateFin, int idMotif, string oldDateDebut, string oldDateFin)
        {
            string query = @"UPDATE absence 
                             SET idpersonnel = @newIdPersonnel,
                                 datedebut = @newDateDebut, 
                                 datefin = @newDateFin, 
                                 idmotif = @idMotif 
                             WHERE idpersonnel = @oldIdPersonnel 
                               AND datedebut = @oldDateDebut 
                               AND datefin = @oldDateFin";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@newIdPersonnel", newIdPersonnel },
                { "@newDateDebut", newDateDebut },
                { "@newDateFin", newDateFin },
                { "@idMotif", idMotif },
                { "@oldIdPersonnel", oldIdPersonnel },
                { "@oldDateDebut", oldDateDebut },
                { "@oldDateFin", oldDateFin }
            };

            return BddManager.GetInstance().ReqUpdate(query, parameters);
        }

        /// <summary>
        /// Événement déclenché lorsque le bouton "Annuler" est cliqué.
        /// Ferme le formulaire.
        /// </summary>
        private void btn_Abs_Annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
