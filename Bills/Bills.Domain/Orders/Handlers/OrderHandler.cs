using Bills.Domain.Clients.Repositories;
using Bills.Domain.Commands;
using Bills.Domain.Orders.Commands;
using Bills.Domain.Orders.Entities;
using Bills.Domain.Orders.Repositories;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;
using System.Linq;

namespace Bills.Domain.Orders.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IClientRepository _clientRepository;

        public OrderHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IClientRepository clientRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(CreateOrderItemCommand command)
        {
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            var client = _clientRepository.GetClientById(command.Client).First();

            if (client == null)
                return new GenericCommandResult(false, "Cliente inválido", client);

            var orderItem = new OrderItem(command.Product, command.Price, command.Quantity);
            client.Order.AddItems(orderItem);

            AddNotifications(orderItem, client);

            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", Notifications);

            _clientRepository.Update(client);
            _orderRepository.Update(client.Order);
            foreach (var item in client.Order.Items)
            {
                _orderItemRepository.Create(item);
            }

            return new GenericCommandResult(true, "Pedido criado com sucesso", client);
        }
    }
}
