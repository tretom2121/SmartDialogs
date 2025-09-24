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
            // 1. Register the provider that the controller uses to get the correct dialog service.
            builder.RegisterType<DialogServiceProvider>()
                .As<IDialogServiceProvider>()
                .InstancePerLifetimeScope();

            // 2. Register ALL possible dialog nodes from your Implementations project.
            // This is efficient and allows us to filter them later.
            builder.RegisterAssemblyTypes(typeof(VehicleSchedulingDialogService).Assembly)
                .Where(t => typeof(IDialogNode).IsAssignableFrom(t))
                .As<IDialogNode>();

            // 3. Register the "VehicleScheduling" dialog flow as a self-contained unit.
            builder.Register(c =>
                {
                    // First, resolve all registered nodes.
                    var allNodes = c.Resolve<IEnumerable<IDialogNode>>();

                    // Filter the nodes to get ONLY the ones in the "VehicleScheduling" namespace.
                    var vehicleSchedulingNodes = allNodes
                        .Where(n => n.GetType().Namespace.Contains("VehicleScheduling"))
                        .ToList();

                    // Create a new chain with ONLY the correct nodes.
                    var chain = new VehicleSchedulingDialogChain(vehicleSchedulingNodes);

                    // Create and return the service, now guaranteed to have the correct chain.
                    return new VehicleSchedulingDialogService(chain);
                })
                .Named<IDialogService>("VehicleScheduling") // This key MUST match the frontend link.
                .InstancePerLifetimeScope();

            // 4. Register the "DutySchedule" dialog flow as another self-contained unit.
            builder.Register(c =>
                {
                    // Resolve all registered nodes again.
                    var allNodes = c.Resolve<IEnumerable<IDialogNode>>();

                    // Filter for nodes ONLY in the "DutySchedule" namespace.
                    var dutyScheduleNodes = allNodes
                        .Where(n => n.GetType().Namespace.Contains("DutySchedule"))
                        .ToList();

                    // Create its specific chain.
                    var chain = new DutyScheduleDialogChain(dutyScheduleNodes);

                    // Create and return the service with its correct chain.
                    return new DutyScheduleDialogService(chain);
                })
                .Named<IDialogService>("DutySchedule") // The key for the other dialog flow.
                .InstancePerLifetimeScope();
        }
    }
}