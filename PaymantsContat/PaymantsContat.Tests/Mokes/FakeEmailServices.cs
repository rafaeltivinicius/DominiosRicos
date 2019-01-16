using PaymantsContat.Domin.Repositorios;
using PaymantsContat.Shared.Services;
using PaymentsContat.Domain.Entities;

namespace PaymantsContat.Tests.Mokes
{

    public class FakeEmailServices : IemailService
    {
        public void send(string to, string email, string subject, string bory)
        {
            
        }
    }

}