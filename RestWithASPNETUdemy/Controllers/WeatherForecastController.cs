using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{fistNumber}/{SecondNumber}")]
    public IActionResult sum(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Invalid Input");
    }

    [HttpGet("sub/{fistNumber}/{SecondNumber}")]
    public IActionResult sub(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(fistNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mult/{fistNumber}/{SecondNumber}")]
    public IActionResult mult(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var mult = ConvertToDecimal(fistNumber) * ConvertToDecimal(secondNumber);
            return Ok(mult.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{fistNumber}/{SecondNumber}")]
    public IActionResult div(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var div = ConvertToDecimal(fistNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("media/{fistNumber}/{SecondNumber}")]
    public IActionResult media(string fistNumber, string secondNumber)
    {
        if (IsNumeric(fistNumber) && IsNumeric(secondNumber))
        {
            var media = (ConvertToDecimal(fistNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(media.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("raiz/{fistNumber}")]
    public IActionResult raiz(string fistNumber)
    {
        if (IsNumeric(fistNumber))
        {
            var raiz = Math.Sqrt((double)ConvertToDecimal(fistNumber));
            return Ok(raiz.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool IsNumber = double.TryParse(strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
        return IsNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        throw new NotImplementedException();
    }

 
}
