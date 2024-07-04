using CreditCardValidationAPI.Models;
using CreditCardValidationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CreditCardValidationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("validate")]
        public IActionResult ValidateCreditCard(CreditCard creditCard)
        {
            try
            {
                if (string.IsNullOrEmpty(creditCard.CardNumber))
                {
                    return BadRequest("Credit card number is required.");
                }

                var isValid = _creditCardService.ValidateLuhn(creditCard.CardNumber);
                var result = new CreditCardValidationResult { IsValid = isValid };

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
