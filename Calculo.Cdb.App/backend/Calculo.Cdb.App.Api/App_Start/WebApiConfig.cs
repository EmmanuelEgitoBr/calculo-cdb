﻿using Calculo.Cdb.App.Api.Services;
using Calculo.Cdb.App.Api.Services.Interfaces;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace Calculo.Cdb.App.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração da injeção de dependência
            var container = new UnityContainer();

            // Registrar dependências (Exemplo: ICalculationService → CalculationService)
            container.RegisterType<ICalculationsService, CalculationsService>(new HierarchicalLifetimeManager());

            // Aplicar DI no Web API
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Permitir requisições apenas do Angular (localhost:4200)
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
