using Contracts;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApplication1.Extension
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// 跨域策略
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AnyPolicy",
                    configurePolicy: builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        /// <summary>
        /// EF Core_MySql数据上下文的配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config) 
        {
            var connectionString = config.GetConnectionString(name: "AppDb");
            services.AddDbContext<WebApplicationDbContext>(
                optionsAction: builder => builder.UseMySql(connectionString, //委托
                MySqlServerVersion.LatestSupportedServerVersion));
        }
        /// <summary>
        /// 仓储配置
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWapper, RepositoryWapper>();
        }
    }
}
