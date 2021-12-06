using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadArquivo.MVC.Models;

namespace UploadArquivo.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <List<ArquivoModel>> Import(IFormFile arquivo)
        {
            var list = new List<ArquivoModel>();
            using (var stream = new MemoryStream())
            {
                await arquivo.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {

                    
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets[0];
                    var linhas = excelWorksheet.Dimension.Rows;
                    for (int row = 2; row <= linhas ; row++) 
                    {
                        list.Add(new ArquivoModel { 
                        
                        DataEntrega = excelWorksheet.Cells[row, 1].Value.ToString().Trim(),
                        NomeDoProduto = excelWorksheet.Cells[row, 2].Value.ToString().Trim(),
                        Quantidade = excelWorksheet.Cells[row, 3].Value.ToString().Trim(),
                        ValorUnitario = excelWorksheet.Cells[row, 4].Value.ToString().Trim(),
                        
                        });
                    }
                }
            }
            return list;
        }
    }
}
