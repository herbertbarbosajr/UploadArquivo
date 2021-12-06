using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadArquivo.Core.Entities
{
    public class Arquivo : Entity
    {
        public string DataEntrega { get; set; }
        public string NomeDoProduto { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
    }
}
