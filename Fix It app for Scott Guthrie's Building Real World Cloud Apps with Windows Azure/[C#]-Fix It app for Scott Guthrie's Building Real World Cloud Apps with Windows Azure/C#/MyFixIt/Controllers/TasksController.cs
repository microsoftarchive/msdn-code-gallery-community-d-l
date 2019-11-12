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
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFixIt.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private IFixItTaskRepository fixItRepository = null;
        private IPhotoService photoService = null;
        private IFixItQueueManager queueManager = null;

        public TasksController(IFixItTaskRepository repository, IPhotoService photoStore, IFixItQueueManager queueManager)
        {
            fixItRepository = repository;
            photoService = photoStore;
            this.queueManager = queueManager;
        }

        // GET: /FixIt/
        public async Task<ActionResult> Status()
        {
            string currentUser = User.Identity.Name;
            var result = await fixItRepository.FindTasksByCreatorAsync(currentUser);

            return View(result);
        }

        //
        // GET: /Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FixItTaskId,CreatedBy,Owner,Title,Notes,PhotoUrl,IsDone")]FixItTask fixittask, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                fixittask.CreatedBy = User.Identity.Name;
                fixittask.PhotoUrl = await photoService.UploadPhotoAsync(photo);

                if (ConfigurationManager.AppSettings["UseQueues"] == "true")
                {
                    await queueManager.SendMessageAsync(fixittask);
                }
                else
                {
                    await fixItRepository.CreateAsync(fixittask);
                }

                return RedirectToAction("Success");
            }

            return View(fixittask);
        }

        //
        // GET: /Tasks/Success
        public ActionResult Success()
        {
            return View();
        }
    }
}