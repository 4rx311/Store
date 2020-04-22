using System.Reflection;
using Autofac;
using Store.Application;
using Store.Application.Configuration.Processing.Validation;
using FluentValidation;
using MediatR;
using Module = Autofac.Module;

namespace Store.Infrastructre.Processing.Modules
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mediatorAssembly = typeof(IMediator).GetTypeInfo().Assembly;
            builder.RegisterAssemblyTypes(mediatorAssembly).AsImplementedInterfaces();

            //типы MediatR
            var mediatorTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(IValidator<>),
                typeof(INotificationHandler<>)
            };

            //регистрируем все реализации типов MediatR в Application
            var applicationAssembly = typeof(ICommandHandler<>).GetTypeInfo().Assembly;
            foreach (var mediatorType in mediatorTypes)
            {
                builder.RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(mediatorType)
                    .AsImplementedInterfaces();

            }

            //регистрируем фабрику MediatR для Request & Notification handlers
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterGeneric(typeof(CommandValidationBehaviour<,>))
                .As(typeof(IPipelineBehavior<,>));
        }
    }
}
