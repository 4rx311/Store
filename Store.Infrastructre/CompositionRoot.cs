using Autofac;

namespace Store.Infrastructre
{
    public static class CompositionRoot
    {
        private static IContainer _container;

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static ILifetimeScope BeginLifetimeScope() => _container.BeginLifetimeScope();
    }
}
