using Microsoft.VisualStudio.TestTools.UnitTesting;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using VidottiStore.Domain.StoreContext.Handlers;
using VidottiStore.Tests.Fakes;

namespace VidottiStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Gustavo";
            command.LastName = "Vidotti";
            command.Document = "28659170377";
            command.Email = "vidotti@teste.com";
            command.Phone = "11999999997";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}