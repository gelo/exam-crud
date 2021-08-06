using Exam.Service.Interfaces;
using Autofac;

namespace Exam.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
        }
    }
}
