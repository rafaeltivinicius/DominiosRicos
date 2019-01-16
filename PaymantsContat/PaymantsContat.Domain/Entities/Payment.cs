using System;
using Flunt.Validations;
using PaymantsContat.Domain.ValueObjects;
using PaymantsContat.Shared.Entities;

namespace PaymentsContat.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Owner { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Owner = owner;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(0,total,"Paymant.Total","O total não pode ser zero")
                .IsGreaterOrEqualsThan(total,TotalPaid,"Paymant.TotalPaid","o valor pago é menor que o valor do pagamento"));
        }
    }
}