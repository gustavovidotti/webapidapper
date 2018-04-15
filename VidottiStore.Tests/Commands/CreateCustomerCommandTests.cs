using Microsoft.VisualStudio.TestTools.UnitTesting;
using VidottiStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace VidottiStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Gustavo";
            command.LastName = "Vidotti";
            command.Document = "28659170377";
            command.Email = "vidotti@teste.com";
            command.Phone = "11999999997";

            Assert.AreEqual(true, command.Valid());
        }
    }
}