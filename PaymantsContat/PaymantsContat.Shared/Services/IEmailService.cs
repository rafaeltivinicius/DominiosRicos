namespace PaymantsContat.Shared.Services
{
    public interface IemailService
    {
        void send(string to, string email, string subject, string bory);
    }
}