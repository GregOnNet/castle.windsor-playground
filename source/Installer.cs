using Castle.MicroKernel.Registration;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Method.Intercetption
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Components().ToArray());
        }

        private IEnumerable<IRegistration> Components()
        {
            yield return Component
                .For<ConsoleLoggingInterceptor>()
                .LifeStyle.Transient;

            yield return Component
                .For<IService>()
                .ImplementedBy<Service>()
                .LifeStyle.Singleton;
        }
    }
}
