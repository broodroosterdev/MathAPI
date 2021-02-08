using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathAPI.Controllers
{

    [ApiController]
    public class MathController : ControllerBase
    {
        // Adds to number together
        [Route("/add")]
        [HttpGet]
        public ObjectResult Add(int? a, int? b)
        {
            if(a == null || b == null)
            {
                return BadRequest("U need to provide both an 'a' and a 'b' parameter");
            }
            return Ok(MathHelper.Add(a ?? 0, b ?? 0));
        }

        // Adds to number together
        [Route("/multiply")]
        [HttpGet]
        public ObjectResult Multiply(int a, int b)
        {
            if (a == null || b == null)
            {
                return BadRequest("U need to provide both an 'a' and a 'b' parameter");
            }
            return Ok(MathHelper.Multiply(a, b));
        }
    }
}
