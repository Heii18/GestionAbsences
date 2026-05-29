using System;
using System.Collections.Generic;
using System.Text;

namespace GestionAbsences.Modele
{
    /// <summary>
    /// Représente un motif légal ou organisationnel d'absence (ex: Maladie, Congés payés).
    /// </summary>
    public class Motif
    {
        /// <summary>
        /// Obtient ou définit l'identifiant unique du motif.
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Obtient ou définit le libellé descriptif du motif.
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Motif"/>.
        /// </summary>
        /// <param name="idMotif">L'identifiant unique du motif.</param>
        /// <param name="libelle">Le libellé de l'absence.</param>
        public Motif(int idMotif, string libelle)
        {
            this.IdMotif = idMotif;
            this.Libelle = libelle;
        }
    }
}