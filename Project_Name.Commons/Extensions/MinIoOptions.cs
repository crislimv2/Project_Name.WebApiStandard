using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Name.Commons.Extensions
{
    public class MinIoOptions
    {
        public string EndPoint { get; set; } = "";

        public string AccessKey { get; set; } = "";

        public string ServerKey { get; set; } = "";

        public string BucketName { get; set; } = "";

        public bool IsUseSsl { get; set; }
    }
}
