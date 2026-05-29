using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace GestionAbsences.bddmanager
{
    /// <summary>
    /// Gestionnaire singleton de la connexion à la base de données MySQL.
    /// Fournit des méthodes pour exécuter des requêtes SELECT et UPDATE paramétrées.
    /// </summary>
    public class BddManager
    {
        private static BddManager? instance = null;
        private MySqlConnection connection;

        private BddManager(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Retourne l'instance unique du BddManager, en créant la connexion si nécessaire.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion MySQL.</param>
        /// <returns>Instance singleton de BddManager.</returns>
        public static BddManager GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new BddManager(connectionString);
            }
            return instance;
        }

        /// <summary>
        /// Exécute une requête SELECT et retourne un MySqlDataReader pour lire les résultats.
        /// </summary>
        /// <param name="chaineReq">La requête SQL à exécuter (SELECT).</param>
        /// <returns>MySqlDataReader contenant les résultats, ou null en cas d'erreur.</returns>
        public MySqlDataReader? ReqSelect(string chaineReq)
        {
            try
            {
                if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }
                MySqlCommand cmd = new MySqlCommand(chaineReq, this.connection);
                return cmd.ExecuteReader();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Exécute une requête UPDATE/INSERT/DELETE paramétrée.
        /// </summary>
        /// <param name="chaineReq">La requête SQL avec paramètres.</param>
        /// <param name="parametres">Dictionnaire des paramètres (nom -> valeur).</param>
        public void ReqUpdateParametree(string chaineReq, Dictionary<string, object> parametres)
        {
            try
            {
                if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }

                using (MySqlCommand cmd = new MySqlCommand(chaineReq, this.connection))
                {
                    foreach (var param in parametres)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur BDD : " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// Ferme la connexion à la base de données si elle est actuellement ouverte.
        /// </summary>
        public void Close()
        {
            this.FermerConnexion();
        }

        /// <summary>
        /// Exécute une requête de modification (INSERT, UPDATE, DELETE) dans la base de données.
        /// </summary>
        /// <param name="req">La requête SQL à exécuter.</param>
        public void ReqUpdate(string req)
        {
            try
            {
                // 1. On s'assure que la connexion est bien ouverte avant d'agir
                // (Ajuste le nom de ta méthode si elle s'appelle autrement, ex: Open() ou OuvrirConnexion())
                this.OuvrirConnexion();

                // 2. On prépare la commande SQL (en lui passant la requête et l'objet de connexion)
                // Note : Si ton objet de connexion s'appelle autrement que 'connection' (ex: 'cn', 'mysqlnex'), adapte-le ici.
                MySqlCommand cmd = new MySqlCommand(req, connection);

                // 3. On exécute la requête (ExecuteNonQuery est parfait pour INSERT, UPDATE, DELETE)
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // En cas d'erreur (problème de clé étrangère, syntaxe SQL...), on affiche un message clair
                MessageBox.Show($"Erreur lors de l'exécution de la modification : {ex.Message}",
                                "Erreur Base de données",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                // 4. On referme toujours la connexion pour libérer la base de données
                // (Ajuste si ta méthode s'appelle 'Close()' ou 'FermerConnexion()')
                this.FermerConnexion();
            }
        }

        private void OuvrirConnexion()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void FermerConnexion()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}