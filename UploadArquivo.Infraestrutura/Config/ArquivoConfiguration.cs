using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadArquivo.Core.Entities;

namespace UploadArquivo.Infraestrutura.Config
{
    public class ArquivoConfiguration : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure (EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(a => new { a.ArquivoId });
            builder.Property(a => a.DataEntrega).IsRequired();
            builder.Property(a => a.NomeDoProduto).IsRequired();
            builder.Property(a => a.Quantidade).IsRequired();
            builder.Property(a => a.ValorUnitario).IsRequired().HasPrecision(18,2);
            
        }
    }
}


