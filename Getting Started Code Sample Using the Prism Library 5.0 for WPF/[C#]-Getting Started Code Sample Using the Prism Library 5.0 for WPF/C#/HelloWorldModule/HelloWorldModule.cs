// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace HelloWorldModule
{
    public class HelloWorldModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public HelloWorldModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;   
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("MainRegion", typeof(Views.HelloWorldView));
        }
    }
}
