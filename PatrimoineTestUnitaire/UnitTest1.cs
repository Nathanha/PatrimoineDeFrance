using Microsoft.VisualStudio.TestTools.UnitTesting;
using dll.Metiers;
namespace PatrimoineTestUnitaire
{
    [TestClass]
    public class UtilisateurTest
    {
        [TestMethod]
        public void Set_Get_Utilisateur()
        {
            Utilisateur john = new Utilisateur { Id = 1, Nom = "John", Prenom = "Don" };
            Utilisateur john2 = john;
            Assert.AreEqual(john, john2);
        }
    }
}
