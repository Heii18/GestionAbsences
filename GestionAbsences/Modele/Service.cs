using System;
using System.Collections.Generic;
using System.Text;

namespace GestionAbsences.Modele
{
    /// <summary>
    /// Représente un département ou un service au sein de la structure (ex: RH, Informatique).
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du service.
        /// </summary>
        public int IdService { get; set; }

        /// <summary>
        /// Obtient ou définit l'intitulé ou libellé du service.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Service"/>.
        /// </summary>
        /// <param name="idService">L'identifiant unique du service.</param>
        /// <param name="libelle">Le nom du service.</param>
        public Service(int idService, string libelle)
        {
            this.IdService = idService;
            this.Libelle = libelle;
        }
    }
}