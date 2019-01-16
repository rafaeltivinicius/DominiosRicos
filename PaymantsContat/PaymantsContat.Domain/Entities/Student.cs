using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymantsContat.Domain.ValueObjects;
using PaymantsContat.Shared.Entities;

namespace PaymentsContat.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscription;
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscription = new List<Subscription>();

            AddNotifications(name, document, address);
        }

        //Assinatura
        public void AddSubscription(Subscription subscription)
        {
            // foreach (var sub in Subscriptions)
            //   sub.Inactivate();

            // _subscription.Add(subscription);

            var hasSubscriptionActive = false;

            foreach (var sub in _subscription)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                        .Requires()
                        .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
                        .IsGreaterThan(0,subscription.Payments.Count,"Student.Subscription.Paymants","Essa assinatura não possui pagamento"));
        }

    }
}