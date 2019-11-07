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

using MyFixIt.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFixIt.Persistence
{
    public class FixItTaskRepository : IFixItTaskRepository, IDisposable
    {
        private MyFixItContext db = new MyFixItContext();
        private ILogger log = null;

        public FixItTaskRepository(ILogger logger)
        {
            log = logger;
        }

        public async Task<FixItTask> FindTaskByIdAsync(int id)
        {
            FixItTask fixItTask = null;
            Stopwatch timespan = Stopwatch.StartNew();

            try
            {
                fixItTask = await db.FixItTasks.FindAsync(id);
                
                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.FindTaskByIdAsync", timespan.Elapsed, "id={0}", id);
            }
            catch(Exception e)
            {
               log.Error(e, "Error in FixItTaskRepository.FindTaskByIdAsync(id={0})", id);
               throw;
            }

            return fixItTask;
        }

        public async Task<List<FixItTask>> FindOpenTasksByOwnerAsync(string userName)
        {
            Stopwatch timespan = Stopwatch.StartNew();

            try
            {
                var result = await db.FixItTasks
                    .Where(t => t.Owner == userName)
                    .Where(t=>t.IsDone == false)
                    .OrderByDescending(t => t.FixItTaskId).ToListAsync();

                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.FindTasksByOwnerAsync", timespan.Elapsed, "username={0}", userName);

                return result;
            }
            catch (Exception e)
            {
                log.Error(e, "Error in FixItTaskRepository.FindTasksByOwnerAsync(userName={0})", userName);
                throw;
            }
        }

        public async Task<List<FixItTask>> FindTasksByCreatorAsync(string creator)
        {
            Stopwatch timespan = Stopwatch.StartNew();

            try
            {
                var result = await db.FixItTasks
                    .Where(t => t.CreatedBy == creator)
                    .OrderByDescending(t => t.FixItTaskId).ToListAsync();

                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.FindTasksByCreatorAsync", timespan.Elapsed, "creater={0}", creator);

                return result;
            }
            catch (Exception e)
            {
                log.Error(e, "Error in FixItTaskRepository.FindTasksByCreatorAsync(creater={0})", creator);
                throw;
            }
        }

        public async Task CreateAsync(FixItTask taskToAdd)
        {
            Stopwatch timespan = Stopwatch.StartNew();

            try {
                db.FixItTasks.Add(taskToAdd);
                await db.SaveChangesAsync();

                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.CreateAsync", timespan.Elapsed, "taskToAdd={0}", taskToAdd);
            }
            catch (Exception e)
            {
                log.Error(e, "Error in FixItTaskRepository.CreateAsync(taskToAdd={0})", taskToAdd);
                throw;
            }
        }

        public async Task UpdateAsync(FixItTask taskToSave)
        {
            Stopwatch timespan = Stopwatch.StartNew();

            try {
                db.Entry(taskToSave).State = EntityState.Modified;
                await db.SaveChangesAsync();

                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.UpdateAsync", timespan.Elapsed, "taskToSave={0}", taskToSave);
            }
            catch (Exception e)
            {
                log.Error(e, "Error in FixItTaskRepository.UpdateAsync(taskToSave={0})", taskToSave);
                throw;
            }
        }
        
        public async Task DeleteAsync(Int32 id)
        {
            Stopwatch timespan = Stopwatch.StartNew();

            try
            {
                FixItTask fixittask = await db.FixItTasks.FindAsync(id);
                db.FixItTasks.Remove(fixittask);
                await db.SaveChangesAsync();

                timespan.Stop();
                log.TraceApi("SQL Database", "FixItTaskRepository.DeleteAsync", timespan.Elapsed, "id={0}", id);

            }
            catch (Exception e)
            {
                log.Error(e, "Error in FixItTaskRepository.DeleteAsync(id={0})", id);
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free managed resources
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}