using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymantsContat.Domain.Commands;
using PaymantsContat.Domain.Handlers;
using PaymantsContat.Domain.ValueObjects;
using PaymantsContat.Tests.Mokes;
using PaymentsContat.Domain.Entities;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Tests.Handlers
{
    [TestClass]
    public class SubscriptionhandlerTests
    {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenDocuemtnExists()
        {
            var handrler = new SubscriptionHandlers(new FakeStudentRepository(), new FakeEmailServices());
            var command = new CreateBoletoSubscriptionCommand();
 
            command.FistName = "Rafael";
            command.LastName = "Machado";
            command.Document = "12345678912";
            command.Email = "fael.rion@gmail.com";
            command.BarCode = "1234568789";
            command.BoletoNumber = "12345678954";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "teste teste";
            command.PayerDocument = "12345689";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@gmail.com";
            command.Street = "asasd";
            command.Number = "asdasd";
            command.Neighborhood = "asasa";
            command.City = "as";
            command.State = "as";
            command.Country = "as";
            command.ZipCode = "as";

            handrler.Handle(command);
            Assert.AreEqual(false, command.Valid);


        }

    }
}
