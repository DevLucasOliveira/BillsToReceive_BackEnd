using Bills.Domain.Clients.Repositories;
using Bills.Domain.Commands;
using Bills.Domain.Orders.Commands;
using Bills.Domain.Orders.Entities;
using Bills.Domain.Orders.Repositories;
using Bills.Shared.Commands;
using Bills.Shared.Handlers;
using Flunt.Notifications;

namespace Bills.Domain.Orders.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderItemCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IClientRepository _clientRepository;

        public OrderHandler(IOrderItemRepository orderItemRepository, IClientRepository clientRepository)
        {
            _orderItemRepository = orderItemRepository;
            _clientRepository = clientRepository;
        }

        public ICommandResult Handle(CreateOrderItemCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            // Recuperar o cliente
            var client = _clientRepository.GetClientById(command.Client);

            // Gerar a entidade
            var orderItem = new OrderItem(command.Product, command.Price, command.Quantity);
            var order = new Order(orderItem);

            // Adicionar o pedido do cliente
            client.AddOrder(order);

            // Agrupar notificações
            AddNotifications(orderItem, order, order);

            // Verificar se há erros
            if (Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", Notifications);

            // Salvar no banco
            _clientRepository.Update(client);
            _orderRepository.Create(order);
            foreach (var item in order.Items)
            {
                _orderItemRepository.Create(item);
            }

            // Retornar informações
            return new GenericCommandResult(true, "Pedido criado com sucesso", client);
        }
    }
}
