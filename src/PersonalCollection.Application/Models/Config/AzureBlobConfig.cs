using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Application.Models.Config
{
    public class AzureBlobConfig
    {
        public string ServiceUri { get; set; }
        public string ContainerName { get; set; }
    }
}
