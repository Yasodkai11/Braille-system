using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Braille.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class DotPatternController : ControllerBase
    {
        [HttpGet("rectangle/{width}/{height}")]
        public IActionResult Rectangle(int width, int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
        [HttpGet("square/{height}")]
        public IActionResult Square(int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

        [HttpGet("circle/{radius}")]
        public IActionResult Circle(int radius)
        {
            string dotPattern = "";
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (i * i + j * j <= radius * radius)
                    {
                        dotPattern += ".   ";
                    }
                    else
                    {
                        dotPattern += "    ";
                    }
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }


        [HttpGet("triangle/{height}")]
        public IActionResult Triangle(int height)
        {
            string dotPattern = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    dotPattern += ".   ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

        [HttpGet("diamond/{height}")]
        public IActionResult Diamond(int height)
        {
            string dotPattern = "";
            int midPoint = height / 2;
            for (int i = 0; i < height; i++)
            {
                int spaces = Math.Abs(midPoint - i);
                for (int j = 0; j < spaces; j++)
                {
                    dotPattern += " ";
                }
                for (int k = 0; k < height - 2 * spaces; k++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }

        [HttpGet("pyramid/{height}")]
        public IActionResult Pyramid(int height)
        {
            string dotPattern = "";
            int midPoint = height / 2;
            for (int i = 0; i < height; i++)
            {
                int spaces = Math.Abs(midPoint - i);
                for (int j = 0; j < spaces; j++)
                {
                    dotPattern += " ";
                }
                for (int k = 0; k < 2 * (height - spaces) - 1; k++)
                {
                    dotPattern += ". ";
                }
                dotPattern += "\n";
            }
            return Ok(dotPattern);
        }
       






    }
}
    

       
    