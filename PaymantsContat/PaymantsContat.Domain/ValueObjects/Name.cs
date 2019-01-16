using Flunt.Validations;
using PaymantsContat.Shared.ValueObject;

namespace PaymantsContat.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FistName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FistName} {LastName}";
        }

        public Name(string fistName, string lastName)
        {
            FistName = fistName;
            LastName = lastName;

            AddNotifications(new Contract()
                                .Requires()
                                .HasMinLen(FistName, 3, "Student.FistName", "Nome deve Conter mais de 3 caracter")
                                .HasMinLen(LastName, 3, "Student.LastName", "SobreNome deve Conter mais de 3 caracter"));
        }
    }
}