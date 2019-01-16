using PaymentsContat.Domain.Entities;

namespace PaymantsContat.Domin.Repositorios
{
    public interface IStudentRepository
    {
        bool DocumentExist(string document);
        bool EmailExist(string email);
        void CreateSubscription(Student student);

    }

}