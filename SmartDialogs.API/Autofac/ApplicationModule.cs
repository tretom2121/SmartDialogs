using Autofac;
using SmartDialogs.API.Dialogs;
using SmartDialogs.API.Services;

namespace SmartDialogs.API.Autofac;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IDialogNode).Assembly)
            .As<IDialogNode>()
            .InstancePerLifetimeScope();

        builder.RegisterType<DialogChain>()
            .As<IDialogChain>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<DialogService>()
            .As<IDialogService>()
            .InstancePerLifetimeScope();

        builder.RegisterType<RecommendationService>()
            .As<IRecommendationService>()
            .InstancePerLifetimeScope();
    }
}