using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using VidottiStore.Domain.StoreContext.Entities;
using VidottiStore.Domain.StoreContext.Handlers;
using VidottiStore.Domain.StoreContext.Queries;
using VidottiStore.Domain.StoreContext.Repositories;
using VidottiStore.Domain.StoreContext.ValueObjects;
using VidottiStore.Shared.Commands;

namespace VidottiStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 15)]
        //Cache-Control: public,max-age=60
        //StrathWeb.CacheOutput - Versão antes do .Net Core
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
            // var name = new Name("Gustavo", "Vidotti");
            // var document = new Document("46718115533");
            // var email = new Email("vidotti@teste.com");
            // var customer = new Customer(name, document, email, "551999876542");
            // var customers = new List<Customer>();
            // customers.Add(customer);
            // return customers;
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
            // var name = new Name("Gustavo", "Vidotti");
            // var document = new Document("46718115533");
            // var email = new Email("vidotti@teste.com");
            // var customer = new Customer(name, document, email, "551999876542");
            // return customer;
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _repository.Get(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
            // var name = new Name("Gustavo", "Vidotti");
            // var document = new Document("46718115533");
            // var email = new Email("vidotti@teste.com");
            // var customer = new Customer(name, document, email, "551999876542");
            // var order = new Order(customer);

            // var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            // var monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);

            // order.AddItem(monitor, 5);
            // order.AddItem(mouse, 5);

            // var orders = new List<Order>();
            // orders.Add(order);

            // return orders;
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
            // var name = new Name(command.FirstName, command.LastName);
            // var document = new Document(command.Document);
            // var email = new Email(command.Email);
            // var customer = new Customer(name, document, email, command.Phone);
            // return customer;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}