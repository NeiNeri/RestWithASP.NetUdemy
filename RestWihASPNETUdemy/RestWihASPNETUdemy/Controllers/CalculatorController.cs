using Microsoft.AspNetCore.Mvc;

namespace RestWihASPNETUdemy.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CalculatorController : ControllerBase
  {     
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
      _logger = logger;
    }
    [HttpGet("sum/{firstNumber}/{secundNumber}")]
    public IActionResult Get(string firstNumber, string secundNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
      {
        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber);
        return Ok(sum.ToString());
      }     
      return BadRequest("Valor informado é inválido");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Valor informado é inválido");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Valor informado é inválido");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Valor informado é inválido");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
        return Ok(sum.ToString());
      }
      return BadRequest("Valor informado é inválido");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
      if (IsNumeric(firstNumber))
      {
        var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        return Ok(squareRoot.ToString());
      }
      return BadRequest("Valor informado é inválido");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
      decimal result = 0;
      if (decimal.TryParse(strNumber, out result))
      {
        return result;
      }
      return 0;      
    }

    private bool IsNumeric(string strNumber)
    {
      double number;
      bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                      System.Globalization.NumberFormatInfo.InvariantInfo, out number);
      return isNumber;      
    }
  }
}