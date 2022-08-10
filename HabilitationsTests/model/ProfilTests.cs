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
    public class ProfilTests
    {
        private const int id = 6;
        private const string nom = "responsable";
        private readonly Profil profil = new Profil(id, nom);

        [TestMethod()]
        public void ProfilTest()
        {
            Assert.AreEqual(id, profil.Idprofil, "devrait réussir : id valorisé");
            Assert.AreEqual(nom, profil.Nom, "devrait réussir : nom valorisé");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(nom, profil.ToString(), "devrait réussir : nom retourné");
        }
    }
}