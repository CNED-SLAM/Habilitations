using Microsoft.VisualStudio.TestTools.UnitTesting;
using Habilitations.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habilitations.model.Tests
{
    [TestClass()]
    public class DeveloppeurTests
    {
        private const int id = 21;
        private const string nom = "Dupont";
        private const string prenom = "Alain";
        private const string tel = "666";
        private const string mail = "alain.dupond@domain.fr";
        private static readonly Profil profil = new Profil(5, "admin");
        private static readonly Developpeur dev = new Developpeur(id, nom, prenom, tel, mail, profil);

        [TestMethod()]
        public void DeveloppeurTest()
        {
            Assert.AreEqual(id, dev.Iddeveloppeur, "devrait réussir : id valorisé");
            Assert.AreEqual(nom, dev.Nom, "devrait réussir : nom valorisé");
            Assert.AreEqual(prenom, dev.Prenom, "devrait réussir : prenom valorisé");
            Assert.AreEqual(tel, dev.Tel, "devrait réussir : tel valorisé");
            Assert.AreEqual(mail, dev.Mail, "devrait réussir : mail valorisé");
            Assert.AreEqual(profil, dev.Profil, "devrait réussir : profil valorisé");
        }
    }
}