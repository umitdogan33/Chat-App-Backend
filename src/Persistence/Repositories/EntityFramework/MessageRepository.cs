using Application.Features.Messages.Dtos;
using Application.Repositories.EntityFramework;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.EntityFramework.Contexts;
using System.Linq;
using Domain.Entities.Common;

namespace Persistence.Repositories.EntityFramework;

public class MessageRepository : EfRepositoryBase<MessageEntity, BaseDbContext>, IMessageRepository
{
    public BaseDbContext _DbContext { get; set; }
    public MessageRepository(BaseDbContext context) : base(context)
    {
        _DbContext = context;
    }
    public async Task<List<LastContactsUser>> GetLastContact(string UserId)
    {
        var data =await _DbContext.GetLastContacts.FromSqlRaw($"EXEC GetLastContact @UserId='{UserId}'").ToListAsync();

        var result = from d in data
            join i in _DbContext.Users on d.ContactId equals i.Id
            select new LastContactsUser()
            {
                Email = i.Email,
                Id = i.Id,
                Status = i.Status,
                Username = i.Username,
                AuthenticatorType = i.AuthenticatorType,
                FeelText = i.FeelText,
                FirstName = i.FirstName,
                LastName = i.LastName,
                PhotoUrl = i.PhotoUrl
            };

        return result.ToList();

    }
}
