using Application.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Repositories.EntityFramework.Contexts;

namespace Persistence.Repositories.EntityFramework;

public class MessageRepository : EfRepositoryBase<MessageEntity, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext context) : base(context)
    {
    }
}
