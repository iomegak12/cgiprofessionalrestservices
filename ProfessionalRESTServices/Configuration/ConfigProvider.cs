using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionalRESTServices.Configuration
{
    public static class ConfigProvider
    {
        public static string GetConfigurationData(string configurationKey)
        {
            return Environment.GetEnvironmentVariable(configurationKey);
        }
    }
}
