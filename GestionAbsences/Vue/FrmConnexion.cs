using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GestionAbsences.Controleur;

namespace GestionAbsences.Vue
{
    /// <summary>
    /// Formulaire d'authentification permettant à l'utilisateur de se connecter à l'application.
    /// </summary>
    public partial class FrmConnexion : Form
    {
        private ControleurApp controleur;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="FrmConnexion"/>.
        /// </summary>
        /// <param name="controleur">Instance du contrôleur principal de l'application.</param>
        public FrmConnexion(ControleurApp controleur)
        {
            InitializeComponent();
            this.controleur = controleur;
        }

        /// <summary>
        /// Gestionnaire d'événement lié au clic sur le bouton de validation de connexion.
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les données de l'événement.</param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string pwd = txtPassword.Text;

            if (login != "" && pwd != "")
            {
                controleur.Connexion(login, pwd);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs vides", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}