using Kanban.view;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kanban
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Événement déclenché lors du clic sur le bouton de connexion.
        /// Vérifie les informations d'identification et ouvre le formulaire principal en cas de succès.
        /// </summary>
        /// <param name="sender">Objet qui déclenche l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void btn_Connexion_Ok_Click(object sender, EventArgs e)
        {
            // Récupération des données saisies
            string enteredLogin = textBox_Name_Utilisateur.Text;
            string enteredPassword = textBox_Password.Text;

            // Vérification des informations d'identification
            if (CheckLoginCredentials(enteredLogin, enteredPassword))
            {
                MessageBox.Show("Connexion réussie !");

                // Ouverture du formulaire principal FrmListe
                FrmListe mainForm = new FrmListe();
                mainForm.Show();

                // Fermeture du formulaire actuel (connexion)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect !");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Vérifie si les informations d'identification (login et mot de passe) sont valides.
        /// Le mot de passe est haché avant la comparaison avec la base de données.
        /// </summary>
        /// <param name="enteredLogin">Login saisi par l'utilisateur.</param>
        /// <param name="enteredPassword">Mot de passe saisi par l'utilisateur.</param>
        /// <returns>Retourne true si les informations sont valides, sinon false.</returns>
        private bool CheckLoginCredentials(string enteredLogin, string enteredPassword)
        {
            try
            {
                // Chaîne de connexion à la base de données
                string connectionString = "server=localhost;userid=Mediatek86_Admin;password=GEd(E[*-zmK9w6W7;database=mediatek86_db";

                // Hachage du mot de passe
                string hashedPassword = HashPassword(enteredPassword);

                // Requête SQL pour vérifier le login et le mot de passe haché
                string query = "SELECT COUNT(*) FROM responsable WHERE login = @login AND pwd = @hashedPassword";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Ajout des paramètres sécurisés
                        command.Parameters.AddWithValue("@login", enteredLogin);
                        command.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                        // Exécution de la requête
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Retourne true si un enregistrement est trouvé
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion à la base de données : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Hache un mot de passe en utilisant l'algorithme SHA-256.
        /// </summary>
        /// <param name="password">Le mot de passe à hacher.</param>
        /// <returns>Le mot de passe haché sous forme de chaîne hexadécimale.</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Conversion du mot de passe en tableau d'octets
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Hachage du tableau d'octets
                byte[] hash = sha256.ComputeHash(bytes);

                // Conversion en chaîne hexadécimale
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2")); // "x2" pour un format hexadécimal
                }
                return result.ToString();
            }
        }
    }
}
