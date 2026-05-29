using System;
using System.Collections.Generic;
using System.Text;

namespace GestionAbsences.Modele
{
    /// <summary>
    /// Représente une absence d'un personnel sur une période donnée.
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Identifiant du personnel concerné par l'absence.
        /// </summary>
        public int IdPersonnel { get; set; }

        /// <summary>
        /// Date de début de l'absence.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'absence.
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Identifiant du motif d'absence.
        /// </summary>
        public int IdMotif { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Absence"/>.
        /// </summary>
        /// <param name="idPersonnel">Identifiant du personnel.</param>
        /// <param name="dateDebut">Date de début de l'absence.</param>
        /// <param name="dateFin">Date de fin de l'absence.</param>
        /// <param name="idMotif">Identifiant du motif d'absence.</param>
        /// <param name="libelleMotif">Libellé du motif (optionnel).</param>
        public Absence(int idPersonnel, DateTime dateDebut, DateTime dateFin, int idMotif, string libelleMotif)
        {
            this.IdPersonnel = idPersonnel;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.IdMotif = idMotif;
        }
    }
}