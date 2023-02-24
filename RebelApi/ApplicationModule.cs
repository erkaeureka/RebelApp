using Api.Managers;
using Autofac;
using Core.Services;
using Infrastructure.Data;
using System;

namespace API {
    public class ApplicationModule : Module {
        protected override void Load(ContainerBuilder builder) {
            //base.Load(builder);
            builder.RegisterType<UnitOfWork<ApplicationDbContext>>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ArtistManager>().As<IArtistManager>().SingleInstance();
            builder.RegisterType<ArtistService>().As<IArtistService>().SingleInstance();

        }
    }
}
