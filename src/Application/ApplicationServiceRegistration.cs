using System.Reflection;
using Application.Common.Behaviours.Authorization;
using Application.Common.Behaviours.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.Http;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSignalRCore();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient<IHttpContextAccessor,HttpContextAccessor>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        return services;
    }
}