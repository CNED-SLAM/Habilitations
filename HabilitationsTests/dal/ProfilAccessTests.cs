using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Habilitations.model;

namespace Habilitations.dal.Tests
{
    [TestClass()]
    public class ProfilAccessTests
    {
        private static readonly Access access = Access.GetInstance();
        private static readonly ProfilAccess profilAccess = new ProfilAccess();

        [TestMethod()]
        public void ProfilAccessTest()
        {
            Assert.IsNotNull(access, "devrait réussir si connexion à la BDD correcte");
        }

        [TestMethod()]
        public void GetLesProfilsTest()
        {
            List<Profil> lesProfils = profilAccess.GetLesProfils();
            Assert.AreNotEqual(0, lesProfils.Count, "devrait réussir : au moins 1 profil dans la BDD");
        }
    }
}