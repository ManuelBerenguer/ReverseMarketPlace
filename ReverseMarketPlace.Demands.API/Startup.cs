using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReversemarketPlace.Common.Infrastructure.RabbitMq.Extensions;
using ReverseMarketPlace.Common.Dispatchers;
using ReverseMarketPlace.Common.Types.Handlers;
using ReverseMarketPlace.Demands.API.Configuration.EF;
using ReverseMarketPlace.Demands.Core.Handlers.Demands;
using ReverseMarketPlace.Demands.Core.Messages.Commands.Demands;
using ReverseMarketPlace.Demands.Core.Messages.Events;
using ReverseMarketPlace.Demands.Core.UseCases.Demands;
using ReverseMarketPlace.Demands.Core.UseCases.ProductTypes;

namespace ReverseMarketPlace.Demands.API
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
            services.AddControllers().AddNewtonsoftJson();

            // Configure EF
            services.AddEFConfiguration(Configuration);

            // Configure RabbitMq
            services.AddRabbitMq(Configuration.GetSection("rabbitMq"));
            
            // We add all dependencies related to dispatchers
            services.AddDispatchers();

            // We add localization support to be able to inject IStringLocalizer anywhere
            services.AddLocalization();

            // We add logging support to be able to inject ILogger anywhere
            services.AddLogging();

            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            // Notice we declare the dependency as transient because should be resolved from the root non-requested scope.
            // If we define the dependency as Scoped, the RabbitBusSubscriber subscribe callback method fails to resolve the dependency since it's execution is out of any
            // Http Request scope.
            services.AddTransient<ICommandHandler<CreateDemand>, CreateDemandHandler>(); 
            services.AddScoped<IAttributesBelongToProductTypeUseCase, AttributesBelongToProductTypeUseCase>();
            services.AddScoped<ICheckDuplicatedDemandUseCase, CheckDuplicatedDemandUseCase>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reverse Market Place Demands API", Version = "v1" });
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demands API V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseRabbitMq()
                .SubscribeCommand<CreateDemand>();
        }

       
    }
}
