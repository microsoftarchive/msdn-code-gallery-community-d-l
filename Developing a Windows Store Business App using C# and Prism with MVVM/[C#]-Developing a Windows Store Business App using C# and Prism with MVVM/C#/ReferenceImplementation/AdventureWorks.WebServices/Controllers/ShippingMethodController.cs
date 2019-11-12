// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AdventureWorks.WebServices.Models;
using AdventureWorks.WebServices.Repositories;

namespace AdventureWorks.WebServices.Controllers
{
    public class ShippingMethodController : ApiController
    {
        private IRepository<ShippingMethod> _shippingMethodRepository;

        public ShippingMethodController()
            : this(new ShippingMethodRepository())
        { }

        public ShippingMethodController(IRepository<ShippingMethod> shippingMethodRepository)
        {
            _shippingMethodRepository = shippingMethodRepository;
        }

        // GET /api/ShippingMethod/
        [HttpGet]
        [ActionName("defaultAction")]
        public IEnumerable<ShippingMethod> GetShippingMethods()
        {
            return _shippingMethodRepository.GetAll();
        }

        // GET /api/ShippingMethod/basic
        [HttpGet]
        [ActionName("basic")]
        public ShippingMethod GetBasicShippingMethod()
        {
            return _shippingMethodRepository.GetAll().FirstOrDefault(c => c.Description.Contains("Standard"));
        }
    }
}