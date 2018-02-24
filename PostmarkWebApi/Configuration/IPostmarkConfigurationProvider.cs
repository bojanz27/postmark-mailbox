using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostmarkWebApi.Configuration
{
    internal interface IPostmarkConfigurationProvider
    {
        IPostmarkConfiguration GetConfiguration();
    }
}