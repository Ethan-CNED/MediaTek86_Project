﻿namespace Kanban.view
{
    partial class FrmAjoutPersonnel
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
            this.btn_Perso_Annuler = new System.Windows.Forms.Button();
            this.btn_Perso_Valider = new System.Windows.Forms.Button();
            this.textBox_Mail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Prenom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Perso_Annuler);
            this.panel1.Controls.Add(this.btn_Perso_Valider);
            this.panel1.Controls.Add(this.textBox_Mail);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_Tel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_Prenom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Nom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 208);
            this.panel1.TabIndex = 0;
            // 
            // btn_Perso_Annuler
            // 
            this.btn_Perso_Annuler.Location = new System.Drawing.Point(146, 135);
            this.btn_Perso_Annuler.Name = "btn_Perso_Annuler";
            this.btn_Perso_Annuler.Size = new System.Drawing.Size(110, 36);
            this.btn_Perso_Annuler.TabIndex = 9;
            this.btn_Perso_Annuler.Text = "Annuler";
            this.btn_Perso_Annuler.UseVisualStyleBackColor = true;
            this.btn_Perso_Annuler.Click += new System.EventHandler(this.btn_Perso_Annuler_Click);
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
            // textBox_Mail
            // 
            this.textBox_Mail.Location = new System.Drawing.Point(466, 19);
            this.textBox_Mail.Name = "textBox_Mail";
            this.textBox_Mail.Size = new System.Drawing.Size(291, 20);
            this.textBox_Mail.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mail";
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.Location = new System.Drawing.Point(466, 61);
            this.textBox_Tel.Name = "textBox_Tel";
            this.textBox_Tel.Size = new System.Drawing.Size(291, 20);
            this.textBox_Tel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tel";
            // 
            // textBox_Prenom
            // 
            this.textBox_Prenom.Location = new System.Drawing.Point(53, 61);
            this.textBox_Prenom.Name = "textBox_Prenom";
            this.textBox_Prenom.Size = new System.Drawing.Size(291, 20);
            this.textBox_Prenom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prénom";
            // 
            // textBox_Nom
            // 
            this.textBox_Nom.Location = new System.Drawing.Point(53, 19);
            this.textBox_Nom.Name = "textBox_Nom";
            this.textBox_Nom.Size = new System.Drawing.Size(291, 20);
            this.textBox_Nom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            // 
            // FrmAjoutPersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 227);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAjoutPersonnel";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Prenom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Tel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Perso_Annuler;
        private System.Windows.Forms.Button btn_Perso_Valider;
    }
}