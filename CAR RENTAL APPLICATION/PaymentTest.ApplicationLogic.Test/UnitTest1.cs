using CAR_RENTAL_APPLICATION.Models;
using CAR_RENTAL_APPLICATION.Repositories;
using CAR_RENTAL_APPLICATION.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System;

namespace PaymentTest.ApplicationLogic.Test
{
    [TestClass]
    public class PaymentServiceTest
    {
        private static PaymentService PaymentService;
        private List<Payment> expectedAllPayments = new List<Payment>();
        private List<Payment> expectedPaymentsByCondition = new List<Payment>();

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            var options = new DbContextOptionsBuilder<CarsContext>();
            CarsContext PaymentContext = new CarsContext();
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(PaymentContext);
            PaymentService = new PaymentService(repositoryWrapper);
            populateDatabase();
        }

       
        private static void populateDatabase()
        {

            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            Payment payment1 = new Payment(1, 0, new DateTime(2015, 12, 31), 100, a);
            Payment payment2 = new Payment(2, 1, new DateTime(2016, 12, 31), 200, a);
            Payment payment3 = new Payment(3, 2, new DateTime(2017, 12, 31), 300, a);
            Payment payment4 = new Payment(4, 3, new DateTime(2018, 12, 31), 400, a);

            PaymentService.AddPayment(payment1);
            PaymentService.AddPayment(payment2);
            PaymentService.AddPayment(payment3);
            PaymentService.AddPayment(payment4);



            PaymentService.Save();
        }

        [TestMethod]
        public void testPPP()
        {
            string s = "aaa";
            string b = s;
            Assert.AreNotEqual(s, b);
        }



        [TestMethod]
        // testGetPayments_ReturnAllPaymentsFromDatabase
        public void TestGetPayments()
        {
            //arrange
            populateExpectedAllPayments();

            //act
            List<Payment> actualPayments = PaymentService.GetPayments();

            //assert
            Assert.AreEqual(4, actualPayments.Count);
            for (int index = 0; index < actualPayments.Count; index++)
            {
                Payment actualPayment = actualPayments[index];
                Payment expectedPayment = expectedAllPayments[index];
                Assert.AreEqual(expectedPayment, actualPayment);
            }
        }

        [TestMethod]
        //TestGetPaymentsByCondition_ReturnOnlyThePaymentsWithCondition
        public void TestGetPaymentsByCondition()
        {
            //arrange
            populateExpectedPaymentsByCondition();

            //act
            List<Payment> actualPayments = PaymentService.GetPaymentsByCondition(Payment => Payment.Amount.Equals(200));

            //assert
            Assert.AreEqual(4, actualPayments.Count);
            for (int index = 0; index < actualPayments.Count; index++)
            {
                Payment actualPayment = actualPayments[index];
                Payment expectedPayment = expectedPaymentsByCondition[index];
                Assert.AreEqual(expectedPayment, actualPayment);
            }
        }

        [TestMethod]
        public void TestAddPayment()
        {
            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            Payment newPayment = new Payment(5, 4, new DateTime(2010, 12, 31), 100, a);
            //act
            PaymentService.AddPayment(newPayment);

            PaymentService.Save();
            List<Payment> actualPayments = PaymentService.GetPayments();
            Assert.AreEqual(4, actualPayments.Count);
            PaymentService.DeletePayment(newPayment);
            PaymentService.Save();
        }

        [TestMethod]
        public void TestDeletePayment()
        {
            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            Payment payment3 = new Payment(3, 2, new DateTime(2017, 12, 31), 300, a);

            PaymentService.AddPayment(payment3);
            PaymentService.Save();

            //act
            PaymentService.DeletePayment(payment3);

            PaymentService.Save();
            List<Payment> actualPayments = PaymentService.GetPayments();
            Assert.AreEqual(3, actualPayments.Count);
        }

        [TestMethod]
        public void TestUpdatePayment()
        {
            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            Payment payment3 = new Payment(3, 2, new DateTime(2017, 12, 31), 300, a);

            PaymentService.AddPayment(payment3);
            PaymentService.Save();

            //modify Payment
            //modific toate campurile
            payment3.Amount = 666;

            //act
            PaymentService.UpdatePayment(payment3);

            PaymentService.Save();
            List<Payment> actualPayments = PaymentService.GetPaymentsByCondition(Payment => Payment.PaymentId == 4);
            Payment updatedPayment = actualPayments[0];

            Assert.AreEqual(666, updatedPayment.Amount);
            PaymentService.DeletePayment(payment3);
            PaymentService.Save();
        }

        private void populateExpectedPaymentsByCondition()
        {
            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            expectedPaymentsByCondition.Add(new Payment(31, 2, new DateTime(2027, 12, 31), 300, a));
            expectedPaymentsByCondition.Add(new Payment(32, 2, new DateTime(2037, 12, 31), 300, a));
            expectedPaymentsByCondition.Add(new Payment(33, 2, new DateTime(2047, 12, 31), 300, a));
        }

        private void populateExpectedAllPayments()
        {
            PaymentMethod a = new PaymentMethod(0, "pay-ment");
            expectedAllPayments.Add(new Payment(34, 2, new DateTime(2017, 12, 31), 300, a));
            expectedAllPayments.Add(new Payment(35, 2, new DateTime(2017, 12, 31), 300, a));

        }



    }
}
