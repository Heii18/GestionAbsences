using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using GestionAbsences.Vue;
using GestionAbsences.dal;
using GestionAbsences.Modele;

namespace GestionAbsences.Controleur
{
    /// <summary>
    /// Contrôleur principal de l'application de gestion des absences.
    /// Gère la connexion et délègue les opérations CRUD vers AccesDonnees.
    /// </summary>
    public class ControleurApp
    {
        private FrmConnexion frmConnexion;

        /// <summary>
        /// Initialise une nouvelle instance du contrôleur principal de l'application.
        /// Ouvre le formulaire de connexion.
        /// </summary>
        public ControleurApp()
        {
            frmConnexion = new FrmConnexion(this);
            frmConnexion.ShowDialog();
        }

        /// <summary>
        /// Tente de connecter un utilisateur avec le couple login / mot de passe.
        /// Si la connexion réussit, cache le formulaire de connexion et ouvre le formulaire de gestion.
        /// Sinon affiche un message d'erreur.
        /// </summary>
        /// <param name="login">Identifiant de connexion.</param>
        /// <param name="password">Mot de passe de l'utilisateur.</param>
        public void Connexion(string login, string password)
        {
            if (AccesDonnees.VerifierConnexion(login, password))
            {
                frmConnexion.Hide();

                FrmGestion frmGestion = new FrmGestion(this);
                frmGestion.ShowDialog();

                frmConnexion.Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprime le personnel identifié par idPersonnel en déléguant l'opération à AccesDonnees.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Maintained as instance for compatibility with existing callers")]
        public void SupprimerPersonnel(int idPersonnel)
        {
            AccesDonnees.SupprimerPersonnel(idPersonnel);
        }

        /// <summary>
        /// Récupère la liste des services.
        /// Délègue la récupération à AccesDonnees.
        /// </summary>
        /// <returns>Liste des services disponibles.</returns>
        public List<Service> GetLesServices()
        {
            return AccesDonnees.GetLesServices();
        }

        /// <summary>
        /// Enregistre un nouveau personnel en délégant l'insertion à AccesDonnees.
        /// </summary>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        /// <param name="mail">Adresse e‑mail.</param>
        /// <param name="idService">Identifiant du service.</param>
        public void EnregistrerNouveauPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            AccesDonnees.AjouterPersonnel(nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Récupère la liste des personnels.
        /// Délègue la récupération à AccesDonnees.
        /// </summary>
        public List<Personnel> GetLesPersonnels()
        {
            return AccesDonnees.GetLesPersonnels();
        }

        /// <summary>
        /// Modifie un personnel existant en déléguant la mise à jour à AccesDonnees.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Numéro de téléphone.</param>
        /// <param name="mail">Adresse e‑mail.</param>
        /// <param name="idService">Identifiant du service.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Maintained as instance for compatibility with existing callers")]
        public void ModifierPersonnel(int idPersonnel, string nom, string prenom, string tel, string mail, int idService)
        {
            AccesDonnees.ModifierPersonnel(idPersonnel, nom, prenom, tel, mail, idService);
        }

        /// <summary>
        /// Récupère la liste des absences pour le personnel identifié par idPersonnel.
        /// Délège l'accès à AccesDonnees.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <returns>Liste des absences pour le personnel.</returns>
        public List<Absence> GetLesAbsences(int idPersonnel)
        {
            return AccesDonnees.GetLesAbsences(idPersonnel);
        }

        /// <summary>
        /// Récupère la liste des motifs disponibles.
        /// Délègue la récupération à AccesDonnees.
        /// </summary>
        public List<Motif> GetLesMotifs()
        {
            return AccesDonnees.GetLesMotifs();
        }

        /// <summary>
        /// Supprime une absence pour le personnel indiqué.
        /// Délègue l'opération à AccesDonnees.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début de l'absence à supprimer (clé d'identification).</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Maintained as instance for compatibility with existing callers")]
        public void SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            AccesDonnees.SupprimerAbsence(idPersonnel, dateDebut);
        }

        /// <summary>
        /// Modifie une absence existante en déléguant la mise à jour à AccesDonnees.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebutOrigine">Date de début d'origine de l'absence (clé d'identification).</param>
        /// <param name="nouvelleDateDebut">Nouvelle date de début de l'absence.</param>
        /// <param name="nouvelleDateFin">Nouvelle date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        public void ModifierAbsence(int idPersonnel, DateTime dateDebutOrigine, DateTime nouvelleDateDebut, DateTime nouvelleDateFin, int idMotif)
        {
            AccesDonnees.ModifierAbsence(idPersonnel, dateDebutOrigine, nouvelleDateDebut, nouvelleDateFin, idMotif);
        }

        /// <summary>
        /// Enregistre une nouvelle absence pour le personnel indiqué.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif.</param>
        public void EnregistrerNouvelleAbsence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            AccesDonnees.AjouterAbsence(idPersonnel, dateDebut, dateFin, idMotif);
        }
    }
}