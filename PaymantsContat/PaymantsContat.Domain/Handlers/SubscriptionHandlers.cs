using System;
using Flunt.Notifications;
using PaymantsContat.Domain.Commands;
using PaymantsContat.Domain.ValueObjects;
using PaymantsContat.Domin.Repositorios;
using PaymantsContat.Shared.Commands;
using PaymantsContat.Shared.Handlers;
using PaymantsContat.Shared.Services;
using PaymentsContat.Domain.Entities;
using PaymentsContat.Domain.Enums;

namespace PaymantsContat.Domain.Handlers
{
    public class SubscriptionHandlers : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IemailService _send;

        public SubscriptionHandlers(IStudentRepository repository, IemailService send)
        {
            _repository = repository;
            _send = send;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand commad)
        {
            //validações
            commad.validate();
            if (commad.Invalid)
            {
                AddNotifications(commad);
                return new CommandResult(false, "não foi possivel realiar seu cadastro");
            }

            if (_repository.DocumentExist(commad.Document))
                AddNotification("Documento", "Este Documento já Existe");

            if (_repository.EmailExist(commad.Email))
                AddNotification("Email", "Este email já esta em uso");

            //gerar os VOs
            var document = new Document(commad.Document, EDocumentType.CPF);
            var nome = new Name(commad.FistName, commad.LastName);
            var email = new Email(commad.Email);
            var adrress = new Address(commad.Street, commad.Number, commad.Neighborhood, commad.City, "Rj", "Niteroi", "123456");

            //gerar as entidaes
            var student = new Student(nome, document, email, adrress);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(commad.BarCode, commad.BoletoNumber,
                        commad.PaidDate, commad.ExpireDate, commad.Total,
                        commad.TotalPaid, commad.Payer, new Document(commad.PayerDocument,
                        commad.PayerDocumentType), adrress, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validações
            AddNotifications(nome, document, email, adrress, student, subscription, payment);

            //Checar notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possivel validar sua assinatura");

            //salvar as informações
            _repository.CreateSubscription(student);

            //enviar emai de boas vindas

            // retorna informações
            return new CommandResult(true, "Usuario cadastrado com sucesso");
        }
    }
}