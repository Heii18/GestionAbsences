namespace GestionAbsences.Vue
{
    partial class FrmModifierAbsence
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
            cmbMotif = new ComboBox();
            dtpDebut = new DateTimePicker();
            dtpFin = new DateTimePicker();
            btnAnnuler = new Button();
            btnEnregistrer = new Button();
            SuspendLayout();
            // 
            // cmbMotif
            // 
            cmbMotif.FormattingEnabled = true;
            cmbMotif.Location = new Point(12, 12);
            cmbMotif.Name = "cmbMotif";
            cmbMotif.Size = new Size(121, 23);
            cmbMotif.TabIndex = 3;
            // 
            // dtpDebut
            // 
            dtpDebut.Location = new Point(139, 12);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(200, 23);
            dtpDebut.TabIndex = 4;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(345, 12);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 5;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(58, 415);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 23);
            btnAnnuler.TabIndex = 6;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(470, 415);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(75, 23);
            btnEnregistrer.TabIndex = 7;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // FrmModifierAbsence
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAnnuler);
            Controls.Add(dtpFin);
            Controls.Add(dtpDebut);
            Controls.Add(cmbMotif);
            Name = "FrmModifierAbsence";
            Text = "FrmModifierAbsence";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbMotif;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private Button btnAnnuler;
        private Button btnEnregistrer;
    }
}