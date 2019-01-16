using Flunt.Validations;
using PaymantsContat.Shared.ValueObject;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                                .Requires()
                                .IsTrue(Validade(), "Document.Validade", "CPF/CNPJ Invalidos"));
        }

        private bool Validade()
        {

            if (Type == EDocumentType.CNPJ && Number.Length == 14)
                return true;

            if (Type == EDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}