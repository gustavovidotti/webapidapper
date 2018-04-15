using Microsoft.VisualStudio.TestTools.UnitTesting;
using VidottiStore.Domain.StoreContext.ValueObjects;

namespace VidottiStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShoudReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Vidotti");
            Assert.AreEqual(true, name.Invalid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}