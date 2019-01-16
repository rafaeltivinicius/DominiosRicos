using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymantsContat.Domain.ValueObjects;
using PaymentsContat.Domain.Entities;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Tests
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123",EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCNPJIsValid()
        {
            var doc = new Document("12345678912345 ",EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenCPFIsInvalid()
        {
            var doc = new Document("123",EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsValid()
        {
            var doc = new Document("12345678912",EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
