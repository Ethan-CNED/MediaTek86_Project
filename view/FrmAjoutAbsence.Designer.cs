namespace Kanban.view
{
    partial class FrmAjoutAbsence
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Nom = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_Ajout_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Ajout_Début = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Motif = new System.Windows.Forms.ComboBox();
            this.btn_Abs_Annuler = new System.Windows.Forms.Button();
            this.btn_Perso_Valider = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_Nom);
            this.panel1.Controls.Add(this.dateTimePicker_Ajout_Fin);
            this.panel1.Controls.Add(this.dateTimePicker_Ajout_Début);
            this.panel1.Controls.Add(this.comboBox_Motif);
            this.panel1.Controls.Add(this.btn_Abs_Annuler);
            this.panel1.Controls.Add(this.btn_Perso_Valider);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 208);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nom";
            // 
            // comboBox_Nom
            // 
            this.comboBox_Nom.FormattingEnabled = true;
            this.comboBox_Nom.Location = new System.Drawing.Point(460, 62);
            this.comboBox_Nom.Name = "comboBox_Nom";
            this.comboBox_Nom.Size = new System.Drawing.Size(291, 21);
            this.comboBox_Nom.TabIndex = 13;
            // 
            // dateTimePicker_Ajout_Fin
            // 
            this.dateTimePicker_Ajout_Fin.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_Ajout_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Ajout_Fin.Location = new System.Drawing.Point(53, 62);
            this.dateTimePicker_Ajout_Fin.Name = "dateTimePicker_Ajout_Fin";
            this.dateTimePicker_Ajout_Fin.Size = new System.Drawing.Size(291, 20);
            this.dateTimePicker_Ajout_Fin.TabIndex = 12;
            // 
            // dateTimePicker_Ajout_Début
            // 
            this.dateTimePicker_Ajout_Début.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_Ajout_Début.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Ajout_Début.Location = new System.Drawing.Point(53, 20);
            this.dateTimePicker_Ajout_Début.Name = "dateTimePicker_Ajout_Début";
            this.dateTimePicker_Ajout_Début.Size = new System.Drawing.Size(291, 20);
            this.dateTimePicker_Ajout_Début.TabIndex = 11;
            // 
            // comboBox_Motif
            // 
            this.comboBox_Motif.FormattingEnabled = true;
            this.comboBox_Motif.Location = new System.Drawing.Point(460, 19);
            this.comboBox_Motif.Name = "comboBox_Motif";
            this.comboBox_Motif.Size = new System.Drawing.Size(291, 21);
            this.comboBox_Motif.TabIndex = 10;
            // 
            // btn_Abs_Annuler
            // 
            this.btn_Abs_Annuler.Location = new System.Drawing.Point(146, 135);
            this.btn_Abs_Annuler.Name = "btn_Abs_Annuler";
            this.btn_Abs_Annuler.Size = new System.Drawing.Size(110, 36);
            this.btn_Abs_Annuler.TabIndex = 9;
            this.btn_Abs_Annuler.Text = "Annuler";
            this.btn_Abs_Annuler.UseVisualStyleBackColor = true;
            this.btn_Abs_Annuler.Click += new System.EventHandler(this.btn_Abs_Annuler_Click);
            // 
            // btn_Perso_Valider
            // 
            this.btn_Perso_Valider.Location = new System.Drawing.Point(6, 135);
            this.btn_Perso_Valider.Name = "btn_Perso_Valider";
            this.btn_Perso_Valider.Size = new System.Drawing.Size(110, 36);
            this.btn_Perso_Valider.TabIndex = 8;
            this.btn_Perso_Valider.Text = "Ok";
            this.btn_Perso_Valider.UseVisualStyleBackColor = true;
            this.btn_Perso_Valider.Click += new System.EventHandler(this.btn_Perso_Valider_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motif";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Début";
            // 
            // FrmAjoutAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 226);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAjoutAbsence";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Abs_Annuler;
        private System.Windows.Forms.Button btn_Perso_Valider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Motif;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ajout_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Ajout_Début;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Nom;
    }
}