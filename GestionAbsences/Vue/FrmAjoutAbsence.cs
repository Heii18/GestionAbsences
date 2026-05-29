using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionAbsences.Controleur;
using GestionAbsences.Modele;

namespace GestionAbsences.Vue
{
    public partial class FrmAjoutAbsence : Form
    {
        private ControleurApp controleur;
        private int idPersonnel;

        /// <summary>
        /// Initialise une nouvelle instance de <see cref="FrmAjoutAbsence"/>.
        /// </summary>
        /// <param name="controleur">Le contrôleur applicatif utilisé par la vue.</param>
        /// <param name="idPersonnel">L'identifiant du personnel pour lequel on ajoute l'absence.</param>
        public FrmAjoutAbsence(ControleurApp controleur, int idPersonnel)
        {
            InitializeComponent();
            this.controleur = controleur;
            this.idPersonnel = idPersonnel;

            RemplirDonneesMotifs(GetControleur1());
        }

        private ControleurApp GetControleur1()
        {
            return controleur;
        }

        private void RemplirDonneesMotifs(ControleurApp controleur1)
        {
            List<Motif> lesMotifs = controleur1.GetLesMotifs();
            cmbMotif.DataSource = lesMotifs;
            cmbMotif.DisplayMember = "Libelle";
            cmbMotif.ValueMember = "IdMotif";
        }

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

            List<Absence> lesAbsencesExistantes = controleur.GetLesAbsences(idPersonnel);

            foreach (Absence abs in lesAbsencesExistantes)
            {
                if (dateDebut <= abs.DateFin.Date && dateFin >= abs.DateDebut.Date)
                {
                    MessageBox.Show($"Impossible d'enregistrer : ce personnel est déjà déclaré absent sur cette période.\n" +
                                    $"(Absence existante : du {abs.DateDebut:dd/MM/yyyy} au {abs.DateFin:dd/MM/yyyy})",
                                    "Doublon / Chevauchement détecté",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return; 
                }
            }

            int idMotif = Convert.ToInt32(cmbMotif.SelectedValue);
            controleur.EnregistrerNouvelleAbsence(idPersonnel, dtpDebut.Value, dtpFin.Value, idMotif);

            MessageBox.Show("Absence enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}