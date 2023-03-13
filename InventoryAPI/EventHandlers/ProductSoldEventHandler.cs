using InventoryCore.Events;
using MediatR;

namespace InventoryAPI.EventHandlers
{
    public class ProductSoldEventHandler : INotificationHandler<ProductSoldEvent>
    {
        private readonly ILogger<ProductSoldEventHandler> _logger;

        public ProductSoldEventHandler(ILogger<ProductSoldEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductSoldEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
