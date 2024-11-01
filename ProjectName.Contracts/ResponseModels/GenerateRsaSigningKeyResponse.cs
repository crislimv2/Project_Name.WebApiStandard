using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Name.Contracts.ResponseModels
{
    public class GenerateRsaSigningKeyResponse
    {
        public string OidcSigningKey { set; get; } = "";

        public string OidcEncryptionKey { set; get; } = "";
    }
}
