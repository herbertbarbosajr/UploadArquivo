using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadArquivo.Core.Entities;
using UploadArquivo.Core.Request;

namespace UploadArquivo.Core.Interface
{
    public interface IArquivoRepository
    {
        Task<IEnumerable<Arquivo>> GetArquivosAsync();
        Task<Arquivo> GetByIdAsync(long id);
        Task<Arquivo> CreateAsync(Arquivo arquivo);
        Task<Arquivo> UpdateAsync(Arquivo arquivo);
        Task<Arquivo> RemoveAsync(Arquivo arquivo);
        Task <Arquivo> RemoveAsync(long id);
        Task <Arquivo> CreateAsync(ArquivoRequest request);
    }
}
