using GraphiQl;
using GraphQl.Api.Mutations;
using GraphQl.Api.Queries;
using GraphQl.Api.Queries.Schema;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateManager.DataAccess.Respositories;
using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Database.Models;
using RealEstateManager.Types;
using RealEstateManager.Types.Property;

namespace GraphQl.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<RealEstateContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyMutation>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PropertyInputType>();
            services.AddSingleton<PaymentType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}