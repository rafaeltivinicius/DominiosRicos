using PaymantsContat.Domin.Repositorios;
using PaymentsContat.Domain.Entities;

namespace PaymantsContat.Tests.Mokes
{

    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExist(string document)
        {
            if (document == "12345678912")
                return true;

            return false;
        }

        public bool EmailExist(string email)
        {
            if (email == "fael.rion@gmail.com")
                return true;

            return false;
        }
    }

}