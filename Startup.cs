using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos;
using Capital.Data.Repositories;
using Microsoft.Win32;
using AutoMapper;
using Capital.Models;
using Capital.DTOs;

namespace Capital
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Configure Cosmos DB
            services.AddSingleton((serviceProvider) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var cosmosDbSettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();

                var cosmosClient = new CosmosClient(cosmosDbSettings.EndpointUri, cosmosDbSettings.PrimaryKey);
                var database = cosmosClient.GetDatabase(cosmosDbSettings.DatabaseName);
                var container = database.GetContainer(cosmosDbSettings.ContainerName);

                return container;
            });

            // Register repositories
            services.AddTransient<QuestionRepository>();

            // Add framework services
            services.AddControllers();

            // Add AutoMapper and register mapping profiles
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<CosmosClient>(InitializeCosmosClientInstanceAsync(Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
            services.AddScoped<ICosmosDbService, CosmosDbService>();



            // Add services here as needed.
            // Example: services.AddTransient<IQuestionService, QuestionService>();
            // Replace IQuestionService and QuestionService with actual service interfaces and implementations.
        }



        private async Task<CosmosClient> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return client;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
