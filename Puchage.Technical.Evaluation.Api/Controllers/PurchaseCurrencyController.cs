using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puchage.Technical.Evaluation.Application.Interfaces;
using Puchage.Technical.Evaluation.Application.DTO;

namespace Puchage.Technical.Evaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCurrencyController : ControllerBase
    {

         private readonly IPurchaseCurrencyService _PurchaseCurrencyService;

        public PurchaseCurrencyController(IPurchaseCurrencyService PurchaseCurrencyService)
        {
            _PurchaseCurrencyService = PurchaseCurrencyService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Buycurrencies([FromBody] CurrencyRequestDTO currencyRequestDTO)
        {
            try
            {
                if (currencyRequestDTO.originCurrency == "") throw new Exception("No existe moneda de origen");
                if (currencyRequestDTO.CurrencyChange == "") throw new Exception("Estimado usuario es necesario que ingrese la moneda de cambio");
                if (currencyRequestDTO.Amount == 0) throw new Exception("Estimado usuario ingrese la cantidad de cambio");
                if (currencyRequestDTO.codUserBuyer == 0) throw new Exception("No se detecto tu session"); 
                var exchange = await _PurchaseCurrencyService.ProcessBuyCurrencies(currencyRequestDTO);
                return Ok(exchange);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }


    }
}
