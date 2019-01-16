using Flunt.Validations;
using PaymantsContat.Shared.ValueObject;

namespace PaymantsContat.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(address,"Email.Address","E-mail invalido"));
        }
    }
}