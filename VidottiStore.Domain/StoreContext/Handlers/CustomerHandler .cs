using System;
using FluentValidator;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using VidottiStore.Domain.StoreContext.Entities;
using VidottiStore.Domain.StoreContext.Repositories;
using VidottiStore.Domain.StoreContext.Services;
using VidottiStore.Domain.StoreContext.ValueObjects;
using VidottiStore.Shared.Commands;

namespace VidottiStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");
            // Verificar se o E-mail já existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");
            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            //Criar entidade
            var customer = new Customer(name, document, email, command.Phone);
            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, "Por favor, corrija os campos abaixo", Notifications);

            //Persistir o cliente
            _repository.Save(customer);
            //Enviar um email de boas vindas
            _emailService.Send(email.Address, "vidottti@teste.com", "Bem vindo", "Seja bem vindo a Vidotti Store!");
            //Retornar o resultado para tela

            return new CommandResult(true, "Bem vindo ao Vidotti Store", new
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}