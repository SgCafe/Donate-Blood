﻿using DonateBlood.Application.Services.Donations;
using DonateBlood.Application.Services.Donors;
using DonateBlood.Application.Services.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportsControllers : ControllerBase
    {
        #region Properties

        private readonly IDonorsService _donorsService;
        private readonly IDonationsService _donationsService;
        private readonly IStockService _stockService;
        private readonly IWebHostEnvironment _webHostEnv;

        #endregion Properties

        public ReportsControllers(
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

        [HttpGet("CreateReport")]
        public IActionResult CreateReport()
        {
            var caminhoRelatorio = Path.Combine(_webHostEnv.WebRootPath, @"reports/ReportDonors.frx");
            var reportFile = caminhoRelatorio;
            var fReport = new FastReport.Report();
            var donateListResult = _donorsService.GetAll();
            var donateList = donateListResult.Data;
            fReport.Dictionary.RegisterBusinessObject(donateList, "Donations", 10, true);
            fReport.Report.Save(reportFile);

            return Ok($"Relatório gerado: {caminhoRelatorio}");
        }

    }
}
