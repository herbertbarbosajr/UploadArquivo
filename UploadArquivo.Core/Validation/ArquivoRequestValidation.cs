using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadArquivo.Core.Request;

namespace UploadArquivo.Core.Validation
{
   public class ArquivoRequestValidation : AbstractValidator<ArquivoRequest>
    {
        public ArquivoRequestValidation()
        {
            RuleFor(a => a.DataEntrega).NotNull().GreaterThan(DateTime.Today)
            .WithMessage("A data de entrega está incorreta.");
            RuleFor(a => a.NomeDoProduto).MaximumLength(50).WithMessage("O Nome do Produto ultrapassou os 50 carateres.");
            RuleFor(a => a.Quantidade).GreaterThan(0).WithMessage("A quantidade não pode ser zero.");
            RuleFor(a => a.ValorUnitario).LessThanOrEqualTo(0).WithMessage("Valor unitário está incorreto");
        }
    }
}
