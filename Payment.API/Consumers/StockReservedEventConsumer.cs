using System;
using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            // ödeme islemleri...


            if (true)
            {
                // ödemenin basariyla tamamlandigini...
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId

                };

                _publishEndpoint.Publish(paymentCompletedEvent);

                Console.WriteLine("Ödeme başarılı...");
            }
            else
            {
                // ödemede sikinti oldugunu...
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Bakiye yetersiz..."
                };

                _publishEndpoint.Publish(paymentFailedEvent);

                Console.WriteLine("Ödeme başarısız...");
            }

            return Task.CompletedTask;
        }

        
    }
}

