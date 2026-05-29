using System;
using System.Collections.Generic;
using GestionAbsences.bddmanager;
using GestionAbsences.Modele;
using MySql.Data.MySqlClient;

namespace GestionAbsences.dal
{
    /// <summary>
    /// Fournit les méthodes d'accès aux données pour l'application GestionAbsences
    /// (récupération et modification des personnels, services, absences et motifs).
    /// </summary>
    public class AccesDonnees
    {
        private static string connectionString = "server=localhost;user=root;password=;database=gestionabsences;";
        private static BddManager? manager = null;

        private static void InitManager()
        {
            manager = BddManager.GetInstance(connectionString);
        }

        /// <summary>
        /// Récupère la liste des services.
        /// </summary>
        /// <returns>Liste des objets Service.</returns>
        public static List<Service> GetLesServices()
        {
            List<Service> lesServices = new List<Service>();
            InitManager();

            if (manager != null)
            {
                string req = "SELECT * FROM service;";
                MySqlDataReader? reader = manager.ReqSelect(req);

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["idservice"]);
                        string nom = reader["nom"].ToString() ?? "";

                        Service s = new Service(id, nom);
                        lesServices.Add(s);
                    }
                    manager.Close();
                }
            }
            return lesServices;
        }

        /// <summary>
        /// Récupère la liste complète des personnels triée par nom et prénom.
        /// </summary>
        /// <returns>Liste des objets Personnel.</returns>
        public static List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            InitManager();

            if (manager != null)
            {
                string req = "SELECT * FROM personnel ORDER BY nom, prenom;";
                MySqlDataReader? reader = manager.ReqSelect(req);

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["idpersonnel"]);
                        string nom = reader["nom"].ToString() ?? "";
                        string prenom = reader["prenom"].ToString() ?? "";
                        string tel = reader["tel"].ToString() ?? "";
                        string mail = reader["mail"].ToString() ?? "";
                        int idService = Convert.ToInt32(reader["idservice"]);

                        Personnel p = new Personnel(id, nom, prenom, tel, mail, idService);
                        lesPersonnels.Add(p);
                    }
                    manager.Close();
                }
            }
            return lesPersonnels;
        }

        /// <summary>
        /// Récupère la liste des absences pour un personnel donné.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <returns>Liste des absences (Objet Absence) du personnel.</returns>
        public static List<Absence> GetLesAbsences(int idPersonnel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            InitManager();

            if (manager != null)
            {
                string req = $"SELECT a.idpersonnel, a.datedebut, a.datefin, m.idmotif, m.libelle " +
                             $"FROM absence a " +
                             $"JOIN motif m ON a.idmotif = m.idmotif " +
                             $"WHERE a.idpersonnel = {idPersonnel} " +
                             $"ORDER BY a.datedebut DESC;";

                MySqlDataReader? reader = manager.ReqSelect(req);

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        DateTime dateDebut = Convert.ToDateTime(reader["datedebut"]);
                        DateTime dateFin = Convert.ToDateTime(reader["datefin"]);
                        int idMotif = Convert.ToInt32(reader["idmotif"]);
                        string libelleMotif = reader["libelle"].ToString() ?? "";

                        Absence abs = new Absence(idPersonnel, dateDebut, dateFin, idMotif, libelleMotif);
                        lesAbsences.Add(abs);
                    }
                    manager.Close();
                }
            }
            return lesAbsences;
        }
        /// <summary>
        /// Récupère la liste des motifs d'absence triés par libellé.
        /// </summary>
        /// <returns>Liste des motifs (objet Motif).</returns>
        public static List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            InitManager();

            if (manager != null)
            {
                string req = "SELECT * FROM motif ORDER BY libelle;";
                MySqlDataReader? reader = manager.ReqSelect(req);

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["idmotif"]);
                        string libelle = reader["libelle"].ToString() ?? "";

                        Motif m = new Motif(id, libelle);
                        lesMotifs.Add(m);
                    }
                    manager.Close();
                }
            }
            return lesMotifs;
        }

        /// <summary>
        /// Ajoute une absence pour un personnel donné.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif d'absence.</param>
        public static void AjouterAbsence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif)
        {
            InitManager();
            if (manager != null)
            {
                string debutStr = dateDebut.ToString("yyyy-MM-dd");
                string finStr = dateFin.ToString("yyyy-MM-dd");

                string req = $"INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) " +
                             $"VALUES ({idPersonnel}, '{debutStr}', '{finStr}', {idMotif});";
                manager.ReqUpdate(req);
            }
        }

        /// <summary>
        /// Vérifie si les identifiants fournis correspondent à un responsable.
        /// </summary>
        /// <param name="login">Le login du responsable.</param>
        /// <param name="pwd">Le mot de passe en clair (comparé via SHA-256 côté base).</param>
        /// <returns>True si les identifiants sont valides, sinon false.</returns>
        public static bool VerifierConnexion(string login, string pwd)
        {
            bool estValide = false;
            InitManager();

            if (manager != null)
            {
                string req = "SELECT * FROM responsable WHERE login = '" + login + "' AND pwd = SHA2('" + pwd + "', 256);";
                MySqlDataReader? reader = manager.ReqSelect(req);

                if (reader != null)
                {
                    if (reader.Read())
                    {
                        estValide = true;
                    }
                    manager.Close();
                }
            }
            return estValide;
        }

        /// <summary>
        /// Ajoute un nouveau personnel dans la base de données.
        /// </summary>
        /// <param name="nom">Nom du personnel.</param>
        /// <param name="prenom">Prénom du personnel.</param>
        /// <param name="tel">Numéro de téléphone du personnel.</param>
        /// <param name="mail">Adresse e-mail du personnel.</param>
        /// <param name="idService">Identifiant du service associé au personnel.</param>
        public static void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idService)
        {
            InitManager();
            if (manager != null)
            {
                string req = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES (@nom, @prenom, @tel, @mail, @idService);";

                Dictionary<string, object> parametres = new Dictionary<string, object>
                {
                    { "@nom", nom },
                    { "@prenom", prenom },
                    { "@tel", tel },
                    { "@mail", mail },
                    { "@idService", idService }
                };

                manager.ReqUpdateParametree(req, parametres);
            }
        }
        /// <summary>
        /// Supprime le personnel identifié par son identifiant.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel à supprimer.</param>
        public static void SupprimerPersonnel(int idPersonnel)
        {
            InitManager();
            if (manager != null)
            {
                string req = $"DELETE FROM personnel WHERE idpersonnel = {idPersonnel};";
                manager.ReqUpdate(req);
            }
        }
        /// <summary>
