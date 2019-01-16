using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymantsContat.Domain.Commands;
using PaymantsContat.Domain.ValueObjects;
using PaymentsContat.Domain.Entities;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Tests.Command
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FistName ="";

            command.validate();
            Assert.AreEqual(false,command.Valid);
            
        }

    }
}
