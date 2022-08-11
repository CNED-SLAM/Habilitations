using Habilitations.model;
using System;
using System.Collections.Generic;
using Serilog;

namespace Habilitations.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les profils
    /// </summary>
    public class ProfilAccess
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public ProfilAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les profils
        /// </summary>
        /// <returns>liste des profils</returns>
        public List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();
            if (access.Manager != null)
            {
                string req = "select * from profil order by nom;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("ProfilAccess.GesLesProfils nb records = {0}", records.Count);
                        foreach (Object[] record in records)
                        {
                            Log.Debug("ProfilAccess.GestLesProfils id={0} nom={1}", record[0], record[1]);
                            Profil profil = new Profil((int)record[0], (string)record[1]);
                            lesProfils.Add(profil);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("ProfilAccess.GetLesProfils catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
            return lesProfils;
        }

        /// <summary>
        /// Suppression d'un profil
        /// </summary>
        /// <param name="profil"></param>
        public void DelProfil(Profil profil)
        {
            if (access.Manager != null)
            {
                string req = "delete from profil where idprofil = @idprofil;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idprofil", profil.Idprofil }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("ProfilAccess.DelProfil catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Ajout d'un profil
        /// </summary>
        /// <param name="profil"></param>
        public void AddProfil(Profil profil)
        {
            if (access.Manager != null)
            {
                string req = "insert into profil (nom) values (@nom);";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@nom", profil.Nom }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.AddDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

    }
}
