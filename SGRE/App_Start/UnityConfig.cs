using SGRE.Application.Interfaces;
using SGRE.Application.Services;
using SGRE.Domain.Interfaces;
using SGRE.Infrastructure.Data;
using SGRE.Infrastructure.Mongo;
using SGRE.Infrastructure.Notificaciones;
using SGRE.Infrastructure.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using System.Configuration;

namespace SGRE.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // DbContext - una instancia por request (importante para EF6)
            container.RegisterType<SGREDbContext>(new HierarchicalLifetimeManager());

            // Repositorios (Domain <- Infrastructure)
            container.RegisterType<IRepositorioCliente, RepositorioCliente>();
            container.RegisterType<IRepositorioVehiculo, RepositorioVehiculo>();
            container.RegisterType<IRepositorioChofer, RepositorioChofer>();
            container.RegisterType<IRepositorioEnvio, RepositorioEnvio>();

            // Notificador
            container.RegisterType<INotificador, NotificadorLog>();

            // Servicios de negocio (Application)
            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<IVehiculoService, VehiculoService>();
            container.RegisterType<IChoferService, ChoferService>();
            container.RegisterType<IEnvioService, EnvioService>();

            // MongoDB
            container.RegisterType<MongoContext>(new InjectionFactory(c =>
                new MongoContext(
                    ConfigurationManager.AppSettings["MongoConnectionString"],
                    ConfigurationManager.AppSettings["MongoDatabaseName"]
                )));

            container.RegisterType<IRepositorioEvidencia, RepositorioEvidencia>();
            container.RegisterType<IEvidenciaService, EvidenciaService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}