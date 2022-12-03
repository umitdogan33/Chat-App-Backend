using Application.Common.Exceptions;
using Application.Common.Utilities;
using Application.Features.Auth.Dtos;
using Application.Repositories.EntityFramework;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Application.Features.Auth.Commands.GoogleLogin;

public class LoginGoogleCommandHandler : IRequestHandler<GoogleLoginCommand, LoginedUserDto>
{
    readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private IMapper _mapper;
    private ITokenHelper _tokenHelper;
    private IHttpContextAccessor _accessor;
    public LoginGoogleCommandHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IMapper mapper, ITokenHelper tokenHelper, IHttpContextAccessor accessor,IConfiguration configuration)
    {
        _userRepository=userRepository;
        _refreshTokenRepository=refreshTokenRepository;
        _mapper=mapper;
        _tokenHelper=tokenHelper;
        _accessor=accessor;
        _configuration = configuration;
    }

    public async Task<LoginedUserDto> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
            ValidationSettings? settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>()
                { _configuration["ExternalLogin:Google-Client-Id"] }
            };
            Payload payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            if(payload == null)
            {
                throw new BusinessException("beklenmeyen bir hata oluştu");
            }
        var remoteIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

        var user = await _userRepository.GetAsync(
            u => u.Email.ToLower() == request.Email.ToLower(),
            include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

        if (user == null)
           user = await _userRepository.AddAsync( new User(Guid.NewGuid().ToString(),request.FirstName,request.LastName,request.Email,null,null,true,Domain.Enums.AuthenticatorType.None,request.FirstName+request.LastName,request.PhotoUrl));

        var token = _tokenHelper.CreateRefreshToken(user, remoteIpAddress);
        await _refreshTokenRepository.AddAsync(token);
        LoginedUserDto loginedUserDto = _mapper.Map<LoginedUserDto>(token);
        return loginedUserDto;
    }
}
