using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymantsContat.Domain.ValueObjects;
using PaymentsContat.Domain.Entities;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Address _Adrress;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            var document = new Document("123456789123", EDocumentType.CPF);
            var nome = new Name("Rafa", "Vini");
            var email = new Email("fael.rn@hotmail.com");
            var adrress = new Address("rua", "15", "inga", "niteroi", "Rj", "Niteroi", "123456");
            _student = new Student(nome, document, email, adrress);
            _subscription = new Subscription(null);
                   
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var paymant = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 0, "Teste", _document, _Adrress, _email);

            _subscription.AddPayment(paymant); 

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveeSubscription()
        {
            Assert.Fail();
        }
    }
}
