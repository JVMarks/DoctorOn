using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace DoctorOn
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //criação ds tabelas de login do usuario, paciente e medico simpleMembership
            WebSecurity.InitializeDatabaseConnection("AgendamentoContext", "Usuarios", "id", "Email", true);
            /*
            if (!WebMatrix.WebData.WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("AgendamentoContext", "Pacientes", "id", "CRM", true);
                WebSecurity.InitializeDatabaseConnection("AgendamentoContext", "Medicos", "id", "Matricula_do_convenio", true);
            }
            */

        }
    }
}
