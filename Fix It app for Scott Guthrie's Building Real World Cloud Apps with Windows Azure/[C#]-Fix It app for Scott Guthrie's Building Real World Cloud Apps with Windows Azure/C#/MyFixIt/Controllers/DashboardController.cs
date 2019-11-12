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

using MyFixIt.Persistence;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFixIt.Controllers
{
     [Authorize]
    public class DashboardController : Controller
    {
        private readonly IFixItTaskRepository fixItRepository = null;

        public DashboardController(IFixItTaskRepository repository)
        {
            fixItRepository = repository;
        }

        //
        // GET: /Dashboard/
        public async Task<ActionResult> Index()
        {
            string currentUser = User.Identity.Name;
            var result = await fixItRepository.FindOpenTasksByOwnerAsync(currentUser);

            return View(result);
        }

        //
        // GET: /Dashboard/Details/5
        public async Task<ActionResult> Details(int id)
        {
            FixItTask fixItTask = await fixItRepository.FindTaskByIdAsync(id);

            if (fixItTask == null)
            {
                return HttpNotFound();
            }
            
            return View(fixItTask);
        }

        //
        // GET: /Dashboard/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            FixItTask fixittask = await fixItRepository.FindTaskByIdAsync(id);
            if (fixittask == null)
            {
                return HttpNotFound();
            }

            // Verify logged in user owns this FixIt task.
            if (User.Identity.Name != fixittask.Owner)
            {
               return HttpNotFound();
            }

            return View(fixittask);
        }

        //
        // POST: /Dashboard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind(Include = "CreatedBy,Owner,Title,Notes,PhotoUrl,IsDone")]FormCollection form)
        {
            FixItTask fixittask = await fixItRepository.FindTaskByIdAsync(id);

            // Verify logged in user owns this FixIt task.
            if (User.Identity.Name != fixittask.Owner)
            {
               return HttpNotFound();
            }

            if (TryUpdateModel(fixittask, form))
            {
                await fixItRepository.UpdateAsync(fixittask);
                return RedirectToAction("Index");
            }

            return View(fixittask);
        }
    }
}
