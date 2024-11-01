using Microsoft.AspNetCore.Mvc;
using Project_Name.Contracts.ResponseModels;
using System.Security.Cryptography;

namespace Project_Name.WebApi.Controllers
{
    [Route("api/generate-rsa-keys")]
    [ApiController]
    public class GenerateRsaKeysApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<GenerateRsaSigningKeyResponse> Get()
        {
            using var encryptionKey = RSA.Create(2048);
            using var signingKey = RSA.Create(2048);
            var encryptionKeyBits = encryptionKey.ExportRSAPrivateKey();
            var signingKeyBits = signingKey.ExportRSAPrivateKey();
            var result = new GenerateRsaSigningKeyResponse
            {
                OidcEncryptionKey = Convert.ToBase64String(encryptionKeyBits),
                OidcSigningKey = Convert.ToBase64String(signingKeyBits)
            };
            return result;
        }
    }
}

