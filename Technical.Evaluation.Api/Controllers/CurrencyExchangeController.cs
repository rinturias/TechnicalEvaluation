using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technical.Evaluation.Application.DTO;
using Technical.Evaluation.Application.Interfaces;

namespace Technical.Evaluation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CurrencyExchangeController : Controller
    {

        private readonly ILogger<CurrencyExchangeController> _logger;
        private readonly ICurrencyExchange _ICurrencyExchange;
        public CurrencyExchangeController(ICurrencyExchange ICurrencyExchange, ILogger<CurrencyExchangeController> logger)
        {
            _ICurrencyExchange = ICurrencyExchange;
            _logger = logger;
        }

        [HttpGet("[action]/{currency}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetExchangeRate([FromRoute] string currency)
        {
            string namemethod = "GetExchangeRate";
            try
            {
                if (currency == "") throw new Exception("No es valido codigo iso de la moneda");
                var exchange = await _ICurrencyExchange.GetExchangeRate(currency);
                _logger.LogWarning(namemethod + "CODERROR " + exchange.codError + ",MENSAJE:" + exchange.error);
                return Ok(exchange);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " InnerException:" + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpGet("[action]/{originCurrency}/{CurrencyChange}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCurrencyExchangeRateSale([FromRoute] string originCurrency, string CurrencyChange)
        {
            string namemethod = "GetCurrencyExchangeRateSale";
            try
            {
                if (originCurrency == "" || CurrencyChange == "") throw new Exception("No es valido codigo iso de la moneda");
                var exchange = await _ICurrencyExchange.GetCurrencyExchangeRateSale(originCurrency, CurrencyChange);
                _logger.LogWarning(namemethod + "CODERROR " + exchange.codError + ",MENSAJE:" + exchange.error);
                return Ok(exchange);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " InnerException:" + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }
    }
}
