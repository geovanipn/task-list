﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq;

namespace TaskList.Api.Configurations.WebApi
{
    public sealed class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel centralPrefix;

        public RouteConvention(in IRouteTemplateProvider routeTemplateProvider)
        {
            centralPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel =
                            AttributeRouteModel.CombineAttributeRouteModel(
                                centralPrefix,
                                selectorModel.AttributeRouteModel
                            );
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();

                if (!unmatchedSelectors.Any()) continue;

                foreach (var selectorModel in unmatchedSelectors)
                    selectorModel.AttributeRouteModel = centralPrefix;
            }
        }
    }
}
