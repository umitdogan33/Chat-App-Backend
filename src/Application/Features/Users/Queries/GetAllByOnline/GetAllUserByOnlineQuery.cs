using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllByOnline
{
    public class GetAllUserByOnlineQuery : IRequest<IList<UserListByOnline>>
    {
    }
}
