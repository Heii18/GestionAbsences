using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire affichant et gérant les absences d'un membre du personnel.
    /// </summary>
    public partial class FrmAbsences : Form
    {
        private ControleurApp controleur;
        private Personnel personnelConcerne;

        /// <summary>
        /// Initialise le formulaire affichant et gérant les absences pour un membre du personnel.
        /// </summary>
        /// <param name="controleur">Instance du contrôleur de l'application.</param>
        /// <param name="personnel">Le personnel dont on affiche les absences.</param>
        public FrmAbsences(ControleurApp controleur, Personnel personnel)
        {
            InitializeComponent();
            this.controleur = controleur;
            this.personnelConcerne = personnel;

            lblTitre.Text = $"Absences de : {personnelConcerne.Prenom} {personnelConcerne.Nom}";

            RemplirAbsences();
        }

        private void RemplirAbsences()
        {
            // CORRECTION ICI : Changement de "ControleurApp" par "controleur" (instance non-statique)
            List<Absence> lesAbsences = controleur.GetLesAbsences(personnelConcerne.IdPersonnel);
            dgvAbsences.DataSource = lesAbsences;

            dgvAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutAbsence frmAjout = new FrmAjoutAbsence(controleur, personnelConcerne.IdPersonnel);
            frmAjout.ShowDialog();

            RemplirAbsences();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0 && dgvAbsences.SelectedRows[0].DataBoundItem is Absence absenceSelectionnee)
            {
                DialogResult confirmation = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer l'absence débutant le {absenceSelectionnee.DateDebut.ToString("dd/MM/yyyy")} ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmation == DialogResult.Yes)
                {
                    controleur.SupprimerAbsence(absenceSelectionnee.IdPersonnel, absenceSelectionnee.DateDebut);

                    MessageBox.Show("Absence supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RemplirAbsences();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une absence dans le tableau.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAbsences.SelectedRows.Count > 0 && dgvAbsences.SelectedRows[0].DataBoundItem is Absence absenceSelectionnee)
            {
                FrmModifierAbsence frmModif = new FrmModifierAbsence(controleur, absenceSelectionnee);
                frmModif.ShowDialog();

                RemplirAbsences();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une absence à modifier.", "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}