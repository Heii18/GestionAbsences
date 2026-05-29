using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire dédié à la mise à jour des informations d'un membre du personnel.
    /// </summary>
    public partial class FrmModifierPersonnel : Form
    {
        private ControleurApp controleur;
        private Personnel personnelAModifier;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FrmModifierPersonnel"/>.
        /// </summary>
        /// <param name="controleur">Instance du contrôleur principal de l'application.</param>
        /// <param name="personnel">Le membre du personnel à modifier.</param>
        public FrmModifierPersonnel(ControleurApp controleur, Personnel personnel)
        {
            InitializeComponent();
            this.controleur = controleur;
            this.personnelAModifier = personnel;

            RemplirDonneesServices();
            InitialiserChamps();
        }

        /// <summary>
        /// Remplit la ComboBox des services de l'entreprise.
        /// </summary>
        private void RemplirDonneesServices()
        {
            List<Service> lesServices = controleur.GetLesServices();
            cmbService.DataSource = lesServices;
            cmbService.DisplayMember = "Libelle";
            cmbService.ValueMember = "IdService";
        }

        /// <summary>
        /// Injecte les données actuelles du personnel dans les champs textuels du formulaire.
        /// </summary>
        private void InitialiserChamps()
        {
            txtNom.Text = personnelAModifier.Nom;
            txtPrenom.Text = personnelAModifier.Prenom;
            txtTel.Text = personnelAModifier.Tel;
            txtMail.Text = personnelAModifier.Mail;
            cmbService.SelectedValue = personnelAModifier.IdService;
        }

        /// <summary>
        /// Enregistre les nouvelles coordonnées du personnel après s'être assuré de leur présence.
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNom.Text) && !string.IsNullOrWhiteSpace(txtPrenom.Text) && cmbService.SelectedValue != null)
            {
                controleur.ModifierPersonnel(
                    personnelAModifier.IdPersonnel,
                    txtNom.Text,
                    txtPrenom.Text,
                    txtTel.Text,
                    txtMail.Text,
                    Convert.ToInt32(cmbService.SelectedValue)
                );

                MessageBox.Show("Informations modifiées avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Le nom et le prénom ne peuvent pas être vides.", "Champs obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Annule l'action en cours et ferme la fenêtre.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}