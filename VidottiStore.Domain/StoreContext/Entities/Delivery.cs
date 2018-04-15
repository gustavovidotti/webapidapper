using System;
using FluentValidator;
using VidottiStore.Domain.StoreContext.Enums;
using VidottiStore.Shared.Entities;

namespace VidottiStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.Status = EDeliveryStatus.Wating;

        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //Se data estimada de entrega for no passado nao entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o status ja estiver entregue nao pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}