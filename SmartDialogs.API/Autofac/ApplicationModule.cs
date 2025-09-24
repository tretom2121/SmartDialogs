using Autofac;
using SmartDialogs.API.Services;
using SmartDialogs.Core.Dialogs;
using SmartDialogs.Core.Services;
using SmartDialogs.Implementations.DutySchedule;
using SmartDialogs.Implementations.VehicleScheduling;

namespace SmartDialogs.API.Autofac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogServiceProvider>()
                .As<IDialogServiceProvider>()
                .InstancePerLifetimeScope();

            // Register VehicleScheduling Implementation
            builder.RegisterType<VehicleSchedulingDialogService>()
                .Named<IDialogService>("VehicleScheduling")
                .InstancePerLifetimeScope();
            
            builder.RegisterType<VehicleSchedulingDialogChain>()
                .As<IDialogChain>()
                .InstancePerLifetimeScope();

            // Register DutySchedule Implementation
            builder.RegisterType<DutyScheduleDialogService>()
                .Named<IDialogService>("DutySchedule")
                .InstancePerLifetimeScope();

            builder.RegisterType<DutyScheduleDialogChain>()
                .As<IDialogChain>()
                .InstancePerLifetimeScope();

            // Register all IDialogNode implementations from the implementation assembly
            builder.RegisterAssemblyTypes(typeof(VehicleSchedulingDialogService).Assembly)
                .As<IDialogNode>()
                .InstancePerLifetimeScope();
        }
    }
}