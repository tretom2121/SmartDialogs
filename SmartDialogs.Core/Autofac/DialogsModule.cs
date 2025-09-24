using Autofac;
using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Services;

namespace SmartDialogs.Core.Autofac;

public class DialogsModule : Module
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
    }
}