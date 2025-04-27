namespace Kanban.view
{
    partial class FrmListePersonnel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Perso_Ajoutez = new System.Windows.Forms.Button();
            this.btn_Perso_Modifier = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_Absence = new System.Windows.Forms.DataGridView();
            this.button_Abs_Modifier = new System.Windows.Forms.Button();
            this.button_Abs_Ajoutez = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Absence)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(840, 408);
            this.dataGridView1.TabIndex = 2;
            // 
            // btn_Perso_Ajoutez
            // 
            this.btn_Perso_Ajoutez.Location = new System.Drawing.Point(5, 431);
            this.btn_Perso_Ajoutez.Name = "btn_Perso_Ajoutez";
            this.btn_Perso_Ajoutez.Size = new System.Drawing.Size(97, 31);
            this.btn_Perso_Ajoutez.TabIndex = 3;
            this.btn_Perso_Ajoutez.Text = "Ajoutez";
            this.btn_Perso_Ajoutez.UseVisualStyleBackColor = true;
            // 
            // btn_Perso_Modifier
            // 
            this.btn_Perso_Modifier.Location = new System.Drawing.Point(117, 431);
            this.btn_Perso_Modifier.Name = "btn_Perso_Modifier";
            this.btn_Perso_Modifier.Size = new System.Drawing.Size(97, 31);
            this.btn_Perso_Modifier.TabIndex = 4;
            this.btn_Perso_Modifier.Text = "Modifier";
            this.btn_Perso_Modifier.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 580);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btn_Perso_Modifier);
            this.tabPage1.Controls.Add(this.btn_Perso_Ajoutez);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(904, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personnel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_Absence);
            this.tabPage2.Controls.Add(this.button_Abs_Modifier);
            this.tabPage2.Controls.Add(this.button_Abs_Ajoutez);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(904, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Absence";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Absence
            // 
            this.dataGridView_Absence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Absence.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_Absence.Name = "dataGridView_Absence";
            this.dataGridView_Absence.Size = new System.Drawing.Size(840, 408);
            this.dataGridView_Absence.TabIndex = 5;
            // 
            // button_Abs_Modifier
            // 
            this.button_Abs_Modifier.Location = new System.Drawing.Point(117, 431);
            this.button_Abs_Modifier.Name = "button_Abs_Modifier";
            this.button_Abs_Modifier.Size = new System.Drawing.Size(97, 31);
            this.button_Abs_Modifier.TabIndex = 7;
            this.button_Abs_Modifier.Text = "Modifier";
            this.button_Abs_Modifier.UseVisualStyleBackColor = true;
            // 
            // button_Abs_Ajoutez
            // 
            this.button_Abs_Ajoutez.Location = new System.Drawing.Point(5, 431);
            this.button_Abs_Ajoutez.Name = "button_Abs_Ajoutez";
            this.button_Abs_Ajoutez.Size = new System.Drawing.Size(97, 31);
            this.button_Abs_Ajoutez.TabIndex = 6;
            this.button_Abs_Ajoutez.Text = "Ajoutez";
            this.button_Abs_Ajoutez.UseVisualStyleBackColor = true;
            // 
            // FrmListePersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 604);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmListePersonnel";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmListePersonnel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Absence)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Perso_Modifier;
        private System.Windows.Forms.Button btn_Perso_Ajoutez;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_Absence;
        private System.Windows.Forms.Button button_Abs_Modifier;
        private System.Windows.Forms.Button button_Abs_Ajoutez;
    }
}