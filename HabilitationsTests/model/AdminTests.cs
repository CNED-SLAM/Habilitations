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
    public class AdminTests
    {
        private const string nom = "Dupont";
        private const string prenom = "Alain";
        private const string pwd = "pwddupontalain";
        private static readonly Admin admin = new Admin(nom, prenom, pwd);

        [TestMethod()]
        public void AdminTest()
        {
            Assert.AreEqual(nom, admin.Nom, "devrait réussir : nom valorisé");
            Assert.AreEqual(prenom, admin.Prenom, "devrait réussir : prenom valorisé");
            Assert.AreEqual(pwd, admin.Pwd, "devrait réussir : pwd valorisé");
        }
    }
}