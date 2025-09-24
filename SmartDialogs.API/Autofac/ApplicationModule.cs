using Autofac;
using SmartDialogs.API.Services;
using SmartDialogs.Core.Autofac;

namespace SmartDialogs.API.Autofac;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule(new DialogsModule());
        
        builder.RegisterType<RecommendationService>()
            .As<IRecommendationService>()
            .InstancePerLifetimeScope();
    }
}