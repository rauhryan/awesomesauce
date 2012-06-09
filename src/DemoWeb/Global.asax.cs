using System;
using System.Web;
using AwesomeSauce.Configuration.Storage;
using DemoWeb.Configuration;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace DemoWeb
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication.For<DemoWebFubuRegistry>()
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