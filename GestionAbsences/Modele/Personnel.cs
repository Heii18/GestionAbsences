using System;
using System.Collections.Generic;
using System.Text;

namespace GestionAbsences.Modele
{
    /// <summary>
    /// Représente un membre du personnel de l'entreprise.
    /// </summary>
    public class Personnel
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du personnel.
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Obtient ou définit le nom de famille.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Obtient ou définit le prénom.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Obtient ou définit le numéro de téléphone professionnel ou personnel.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Obtient ou définit l'adresse e-mail.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Obtient ou définit l'identifiant du service auquel appartient le membre du personnel.
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Personnel"/>.
        /// </summary>
        /// <param name="idPersonnel">L'identifiant unique du personnel.</param>
        /// <param name="nom">Le nom de famille.</param>
        /// <param name="prenom">Le prénom.</param>
        /// <param name="tel">Le numéro de téléphone.</param>
        /// <param name="mail">L'adresse de courrier électronique.</param>
        /// <param name="idService">L'identifiant du service d'affectation.</param>
        public Personnel(int idPersonnel, string nom, string prenom, string tel, string mail, int idService)
        {
            this.IdPersonnel = idPersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.IdService = idService;
        }
    }
}