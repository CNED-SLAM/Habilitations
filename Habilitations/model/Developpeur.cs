
namespace Habilitations.model
{
    /// <summary>
    /// Classe métier liée à la table Developpeur
    /// </summary>
    public class Developpeur
    {

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idDeveloppeur"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="pwd"></param>
        /// <param name="profil"></param>
        public Developpeur(int iddeveloppeur, string nom, string prenom, string tel, string mail, Profil profil)
        {
            this.Iddeveloppeur = iddeveloppeur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Pwd = Pwd;
            this.Profil = profil;
        }

        public int Iddeveloppeur { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }
        public Profil Profil { get; set; }

    }
}
