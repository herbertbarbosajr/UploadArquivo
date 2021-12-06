using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadArquivo.Core.Request
{
   public class ArquivoRequest
    {
        public int ArquivoID { get; set; }
        public DateTime DataEntrega { get; set; }
        public string NomeDoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
