using System;
using System.Web;
using AwesomeSauce.Configuration.Storage;
using AwesomeSauce.Web.Configuration;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace AwesomeSauce.Web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication.For<AwesomeSauceFubuRegistry>()
                .StructureMap(() =>
                                  {
                                      ObjectFactory.Initialize(c =>
                                                                   {
                                                                       c.AddRegistry<StorageRegistry>();
                                                                   });
                                      return ObjectFactory.Container;
                                  })
                .Bootstrap();
        }
    }
}