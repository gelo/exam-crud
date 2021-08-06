using Exam.Repository;
using Exam.Service;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;    
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace Exam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://web.postman.co")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });
            services.AddDbContext<RepositoryDbContext>(options => options.UseSqlServer(Configuration["Database:ConnectionString"]));
            services.AddControllers();
            services.AddOptions();
            services.AddSwaggerGen();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {   
            // Register your own things directly with Autofac here. Don't
            // call builder.Populate(), that happens in AutofacServiceProviderFactory
            // for you.
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();                
            }

            app.UseRequestResponseLoggingMiddleware();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET CORE EXAM PROJECT"); });
            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                     .RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
