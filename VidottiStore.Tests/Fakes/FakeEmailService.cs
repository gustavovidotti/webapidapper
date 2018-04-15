using VidottiStore.Domain.StoreContext.Services;

namespace VidottiStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {

        }
    }
}