using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymantsContat.Shared.Commands;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

//você pode usar aqui no lugar do Name.cs
        public void validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .HasMinLen(FistName, 3, "Student.FistName", "Nome deve Conter mais de 3 caracter")
                 .HasMinLen(LastName, 3, "Student.LastName", "SobreNome deve Conter mais de 3 caracter"));

        }
    }
}