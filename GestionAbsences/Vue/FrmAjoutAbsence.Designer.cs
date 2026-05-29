namespace GestionAbsences.Vue
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
            dtpDebut = new DateTimePicker();
            dtpFin = new DateTimePicker();
            cmbMotif = new ComboBox();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            SuspendLayout();
            // 
            // dtpDebut
            // 
            dtpDebut.Location = new Point(139, 12);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(200, 23);
            dtpDebut.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(345, 12);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 1;
            // 
            // cmbMotif
            // 
            cmbMotif.FormattingEnabled = true;
            cmbMotif.Location = new Point(12, 12);
            cmbMotif.Name = "cmbMotif";
            cmbMotif.Size = new Size(121, 23);
            cmbMotif.TabIndex = 2;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(470, 415);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(75, 23);
            btnEnregistrer.TabIndex = 3;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(58, 415);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 23);
            btnAnnuler.TabIndex = 4;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // FrmAjoutAbsence
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAnnuler);
            Controls.Add(btnEnregistrer);
            Controls.Add(cmbMotif);
            Controls.Add(dtpFin);
            Controls.Add(dtpDebut);
            Name = "FrmAjoutAbsence";
            Text = "FrmAjoutAbsence";
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private ComboBox cmbMotif;
        private Button btnEnregistrer;
        private Button btnAnnuler;
    }
}