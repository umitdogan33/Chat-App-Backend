using Application.Common.Exceptions;
using Application.Common.Hubs.HubDto;
using Application.Repositories.EntityFramework;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Application.Common.Hubs
{
    public class MessageHub : Hub
    {
        private IMessageRepository _messageRepository;

        public MessageHub(IMessageRepository messageRepository)
        {
            _messageRepository=messageRepository;
        }

        public async Task SendMessageAsync(SendMessageDto messageDto)
        {
            if (messageDto.Message == null || messageDto.ReceiverUserId == null) return;
            var data = ConnectedUser.ClientsData.FirstOrDefault(p => p.UserId == messageDto.ReceiverUserId);
            if (data == null) throw new BusinessException("user is not found");
            var user = Context.User.Claims.FirstOrDefault(a => a.Type =="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            MessageEntity messageEntity = new() { Id=Guid.NewGuid().ToString(), Message = messageDto.Message, ReceverId = data.UserId, SenderId = user,CreateDate  = DateTime.UtcNow,IsPhoto = messageDto.IsPhoto};
            await _messageRepository.AddAsync(messageEntity);
            await Clients.Clients(data.ConnectionId, Context.ConnectionId).SendAsync("receiveMessage", messageEntity);
        }

        public override Task OnConnectedAsync()
        {
            var user = Context.User.Claims.FirstOrDefault(a => a.Type =="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var savedData = ConnectedUser.ClientsData.FirstOrDefault(p => p.UserId == user);

            if (savedData != null)
            {
                savedData.ConnectionId = Context.ConnectionId;
                savedData.Status = true;
                return Task.CompletedTask;
            }
            Client client = new()
            {
                ConnectionId = Context.ConnectionId,
                Status = true,
                UserId = user
            };
            ConnectedUser.ClientsData.Add(client);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = Context.User.Claims.FirstOrDefault(a => a.Type =="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            var savedData = ConnectedUser.ClientsData.FirstOrDefault(p => p.UserId == user);
            if (savedData is null)
            {
                throw new BusinessException("user is not found");
            }
            savedData.Status = false;
            return Task.CompletedTask;
        }
    }
}
