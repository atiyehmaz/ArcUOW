using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApi.Controllers;
using Data;
using Data.Repsitory;
using Service;
using System.Reflection;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Data.Entity;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacRegister();
        }

        private void AutofacRegister()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(CustomerController).Assembly);
            builder.RegisterApiControllers(typeof(DepositController).Assembly);

            builder.RegisterType<BankDbContext>().As<DbContext>().InstancePerRequest().WithParameter("ConnectionString", "BankCS");
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            builder.RegisterType(typeof(CustomerService)).As<ICustomerService>();
            builder.RegisterType(typeof(DepositService)).As<IDepositService>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);



        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
             HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
