using FluentValidator;
using FluentValidator.Validation;

namespace VidottiStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            this.Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail é inválido"));
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return $"{Address}";
        }
    }
}