using Habilitations.model;
using System;
using System.Collections.Generic;

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
                        lesProfils = records.ConvertAll(new Converter<Object[], Profil>(ConvertProfil));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesProfils;
        }

        /// <summary>
        /// Utilise les valeurs d'un tableau pour créer un objet de type Profil
        /// </summary>
        /// <param name="profil">tableau d'objets contenant les valeurs des champs du profil</param>
        /// <returns>objet de type Profil</returns>
        private Profil ConvertProfil(Object[] profil)
        {
            return new Profil((int)profil[0], (string)profil[1]);
        }

    }
}
