using Application.Repositories.EntityFramework;
using Domain.Entities;
using Persistence.Repositories.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.EntityFramework
{
    public class FriendRequestRepository : EfRepositoryBase<Friend, BaseDbContext>, IFriendRequestRepository
    {
        public FriendRequestRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
