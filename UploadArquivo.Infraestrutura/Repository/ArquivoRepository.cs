using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadArquivo.Core.Entities;
using UploadArquivo.Core.Interface;
using UploadArquivo.Core.Request;
using UploadArquivo.Infraestrutura.Data;

namespace UploadArquivo.Infraestrutura.Repository
{
    public class ArquivoRepository : IArquivoRepository
    {
        private ArquivoContexto _arquivoContexto;
        public ArquivoRepository(ArquivoContexto context)
        {
            _arquivoContexto = context;
        }

        public async Task<Arquivo> CreateAsync(Arquivo arquivo)
        {
            _arquivoContexto.Add(arquivo);
            await _arquivoContexto.SaveChangesAsync();
            return arquivo;
        }

        public Task<Arquivo> CreateAsync(ArquivoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Arquivo>> GetArquivosAsync()
        {
            return await _arquivoContexto.Arquivos.ToListAsync();
        }
        public async Task<Arquivo> GetByIdAsync(long id)
        {
            
            return await _arquivoContexto.Arquivos.Include(c => c.ArquivoId)
               .SingleOrDefaultAsync(p => p.ArquivoId == id);
        }
        public async Task<Arquivo> RemoveAsync(Arquivo arquivo)
        {
            _arquivoContexto.Remove(arquivo);
            await _arquivoContexto.SaveChangesAsync();
            return arquivo;
        }

        public Task<Arquivo> RemoveAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Arquivo> UpdateAsync(Arquivo arquivo)
        {
            _arquivoContexto.Update(arquivo);
            await _arquivoContexto.SaveChangesAsync();
            return arquivo;
        }
    }
}
