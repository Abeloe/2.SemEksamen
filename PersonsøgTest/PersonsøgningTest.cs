using System;
using Eksamen2Semester.Model;
using Eksamen2Semester.VM;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace PersonsøgTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
          Deltager deltager = new Deltager("Mads", "22443322", "AE@BC.GF");
            Assert.AreEqual(deltager.Navn, "Mads");
        }

        [TestMethod]

        public void TestMethod2()
        {
            PersonSøgningVM søgning = new PersonSøgningVM();
            
            {
                søgning.DeltagerListe.Add(new Deltager("Mads","2222","ss-ss"));
            }
          
        }

        public void TestMethod3()
        {
            
        }
    }
}
