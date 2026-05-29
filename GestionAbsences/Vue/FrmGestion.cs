using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire principal de l'application assurant la gestion et l'affichage des membres du personnel.
    /// </summary>
    public partial class FrmGestion : Form
    {
        private ControleurApp controleur;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FrmGestion"/>.
        /// </summary>
        /// <param name="controleur">Instance du contrôleur principal de l'application.</param>
        public FrmGestion(ControleurApp controleur)
        {
            InitializeComponent();
            this.controleur = controleur;

            RemplirPersonnel();
        }

        /// <summary>
        /// Récupère la liste globale des membres du personnel et alimente le tableau d'affichage.
        /// </summary>
        private void RemplirPersonnel()
        {
            List<Personnel> lesPersonnels = controleur.GetLesPersonnels();

            dgvPersonnel.DataSource = lesPersonnels;

            dgvPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonnel.MultiSelect = false;
        }

        /// <summary>
        /// Ouvre le formulaire d'ajout d'un nouveau personnel.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutPersonnel frmAjout = new FrmAjoutPersonnel(controleur);
            frmAjout.ShowDialog();

            RemplirPersonnel();
        }

        /// <summary>
        /// Supprime le membre du personnel sélectionné après confirmation.
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count > 0 && dgvPersonnel.SelectedRows[0].DataBoundItem is Personnel perso)
            {
                DialogResult confirmation = MessageBox.Show(
                    $"Voulez-vous vraiment supprimer {perso.Prenom} {perso.Nom} ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    controleur.SupprimerPersonnel(perso.IdPersonnel);
                    MessageBox.Show("Employé supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RemplirPersonnel();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un membre du personnel à supprimer.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Ouvre le formulaire de modification pour le membre du personnel sélectionné.
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count > 0 && dgvPersonnel.SelectedRows[0].DataBoundItem is Personnel personnelSelectionne)
            {
                FrmModifierPersonnel frmModif = new FrmModifierPersonnel(controleur, personnelSelectionne);
                frmModif.ShowDialog();

                RemplirPersonnel();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un membre du personnel à modifier.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Ouvre la gestion des absences liée au membre du personnel sélectionné.
        /// </summary>
        private void btnAbsences_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count > 0 && dgvPersonnel.SelectedRows[0].DataBoundItem is Personnel personnelSelectionne)
            {
                FrmAbsences frmAbs = new FrmAbsences(controleur, personnelSelectionne);
                frmAbs.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un membre du personnel pour voir ses absences.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}