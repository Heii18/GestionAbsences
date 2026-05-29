namespace GestionAbsences.Vue
{
    partial class FrmGestion
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
            dgvPersonnel = new DataGridView();
            btnAjouter = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnAbsences = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).BeginInit();
            SuspendLayout();
            // 
            // dgvPersonnel
            // 
            dgvPersonnel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonnel.Location = new Point(12, 32);
            dgvPersonnel.Name = "dgvPersonnel";
            dgvPersonnel.Size = new Size(671, 317);
            dgvPersonnel.TabIndex = 0;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(12, 355);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(75, 23);
            btnAjouter.TabIndex = 1;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(204, 355);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(75, 23);
            btnModifier.TabIndex = 2;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(436, 355);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(75, 23);
            btnSupprimer.TabIndex = 3;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnAbsences
            // 
            btnAbsences.Location = new Point(552, 355);
            btnAbsences.Name = "btnAbsences";
            btnAbsences.Size = new Size(131, 23);
            btnAbsences.TabIndex = 4;
            btnAbsences.Text = "Afficher Absences";
            btnAbsences.UseVisualStyleBackColor = true;
            btnAbsences.Click += btnAbsences_Click;
            // 
            // FrmGestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAbsences);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnAjouter);
            Controls.Add(dgvPersonnel);
            Name = "FrmGestion";
            Text = "FrmGestion";
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).EndInit();
            ResumeLayout(false);
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView dgvPersonnel;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnAbsences;
    }
}