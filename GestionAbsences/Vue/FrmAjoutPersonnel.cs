using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire permettant l'ajout d'un nouveau membre du personnel dans le système.
    /// </summary>
    public partial class FrmAjoutPersonnel : Form
    {
        private ControleurApp controleur;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FrmAjoutPersonnel"/>.
        /// </summary>
        /// <param name="controleur">L'instance du contrôleur principal de l'application.</param>
        public FrmAjoutPersonnel(ControleurApp controleur)
        {
            InitializeComponent();
            this.controleur = controleur;

            RemplirDonneesServices();
        }

        /// <summary>
        /// Récupère la liste des services depuis le contrôleur et alimente la ComboBox associée.
        /// </summary>
        private void RemplirDonneesServices()
        {
            List<Service> lesServices = controleur.GetLesServices();

            cmbService.DataSource = lesServices;
            cmbService.DisplayMember = "Libelle";
            cmbService.ValueMember = "IdService";
        }

        /// <summary>
        /// Gestionnaire d'événement déclenché lors du clic sur le bouton d'enregistrement.
        /// Vérifie la validité des champs requis et effectue l'appel au contrôleur.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les données de l'événement de clic.</param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNom.Text) && !string.IsNullOrWhiteSpace(txtPrenom.Text) && cmbService.SelectedValue != null)
            {
                string nom = txtNom.Text;
                string prenom = txtPrenom.Text;
                string tel = txtTel.Text;
                string mail = txtMail.Text;
                int idService = Convert.ToInt32(cmbService.SelectedValue);

                controleur.EnregistrerNouveauPersonnel(nom, prenom, tel, mail, idService);

                MessageBox.Show("Personnel ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir au moins le Nom et le Prénom.", "Données manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Gestionnaire d'événement déclenché lors du clic sur le bouton Annuler.
        /// Ferme le formulaire sans enregistrer.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les données de l'événement.</param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}