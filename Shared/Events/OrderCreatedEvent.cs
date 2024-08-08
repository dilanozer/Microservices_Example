using System;
using Shared.Events.Common;
using Shared.Messages;

namespace Shared.Events
{
	public class OrderCreatedEvent : IEvent
	{
		public Guid OrderId { get; set; }
		public Guid BuyerId { get; set; }
		public List<OrderItemMessage>? OrderItemMessages { get; set; }
		public decimal TotalPrice { get; set; }
	}
}

