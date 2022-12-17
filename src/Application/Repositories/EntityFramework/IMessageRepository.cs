using Domain.Entities;
using Domain.Entities.Common;

namespace Application.Repositories.EntityFramework
{
    public interface IMessageRepository:IAsyncRepository<MessageEntity>,IRepository<MessageEntity>
    {
        Task<List<LastContactsUser>> GetLastContact(string UserId);
    }
    }