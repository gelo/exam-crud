using Exam.Repository.Interfaces;
using Exam.Repository.Models;
using Autofac;

namespace Exam.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<Repository<Employee>>().As<IRepository<Employee>>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
        }
    }
}
