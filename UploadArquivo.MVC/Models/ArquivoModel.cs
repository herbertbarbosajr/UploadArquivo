using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UploadArquivo.Core.Entities;

namespace UploadArquivo.MVC.Models
{
    public class ArquivoModel : Entity
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        public string DataEntrega { get; set; }

        [DisplayName("Nome do Produto")]
        [MaxLength(50)]
        public string NomeDoProduto { get; set; }

        [DisplayName("Quantidade")]
        [MinLength(1)]
        public string Quantidade { get; set; }

        [DisplayName("Valor Unitario")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public string ValorUnitario { get; set; }
    }
}
