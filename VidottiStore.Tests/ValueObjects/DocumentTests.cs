using Microsoft.VisualStudio.TestTools.UnitTesting;
using VidottiStore.Domain.StoreContext.ValueObjects;

namespace VidottiStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests()
        {
            invalidDocument = new Document("12345678910");
            validDocument = new Document("04747148612");
        }

        [TestMethod]
        public void ShoudReturnNotificationWhenDocumentIsNotValid()
        {

            Assert.AreEqual(true, invalidDocument.Invalid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShoudNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}