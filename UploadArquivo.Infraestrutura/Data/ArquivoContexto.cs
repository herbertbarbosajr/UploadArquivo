using Microsoft.EntityFrameworkCore;
using UploadArquivo.Core.Entities;

namespace UploadArquivo.Infraestrutura.Data
{
    public class ArquivoContexto : DbContext
    {
        public ArquivoContexto (DbContextOptions<ArquivoContexto> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Arquivo> Arquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ArquivoContexto).Assembly);
        }
    }
}
