using CreditCardValidationAPI.Models;
using CreditCardValidationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("validate")]
        public IActionResult ValidateCreditCard([FromBody] CreditCard creditCard)
        {
            if (creditCard == null || string.IsNullOrWhiteSpace(creditCard.CardNumber))
            {
                return BadRequest("Credit card number is required.");
            }

            try
            {
                var isValid = _creditCardService.ValidateLuhn(creditCard.CardNumber);
                return Ok(new { isValid });
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
