using DonateBlood.Application.Services.Donations;
using DonateBlood.Application.Services.Donors;
using DonateBlood.Application.Services.Stock;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        #region Properties

        private readonly IDonorsService _donorsService;
        private readonly IDonationsService _donationsService;
        private readonly IStockService _stockService;
        private readonly IWebHostEnvironment _webHostEnv;

        #endregion Properties

        public ReportsController(
            IDonorsService donorsService,
            IDonationsService donationsService,
            IStockService stockService,
            IWebHostEnvironment webHostEnv)
        {
            _donorsService = donorsService;
            _donationsService = donationsService;
            _stockService = stockService;
            _webHostEnv = webHostEnv;
        }

        /// <summary>
        /// Gera relatório de doadores
        /// </summary>
        /// <returns>Retorna link para download de relatório de doadores</returns>
        [HttpGet("GetReport")]
        public IActionResult GetReportDonors()
        {
            var caminhoRelatorio = Path.Combine(_webHostEnv.WebRootPath, @"reports/ReportDonor.frx");
            var fReport = new FastReport.Report();

            var donateListResult = _donorsService.GetAll();
            var donateList = donateListResult.Data;
            
            var stockListResult = _stockService.GetAll();
            var stockList = stockListResult.Data;

            var donationsListResult = _donationsService.GetAll();
            var donationsList = donationsListResult.Data;

            fReport.Report.Load(caminhoRelatorio);

            fReport.Dictionary.RegisterBusinessObject(donateList, "Donors", 10, true);
            fReport.Dictionary.RegisterBusinessObject(stockList, "Stocks", 10, true);
            fReport.Dictionary.RegisterBusinessObject(donationsList, "Donations", 100, true);

            fReport.Prepare();

            using var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();

            pdfExport.Export(fReport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf", "RelatorioDoadores.pdf");
        }

        /// <summary>
        /// Gera relatório de estoque
        /// </summary>
        /// <returns>Retorna link para download de relatório de estoque</returns>
        [HttpGet("GetReportStock")]
        public IActionResult GetStock()
        {
            var caminhoRelatorio = Path.Combine(_webHostEnv.WebRootPath, @"reports/ReportStock.frx");
            var fReport = new FastReport.Report();

            var donateListResult = _donorsService.GetAll();
            var donateList = donateListResult.Data;
            
            var stockListResult = _stockService.GetAll();
            var stockList = stockListResult.Data;

            var donationsListResult = _donationsService.GetAll();
            var donationsList = donationsListResult.Data;

            fReport.Report.Load(caminhoRelatorio);

            fReport.Dictionary.RegisterBusinessObject(donateList, "Donors", 10, true);
            fReport.Dictionary.RegisterBusinessObject(stockList, "Stocks", 10, true);
            fReport.Dictionary.RegisterBusinessObject(donationsList, "Donations", 100, true);

            fReport.Prepare();

            using var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();

            pdfExport.Export(fReport, ms);
            ms.Flush();

            return File(ms.ToArray(), "application/pdf", "RelatorioDoações.pdf");
        }

        /// <summary>
        /// Cria relatório de estoque
        /// </summary>
        /// <remarks>
        /// Caso crie um relatório, saiba que o design do atual será perdido.
        /// </remarks>
        /// <returns>Coleção de estoque</returns>
        [HttpPost("CreateReportStock")]
        public IActionResult CreateReportStock()
        {
            var caminhoRelatorio = Path.Combine(_webHostEnv.WebRootPath, @"reports/ReportStock.frx");
            var reportFile = caminhoRelatorio;
            var fReport = new FastReport.Report();

            var donateListResult = _donorsService.GetAll();
            var donateList = donateListResult.Data;

            var stockListResult = _stockService.GetAll();
            var stockList = stockListResult.Data;

            var donationsListResult = _donationsService.GetAll();
            var donationsList = donationsListResult.Data;

            fReport.Dictionary.RegisterBusinessObject(donateList, "Donors", 100, true);
            fReport.Dictionary.RegisterBusinessObject(stockList, "Stocks", 100, true);
            fReport.Dictionary.RegisterBusinessObject(donationsList, "Donations", 100, true);

            fReport.Report.Save(reportFile);

            return Ok($"Relatório gerado: {caminhoRelatorio}");
        }

        /// <summary>
        /// Cria relatório de doadores
        /// </summary>
        /// <remarks>
        /// Caso crie um relatório, saiba que o design do atual será perdido.
        /// </remarks>
        /// <returns> Link para editar relatório no FasReports</returns>
        [HttpPost("CreateReport")]
        public IActionResult CreateReportDonors()
        {
            var caminhoRelatorio = Path.Combine(_webHostEnv.WebRootPath, @"reports/ReportDonor.frx");
            var reportFile = caminhoRelatorio;
            var fReport = new FastReport.Report();
            
            var donateListResult = _donorsService.GetAll();
            var donateList = donateListResult.Data;

            var stockListResult = _stockService.GetAll();
            var stockList = stockListResult.Data;

            var donationsListResult = _donationsService.GetAll();
            var donationsList = donationsListResult.Data;

            fReport.Dictionary.RegisterBusinessObject(donateList, "Donors", 100, true);
            fReport.Dictionary.RegisterBusinessObject(stockList, "Stocks", 100, true);
            fReport.Dictionary.RegisterBusinessObject(donationsList, "Donations", 100, true);

            fReport.Report.Save(reportFile);

            return Ok($"Relatório gerado: {caminhoRelatorio}");
        }

    }
}
