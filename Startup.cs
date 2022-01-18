using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBotGqlApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FoodBotGqlApi.GraphQl;
using FoodBotGqlApi.GraphQl.Foods;
using FoodBotGqlApi.GraphQl.Preparations;
using FoodBotGqlApi.GraphQl.Mutation;

namespace FoodBotGqlApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<FoodType>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<PreparationType>()
                .AddType<AddFoodInputType>()
                .AddType<AddFoodPayloadType>()
                .AddType<AddPreparationInputType>()
                .AddType<AddPreparationPayloadType>()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddInMemorySubscriptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            // app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
            // {
            //     GraphQLEndPoint = "/graphql",
            //     Path = "/graphql-voyager"
            // });
            app.UseGraphQLVoyager();
        }
    }
}
