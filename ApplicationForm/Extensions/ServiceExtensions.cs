using Contracts.IRepositories;
using Contracts.IServices;
using LoggerService;
using Microsoft.OpenApi.Models;
using Repository;
using Services.ServiceImplementation;

namespace ApplicationForm.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApplicationForm", Version = "v1" });
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>(); 
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<Lazy<IApplicantRepository>>(provider =>
                new Lazy<IApplicantRepository>(() => provider.GetRequiredService<IApplicantRepository>()));
            services.AddScoped<Lazy<IQuestionRepository>>(provider =>
                new Lazy<IQuestionRepository>(() => provider.GetRequiredService<IQuestionRepository>()));

            services.AddScoped<Lazy<IApplicantService>>(provider =>
                new Lazy<IApplicantService>(() => provider.GetRequiredService<IApplicantService>()));
            services.AddScoped<Lazy<IQuestionService>>(provider =>
                new Lazy<IQuestionService>(() => provider.GetRequiredService<IQuestionService>()));

        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>(); 
            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureDbContext(this IServiceCollection services) => services.AddSingleton<CosmosDbContext>();

    }
}
