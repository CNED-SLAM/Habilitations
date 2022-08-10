using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Habilitations.model;

namespace Habilitations.dal.Tests
{
    [TestClass()]
    public class DeveloppeurAccessTests
    {
        private static readonly Access access = Access.GetInstance();
        private static readonly DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();

        private void BeginTransaction()
        {
            access.Manager.ReqControle("SET AUTOCOMMIT=0");
            access.Manager.ReqControle("START TRANSACTION");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=0");
        }

        private void EndTransaction()
        {
            access.Manager.ReqControle("ROLLBACK");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=1");
        }

        [TestMethod()]
        public void DeveloppeurAccessTest()
        {
            Assert.IsNotNull(access, "devrait réussir si connexion à la BDD correcte");
        }

        [TestMethod()]
        public void ControleAuthentificationTest()
        {
            string nom = "Nolan";
            string prenom = "Rooney";
            string pwd = "Nolan";
            Assert.IsTrue(developpeurAccess.ControleAuthentification(new Admin(nom, prenom, pwd)), 
                "devrait réussir : données utilisateur correctes");
            string erreurNom = "__";
            string erreurPrenom = "__";
            string erreurPwd = "__";
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(erreurNom, prenom, pwd)), 
                "devrait échouer : nom incorrect");
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(nom, erreurPrenom, pwd)),
                "devrait échouer : prenom incorrect");
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(nom, prenom, erreurPwd)),
                "devrait échouer : pwd incorrect");
        }

        [TestMethod()]
        public void GetLesDeveloppeursTest()
        {
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            Assert.AreNotEqual(0, lesDeveloppeurs.Count, "devrait réussir : au moins 1 développeur dans la BDD");
        }

        [TestMethod()]
        public void DelDepveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            int nbBeforeDelete = lesDeveloppeurs.Count;
            if (nbBeforeDelete > 0)
            {
                Developpeur dev = lesDeveloppeurs[0];
                developpeurAccess.DelDepveloppeur(dev);
                lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
                Developpeur devDel = lesDeveloppeurs.Find(obj => obj.Iddeveloppeur.Equals(dev.Iddeveloppeur));
                Assert.IsNull(devDel, "devrait réussir : un développeur supprimé");
                int nbAfterDelete = lesDeveloppeurs.Count;
                Assert.AreEqual(nbBeforeDelete - 1, nbAfterDelete, "devrait réussir : un développeur en moins");
            }
            EndTransaction();
        }

        [TestMethod()]
        public void AddDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            int nbBeforeInsert = lesDeveloppeurs.Count;
            string nom = "nvnom";
            string prenom = "nvprenom";
            string tel = "nvtel";
            string mail = "nvmail";
            Profil profil = new Profil(1, "stagiaire");
            Developpeur dev = new Developpeur(0, nom, prenom, tel, mail, profil);
            developpeurAccess.AddDeveloppeur(dev);
            lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            int nbAfterInsert = lesDeveloppeurs.Count;
            Developpeur devAdd = lesDeveloppeurs.Find(obj => obj.Nom.Equals(nom)
                && obj.Prenom.Equals(prenom)
                && obj.Tel.Equals(tel)
                && obj.Mail.Equals(mail)
                && (obj.Profil.Idprofil == profil.Idprofil)
                && (obj.Profil.Nom == profil.Nom));
            Assert.IsNotNull(devAdd, "devrait réussir : un développeur ajouté");
            Assert.AreEqual(nbBeforeInsert + 1, nbAfterInsert, "devrait réussir : un développeur en plus");
            EndTransaction();
        }

        [TestMethod()]
        public void UpdateDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            int nbBeforeUpdate = lesDeveloppeurs.Count;
            if (lesDeveloppeurs.Count > 0)
            {
                Developpeur dev = lesDeveloppeurs[0];
                string nom = "nvnom";
                string prenom = "nvprenom";
                string tel = "nvtel";
                string mail = "nvmail";
                Profil profil = new Profil(1, "stagiaire");
                Developpeur newDev = new Developpeur(dev.Iddeveloppeur, nom, prenom, tel, mail, profil);
                developpeurAccess.UpdateDeveloppeur(newDev);
                lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
                int nbAfterUpdate = lesDeveloppeurs.Count;
                Developpeur devUpdate = lesDeveloppeurs.Find(obj => obj.Iddeveloppeur == dev.Iddeveloppeur);
                if (devUpdate != null)
                {
                    bool identique = devUpdate.Nom.Equals(nom)
                        && devUpdate.Prenom.Equals(prenom)
                        && devUpdate.Tel.Equals(tel)
                        && devUpdate.Mail.Equals(mail)
                        && (devUpdate.Profil.Idprofil == profil.Idprofil)
                        && (devUpdate.Profil.Nom == profil.Nom);
                    Assert.AreEqual(true, identique, "devrait réussir : un développeur modifié");
                }
                else
                {
                    Assert.Fail("développeur perdu suite aux modifications");
                }
                Assert.AreEqual(nbBeforeUpdate, nbAfterUpdate, "devrait réussir : autant de développeurs");
            }
            EndTransaction();
        }

        [TestMethod()]
        public void UpdatePwdTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs();
            if (lesDeveloppeurs.Count > 0)
            {
                Developpeur dev = lesDeveloppeurs[0];
                dev.Pwd = "000";
                string hashPwd = GetStringSha256Hash(dev.Pwd);
                developpeurAccess.UpdatePwd(dev);
                string req = "select pwd from developpeur where iddeveloppeur = " + dev.Iddeveloppeur;
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null && records.Count > 0)
                    {
                        string pwdDansBdd = (string)records[0][0];
                        Assert.AreEqual(hashPwd, pwdDansBdd, "devrait réussir : pwd modifié");
                    }
                    else
                    {
                        Assert.Fail("développeur perdu suite au changement de pwd");
                    }
                }
                catch (Exception e)
                {
                    Assert.Fail("erreur grave lors de la tentative de changement de pwd : "+e.Message);
                }
            }
            EndTransaction();
        }

        private static string GetStringSha256Hash(string text)
        {
            Encoding enc = Encoding.UTF8;
            var hashBuilder = new StringBuilder();
            var hash = System.Security.Cryptography.SHA256.Create();
            byte[] result = hash.ComputeHash(enc.GetBytes(text));
            foreach (var b in result)
                hashBuilder.Append(b.ToString("x2"));
            return hashBuilder.ToString();
        }

    }
}