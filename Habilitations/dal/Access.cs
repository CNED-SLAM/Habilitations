using Habilitations.bddmanager;
using System;
using Serilog;
using System.Configuration;

namespace Habilitations.dal
{
    /// <summary>
    /// Singleton : classe d'accès à BddManager
    /// </summary>
    public class Access
    {
        /// <summary>
        /// nom de connexion à la bdd
        /// </summary>
        private static readonly string connectionName = "Habilitations.Properties.Settings.habilitationsConnectionString";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// Getter sur l'objet d'accès aux données
        /// </summary>
        public BddManager Manager { get; }

        /// <summary>
        /// Création unique de l'objet de type BddManager
        /// Arrête le programme si l'accès à la BDD a échoué
        /// </summary>
        private Access()
        {
            String connectionString = null;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt")
                    .CreateLogger();
                connectionString = GetConnectionStringByName(connectionName);
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception e)
            {
                Log.Fatal("Access.Access catch connectionString={0} erreur={1}", connectionString, e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création d'une seule instance de la classe
        /// </summary>
        /// <returns></returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Récupération de la chaîne de connexion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

    }
}
