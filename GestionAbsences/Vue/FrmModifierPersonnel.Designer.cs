namespace GestionAbsences.Vue
{
    partial class FrmModifierPersonnel
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
            btnAnnuler = new Button();
            btnEnregistrer = new Button();
            SuspendLayout();
            // 
            // txtNom
            // 
            txtNom.Location = new Point(100, 119);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(100, 23);
            txtNom.TabIndex = 1;
            txtNom.Text = "Nom";
            // 
            // txtPrenom
            // 
            txtPrenom.Location = new Point(258, 119);
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Size = new Size(100, 23);
            txtPrenom.TabIndex = 2;
            txtPrenom.Text = "Prénom";
            // 
            // txtTel
            // 
            txtTel.Location = new Point(413, 119);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(100, 23);
            txtTel.TabIndex = 3;
            txtTel.Text = "Tel";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(541, 119);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(100, 23);
            txtMail.TabIndex = 4;
            txtMail.Text = "Mail";
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(100, 189);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(121, 23);
            cmbService.TabIndex = 5;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(100, 277);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 23);
            btnAnnuler.TabIndex = 7;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(566, 277);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(75, 23);
            btnEnregistrer.TabIndex = 8;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // FrmModifierPersonnel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnregistrer);
            Controls.Add(btnAnnuler);
            Controls.Add(cmbService);
            Controls.Add(txtMail);
            Controls.Add(txtTel);
            Controls.Add(txtPrenom);
            Controls.Add(txtNom);
            Name = "FrmModifierPersonnel";
            Text = "FrmModifierPersonnel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtTel;
        private TextBox txtMail;
        private ComboBox cmbService;
        private Button btnAnnuler;
        private Button btnEnregistrer;
    }
}