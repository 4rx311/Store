using Autofac;
using MediatR;

namespace Store.Infrastructre.Processing.Modules
{
    public class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>().As<IDomainEventsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterGenericDecorator(typeof(DomainEventsNotificationHandlerDecorator<>),
                typeof(INotificationHandler<>));
        }
    }
}
