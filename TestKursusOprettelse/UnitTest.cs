using System;
using Eksamen2Semester.Model;
using Eksamen2Semester.View;
using Eksamen2Semester.VM;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace TestKursusOprettelse
{
    [TestClass]
    public class UnitTest1
    {

        public Booking Book { get; set; }
        public KursusOprettelseVM KursusOprettelseVm { get; set; }



        [TestMethod]
        public void TestDeltagerAntalTo()
        {
            Book = new Booking();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Book.DeltagerAntal = "5";
            });

            
        }

        

        //[TestMethod]
        //public void Testss()
        //{
        //    KursusOprettelseVm = new KursusOprettelseVM() { BookName = "", BookLokale = new Lokale(), BookDateTime = DateTimeOffset.Now, BookDeltagerAntal = "4", LokationKO = new Lokation()};
        //    KursusOprettelseVm.NewBooking();
        //    Assert.AreEqual(1, BookingSingelton.Intance.SingletonOCBooking.Count);


        //}

        //[TestMethod]
        //public void TestNavnLængde()
        //{
        //    Book = new Booking();
        //    Assert.ThrowsException<ArgumentException>(() =>
        //    {
        //        Book.Name = "2";
        //    });

        //}
    }
}
