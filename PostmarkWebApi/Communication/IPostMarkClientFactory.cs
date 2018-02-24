using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostmarkWebApi.Configuration;

namespace PostmarkWebApi.Communication
{
    internal interface IPostmarkClientFactory
    {
        IPostmarkClient GetClient(IPostmarkConfigurationProvider configurationProvider);
    }
}