namespace GestionAbsences.Vue
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
            txtNom = new TextBox();
            txtPrenom = new TextBox();
            txtTel = new TextBox();
            txtMail = new TextBox();
            cmbService = new ComboBox();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            SuspendLayout();

            txtNom.Location = new Point(112, 79);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(100, 23);
            txtNom.TabIndex = 0;
            txtNom.Text = "Nom";

            txtPrenom.Location = new Point(249, 79);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(100, 23);
            txtPrenom.TabIndex = 1;
            txtPrenom.Text = "Prénom";

            txtTel.Location = new Point(399, 79);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(100, 23);
            txtTel.TabIndex = 2;
            txtTel.Text = "Tel";

            txtMail.Location = new Point(562, 79);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(100, 23);
            txtMail.TabIndex = 3;
            txtMail.Text = "Mail";

            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(112, 165);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(121, 23);
            cmbService.TabIndex = 4;

            btnEnregistrer.Location = new Point(587, 247);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(75, 23);
            btnEnregistrer.TabIndex = 5;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;

            btnAnnuler.Location = new Point(112, 247);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 23);
            btnAnnuler.TabIndex = 6;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAnnuler);
            Controls.Add(btnEnregistrer);
            Controls.Add(cmbService);
            Controls.Add(txtMail);
            Controls.Add(txtTel);
            Controls.Add(txtPrenom);
            Controls.Add(txtNom);
            Name = "FrmAjoutPersonnel";
            Text = "FrmAjoutPersonnel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtTel;
        private TextBox txtMail;
        private ComboBox cmbService;
        private Button btnEnregistrer;
        private Button btnAnnuler;
    }
}