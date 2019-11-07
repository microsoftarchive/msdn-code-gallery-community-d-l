Imports System.Web.Mvc
Imports System.Web.Routing
Imports Mvc3Filter.Filters

Namespace Mvc3Filter

	Public Class MvcApplication
		Inherits HttpApplication
		Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
			filters.Add(New HandleErrorAttribute())
			' review failed attempt to change filter ordering
			   ' var filter = new Filter(new RequestLogFilter(), FilterScope.First, -1);
			  '  filters.Add(filter);
				filters.Add(New RequestLogFilter())


			' Remove comment to make TraceActionFilterAttribute global
			'  filters.Add(new TraceActionFilterAttribute());

			Dim provider = New RequestTimingFilterProvider()
			provider.Add(Function(c)If(c.HttpContext.IsDebuggingEnabled, New RequestTimingFilter(), Nothing))
			FilterProviders.Providers.Add(provider)
		End Sub

		Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

			routes.MapRoute("Default", "{controller}/{action}/{id}", New With {Key .controller = "Home", Key .action = "Index", Key .id = UrlParameter.Optional}) ' Parameter defaults -  URL with parameters -  Route name

		End Sub

		Protected Sub Application_Start()
			AreaRegistration.RegisterAllAreas()

			RegisterGlobalFilters(GlobalFilters.Filters)
			RegisterRoutes(RouteTable.Routes)
		End Sub
	End Class
End Namespace