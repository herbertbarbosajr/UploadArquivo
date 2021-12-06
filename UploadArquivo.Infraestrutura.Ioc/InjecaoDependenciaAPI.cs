using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadArquivo.Core.Interface;
using UploadArquivo.Infraestrutura.Data;
using UploadArquivo.Infraestrutura.Repository;

namespace UploadArquivo.Infraestrutura.Ioc
{
   public static class InjecaoDependenciaAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ArquivoContexto>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ArquivoContexto).Assembly.FullName)));

            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            return services;
        }
    }
}