/// Modifie les données d'un personnel existant.
/// </summary>
/// <param name="idPersonnel">Identifiant du personnel à modifier.</param>
/// <param name="nom">Nom du personnel.</param>
/// <param name="prenom">Prénom du personnel.</param>
/// <param name="tel">Numéro de téléphone.</param>
/// <param name="mail">Adresse e-mail.</param>
/// <param name="idService">Identifiant du service auquel le personnel appartient.</param>
public static void ModifierPersonnel(int idPersonnel, string nom, string prenom, string tel, string mail, int idService)
        {
            InitManager();
            if (manager != null)
            {
                string req = $"UPDATE personnel SET nom = '{nom}', prenom = '{prenom}', tel = '{tel}', mail = '{mail}', idservice = {idService} WHERE idpersonnel = {idPersonnel};";
                manager.ReqUpdate(req);
            }
        }
        /// <summary>
/// Supprime une absence pour le personnel identifié par son identifiant et la date de début.
/// </summary>
/// <param name="idPersonnel">Identifiant du personnel.</param>
/// <param name="dateDebut">Date de début de l'absence à supprimer.</param>
public static void SupprimerAbsence(int idPersonnel, DateTime dateDebut)
        {
            InitManager();
            if (manager != null)
            {
                string debutStr = dateDebut.ToString("yyyy-MM-dd");

                string req = $"DELETE FROM absence WHERE idpersonnel = {idPersonnel} AND datedebut = '{debutStr}';";
                manager.ReqUpdate(req);
            }
        }
        /// <summary>
        /// Modifie une absence pour un personnel donné (met à jour les dates et le motif).
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebutOrigine">Date de début originale utilisée pour identifier l'enregistrement.</param>
        /// <param name="nouvelleDateDebut">Nouvelle date de début de l'absence.</param>
        /// <param name="nouvelleDateFin">Nouvelle date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif d'absence.</param>
        public static void ModifierAbsence(int idPersonnel, DateTime dateDebutOrigine, DateTime nouvelleDateDebut, DateTime nouvelleDateFin, int idMotif)
        {
            InitManager();
            if (manager != null)
            {
                string origineStr = dateDebutOrigine.ToString("yyyy-MM-dd");
                string nouvelleDebutStr = nouvelleDateDebut.ToString("yyyy-MM-dd");
                string nouvelleFinStr = nouvelleDateFin.ToString("yyyy-MM-dd");

                string req = $"UPDATE absence SET datedebut = '{nouvelleDebutStr}', datefin = '{nouvelleFinStr}', idmotif = {idMotif} " +
                             $"WHERE idpersonnel = {idPersonnel} AND datedebut = '{origineStr}';";

                manager.ReqUpdate(req);
            }
        }
    }
}