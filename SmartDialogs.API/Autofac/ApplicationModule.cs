using Autofac;
using SmartDialogs.API.Services;

namespace SmartDialogs.API.Autofac;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DialogService>()
            .As<IDialogService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<RecommendationService>()
            .As<IRecommendationService>()
            .InstancePerLifetimeScope();
    }
}