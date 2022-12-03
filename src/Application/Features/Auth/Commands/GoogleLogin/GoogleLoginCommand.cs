using Application.Features.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.GoogleLogin
{
    public class GoogleLoginCommand : IRequest<LoginedUserDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string IdToken { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }
    }
}
