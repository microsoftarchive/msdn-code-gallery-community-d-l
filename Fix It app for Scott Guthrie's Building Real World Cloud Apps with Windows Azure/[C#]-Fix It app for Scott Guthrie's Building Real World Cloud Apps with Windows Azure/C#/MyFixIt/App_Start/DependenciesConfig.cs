//
// Copyright (C) Microsoft Corporation.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Util;
using Autofac.Integration.Mvc;
using MyFixIt.Logging;
using MyFixIt.Persistence;

namespace MyFixIt.App_Start
{
    public class DependenciesConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<FixItTaskRepository>().As<IFixItTaskRepository>();
            builder.RegisterType<PhotoService>().As<IPhotoService>().SingleInstance();
            builder.RegisterType<FixItQueueManager>().As<IFixItQueueManager>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}