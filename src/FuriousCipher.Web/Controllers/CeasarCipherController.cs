
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static CCipher.FuriousCipher;

namespace FuriousCipher.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class CeasarCipherController : ControllerBase
    {
        private readonly ILogger<CeasarCipherController> logger;

        public CeasarCipherController(ILogger<CeasarCipherController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("encrypt")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<string> EncryptMessage(string message, int secretKey)
        {
         return  Encrypt(message,secretKey);
            
        }

        [HttpPost("decrypt")]
                [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public ActionResult<string> DecryptMessage(string message, int secretKey)
        {
            return Decrypt(message, secretKey);
        }

    }
}