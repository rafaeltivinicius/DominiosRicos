using System;
using PaymantsContat.Domain.ValueObjects;

namespace PaymentsContat.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public string Transaction { get; private set; }

        public PayPalPayment(string transaction, 
                             DateTime paidDate, 
                             DateTime expireDate, 
                             decimal total, 
                             decimal totalPaid, 
                             string owner, 
                             Document document, 
                             Address address, 
                             Email email)
        : base(paidDate, expireDate, total, totalPaid, owner, document, address, email)
        {
            Transaction = transaction;
        }
    }
}