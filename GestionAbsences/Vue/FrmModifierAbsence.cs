using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire permettant de modifier une absence existante.
    /// </summary>
    public partial class FrmModifierAbsence : Form
    {
        private ControleurApp controleur;
        private Absence absenceAModifier;
        private DateTime dateDebutOrigine;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FrmModifierAbsence"/>.
        /// </summary>
        /// <param name="controleur">Instance du contrôleur principal de l'application.</param>
        /// <param name="absence">L'absence sélectionnée pour modification.</param>
        public FrmModifierAbsence(ControleurApp controleur, Absence absence)
        {
            InitializeComponent();
            this.controleur = controleur;
            this.absenceAModifier = absence;

            this.dateDebutOrigine = absence.DateDebut;

            RemplirDonneesMotifs();
            InitialiserChamps();
        }

        /// <summary>
        /// Remplit la liste déroulante des motifs d'absence disponibles.
        /// </summary>
        private void RemplirDonneesMotifs()
        {
            List<Motif> lesMotifs = controleur.GetLesMotifs();
            cmbMotif.DataSource = lesMotifs;
            cmbMotif.DisplayMember = "Libelle";
            cmbMotif.ValueMember = "IdMotif";
        }

        /// <summary>
        /// Pré-remplit les contrôles graphiques avec les données actuelles de l'absence.
        /// </summary>
        private void InitialiserChamps()
        {
            dtpDebut.Value = absenceAModifier.DateDebut;
            dtpFin.Value = absenceAModifier.DateFin;
            cmbMotif.SelectedValue = absenceAModifier.IdMotif;
        }

        /// <summary>
        /// Valide et applique les modifications de l'absence en base de données.
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            DateTime dateDebut = dtpDebut.Value.Date;
            DateTime dateFin = dtpFin.Value.Date;

            if (dateFin < dateDebut)
            {
                MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur de cohérence", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMotif.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un motif.", "Données manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Absence> lesAbsencesExistantes = controleur.GetLesAbsences(absenceAModifier.IdPersonnel);

            foreach (Absence abs in lesAbsencesExistantes)
            {
                if (abs.DateDebut.Date == dateDebutOrigine.Date)
                {
                    continue;
                }

                if (dateDebut <= abs.DateFin.Date && dateFin >= abs.DateDebut.Date)
                {
                    MessageBox.Show($"Impossible de modifier : ce personnel est déjà enregistré absent sur cette période.\n" +
                                    $"(Conflit avec l'absence du {abs.DateDebut:dd/MM/yyyy} au {abs.DateFin:dd/MM/yyyy})",
                                    "Doublon / Chevauchement détecté",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return; 
                }
            }

            int idMotif = Convert.ToInt32(cmbMotif.SelectedValue);

            controleur.ModifierAbsence(
                absenceAModifier.IdPersonnel,
                dateDebutOrigine,
                dateDebut,
                dateFin,
                idMotif
            );

            MessageBox.Show("Absence modifiée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Ferme le formulaire sans enregistrer les modifications.
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}